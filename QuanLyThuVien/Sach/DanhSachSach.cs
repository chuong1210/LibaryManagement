using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace QuanLyThuVien
{
   public class DanhSachSach:OperateXML
    {
      
        List<Sach> danhsachSach = new List<Sach>();
        public void ReadTuFileXML(string tenfile)
        {
            XmlDocument file = new XmlDocument();
            file.Load(tenfile);
            XmlNodeList SachNode = file.SelectNodes("/DanhSachSach/Sach");
            foreach (XmlNode sachnode in SachNode)
            {

                string MaSach = sachnode["Ma"].InnerText;

                string TenSach = sachnode["TenSach"].InnerText;
                int  NamSanXuat = int.Parse(sachnode["NamSanXuat"].InnerText);
                string TacGia = sachnode["TacGia"].InnerText;

                string TheLoai = sachnode["TheLoai"].InnerText;

                int SoLuong = int.Parse(sachnode["SoLuong"].InnerText);

                double GiaBan = double.Parse(sachnode["GiaBan"].InnerText);


                Sach sach = new Sach(MaSach,TenSach,NamSanXuat,TacGia,TheLoai,SoLuong,GiaBan);

                danhsachSach.Add(sach);

            }

        }



        public List<Sach> AdjustmentSach( XmlNodeList sachNodes)
        {

            List<Sach> Books = new List<Sach>();



            foreach (XmlNode sachNode in sachNodes)
                {
                 string   ms = sachNode["MaSach"].InnerText;
                string     ts = sachNode["TenSach"].InnerText;
                 int   nss = int.Parse(sachNode["NamSanXuat"].InnerText);
                  string  tg = sachNode["TacGia"].InnerText;
                    string tl = sachNode["TheLoai"].InnerText;
                int   sl = int.Parse(sachNode["SoLuong"].InnerText);
                double gb = double.Parse(sachNode["GiaBan"].InnerText);

                Sach sach = new Sach(ms, ts, nss, tg, tl, sl,gb);
                    danhsachSach.Add(sach);
                    Books.Add(sach);


                }
            
            return Books;
        }


    public void xuatSach()
        {
            foreach(Sach s in danhsachSach)
            {
                s.XuatSach();
            }
        }
        //public void WriteVaoFileXML(string file)
        //{
        //    string filePath = Path.GetFullPath(file);
        //    foreach (var item in danhsachSach)
        //    {
        //        item.XuatSach();
        //    }

        //    XElement danhSachSachXml = new XElement("DanhSachSach",




        //        from sach in danhsachSach

        //        select new XElement("Sach",
        //            new XElement("MaSach", sach.MaSach),

        //    new XElement("TenSach", sach.TenSach),
        //            new XElement("NamSanXuat", sach.NamSanXuat),
        //            new XElement("TacGia", sach.TacGia),
        //            new XElement("TheLoai", sach.TheLoai),
        //            new XElement("SoLuong", sach.SoLuong),
        //             new XElement("GiaBan", sach.GiaBan)

        //        )
        //    ) ;
        //    Console.WriteLine("After creating XElement");

        //    danhSachSachXml.Save(filePath);
        //}


        public void LuuVaoFileXML()
        {
            string filePath = Path.GetFullPath("../../Sach/Sach2.xml");
            foreach (var item in danhsachSach)
            {
                item.XuatSach();
            }

            XElement danhSachSachXml = new XElement("DanhSachSach",




                from sach in danhsachSach

                select new XElement("Sach",
                    new XElement("MaSach", sach.MaSach),

            new XElement("TenSach", sach.TenSach),
                    new XElement("NamSanXuat", sach.NamSanXuat),
                    new XElement("TacGia", sach.TacGia),
                    new XElement("TheLoai", sach.TheLoai),
                    new XElement("SoLuong", sach.SoLuong),
                     new XElement("GiaBan", sach.GiaBan)

                )
            );

            danhSachSachXml.Save(filePath);
        }
        public void SuaThongTinSach(string maSach, string tenSach, int namSanXuat, string tacGia, string theLoai, int soLuong)
        {
            Sach sachCanSua = danhsachSach.FirstOrDefault(sach => sach.MaSach == maSach);

            if (sachCanSua != null)
            {
                sachCanSua.TenSach = tenSach;
                sachCanSua.NamSanXuat = namSanXuat;
                sachCanSua.TacGia = tacGia;
                sachCanSua.TheLoai = theLoai;
                sachCanSua.SoLuong = soLuong;

                LuuVaoFileXML();          }
            else
            {
                Console.WriteLine("Không tìm thấy sách có mã số {0} để sửa.", maSach);
            }
        }
        
        public void ThemThongTinSach(string ms,string tenSach, int namSanXuat, string tacGia, string theLoai, int soLuong,double giaban)
        {
            Sach sachMoi = new Sach
            (
                ms,
                tenSach,
               namSanXuat,
               tacGia,
               theLoai,
              soLuong,
              giaban
            );

            danhsachSach.Add(sachMoi);

            LuuVaoFileXML();
        }
        public void XoaThongTinSach(string maSach)
        {
            // Tìm sách cần xóa trong danh sách
            Sach sachCanXoa = danhsachSach.FirstOrDefault(sach => sach.MaSach == maSach);

            // Nếu sách tồn tại, thực hiện xóa và lưu danh sách vào file XML
            if (sachCanXoa != null)
            {
                danhsachSach.Remove(sachCanXoa);
                LuuVaoFileXML();        }
            else
            {
                Console.WriteLine("Không tìm thấy sách có mã số {0} để xóa.", maSach);
            }
        }
        public void XuatSachXML()
        {
            foreach (Sach sach in danhsachSach)
            {
                sach.XuatSach();
                Console.WriteLine();
            }
        }

        public void WriteVaoFileXML(string file)
        {

            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement danhSachDoiTuongElement = doc.CreateElement("DanhSachSach");
            doc.AppendChild(danhSachDoiTuongElement);




            int n;
            Console.WriteLine("Nhập phần tử sách cần thêm");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Sách thứ {0}:", i + 1);

                XmlElement doiTuongElement = doc.CreateElement("Sach");
                danhSachDoiTuongElement.AppendChild(doiTuongElement);
            
                XmlElement MaSachElement = doc.CreateElement("Ma");
                Console.WriteLine("Nhập Mã sách:");
                string mpm = Console.ReadLine();
                MaSachElement.InnerText = mpm;
                doiTuongElement.AppendChild(MaSachElement);

                XmlElement TenSachElement = doc.CreateElement("TenSach");
                Console.WriteLine("Nhập Tên sách:");
                string ms = Console.ReadLine();
                TenSachElement.InnerText = ms;
                doiTuongElement.AppendChild(TenSachElement);

                XmlElement NamssElement = doc.CreateElement("NamSanXuat");
                Console.WriteLine("Nhap Năm sản xuất:");
                int namss = int.Parse(Console.ReadLine());
                NamssElement.InnerText = namss.ToString();
                doiTuongElement.AppendChild(NamssElement);

              
                XmlElement GiabanElement = doc.CreateElement("GiaBan");
                Console.WriteLine("Nhập Giá sách: ");
                double gb = double.Parse(Console.ReadLine());
                GiabanElement.InnerText = gb.ToString();
                doiTuongElement.AppendChild(GiabanElement);

                XmlElement tacgiaElement = doc.CreateElement("TacGia");
                Console.WriteLine("Nhập Tên tác giả: ");
                string tg = Console.ReadLine();
                tacgiaElement.InnerText = tg;
                doiTuongElement.AppendChild(tacgiaElement);



                XmlElement theloaiElement = doc.CreateElement("TheLoai");
                Console.WriteLine("Nhập Tên thể loại: ");
                string tl = Console.ReadLine();
                theloaiElement.InnerText = tl;
                doiTuongElement.AppendChild(theloaiElement);

                XmlElement SoLuongElement = doc.CreateElement("SoLuong");
                Console.WriteLine("Nhap Số lượng sách: ");
                int sls = int.Parse(Console.ReadLine());
                SoLuongElement.InnerText = sls.ToString();
                doiTuongElement.AppendChild(SoLuongElement);

            }



            doc.Save(file);
            ReadTuFileXML(file);
        }




        //public Sach TimSachDuocMuonNhieuNhat(List<PhieuMuon> danhSachPhieuMuon)
        //{
        //    var sachDuocMuonNhieuNhat = danhSachPhieuMuon
        //        .GroupBy(p => p.MaSach1)
        //        .OrderByDescending(g => g.Count())
        //        .FirstOrDefault();

        //    if (sachDuocMuonNhieuNhat != null)
        //    {
        //        int maSach = sachDuocMuonNhieuNhat.Key;
        //        return danhsachSach.FirstOrDefault(sach => sach.MaSach == maSach);
        //    }

        //    return null;
        //}



    }
}
