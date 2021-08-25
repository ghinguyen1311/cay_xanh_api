using System;
using System.Collections.Generic;
using System.Text;

namespace CayXanhAPI.Domain
{
    public class QLCX_BaiViet
    {
        public Guid ID { get; set; }
        public int MaChuyenMuc { get; set; }
        public string TieuDe { get; set; }
        public string TomTat { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayDang { get; set; }
        public string NguonTin { get; set; }
        public string TuKhoa { get; set; }
    }
}
