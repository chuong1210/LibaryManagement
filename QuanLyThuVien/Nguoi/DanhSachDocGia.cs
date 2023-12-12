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
    internal class DanhSachDocGia
    {
        List<DoiTuong> ListDT = new List<DoiTuong>();
        public void XuatList()
        {
            foreach (var item in ListDT)
            {
                item.XuatThongTin();
            }
        }
        public void DocGiaTuXML(string file)
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
                        foreach (XmlNode sachNode in sachNodes)
                        {
                            string MaSach = sachNode.SelectSingleNode("MaSach")?.InnerText;
                            string TenSach = sachNode.SelectSingleNode("TenSach")?.InnerText;
                            int NamSanXuat = int.Parse(sachNode.SelectSingleNode("NamSanXuat")?.InnerText);
                            string TacGia = sachNode.SelectSingleNode("TacGia")?.InnerText;
                            string TheLoai = sachNode.SelectSingleNode("TheLoai")?.InnerText;
                            int SoLuong = int.Parse(sachNode.SelectSingleNode("SoLuong")?.InnerText);
                            Sach sach = new Sach(MaSach, TenSach, NamSanXuat, TacGia, TheLoai, SoLuong);
                            dg.ThemSachMuon(sach);

                        }
                        // Lấy danh sách sách mượn

                        //dt = new DocGia(gioitinh, ten, tuoi, madg, diachi, NgayDangKi, soCmt);


                        ListDT.Add(dg);
                    }

                    if(loai=="Thủ thư")
                    {

                    }
                }
            }
        }
    }
        }
    

