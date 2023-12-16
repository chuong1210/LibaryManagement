using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

        public PhieuTra()
        {
            
        }
        public string MaPhieutra1 { get => maPhieutra; set => maPhieutra = value; }
        public DateTime NgayTra1 { get => NgayTra; set => NgayTra = value; }

        public override void NhapPhieu()
        {
            base.NhapPhieu();
            Console.WriteLine("Nhập mã phiếu trả");
            maPhieutra = Console.ReadLine();
            Console.Write("Nhập ngày trả sách theo định dạng (yyyy/MM/dd): ");
            DateTime nt = new DateTime();
            string ngayMuonStr = Console.ReadLine();

            nt = DateTime.ParseExact(ngayMuonStr, "yyyy/MM/dd", CultureInfo.InvariantCulture);

            this.NgayTra = nt;


        }



        public override void XuatPhieu()
        {
            Console.WriteLine("Mã phiếu trả: {0}", MaPhieutra1);

            base.XuatPhieu();
            Console.WriteLine("Ngày mượn: {0}", NgayTra.ToString("yyyy/MM/dd"));


        }
    }
}
