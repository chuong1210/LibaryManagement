using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace QuanLyThuVien
{
   public class DanhSachSach:OperateXML
    {
        PhuongThucDungChung ptdc = new PhuongThucDungChung();
        List<Sach> danhsachSach = new List<Sach>();
        public static string stringfile="../../Sach/DanhSachSach.xml";
        public void ReadTuFileXML(string tenfile)
        {
            danhsachSach.Clear();
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

        public void updateSL(int sl1,string ma)
        {
        //   ReadTuFileXML("../../Sach/DanhSachSach.xml");
            Console.WriteLine("SO luong" + danhsachSach.Count);

            foreach (var item in danhsachSach)
            {
                if(item.MaSach==ma)
                {
                item.SoLuong+=     sl1;
                }

                
            }
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
            (sach.TheLoai.ToLowerInvariant().Trim() == "trinh thám" && sach.Chatluongsach.ToLowerInvariant().Trim() == "tốt") ||
            (sach.TheLoai.ToLowerInvariant().Trim() == "trinh tham" && sach.Chatluongsach.ToLowerInvariant().Trim() == "tốt"))
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

                string ms;

                do
                {
                    ms = Console.ReadLine();
                    Console.WriteLine("Mã nhập đã tồn tại vui lòng nhập mã khác:");

                }
                while (checkMa(ms) == false||ptdc.checkmaS(ms)==false);
                MaSachElement.InnerText = ms;
                doiTuongElement.AppendChild(MaSachElement);

                XmlElement TenSachElement = doc.CreateElement("TenSach");
                Console.WriteLine("Nhập Tên sách:");
                string ts = Console.ReadLine();
                TenSachElement.InnerText = ts;
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



                string ms;

                Console.WriteLine("Nhập mã sách (Vui lòng nhập đủ 6 kí tự):");

                do
                {
                    ms = Console.ReadLine();
                    Console.WriteLine("Mã nhập đã tồn tại vui lòng nhập mã khác:");


                } while (checkMa(ms) == false || ptdc.checkmaS(ms) == false);

                MaSachElement.InnerText = ms;
                doiTuongElement.AppendChild(MaSachElement);


                XmlElement TenSachElement = doc.CreateElement("TenSach");
                Console.WriteLine("Nhập Tên sách:");
                string ts = Console.ReadLine();
                TenSachElement.InnerText = ts;
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


      public void foundNode(string bookId)
        {
            XmlDocument document = new XmlDocument();
            document.Load(stringfile);

            XmlNodeList bookNodes = document.SelectNodes("/DanhSachSach/Sach[Ma='" + bookId + "']");



            foreach (XmlNode bookNode in bookNodes)
            {
                XmlNode quantityNode = bookNode.SelectSingleNode("SoLuong");
                if (quantityNode != null)
                {
                    Console.WriteLine("Số lượng: {0}", quantityNode.InnerText);
                }
                else
                {
                    Console.WriteLine("Không tìm thấy node SoLuong trong sách có mã {0}.", bookId);
                }
            }


            document.Save(stringfile);


            }
        public void UpdateQuantityFromID(string bookId, int newQuantity)
        {



            XmlDocument document = new XmlDocument();
            document.Load(stringfile);

            XmlNodeList sachNodes = document.SelectNodes("/DanhSachSach/Sach[Ma='" + bookId + "']");

            foreach (XmlNode sachNode in sachNodes)
            {
                //                  CÁCH 1
                //string MaSach = sachNode["Ma"].InnerText;


                //if(MaSach.Equals(bookId))
                //{

                //}


                //                      CÁCH 2
                XmlNode quantityNode = sachNode.SelectSingleNode("SoLuong");
                if (quantityNode != null)
                {

                    
                   int  lastQuantity   = int.Parse(quantityNode.InnerText);
                    if (lastQuantity > newQuantity)
                    {
                        int finalQuantity = lastQuantity - newQuantity;
                        quantityNode.InnerText = finalQuantity.ToString();

                    }
                    // hay                  int Newsl = int.Parse(sachNode["SoLuong"].InnerText);

                    else
                    {
                        Console.WriteLine(  "Ko thể mượn sách do quá số lượng cho phéps");
                    }
                }
                else
                {
                  
                    Console.WriteLine("Mượn ko thành công ");
                }
            }



            Console.WriteLine(  "Sách sau khi cập nhập");

            document.Save(stringfile);
            ReadTuFileXML(stringfile);
            xuatSach();


        }

        public void SapXepVaLuuTheoTen(string file)
        {
            var dsSapXep = danhsachSach.OrderBy(sach => sach.TenSach).ToList();
            int i = 1;

            if (dsSapXep.Count > 0)
            {
                Console.WriteLine("Danh sách sau khi sắp xếp theo tên sách:");
                foreach (Sach sach in dsSapXep)
                {
                    Console.WriteLine("Tên sách thứ {0} : {1} ", i, sach.TenSach);
                    Console.WriteLine("---------------------------------");
                    i++;
                }

                XmlDocument doc = new XmlDocument();
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(xmlDeclaration);

                XmlElement danhSachSachElement = doc.CreateElement("DanhSachSach");
                doc.AppendChild(danhSachSachElement);

                foreach (Sach sach in dsSapXep)
                {
                    XmlElement sachElement = doc.CreateElement("Sach");
                    danhSachSachElement.AppendChild(sachElement);

                    XmlElement maElement = doc.CreateElement("Ma");
                    maElement.InnerText = sach.MaSach;
                    sachElement.AppendChild(maElement);

                    XmlElement tenSachElement = doc.CreateElement("TenSach");
                    tenSachElement.InnerText = sach.TenSach;
                    sachElement.AppendChild(tenSachElement);

                    XmlElement namSanXuatElement = doc.CreateElement("NamSanXuat");
                    namSanXuatElement.InnerText = sach.NamSanXuat.ToString();
                    sachElement.AppendChild(namSanXuatElement);

                    XmlElement giaBanElement = doc.CreateElement("GiaBan");
                    giaBanElement.InnerText = sach.GiaBan.ToString();
                    sachElement.AppendChild(giaBanElement);

                    XmlElement tacGiaElement = doc.CreateElement("TacGia");
                    tacGiaElement.InnerText = sach.TacGia;
                    sachElement.AppendChild(tacGiaElement);

                    XmlElement theLoaiElement = doc.CreateElement("TheLoai");
                    theLoaiElement.InnerText = sach.TheLoai;
                    sachElement.AppendChild(theLoaiElement);

                    XmlElement soLuongElement = doc.CreateElement("SoLuong");
                    soLuongElement.InnerText = sach.SoLuong.ToString();
                    sachElement.AppendChild(soLuongElement);
                }

                doc.Save(file);

                Console.WriteLine("Danh sách đã được sắp xếp và lưu vào file thành công.");
            }
            else
            {
                Console.WriteLine("Danh sách rỗng.");
            }
        }
        public void XoaThongTinSachrakhoifileXml(string maSach)
        {
            XDocument doc = XDocument.Load(stringfile);

            var sachToDelete = doc.Descendants("Sach")
                                  .FirstOrDefault(sach => sach.Element("Ma").Value == maSach);

            if (sachToDelete != null)
            {
                sachToDelete.Remove();
                doc.Save(stringfile);

                Console.WriteLine("Thông tin sách có mã {0} đã được xóa khỏi file XML.", maSach);
            }
            else
            {
                Console.WriteLine("Không tìm thấy sách có mã {0} trong file XML.", maSach);
            }
        }

        //Cách2
        public void CapNhatThongTinSach(string filePhieu)
        {
            XmlDocument docDocGia = new XmlDocument();
            docDocGia.Load(stringfile);

            XmlDocument docPhieu = new XmlDocument();
            docPhieu.Load(filePhieu);

            XmlNodeList nodeListSach= docDocGia.SelectNodes("/DanhSachSach/Sach");

            XmlNodeList nodeListPhieu = docPhieu.SelectNodes("/DanhSachPhieu/IPhieu");

            foreach (XmlNode nodeDocGia in nodeListSach)
            {
                string maSach = nodeDocGia.SelectSingleNode("Ma").InnerText;

                XmlNode nodePhieu = nodeListPhieu.Cast<XmlNode>()
                    .FirstOrDefault(phieu => phieu.SelectSingleNode("MaSach").InnerText == maSach);

                if (nodePhieu != null)
                {
                    int slsm = 0;
                    XmlNode nodeDanhSachSachMuon = nodeDocGia.SelectSingleNode("Loai");
                    if(nodeDanhSachSachMuon.InnerText=="Phiếu mượn")
                            {
                        int tongsosach = int.Parse(nodeDocGia["SoLuong"].InnerText);
                        int soLuongSachMuon = int.Parse(nodePhieu["SoLuongSach"].InnerText);

                         slsm = tongsosach - soLuongSachMuon;

                    }


                    else if (nodeDanhSachSachMuon.InnerText == "Phiếu tra3")

                    {
                        int tongsosach = int.Parse(nodeDocGia["SoLuong"].InnerText);
                        int soLuongSachMuon = int.Parse(nodePhieu["SoLuongSach"].InnerText);

                        slsm = tongsosach +soLuongSachMuon;
                    }

                    nodeDocGia["SoLuongSach"].InnerText = slsm.ToString();
                }
            }

            docPhieu.Save(filePhieu);
        }
        public bool checkMa(string ma)
        {
            ReadTuFileXML(stringfile);

            foreach (var item in danhsachSach)
            {
                if (item.MaSach == ma)
                    return false;
            }
            return true;
        }
    }
}
