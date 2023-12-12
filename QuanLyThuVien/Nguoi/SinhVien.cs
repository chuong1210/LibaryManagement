using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Nguoi
{
    internal class SinhVien:DocGia,PhiMuonSach
    {
        string tentruong;
        string tenlop;

        public SinhVien(string gt, string name, int age, string madg, string diachi, DateTime ndk, string cmt,string tentruong,string tenlop) : base(gt, name, age, madg, diachi, ndk, cmt)
        {
        }

        public double PhiMuonSach()
        {
            return 0;
        }
    }
}
