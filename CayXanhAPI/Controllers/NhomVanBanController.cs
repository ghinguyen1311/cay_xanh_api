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
    public class NhomVanBanController : BaseApiController
    {
        private readonly INhomVanBanRepository _repository;

        public NhomVanBanController(INhomVanBanRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> DanhSachNhomVanBan()
        {
            return HandleResult(await _repository.TruyVanLoaiVanBan());
        }

        [HttpGet("{ID}")]
        public async Task<IActionResult> ThongTinChiTietNhomVanBan(int ID)
        {
            return HandleResult(await _repository.ThongTinLoaiVanBan(ID));
        }

        [HttpPost]
        public async Task<IActionResult> ThemMoi([FromBody] QLCX_LoaiVanBan _loaiVanBan)
        {
            return HandleResult(await _repository.ThemMoiLoaiVanBan(_loaiVanBan));
        }

        [HttpPut]
        public async Task<IActionResult> CapNhat([FromBody] QLCX_LoaiVanBan _loaiVanBan)
        {
            return HandleResult(await _repository.CapNhatLoaiVanBan(_loaiVanBan));
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> Xoa(int ID)
        {
            return HandleResult(await _repository.XoaLoaiVanBan(ID));
        }
    }
}
