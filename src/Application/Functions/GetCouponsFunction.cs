using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using BetManager.Domain.Services;
using Microsoft.Azure.Functions.Worker;
using BetManager.Application.Models.Mappers;
using Microsoft.Azure.Functions.Worker.Http;

namespace BetManager.Application.Functions
{
    public class GetCouponsFunction
    {
        private readonly ICouponMapper _couponMapper;
        private readonly ICouponService _couponService;

        public GetCouponsFunction(
            ICouponMapper couponMapper, 
            ICouponService couponService
        )
        {
            _couponMapper = couponMapper;
            _couponService = couponService;
        }

        [Function("GetCoupons")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route="coupons")] HttpRequestData requestData,
            FunctionContext functionContext
        )
        {
            var query = System.Web.HttpUtility.ParseQueryString(requestData.Url.Query);
            string dateFrom = query["dateFrom"] ?? string.Empty;
            string dateTo = query["dateTo"] ?? string.Empty;

            if (string.IsNullOrEmpty(dateFrom) || string.IsNullOrEmpty(dateTo))
            {
                return new BadRequestObjectResult(new { message = "missing required query parameters" });
            }

            if (!DateTime.TryParse(dateFrom, out DateTime timeFrom) || !(DateTime.TryParse(dateTo, out DateTime timeTo)))
            {
                return new BadRequestObjectResult(new { message = "invalid date format" });
            }

            var coupons = await _couponService.GetCouponsInConclusionTimeRangeAsync(timeFrom, timeTo);
            
            var results = coupons.Select(_couponMapper.MapFromCoupon).ToList();

            var responseData = JsonSerializer.Serialize(results, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return new OkObjectResult(responseData);;
        }
    }
}