using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
   public class Sach 
    {
         string maSach;
         string tenSach;
         int namSanXuat;
         string tacGia;
         string theLoai;
         int soLuong;
         double heSoSach;
        string chatluongsach;
        double giaBan;
        int i = 0;



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
                if (i == 0)
                {
                    if (NamSanXuat > 0 && NamSanXuat <= 2)
                    {
                        this.giaBan *= soLuong * 0.95;
                    }
                    else if (NamSanXuat > 2 && NamSanXuat <= 4)
                    {
                        this.giaBan *= soLuong * 0.785;
                    }
                    else
                    {
                        this.giaBan *= soLuong * 0.65;
                    }
                    i++;

                    return giaBan *= 1.1; //phi VAT
                }
                else
                {
                    return giaBan;
                }

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

        public string MaSach
        {
            get
            {


                if (maSach.Length == 6)
                {
                    string S = maSach.Substring(0,1);
                    string so = maSach.Substring(1,5);

                    if (S == "S" && !ContainsNumber(so))
                    {
                        return maSach;
                    }
                    else
                    {
                        maSach = "SI0001";
                    }
                }
                else
                {
                    maSach = "SI0001";
                }

                return maSach;

            }

        }

        public string Chatluongsach
        {
            get
            {
                if (DateTime.Now.Year- NamSanXuat > 0 && DateTime.Now.Year - NamSanXuat  <= 2)
                {
                    this.chatluongsach = "Tốt";
                    this.giaBan *= soLuong * 0.95;
                }
                else if (DateTime.Now.Year - NamSanXuat > 2 && DateTime.Now.Year - NamSanXuat <= 4)
                {
                    this.chatluongsach = "Khá";
                }
                else
                {
                    this.chatluongsach = "Trung bình";
                }

                return chatluongsach;
            }
        }



        public Sach()
        {
                
        }
        public Sach(string ms, string ts, int namss, string tg, string tl, int sl,double gb)
        {


            if ( ms.Length == 6)
            {
                string S = ms.Substring(0, 1);
                //char S = ms[0];
                string so = ms.Substring(1, 3);

                if (S.Equals("S") && !ContainsNumber(so))
                {
                   this.maSach = ms;
                }
                else
                {
                    this.maSach = "SI0001";
                }
            }
            else
            {
               this.maSach = "SI0001";
            }

            tenSach = ts;
            namSanXuat = namss;
            tacGia = tg;
            theLoai = tl;
            soLuong = sl;
            giaBan= gb; 

        }
      
        public void NhapSach()
        {
            Console.WriteLine("Nhap ma sach : ");
            maSach = Console.ReadLine();
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
        

        }
        public void XuatSach()
        {
            Console.WriteLine("Mã Sách :{0} ", MaSach);
            Console.WriteLine("Tên Sách :{0} ", TenSach);
            Console.WriteLine("Năm sản xuất Sách :{0} ", NamSanXuat);
            Console.WriteLine("Tác giả Sách :{0} ", TacGia);
            Console.WriteLine("Thể Loại Sách :{0} ", TheLoai);
            Console.WriteLine("Số lượng Sách :{0} ", SoLuong);
            Console.WriteLine("Chất lượng Sách :{0} ", Chatluongsach);

            Console.WriteLine("Giá bán cuối cùng của sách :{0} ", GiaBan);

        }
        
       
        
      
    }
}
