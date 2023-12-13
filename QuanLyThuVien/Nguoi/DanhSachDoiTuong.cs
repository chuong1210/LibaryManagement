using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace QuanLyThuVien.Nguoi
{
    internal class DanhSachDoiTuong:OperateXML
    {
        List<DoiTuong> ListDT = new List<DoiTuong>();
        DanhSachSach listS = new DanhSachSach();


        public void XuatList()
        {
            foreach (var item in ListDT)
            {
                item.XuatThongTin();
            }
        }
        public void ReadTuFileXML(string file)
        {

            XmlDocument read = new XmlDocument();
            read.Load(file);
            XmlNodeList nodes = read.SelectNodes("/DanhSachDoiTuong/DoiTuong");

            foreach (XmlNode node in nodes)
            {
                DoiTuong dt;

                string loai = node["Loai"].InnerText;
                string gioitinh = node["GioiTinh"].InnerText;
                string ten = node["HoTen"].InnerText;
                int tuoi = int.Parse(node["Tuoi"].InnerText);

                if (loai == "Độc giả")
                {

                    string madg = node["Ma"].InnerText;
                  
                    string diachi = node["DiaChi"].InnerText;
                    string soCmt = node["SoCMT"].InnerText;


                    DateTime ngayDk = new DateTime();/*= DateTime.Parse(node["NgayDangKi"]?.InnerText);*/
                    string ngayDangKiStr = node.SelectSingleNode("NgayDangKi")?.InnerText;

                    ngayDk = DateTime.ParseExact(ngayDangKiStr, "yyyy/MM/dd", CultureInfo.InvariantCulture);


                    DocGia dg = new DocGia(gioitinh, ten, tuoi, madg, diachi, ngayDk, soCmt);



                    XmlNodeList sachNodes = node.SelectNodes("DanhSachSachMuon/Sach");


                    if (sachNodes != null)
                    {
                        List<Sach> Books =listS.AdjustmentSach(sachNodes);
                        foreach (Sach S in Books)
                        {
                            dg.ThemSachMuon(S);

                        }

                        ListDT.Add(dg);
                    }

                    if(loai=="Thủ thư")
                    {

                    }
                }
            }
        }

        public void WriteVaoFileXML(string file)
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement danhSachDoiTuongElement = doc.CreateElement("DanhSachDoiTuong");
            doc.AppendChild(danhSachDoiTuongElement);

            foreach (DocGia dg in ListDT)
            {
                XmlElement doiTuongElement = doc.CreateElement("DoiTuong");
                danhSachDoiTuongElement.AppendChild(doiTuongElement);

                

                XmlElement loaiElement = doc.CreateElement("Loai");
                loaiElement.InnerText = "Độc giả";
                doiTuongElement.AppendChild(loaiElement);

                XmlElement gioiTinhElement = doc.CreateElement("GioiTinh");
                gioiTinhElement.InnerText = dg.GioiTinh;
                doiTuongElement.AppendChild(gioiTinhElement);

                XmlElement tenElement = doc.CreateElement("HoTen");
                tenElement.InnerText = dg.Ten;
                doiTuongElement.AppendChild(tenElement);

                XmlElement tuoiElement = doc.CreateElement("Tuoi");
                tuoiElement.InnerText = dg.Tuoi.ToString();
                doiTuongElement.AppendChild(tuoiElement);

                XmlElement maElement = doc.CreateElement("Ma");
                maElement.InnerText = dg.MaDg1;
                doiTuongElement.AppendChild(maElement);

                XmlElement diaChiElement = doc.CreateElement("DiaChi");
                diaChiElement.InnerText = dg.DiaChi;
                doiTuongElement.AppendChild(diaChiElement);

                XmlElement ngayDangKiElement = doc.CreateElement("NgayDangKi");
                ngayDangKiElement.InnerText = dg.NgayDangki.ToString("yyyy/MM/dd");
                doiTuongElement.AppendChild(ngayDangKiElement);

                XmlElement soCmtElement = doc.CreateElement("SoCMT");
                soCmtElement.InnerText = dg.SoCmt;
                doiTuongElement.AppendChild(soCmtElement);

                XmlElement danhSachSachMuonElement = doc.CreateElement("DanhSachSachMuon");
                doiTuongElement.AppendChild(danhSachSachMuonElement);

                foreach (Sach sach in dg.DanhSachSachMuon)
                {
                    XmlElement sachElement = doc.CreateElement("Sach");
                    danhSachSachMuonElement.AppendChild(sachElement);

                    XmlElement maSachElement = doc.CreateElement("MaSach");
                    maSachElement.InnerText = sach.MaSach;
                    sachElement.AppendChild(maSachElement);

                    XmlElement tenSachElement = doc.CreateElement("TenSach");
                    tenSachElement.InnerText = sach.TenSach;
                    sachElement.AppendChild(tenSachElement);

                    XmlElement namSanXuatElement = doc.CreateElement("NamSanXuat");
                    namSanXuatElement.InnerText = sach.NamSanXuat.ToString();
                    sachElement.AppendChild(namSanXuatElement);

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
            }

            doc.Save(file);
        }

       
    }
}
    

