using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Nguoi
{
    internal class ThieuNhi:DocGia, InterfacePrices
    {
        string nguoiGiamho;

        public string NguoiGiamho { get => nguoiGiamho; set => nguoiGiamho = value; }

        public ThieuNhi(string gt, string name, int age, string madg, string diachi, DateTime ndk, string cmt,string ngh) : base(gt, name, age, madg, diachi, ndk, cmt)
        {
            this.nguoiGiamho = ngh;
        }

 
        public override void kiemTraThe()
        {
            DateTime ngayHienTai = DateTime.Now;

            TimeSpan thoiGianSuDung = ngayHienTai - base.NgayDangki;
            int soNgaySuDung = thoiGianSuDung.Days;
            int songaycothedung = 180 - soNgaySuDung;
            if (songaycothedung <= 0)
            {
                Console.WriteLine("The Het Han");
            }
            Console.WriteLine(" The con co the su dung {0} ngay", songaycothedung);
        }
        public double GiamGiaLamThe()
        {
            return 100 / 100 * tienThe;
        }
        public override double tienLamThe()
        {
            return tienThe - GiamGiaLamThe();
        }
        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine("Người giám hộ:{0} ", NguoiGiamho);
            kiemTraThe();

        }
    }
}
