using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
   public interface IPhieu
    {
        int MaSach { get; set; }
        int MaDocGia { get; set; }
        DateTime NgayMuon { get; set; }
        DateTime NgayTra { get; set; }
        int SoLuongSach { get; set; }
    }
}
