using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace QuanLyThuVien.Phieu
{
    internal class DanhSachPhieu : OperateXML
    {

        private List<IPhieu> danhSachPhieu;

        public DanhSachPhieu()
        {
            danhSachPhieu = new List<IPhieu>();
        }

        public void XoaPhieuTheoMa(string maPhieu)
        {
            IPhieu phieuCanXoa = danhSachPhieu.Find(e => e is PhieuMuon && ((PhieuMuon)e).MaPhieuMuon1 == maPhieu)
                               ?? danhSachPhieu.Find(e => e is PhieuTra && ((PhieuTra)e).MaPhieutra1 == maPhieu);

            if (phieuCanXoa != null)
            {
                danhSachPhieu.Remove(phieuCanXoa);
                Console.WriteLine("Đã xóa phiếu có mã số {0}.", maPhieu);
            }
            else
            {
                Console.WriteLine("Không tìm thấy phiếu có mã số {0} để xóa.", maPhieu);
            }
        }

        public void ThemListPhieu(List<IPhieu> dsp)
        {
            danhSachPhieu= dsp;
        }

            public void ReadTuFileXML(string file)
        {

            XmlDocument read = new XmlDocument();
            read.Load(file);
            XmlNodeList nodes = read.SelectNodes("/DanhSachPhieu/IPhieu");

            foreach (XmlNode node in nodes)
            {

                IPhieu Ip;

                string loai = node["Loai"].InnerText;
                string ms = node["MaSach"].InnerText;
                string mp = node["MaDocGia"].InnerText;
                int sl = int.Parse(node["SoLuongSach"].InnerText);

                if (loai == "Phiếu mượn")
                {


                    string mPm = node["MaPhieuMuon"].InnerText;
                    DateTime ngayM = new DateTime();/*= DateTime.Parse(node["NgayDangKi"].InnerText);*/
                    string ngayDangKiStr = node.SelectSingleNode("NgayMuon")?.InnerText;
                    ngayM = DateTime.ParseExact(ngayDangKiStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    Ip = new PhieuMuon(ms, mp, sl, mPm, ngayM);
                    danhSachPhieu.Add(Ip);


                }

                else if (loai == "Phiếu trả")
                {


                    string mPt = node["MaPhieuTra"].InnerText;
                    DateTime ngayT = new DateTime();/*= DateTime.Parse(node["NgayDangKi"]?.InnerText);*/
                    string ngayDangKiStr = node.SelectSingleNode("NgayTra")?.InnerText;
                    ngayT = DateTime.ParseExact(ngayDangKiStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    Ip = new PhieuMuon(ms, mp, sl, mPt, ngayT);
                    danhSachPhieu.Add(Ip);


                }
            }
        }



        public void WriteVaoFileXML(string file)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement danhSachDoiTuongElement = doc.CreateElement("DanhSachPhieu");
            doc.AppendChild(danhSachDoiTuongElement);
          
             


            int n;
            Console.WriteLine(  "Nhập phần tử phiếu cần thêm");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Phiếu thứ {0}:", i + 1);

                Console.Write("Loại Phiếu (Phiếu mượn/Phiếu trả): ");
                string loaiPhieu = Console.ReadLine();
                loaiPhieu = loaiPhieu.Trim().ToLower();
                if (loaiPhieu.Equals("phiếu mượn") || loaiPhieu.Equals("phieu muon"))
                {
                    XmlElement doiTuongElement = doc.CreateElement("IPhieu");
                    danhSachDoiTuongElement.AppendChild(doiTuongElement);
                    XmlElement loaiElement = doc.CreateElement("Loai");
                    loaiElement.InnerText = "Phiếu mượn";
                    doiTuongElement.AppendChild(loaiElement);

                    XmlElement MaPhieuMuonElement = doc.CreateElement("MaPhieuMuon");
                    Console.WriteLine("Nhap ma phieu muon");
                    string mpm = Console.ReadLine();
                    MaPhieuMuonElement.InnerText = mpm;
                    doiTuongElement.AppendChild(MaPhieuMuonElement);

                    XmlElement MaSachElement = doc.CreateElement("MaSach");
                    Console.WriteLine("Nhap ma sách");
                    string ms = Console.ReadLine();
                    MaSachElement.InnerText = ms;
                    doiTuongElement.AppendChild(MaSachElement);

                    XmlElement MaDocgiaElement = doc.CreateElement("MaDocGia");
                    Console.WriteLine("Nhap ma độc giả");
                    string madocgia = Console.ReadLine();
                    MaDocgiaElement.InnerText = madocgia;
                    doiTuongElement.AppendChild(MaDocgiaElement);

                    XmlElement ngayMuonElement = doc.CreateElement("NgayMuon");
                    Console.Write("Nhập ngày mượn sách theo định dạng (yyyy-MM-dd): ");
                    DateTime NgayMuon = new DateTime();
                    string ngayMuonStr = Console.ReadLine();

                    NgayMuon = DateTime.ParseExact(ngayMuonStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    ngayMuonElement.InnerText = NgayMuon.ToString("yyyy-MM-dd");
                    doiTuongElement.AppendChild(ngayMuonElement);

                    XmlElement SoLuongElement = doc.CreateElement("SoLuongSach");
                    Console.WriteLine("Nhap số lượng sách");
                    int sls = int.Parse(Console.ReadLine());
                    SoLuongElement.InnerText = sls.ToString();
                    doiTuongElement.AppendChild(SoLuongElement);


                }

            else    if (loaiPhieu.Equals("phiếu trả") || loaiPhieu.Equals("phieu tra"))
                {
                    XmlElement doiTuongElement = doc.CreateElement("IPhieu");
                    danhSachDoiTuongElement.AppendChild(doiTuongElement);
                    XmlElement loaiElement = doc.CreateElement("Loai");
                    loaiElement.InnerText = "Phiếu trả";
                    doiTuongElement.AppendChild(loaiElement);

                    XmlElement MaPhieuMuonElement = doc.CreateElement("MaPhieuTra");
                    Console.WriteLine("Nhập mã phiếu trả:");
                    string mpm = Console.ReadLine();
                    MaPhieuMuonElement.InnerText = mpm;
                    doiTuongElement.AppendChild(MaPhieuMuonElement);

                    XmlElement MaSachElement = doc.CreateElement("MaSach");
                    Console.WriteLine("Nhập mã sách: ");
                    string ms = Console.ReadLine();
                    MaSachElement.InnerText = ms;
                    doiTuongElement.AppendChild(MaSachElement);

                    XmlElement MaDocgiaElement = doc.CreateElement("MaDocGia");
                    Console.WriteLine("Nhap mã độc giả:");
                    string madocgia = Console.ReadLine();
                    MaDocgiaElement.InnerText = madocgia;
                    doiTuongElement.AppendChild(MaDocgiaElement);

                    XmlElement ngayTraElement = doc.CreateElement("NgayTra");
                    Console.Write("Nhập ngày trả sách theo định dạng (yyyy-MM-dd): ");
                    DateTime NgayTra = new DateTime();
                    string ngayMuonStr = Console.ReadLine();

                    NgayTra = DateTime.ParseExact(ngayMuonStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    ngayTraElement.InnerText = NgayTra.ToString("yyyy-MM-dd");
                    doiTuongElement.AppendChild(ngayTraElement);

                    XmlElement SoLuongElement = doc.CreateElement("SoLuongSach");
                    Console.WriteLine("Nhap số lượng sách");
                    int sls = int.Parse(Console.ReadLine());
                    SoLuongElement.InnerText = sls.ToString();
                    doiTuongElement.AppendChild(SoLuongElement);


                }
            }
            
            doc.Save(file);
            ReadTuFileXML(file);

        }
        public void ThemPhieu(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Chọn loại phiếu cần nhập (Phieu Muon/Phieu Tra)");
                string loai=Console.ReadLine();
                if (loai.Trim().ToLower() == "phieu muon") 
                {
                    PhieuMuon pm = new PhieuMuon();
                    pm.NhapPhieu();
                    danhSachPhieu.Add(pm);

                }
               else if (loai.Trim().ToLower() == "phieu tra") 
                {
                    PhieuTra pt = new PhieuTra();

                    pt.NhapPhieu();
                    danhSachPhieu.Add(pt);

                }
            }
        }


        public void XoaPhieu(IPhieu phieu)
        {
            danhSachPhieu.Remove(phieu);
        }

        public List<IPhieu> LayDanhSachPhieu()
        {
            return danhSachPhieu;
        }

        public void XuatDanhSachPhieu()
        {
            if (danhSachPhieu.Count > 0)
            {
                Console.WriteLine("Danh sách phiếu:");
                int i = 1;
                foreach (IPhieu phieu in danhSachPhieu)
                {
                    
                    Console.WriteLine("*-------------------------------------------------------*");
                    Console.WriteLine("Thông tin của Phiếu thứ {0}: ", i);
                    phieu.XuatPhieu();
                    Console.WriteLine("--------------------------------------------------------");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Danh sách phiếu trống.");
            }
        }

    }
}
