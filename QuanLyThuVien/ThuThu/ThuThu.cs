﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using QuanLyThuVien.Phieu;

namespace QuanLyThuVien
{
    public class ThuThu : OperateXML
    {
        string maThuThu;
        public List<IPhieu> DanhSachPhieu;
        string gioitinh;
        string name;
        int tuoi;
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

        DanhSachPhieu dsp = new DanhSachPhieu();
        
        public ThuThu(string gt, string name, int age, string matt)
        {
            this.maThuThu = matt;
            this.gioitinh = gt;
            this.name = name;
            this.tuoi = age;
            DanhSachPhieu = new List<IPhieu>();




        }


        public void ReadTuFileXML(string tenfile)
        {
            XmlDocument file = new XmlDocument();
            file.Load(tenfile);
            XmlNodeList Ttnodes = file.SelectNodes("/ThuThu");
            foreach (XmlNode ttnode in Ttnodes)
            {

                string MaThuThu = ttnode["MaThuThu"].InnerText;
                string GioiTinh = ttnode["GioiTinh"].InnerText;
                int Tuoi = int.Parse(ttnode["Tuoi"].InnerText);
                string HoTen = ttnode["HoTen"].InnerText;


                XmlNodeList phieuNodes = ttnode.SelectNodes("DachSachPhieu/IPhieu");

                List<IPhieu> danhSachPhieu = new List<IPhieu>();

                foreach (XmlNode phieuNode in phieuNodes)
                {
                    string loaiPhieu = phieuNode["Loai"].InnerText;

                    if (loaiPhieu == "Phiếu mượn")
                    {
                        string maPhieuMuon = phieuNode["MaPhieuMuon"].InnerText;
                        string maSachMuon = phieuNode["MaSach"].InnerText;
                        string maDocGiaMuon = phieuNode["MaDocGia"].InnerText;
                        DateTime ngayMuon = DateTime.Parse(phieuNode["NgayMuon"].InnerText);
                        int soLuongSachMuon = int.Parse(phieuNode["SoLuongSach"].InnerText);

                        PhieuMuon phieuMuon = new PhieuMuon(maSachMuon, maDocGiaMuon, soLuongSachMuon, maPhieuMuon, ngayMuon);
                        danhSachPhieu.Add(phieuMuon);
                    }
                    else if (loaiPhieu == "Phiếu trả")
                    {
                        string maPhieuTra = phieuNode["MaPhieuTra"].InnerText;
                        string maSachTra = phieuNode["MaSach"].InnerText;
                        string maDocGiaTra = phieuNode["MaDocGia"].InnerText;
                        DateTime ngayTra = DateTime.Parse(phieuNode["NgayTra"].InnerText);
                        int soLuongSachTra = int.Parse(phieuNode["SoLuongSach"].InnerText);

                        PhieuTra phieuTra = new PhieuTra(maSachTra, maDocGiaTra, soLuongSachTra, maPhieuTra, ngayTra);
                        danhSachPhieu.Add(phieuTra);
                    }
                }

                dsp.ThemListPhieu(danhSachPhieu);
                ThuThu thuThu = new ThuThu(MaThuThu, GioiTinh, Tuoi, HoTen);
            }

        }

        public void WriteVaoFileXML(string file)
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement thuThuElement = doc.CreateElement("ThuThu");
            doc.AppendChild(thuThuElement);

            Console.WriteLine("Nhập thông tin Thủ Thư:");
            Console.Write("Mã Thủ Thư: ");
            string maThuThu = Console.ReadLine();

            Console.Write("Giới Tính: ");
            string gioiTinh = Console.ReadLine();

            Console.Write("Tuổi: ");
            int tuoi = int.Parse(Console.ReadLine());

            Console.Write("Họ Tên: ");
            string hoTen = Console.ReadLine();

            XmlElement maThuThuElement = doc.CreateElement("MaThuThu");
            maThuThuElement.InnerText = maThuThu;
            thuThuElement.AppendChild(maThuThuElement);

            XmlElement gioiTinhElement = doc.CreateElement("GioiTinh");
            gioiTinhElement.InnerText = gioiTinh;
            thuThuElement.AppendChild(gioiTinhElement);

