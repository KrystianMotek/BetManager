using System.Text.Json;
using FluentValidation;
using BetManager.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using BetManager.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.Functions.Worker;
using BetManager.Application.Models.DTO;
using BetManager.Application.Models.Mappers;
using Microsoft.Azure.Functions.Worker.Http;

namespace BetManager.Application.Functions
{
    public class CreateCouponFunction
    {
        private readonly ICouponMapper _couponMapper;
        private readonly ICouponService _couponService;
        private readonly IValidator<CreateCouponDTO> _validator;

        public CreateCouponFunction(
            ICouponMapper couponMapper, 
            ICouponService couponService,
            IValidator<CreateCouponDTO> validator
        )
        {
            _couponMapper = couponMapper;
            _couponService = couponService;
            _validator = validator;
        }

        [Function("CreateCoupon")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route="coupons")] HttpRequestData requestData,
            FunctionContext functionContext
        )
        {            
            CreateCouponDTO? dto;
            try
            {
                dto = await JsonSerializer.DeserializeAsync<CreateCouponDTO>(requestData.Body)
                    ?? throw new JsonException("deserialization returned null");
            }
            catch (JsonException)
            {
                return new BadRequestObjectResult(new { message = "invalid JSON format" });
            }

            var validationResult = await _validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult.ToDictionary());
            }

            Coupon coupon; 
            try 
            {
                coupon = await _couponMapper.MapToCouponAsync<CreateCouponDTO, CreateCouponPositionDTO>(dto);
            }
            catch (InvalidOperationException)
            {
                return new BadRequestObjectResult(new { message = "failure when trying to create object" });
            }

            try
            {
                await _couponService.CreateCouponAsync(coupon);
            }
            catch (DbUpdateException)
            {
                return new BadRequestObjectResult(new { message = "failure when trying to create object" });
            }

            return new OkObjectResult(new { message = "coupon created successfully" });
        }
    }
}