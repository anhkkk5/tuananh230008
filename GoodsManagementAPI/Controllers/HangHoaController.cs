using GoodsManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GoodsAPI.Controllers
{
    [Route("api/hanghoa")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private static List<HangHoa> _dsHangHoa = new List<HangHoa>
        {
            new HangHoa { MaHangHoa = "H001", TenHangHoa = "Gạo", SoLuong = 100, GhiChu = "Hàng mới" },
            new HangHoa { MaHangHoa = "H002", TenHangHoa = "Đường", SoLuong = 50, GhiChu = "Hàng tồn" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<HangHoa>> GetAll()
        {
            return Ok(_dsHangHoa);
        }

        [HttpGet("{id}")]
        public ActionResult<HangHoa> GetById(string id)
        {
            var hangHoa = _dsHangHoa.Find(hh => hh.MaHangHoa == id);
            if (hangHoa == null) return NotFound();
            return Ok(hangHoa);
        }
    }
}
