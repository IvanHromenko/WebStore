﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store.Web.Models;
using Store.Web.Service.IService;

namespace Store.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();

            ResponseDto? response = await _couponService.GetAllCouponsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto couponDto)
        {
            if (ModelState.IsValid) 
            {
                ResponseDto? response = await _couponService.CreateCouponAsync(couponDto);

                if(response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(CouponIndex));
                }
            }
            return View(couponDto);
        }

        public async Task<IActionResult> CouponDelete(int couponId)
        {
            return View();
        }
    }
}