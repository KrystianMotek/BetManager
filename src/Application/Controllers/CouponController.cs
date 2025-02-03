using Microsoft.AspNetCore.Mvc;
using BetManager.Domain.Models;
using BetManager.Domain.Services;
using Microsoft.Azure.Functions.Worker;
using BetManager.Application.Models.DTO;
using Microsoft.Azure.Functions.Worker.Http;

namespace BetManager.Application.Controllers
{
    public class CouponController
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
    }
}