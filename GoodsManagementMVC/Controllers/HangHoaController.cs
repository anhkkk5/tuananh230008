using GoodsManagementMVC.Models;
using GoodsManagementMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodsMVC.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly HangHoaService _hangHoaService;

        public HangHoaController(HangHoaService hangHoaService)
        {
            _hangHoaService = hangHoaService;
        }

        public async Task<IActionResult> Index()
        {
            var goods = await _hangHoaService.GetHangHoaAsync();
            return View(goods);
        }
    }
}
