using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
    public class PhieuTra: IPhieu
    {
        string maPhieutra;
        DateTime NgayTra;

        public PhieuTra(string ms, string mdg, int sls,string mPt,DateTime nt) : base(ms, mdg, sls)
        {
            this.maPhieutra = mPt;
            this.NgayTra=nt;
        }

        public string MaPhieutra1 { get => maPhieutra; set => maPhieutra = value; }
        public DateTime NgayTra1 { get => NgayTra; set => NgayTra = value; }

        public override void NhapPhieu()
        {
            base.NhapPhieu();
            Console.Write("Nhập ngày mượn sách theo định dạng (yyyy/MM/dd): ");
            NgayTra = DateTime.ParseExact(Console.ReadLine(), "yyyy/MM/dd", CultureInfo.InvariantCulture);
            Console.WriteLine("Nhập mã phiếu mượn");
            maPhieutra = Console.ReadLine();


        }



        public override void XuatPhieu()
        {
            Console.WriteLine("Mã phiếu trả: {0}", MaPhieutra1);

            base.XuatPhieu();
            Console.WriteLine("Ngày mượn: {0}", NgayTra1);


        }
    }
}
