using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVien;

namespace QuanLyThuVien
{
     public  class DocGia:DoiTuong
    {
        string maDg;
        string diaChi;
        DateTime ngayDangki;
        string soCmt;
        private List<Sach> danhSachSachMuon;

        public DocGia(string gt, string name, int age,string madg,string diachi,DateTime ndk,string cmt) : base(gt, name, age)
        {
            this.maDg = madg;
            this.diaChi= diachi;
            this.NgayDangki= ndk;
            this.soCmt= cmt;
            danhSachSachMuon = new List<Sach>();

        }

       


        public string DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }



        public string MaDg1
        {
            get
            {
                if (maDg.Length <= 6)
                {
                    string DG = maDg.Substring(0, 2);
                    string so = maDg.Substring(2,4);
                    Console.WriteLine(DG);

                    if (DG .Equals("DG") && !DoiTuong.ContainsNumber(so))
                    {
                        return maDg;
                    }
                    else
                    {
                        maDg = "DGI001";
                    }
                }
                else
                {
                    maDg = "DGI001";
                }

                return maDg;
            }
        }

        public List<Sach> DanhSachSachMuon { get => danhSachSachMuon; set => danhSachSachMuon = value; }
        public string SoCmt { get => soCmt; set => soCmt = value; }
        public DateTime NgayDangki { get => ngayDangki; set => ngayDangki = value; }

        public void ThemSachMuon(Sach sach)
        {
            if (danhSachSachMuon == null)
            {
                danhSachSachMuon = new List<Sach>();
            }

            danhSachSachMuon.Add(sach);
        }

        public void HienThiDanhSachSachMuon()
        {
            Console.WriteLine("Dach sách sách đã mượn:");
            if (danhSachSachMuon != null)
            {
                foreach (Sach sach in danhSachSachMuon)
                {
                    Console.WriteLine("Tên Sách: {0}", sach.TenSach);
                }
            }
            else
            {
                Console.WriteLine("Độc giả chưa từn mượn sách nào.");
            }
        }

        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine("Mã độc giả: {0}", MaDg1);
            Console.WriteLine("Địa chỉ: {0}", DiaChi);
            Console.WriteLine("Ngày: {0}", NgayDangki);
            Console.WriteLine("Số chứng minh thư: {0}", SoCmt);
            HienThiDanhSachSachMuon();
        }



    }
}
