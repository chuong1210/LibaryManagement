using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace QuanLyThuVien
{
   public class DanhSachSach
    {
        public DanhSachSach()
        {
        }
        List<Sach> danhsachSach = new List<Sach>();
        public void NhapSachXML(string tenfile)
        {
            XmlDocument file = new XmlDocument();
            file.Load(tenfile);
            XmlNodeList SachNode = file.SelectNodes("DanhSachSach/Sach");
            foreach (XmlNode sachnode in SachNode)
            {
                ////// 
                string MaSach = sachnode.SelectSingleNode("MaSach")?.InnerText;
                string TenSach = sachnode.SelectSingleNode("TenSach")?.InnerText;
                int  NamSanXuat = int.Parse(sachnode.SelectSingleNode("NamSanXuat")?.InnerText);
                string TacGia = sachnode.SelectSingleNode("TacGia")?.InnerText;
                string TheLoai = sachnode.SelectSingleNode("TheLoai")?.InnerText;
                int SoLuong = int.Parse(sachnode.SelectSingleNode("SoLuong")?.InnerText);
                Sach sach = new Sach(MaSach,TenSach,NamSanXuat,TacGia,TheLoai,SoLuong);
                danhsachSach.Add(sach);

            }

        }



        public void xuatSach()
        {
            foreach(Sach s in danhsachSach)
            {
                s.XuatSach();
            }
        }
        public void LuuFileXML()
        {
            string filePath = "SachXML.xml";

            // Tạo đối tượng XElement từ danh sách sách
            XElement danhSachSachXml = new XElement("DanhSachSach",
                from sach in danhsachSach
                select new XElement("Sach",
                    new XElement("MaSach", sach.MaSach),
                    new XElement("TenSach", sach.TenSach),
                    new XElement("NamSanXuat", sach.NamSanXuat),
                    new XElement("TacGia", sach.TacGia),
                    new XElement("TheLoai", sach.TheLoai),
                    new XElement("SoLuong", sach.SoLuong)
                )
            ) ;

            // Lưu danh sách sách vào file XML
            danhSachSachXml.Save(filePath);
        }
        // Phương thức để sửa thông tin sách và lưu vào file XML
        public void SuaThongTinSach(string maSach, string tenSach, int namSanXuat, string tacGia, string theLoai, int soLuong)
        {
            // Tìm sách cần sửa trong danh sách
            Sach sachCanSua = danhsachSach.FirstOrDefault(sach => sach.MaSach == maSach);

            // Nếu sách tồn tại, thực hiện sửa thông tin
            if (sachCanSua != null)
            {
                sachCanSua.TenSach = tenSach;
                sachCanSua.NamSanXuat = namSanXuat;
                sachCanSua.TacGia = tacGia;
                sachCanSua.TheLoai = theLoai;
                sachCanSua.SoLuong = soLuong;

                // Lưu danh sách sách vào file XML
                LuuFileXML();
            }
            else
            {
                Console.WriteLine("Không tìm thấy sách có mã số {0} để sửa.", maSach);
            }
        }
        
        public void ThemThongTinSach(string ms,string tenSach, int namSanXuat, string tacGia, string theLoai, int soLuong)
        {
            Sach sachMoi = new Sach
            (
                ms,
                tenSach,
               namSanXuat,
               tacGia,
               theLoai,
              soLuong
            );

            // Thêm sách mới vào danh sách sách
            danhsachSach.Add(sachMoi);

            // Lưu danh sách sách vào file XML
            LuuFileXML();
        }
        public void XoaThongTinSach(string maSach)
        {
            // Tìm sách cần xóa trong danh sách
            Sach sachCanXoa = danhsachSach.FirstOrDefault(sach => sach.MaSach == maSach);

            // Nếu sách tồn tại, thực hiện xóa và lưu danh sách vào file XML
            if (sachCanXoa != null)
            {
                danhsachSach.Remove(sachCanXoa);
                LuuFileXML();
            }
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
