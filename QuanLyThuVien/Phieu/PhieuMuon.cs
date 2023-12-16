using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
    public class PhieuMuon: IPhieu
    {
        string  maPhieuMuon;
         DateTime NgayMuon;

        public PhieuMuon(string ms, string mdg, int sls,string mPm,DateTime nm) : base(ms, mdg, sls)
        {
            this.maPhieuMuon = mPm;
            this.NgayMuon= nm;  
        }
        public PhieuMuon()
        {
            
        }
        public string MaPhieuMuon1 { get => maPhieuMuon; set => maPhieuMuon = value; }
        public DateTime NgayMuon1 { get => NgayMuon; set => NgayMuon = value; }

        public override void NhapPhieu()
        {
            Console.WriteLine("Nhập mã phiếu mượn");
            maPhieuMuon = Console.ReadLine();
            Console.Write("Nhập ngày mượn sách theo định dạng (yyyy/MM/dd): ");
            NgayMuon = DateTime.ParseExact(Console.ReadLine(), "yyyy/MM/dd", CultureInfo.InvariantCulture);
       
            base.NhapPhieu();
            




        }



        public override void XuatPhieu()
        {
            Console.WriteLine("Mã phiếu mượn: {0}", MaPhieuMuon1);

            base.XuatPhieu();
            Console.WriteLine("Ngày mượn: {0}", NgayMuon1);


        }
    }
}