            XmlElement tuoiElement = doc.CreateElement("Tuoi");
            tuoiElement.InnerText = tuoi.ToString();
            thuThuElement.AppendChild(tuoiElement);

            XmlElement hoTenElement = doc.CreateElement("HoTen");
            hoTenElement.InnerText = hoTen;
            thuThuElement.AppendChild(hoTenElement);


            Console.WriteLine("Nhập thông tin Phiếu:");

            Console.Write("Nhập số lượng phiếu cần thêm: ");
            int slp = int.Parse(Console.ReadLine());
            XmlElement danhSachDoiTuongElement = doc.CreateElement("DachSachPhieu");
            doc.AppendChild(danhSachDoiTuongElement);

            for (int i = 0; i < slp; i++)
            {
                Console.WriteLine("Phiếu thứ {0}:", i + 1);

                Console.WriteLine("Loại Phiếu (Phiếu mượn/Phiếu trả): ");
                string loaiPhieu = Console.ReadLine();
                loaiPhieu = loaiPhieu.Trim().ToLower();
                XmlElement doiTuongElement = doc.CreateElement("IPhieu");
                danhSachDoiTuongElement.AppendChild(doiTuongElement);
                XmlElement loaiElement = doc.CreateElement("Loai");

             
                if (loaiPhieu.Equals("phiếu mượn")|| loaiPhieu.Equals("phieu muon"))
                {
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
                    Console.WriteLine("Nhập số lượng sách");
                    int sls = int.Parse(Console.ReadLine());
                    SoLuongElement.InnerText = sls.ToString();
                    doiTuongElement.AppendChild(SoLuongElement);

                }
                else if(loaiPhieu.Equals("phiếu trả") || loaiPhieu.Equals("phieu trả"))
                {
                    loaiElement.InnerText = "Phiếu mượn";
                    doiTuongElement.AppendChild(loaiElement);

                    XmlElement MaPhieuMuonElement = doc.CreateElement("MaPhieuMuon");
                    Console.WriteLine("Nhập mã phiếu trả");
                    string mpm = Console.ReadLine();
                    MaPhieuMuonElement.InnerText = mpm;
                    doiTuongElement.AppendChild(MaPhieuMuonElement);

                    XmlElement MaSachElement = doc.CreateElement("MaSach");
                    Console.WriteLine("Nhập mã sách");
                    string ms = Console.ReadLine();
                    MaSachElement.InnerText = ms;
                    doiTuongElement.AppendChild(MaSachElement);

                    XmlElement MaDocgiaElement = doc.CreateElement("MaDocGia");
                    Console.WriteLine("Nhap ma độc giả");
                    string madocgia = Console.ReadLine();
                    MaDocgiaElement.InnerText = madocgia;
                    doiTuongElement.AppendChild(MaDocgiaElement);

                    XmlElement ngayTraElement = doc.CreateElement("NgayTra");
                    Console.Write("Nhập ngày trả sách theo định dạng (yyyy-MM-dd): ");
                    DateTime NgayTra = new DateTime();
                    string ngayTraStr = Console.ReadLine();

                    NgayTra = DateTime.ParseExact(ngayTraStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);
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


        public void XuatThongTin()
        {
            xuatPhieuql();
        }
        public void xuatPhieuql()
        {
            Console.WriteLine("Danh sách Phiếu thủ thư quản lí:");

            foreach (IPhieu phieu in DanhSachPhieu)
            {
                phieu.XuatPhieu();

            }
        }
        public void ThemPhieuQuanLi(IPhieu phieu)
        {
            if (DanhSachPhieu == null)
            {
                DanhSachPhieu = new List<IPhieu>();
            }


            DanhSachPhieu.Add(phieu);
        }

     

        public string MaThuThu
        {
            get
            {


                if (maThuThu.Length == 4)
                {
                    string DG = maThuThu.Substring(0, 2);
                    string so = maThuThu.Substring(2);

                    if (DG == "DG" && !ContainsNumber(so))
                    {
                        return maThuThu;
                    }
                    else
                    {
                        maThuThu = "TTI1";
                    }
                }
                else
                {
                    maThuThu = "TTI1";
                }

                return maThuThu;

            }

        }

    }
}
    
