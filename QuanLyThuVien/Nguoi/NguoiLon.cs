using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Nguoi
{
    internal class NguoiLon : DocGia
    {
        string congviec;

        public string Congviec { get => congviec; set => congviec = value; }

        public NguoiLon(string gt, string name, int age, string madg, string diachi, DateTime ndk, string cmt,string cv) : base(gt, name, age, madg, diachi, ndk, cmt)
        {
            this.Congviec = cv;
        }

        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine("Tên công việc: "+ Congviec);

        }


        public override void kiemTraThe()
        {
            DateTime ngayHienTai = DateTime.Now;

            TimeSpan thoiGianSuDung = ngayHienTai - base.NgayDangki;
            int soNgaySuDung = thoiGianSuDung.Days;
            int songaycothedung = 720 - soNgaySuDung;
            if (songaycothedung <= 0)
            {
                Console.WriteLine("Thẻ đã hết hạn");
            }
            else
            Console.WriteLine("Hạn sử dụng của thẻ còn {0} ngày", songaycothedung);
        }

        public override double tienLamThe()
        {
            if (Congviec.Trim().ToLower() == "giao vien" || Congviec.Trim().ToLower() == "giang vien" || Congviec.Trim().ToLower() == "giáo viên" || Congviec.Trim().ToLower() == "giảng viên")
            {
                return 0;
            }
            return DocGia.tienThe;
        }
    }
}
