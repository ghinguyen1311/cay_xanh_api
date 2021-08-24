using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CayXanhAPI.Domain;

namespace CayXanhAPI.BAL.Interfaces
{
    public interface INhomVanBanRepository
    {
        Task<Result<IEnumerable<QLCX_LoaiVanBan>>> TruyVanLoaiVanBan();
        Task<Result<QLCX_LoaiVanBan>> ThongTinLoaiVanBan(int ID);

        Task<Result<QLCX_LoaiVanBan>> ThemMoiLoaiVanBan(QLCX_LoaiVanBan _danhMucVanBan);
        Task<Result<QLCX_LoaiVanBan>> CapNhatLoaiVanBan(QLCX_LoaiVanBan _danhMucVanBan);
        Task<Result<int>> XoaLoaiVanBan(int ID);
    }
}
