using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Nguoi
{
    internal class NguoiLon : DocGia, InterfacePrices
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
            Console.WriteLine("Tên công việc "+ Congviec);
        }
        public double GiamGiaLamThe()
        {
            throw new NotImplementedException();
        }

        public override void kiemTraThe()
        {
            throw new NotImplementedException();
        }

        public override double tienLamThe()
        {
            throw new NotImplementedException();
        }
    }
}
