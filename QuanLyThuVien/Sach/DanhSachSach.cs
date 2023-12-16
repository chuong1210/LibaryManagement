using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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
            if (danhsachSach.Count > 0)
            {
                foreach (Sach s in danhsachSach)
                {
                    s.XuatSach();
                    Console.WriteLine("------------------------------");

                }
            }
            else
            {
                Console.WriteLine("Danh sách sách trống");
            }
        }
       
        public int sumSach()
        {
            return danhsachSach.Sum(e => e.SoLuong);
        }

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

        public void CapNhatTenSach(string maSach, string tenMoi)
        {
            Sach sachCanCapNhat = danhsachSach.FirstOrDefault(s => s.MaSach.Trim().ToLowerInvariant() == maSach.Trim().ToLowerInvariant());

            if (sachCanCapNhat != null)
            {
                sachCanCapNhat.TenSach = tenMoi;

                Console.WriteLine("Cập nhật tên sách thành công!");
                Console.WriteLine( "Sách sau khi cập nhật");
                sachCanCapNhat.XuatSach();

            }
            else
            {
                Console.WriteLine($"Không tìm thấy sách có mã {maSach} để cập nhật.");
            }
        }
        public void ThemSach(int n)
        {


           
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhập mã sách: ");
                string maSach = Console.ReadLine();
                Console.WriteLine("Nhập tên sách: ");
                string tenSach = Console.ReadLine();
                Console.WriteLine("Nhập Năm sản xuất : ");
                int namSanXuat = int.Parse(Console.ReadLine());
                Console.WriteLine("Nhập tác giả : ");
                string tacGia = Console.ReadLine();
                Console.WriteLine("Nhập thể loại : ");
                string theLoai = Console.ReadLine();
                Console.WriteLine("Nhập giá bán : ");
                double giaBan = double.Parse(Console.ReadLine());
                Console.WriteLine("Nhập số lượng sách : ");
                int soLuong = int.Parse(Console.ReadLine());

                Sach sach = new Sach(maSach, tenSach, namSanXuat, tacGia, theLoai, soLuong, giaBan);
                danhsachSach.Add(sach);

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

        }
        public  void XoaThongTinSachDautien(string maSach)
        {
            string ms = maSach.Trim().ToLower();
            Sach sachCanXoa = danhsachSach.FirstOrDefault(sach => sach.MaSach.Trim().ToLower() == ms);

            if (sachCanXoa != null)
            {
                danhsachSach.Remove(sachCanXoa);
                Console.WriteLine("Xóa sách có mã {0} thành công.", maSach);

            }
            else
            {
                Console.WriteLine("Không tìm thấy sách có mã số {0} để xóa.", maSach);
            }
        }



        public void XoaAllThongTinSach(string maSach)
        {
            string ms = maSach.Trim().ToLower();
            List<Sach> removeBook = danhsachSach.FindAll(e => e.MaSach.Trim().ToLower() == ms);

            if (removeBook.Count > 0)
            {
                danhsachSach.RemoveAll(e => e.MaSach.Trim().ToLower() == ms);
                Console.WriteLine("Đã xóa sách có mã số {0}.", maSach);
            }
            else
            {
                Console.WriteLine("Không tìm thấy sách có mã số {0} để xóa.", maSach);
            }
        }
        public void TimSachTrinhThamChatLuongTot()
        {
            List<Sach> sachTrinhThamChatLuongTot = danhsachSach.ToList()
    .Where(sach =>
            (sach.TheLoai.ToLower().Trim() == "trinh thám" && sach.Chatluongsach.ToLower() == "tốt") ||
            (sach.TheLoai.ToLower().Trim() == "trinh tham" && sach.Chatluongsach.ToLower() == "tot"))
                        .ToList();

            if (sachTrinhThamChatLuongTot.Count > 0)
            {
                Console.WriteLine("Danh sách sách trinh thám có chất lượng tốt:");
                foreach (var sach in sachTrinhThamChatLuongTot)
                {
                    sach.XuatSach();
                    Console.WriteLine("--------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Không có sách trinh thám nào có chất lượng tốt.");
            }

        }

        public void XuatSachXML()
        {
            int i = 1;
            foreach (Sach sach in danhsachSach)
            {
                Console.WriteLine("*-------------------------------------------------------*");
                Console.WriteLine("Thông tin của cuốn Sách thứ {0}: ", i);
                sach.XuatSach();
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
                Console.WriteLine("Nhập Mã sách (Vui lòng nhập đủ 6 kí tự):");
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
                Console.WriteLine("Nhập Số lượng sách: ");
                int sls = int.Parse(Console.ReadLine());
                SoLuongElement.InnerText = sls.ToString();
                doiTuongElement.AppendChild(SoLuongElement);

            }



            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = Encoding.UTF8
            };

            using (XmlWriter writer = XmlWriter.Create(file, settings))
            {
                doc.Save(writer);
            }
            ReadTuFileXML(file);
        }




        public void WriteVaoFileXMLkoOverride(string file)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement danhSachDoiTuongElement;

            if (System.IO.File.Exists(file))
            {
                doc.Load(file);

                 danhSachDoiTuongElement = doc.DocumentElement;

            }
            else
            {

                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

                 danhSachDoiTuongElement = doc.CreateElement("DanhSachSach");
                doc.AppendChild(danhSachDoiTuongElement);
            }
            
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
                Console.WriteLine("Nhập Số lượng sách: ");
                int sls = int.Parse(Console.ReadLine());
                SoLuongElement.InnerText = sls.ToString();
                doiTuongElement.AppendChild(SoLuongElement);



            }

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = Encoding.UTF8 
            };

            using (XmlWriter writer = XmlWriter.Create(file, settings))
            {
                doc.Save(writer);
            }

            ReadTuFileXML(file);
        }




    }
}
