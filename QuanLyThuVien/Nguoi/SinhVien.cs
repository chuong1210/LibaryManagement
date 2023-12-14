using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Nguoi
{
    internal class SinhVien:DocGia, InterfacePrices
    {
        string tentruong;
        string tenlop;

        public SinhVien(string gt, string name, int age, string madg, string diachi, DateTime ndk, string cmt,string tt,string tl) : base(gt, name, age, madg, diachi, ndk, cmt)
        {
            this.tentruong = tt;
            this.tenlop = tl;
        }

        public string Tentruong { get => tentruong; set => tentruong = value; }
        public string Tenlop { get => tenlop; set => tenlop = value; }

        public double GiamGiaLamThe()
        {
            throw new NotImplementedException();
        }

        public override void kiemTraThe()
        {
            DateTime ngayHienTai = DateTime.Now;

            TimeSpan thoiGianSuDung = ngayHienTai - base.ngayDangki;
            int soNgaySuDung = thoiGianSuDung.Days;
            int songaycothedung = 360 - soNgaySuDung;
            if (songaycothedung <= 0)
            {
                Console.WriteLine("The Het Han");
            }
            Console.WriteLine(" The con co the su dung {0} ngay", songaycothedung);
        }

        public double PhiMuonSach()
        {
            return 0;
        }

        public override double tienLamThe()
        {
            throw new NotImplementedException();
        }

        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine("Tên trường: {0}",this.Tentruong);
            Console.WriteLine("Tên Lớp:{0}", this.Tenlop);

        }
    }
}
