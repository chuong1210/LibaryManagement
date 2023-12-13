using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
   public class IPhieu:OperateXML
    {
        string MaSach;
        string MaDocGia;
        int SoLuongSach;

        public IPhieu(string ms,string mdg,int sls)
        {
            this.MaSach = ms;
            this.MaDocGia = mdg;
            this.SoLuongSach = sls;
        }

        public string MaSach1 { get => MaSach; set => MaSach = value; }
        public string MaDocGia1 { get => MaDocGia; set => MaDocGia = value; }
       
        public int SoLuongSach1 { get => SoLuongSach; set => SoLuongSach = value; }

        public void nhapDate(DateTime dt)
        {
            string inputDate = Console.ReadLine();
            DateTime date;

            while (DateTime.TryParseExact(inputDate, "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out date))
            {
                // In ngày mượn đã nhập
                Console.WriteLine("Ngày đã không hợp lệ. Hãy nhập theo định dạng dd/MM/yyyy HH:mm:ss: ");

                 inputDate = Console.ReadLine();


            }
               dt = date;


        }

        public virtual void NhapPhieu()
        {
            Console.WriteLine("Nhap ma sach :");
            MaSach = Console.ReadLine();
            Console.WriteLine("Nhap ma doc gia :");
            MaDocGia = Console.ReadLine();
      
            Console.WriteLine("Nhap so luong sach :");
            SoLuongSach = int.Parse(Console.ReadLine());

        }

        public void ReadTuFileXML(string tenfile)
        {
            throw new NotImplementedException();
        }

        public void WriteVaoFileXML(string file)
        {
            throw new NotImplementedException();
        }

        public virtual void XuatPhieu()
        {
            Console.WriteLine("Ma sach :{0}", MaSach1);
            Console.WriteLine("Ma doc gia :{0}", MaDocGia1);
            Console.WriteLine("So luong sach :{0}", SoLuongSach1);

        }

    }
}

//Console.Write("Nhập ngày sinh (yyyy-MM-dd): ");
//string ngaySinhInput = Console.ReadLine();
//DateTime ns;

//while (!DateTime.TryParseExact(ngaySinhInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out ns))
//{
//    Console.WriteLine("Định dạng ngày không đúng. Vui lòng nhập lại.");
//    Console.Write("Nhập ngày sinh (yyyy-MM-dd): ");
//    ngaySinhInput = Console.ReadLine();
//}

//ngaySinh = ns;