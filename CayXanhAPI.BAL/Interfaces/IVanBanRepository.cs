using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CayXanhAPI.Domain;

namespace CayXanhAPI.BAL.Interfaces
{
    public interface IVanBanRepository
    {
        Task<Result<IEnumerable<QLCX_VanBan>>> TruyVanVanBan();
        Task<Result<QLCX_VanBan>> ThongTinLoaiVanBan(Guid ID);

        Task<Result<QLCX_VanBan>> ThemMoiLoaiVanBan(QLCX_VanBan _danhMucVanBan);
        Task<Result<QLCX_VanBan>> CapNhatLoaiVanBan(QLCX_VanBan _danhMucVanBan);
        Task<Result<int>> XoaVanBan(Guid ID);
    }
}
