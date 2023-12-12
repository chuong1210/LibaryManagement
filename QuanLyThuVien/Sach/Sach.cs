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
         double giaBan;
         int soLuong;
         double heSoSach;
        string chatluongsach;

      
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
                if (NamSanXuat > 0 &&NamSanXuat<=2 )
                {
                    this.chatluongsach = "Tốt";
                    this.giaBan = soLuong * 0.95;
                }
                else if (NamSanXuat > 2 && NamSanXuat  <=4)
                {
                    this.chatluongsach = "Khá";
                    this.giaBan = soLuong * 0.785;
                }
                else
                {
                    this.chatluongsach = "Trung bình";
                    this.giaBan = soLuong * 0.65;
                }

                return giaBan*=1.1; //phi VAT
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

    



        public string MaSach
        {
            get
            {


                if (maSach.Length>0&&maSach.Length == 6)
                {
                    char S = maSach[0];
                    string so = maSach.Substring(1,6);

                    if (S == 'S' && DoiTuong.ContainsNumber(so))
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

        public string Chatluongsach { get => chatluongsach; set => chatluongsach = value; }


        public Sach(string ms, string ts, int namss, string tg, string tl, int sl)
        {


            if (ms.Length > 0 && ms.Length <= 6)
            {
                char S = ms[0];
                string so = ms.Substring(1, 5);

                if (S == 'S' && DoiTuong.ContainsNumber(so))
                {
                    maSach = ms;
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

            tenSach = ts;
            namSanXuat = namss;
            tacGia = tg;
            theLoai = tl;
            soLuong = sl;

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
            Console.WriteLine("Nhap he so sach : ");
            heSoSach = double.Parse(Console.ReadLine());

        }
        public void XuatSach()
        {
            Console.WriteLine("Mã Sách :{0} ", MaSach);
            Console.WriteLine("Tên sach :{0} ", TenSach);
            Console.WriteLine("Nam san xuat sach :{0} ", NamSanXuat);
            Console.WriteLine("Tac gia sach :{0} ", TacGia);
            Console.WriteLine("The Loai sach :{0} ", TheLoai);
            Console.WriteLine("So luong sach :{0} ", SoLuong);
            //Console.WriteLine("He so sach :{0} ", HeSoSach);
        }
        
       
        
      
    }
}
