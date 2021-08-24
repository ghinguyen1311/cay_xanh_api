using System;
using System.Collections.Generic;
using System.Text;

namespace CayXanhAPI.Domain
{
    public class QLCX_VanBan
    {
        public Guid ID { get; set; }
        public int MaLoaiVanBan { get; set; }
        public string CoQuanBanHanh { get; set; }
        public DateTime NgayBanHanh { get; set; }
        public string TrichYeu { get; set; }
        public string NguoiKy { get; set; }
        public string ChucVu { get; set; }
        public string NoiDung { get; set; }
    }
}
