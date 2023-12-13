using System;
using System.Collections.Generic;
using System.Globalization;
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
            if (madg.Length <= 6)
            {
                string DG = madg.Substring(0, 2);
                string so = madg.Substring(2, 4);

                if (DG.Equals("DG") && !DoiTuong.ContainsNumber(so))
                {
                     this.maDg= madg;
                }
                else
                {
                    this.maDg = "DGI001";
                }
            }
            else
            {
                this.maDg = "DGI001";
            }
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
        public void NhapDocGiareadInXml()
        {
            Console.WriteLine("Nhập thông tin độc giả:");

            Console.Write("Nhập Giới tính: ");
            string gioiTinh = Console.ReadLine();

            Console.Write("Nhập họ tên: ");
            string ten = Console.ReadLine();

            Console.Write("Nhập tuổi: ");
            int tuoi = int.Parse(Console.ReadLine());

            Console.Write("Nhap mã độc giả: ");
            string maDocGia = Console.ReadLine();

            Console.Write("Nhập địa chỉ: ");
            string diaChi = Console.ReadLine();

            Console.Write("Nhập ngày đăng kí theo định dạng (yyyy/MM/dd): ");
            DateTime ngayDangKi = DateTime.ParseExact(Console.ReadLine(), "yyyy/MM/dd", CultureInfo.InvariantCulture);

            Console.Write("Nhập số CMT: ");
            string soCMT = Console.ReadLine();

            DocGia docGia = new DocGia(gioiTinh, ten, tuoi, maDocGia, diaChi, ngayDangKi, soCMT);

            Console.WriteLine("Nhập thông tin sách mượn (nhap 'q' de ket thuc):");

            while (true)
            {
                Console.Write("Nhap Ma Sach: ");
                string maSach = Console.ReadLine();

                if (maSach.ToLower() == "q")
                    break;

                Console.Write("Nhap Ten Sach: ");
                string tenSach = Console.ReadLine();

                Console.Write("Nhap Nam San Xuat: ");
                int namSanXuat = int.Parse(Console.ReadLine());

                Console.Write("Nhap Tac Gia: ");
                string tacGia = Console.ReadLine();

                Console.Write("Nhập thể loại : ");
                string theLoai = Console.ReadLine();

                Console.Write("Nhap Số lượng: ");
                int soLuong = int.Parse(Console.ReadLine());

                Console.Write("Nhap Giá bán: ");
                double giaban = double.Parse(Console.ReadLine());



                Sach sach = new Sach(maSach, tenSach, namSanXuat, tacGia, theLoai, soLuong,giaban);
                this.ThemSachMuon(sach);
            }

        }
        public void HienThiDanhSachSachMuon()
        {
            Console.WriteLine("Dach sách sách đã mượn:");
            if (danhSachSachMuon != null)
            {
                foreach (Sach sach in danhSachSachMuon)
                {
                    Console.WriteLine("Tên Sách: {0}", sach.TenSach);
                    Console.WriteLine("Giá Sách: {0} USD", ((decimal)sach.GiaBan));

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
