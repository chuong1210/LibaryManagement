using System;
using System.Collections.Generic;
using System.Linq;
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
        public void LuuFileXML()
        {
            string filePath = "../../Sach/SachXMsL.xml";

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
            ) ;

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

                LuuFileXML();
            }
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

        public void WriteVaoFileXML(string file)
        {
            throw new NotImplementedException();
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
