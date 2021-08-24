using Microsoft.AspNetCore.Mvc;
using CayXanhAPI.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CayXanhAPI.Domain;
using CayXanhAPI.RequestEntities;

namespace CayXanhAPI.Controllers
{
    public class VanBanController : BaseApiController
    {
        private readonly IVanBanRepository _repository;

        public VanBanController(IVanBanRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> DanhSachVanBan()
        {
            return HandleResult(await _repository.TruyVanVanBan());
        }

        [HttpGet("{ID}")]
        public async Task<IActionResult> ThongTinChiTietVanBan(string ID)
        {
            Guid id = Guid.Parse(ID);
            return HandleResult(await _repository.ThongTinLoaiVanBan(id));
        }

        [HttpPost]
        public async Task<IActionResult> ThemMoiVanBan([FromBody] QLCX_VanBan _vanban)
        {
            return HandleResult(await _repository.ThemMoiLoaiVanBan(_vanban));
        }

        [HttpPut]
        public async Task<IActionResult> CapNhat([FromBody] QLCX_VanBan _vanBan)
        {
            return HandleResult(await _repository.CapNhatLoaiVanBan(_vanBan));
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> Xoa(string ID)
        {
            Guid id = Guid.Parse(ID);
            return HandleResult(await _repository.XoaVanBan(id));
        }
    }
}
