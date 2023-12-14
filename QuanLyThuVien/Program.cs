using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVien.Nguoi;
using QuanLyThuVien.Phieu;

namespace QuanLyThuVien
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Chào bạn");
            // string file = "../../Nguoi/DanhSachDoiTuong.xml";
            // DanhSachDocGia danhSach = new DanhSachDocGia();
            //danhSach.ReadTuFileXML("../../Nguoi/DSDT2.xml");
            //danhSach.WriteVaoFileXML("../../Nguoi/DSDT2.xml");
            // danhSach.XuatList();





            //DanhSachSach ds = new DanhSachSach();
            //ds.ReadTuFileXML("../../Sach/sachxml2.xml");
            //ds.WriteVaoFileXML("../../Sach/sachxml2.xml");
            //ds.xuatSach();

            DanhSachPhieu dsp = new DanhSachPhieu();
            //dsp.ReadTuFileXML("../../Phieu/DanhSachPhieu.xml");
            dsp.WriteVaoFileXML("../../Phieu/DSP2.xml");
            dsp.XuatDanhSachPhieu();

        }
    }
}
