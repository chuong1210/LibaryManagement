﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVien;
using QuanLyThuVien.Nguoi;

namespace QuanLyThuVien
{
    public abstract class DocGia 
    {
        protected string maDg;
        protected string diaChi;
        protected DateTime ngayDangki;
        protected string soCmt;
        private string gioitinh;
        private string hoten;
        private int tuoi;
        public static double tienThe = 100000;
        public static int thoigianmuon = 30;
        protected List<String> danhSachSachMuon;


        public static bool ContainsNumber(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        public DocGia()
        {
            
        }
        public DocGia(string gt, string name, int age, string madg, string diachi, DateTime ndk, string cmt) 
        {
            if (madg.Length == 6)
            {
                
                string DG = madg.Substring(0, 2);
                string so = madg.Substring(2, 4);

                if (DG.Equals("DG") && !ContainsNumber(so))
                {
                    this.maDg = madg;
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

            if (gt.ToLower() == "nam" || gt.ToLower() == "nữ")
               this.gioitinh = gt;
            else
               this.gioitinh = "Nam";


            this.tuoi = age;
            this.hoten = name;
            this.diaChi = diachi;
            this.NgayDangki = ndk;
            this.soCmt = cmt;
            DanhSachSachMuon = new List<string>();

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
                if (maDg.Length == 6)
                {
                    string DG = maDg.Substring(0, 2);
                    string so = maDg.Substring(2,4);

                    if (DG .Equals("DG") && !ContainsNumber(so))
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

        public string SoCmt { get => soCmt; set => soCmt = value; }
        public DateTime NgayDangki { get => ngayDangki; set => ngayDangki = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public List<string> DanhSachSachMuon { get => danhSachSachMuon; set => danhSachSachMuon = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }

        public void themsachMuon(string tensach)
        {
            danhSachSachMuon.Add(tensach);
        }
    
    
        public void HienThiDanhSachSachMuon()
        {
            Console.WriteLine("Dach sách sách đã mượn:");
            if (DanhSachSachMuon != null)
            {
                foreach (string sach in DanhSachSachMuon)
                {
                    Console.WriteLine("Tên Sách: {0}", sach);

                }
            }
            else
            {
                Console.WriteLine("Độc giả chưa từng mượn sách nào.");
            }
        }
        public abstract void kiemTraThe();
        public abstract double tienLamThe();

        public virtual void XuatThongTin()
        {

            Console.WriteLine("Họ tên: {0}", Hoten);
            Console.WriteLine("Tuổi: {0}", Tuoi);
            Console.WriteLine("Giới tính: {0}", Gioitinh);
            Console.WriteLine("Mã độc giả: {0}", MaDg1);
            Console.WriteLine("Địa chỉ: {0}", DiaChi);
            Console.WriteLine("Ngày làm thẻ: {0}", NgayDangki);
            Console.WriteLine("Số chứng minh thư: {0}", SoCmt);
            if (tienLamThe() == 0)
                Console.WriteLine("Tiền làm thẻ: Khách hàng được miễn phí tiền làm thẻ");
            else
                Console.WriteLine("Tiền làm thẻ: {0} Đ", tienLamThe());
            kiemTraThe();
            HienThiDanhSachSachMuon();
        }



    }
}
