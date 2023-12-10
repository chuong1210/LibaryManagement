using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
   public class Sach:DoiTuong 
    {
         string ma;
         string tenSach;
         int namSanXuat;
         string tacGia;
         string theLoai;
         double giaBan;
         int soLuong;
         double heSoSach;

        public string TenSach
        {
            get
            {
                return tenSach;
            }

            set
            {
                tenSach = value;
            }
        }

        public int NamSanXuat
        {
            get
            {
                return namSanXuat;
            }

            set
            {
                namSanXuat = value;
            }
        }

        public string TacGia
        {
            get
            {
                return tacGia;
            }

            set
            {
                tacGia = value;
            }
        }

        public string TheLoai
        {
            get
            {
                return theLoai;
            }

            set
            {
                theLoai = value;
            }
        }

        public double GiaBan
        {
            get
            {
                return giaBan;
            }

            set
            {
                giaBan = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }

        public double HeSoSach
        {
            get
            {
                return heSoSach;
            }

            set
            {
                heSoSach = value;
            }
        }
        public void TinhGiaBan()
        {
            GiaBan = soLuong * heSoSach + 0.1 * soLuong * heSoSach; // 10% VAT
        }
        public void NhapSach()
        {
            Console.WriteLine("Nhap ma sach : ");
            ma = Console.ReadLine();
            Console.WriteLine("Nhap ten sach : ");
            tenSach = Console.ReadLine();
            Console.WriteLine("Nhap nam san xuat : ");
            namSanXuat = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap tac gia : ");
            tacGia = Console.ReadLine();
            Console.WriteLine("Nhap the loai : ");
            theLoai = Console.ReadLine();
            Console.WriteLine("Nhap gia ban : ");
            giaBan = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap so luong sach : ");
            soLuong = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap he so sach : ");
            heSoSach = double.Parse(Console.ReadLine());

        }
        public void XuatSach()
        {
            Console.WriteLine("Ma sach :{0} ", ma);
            Console.WriteLine("Ten sach :{0} ", tenSach);
            Console.WriteLine("Nam san xuat sach :{0} ", namSanXuat);
            Console.WriteLine("Tac gia sach :{0} ", tacGia);
            Console.WriteLine("The Loai sach :{0} ", theLoai);
            Console.WriteLine("So luong sach :{0} ", soLuong);
            Console.WriteLine("He so sach :{0} ", heSoSach);
        }
        
       
        
      
    }
}
