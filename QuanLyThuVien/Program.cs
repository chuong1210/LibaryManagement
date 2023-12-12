using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVien.Nguoi;

namespace QuanLyThuVien
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Chào bạn"   );
            string file = "../../Nguoi/DanhSachDoiTuong.xml";
            DanhSachDocGia danhSach = new DanhSachDocGia();
            danhSach.DocGiaTuXML(file);
            danhSach.XuatList();


        }
    }
}
