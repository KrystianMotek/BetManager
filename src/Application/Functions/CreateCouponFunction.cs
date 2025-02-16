using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BetManager.Domain.Services;
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

        public CreateCouponFunction(
            ICouponMapper couponMapper, 
            ICouponService couponService
        )
        {
            _couponMapper = couponMapper;
            _couponService = couponService;
        }

        [Function("CreateCoupon")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route="coupons")] HttpRequestData requestData,
            FunctionContext functionContext
        )
        {
            var requestBody = await new StreamReader(requestData.Body).ReadToEndAsync(); 

            CreateCouponDTO dto = JsonSerializer.Deserialize<CreateCouponDTO>(requestBody);

            var coupon = await _couponMapper.MapToCouponAsync<CreateCouponDTO, CreateCouponPositionDTO>(dto);

            await _couponService.CreateCouponAsync(coupon);

            return new OkResult();
        }
    }
}