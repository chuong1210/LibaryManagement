using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuanLyThuVien.Phieu
{
    internal class DanhSachPhieu:OperateXML
    {
        private List<IPhieu> danhSachPhieu;

        public DanhSachPhieu()
        {
            danhSachPhieu = new List<IPhieu>();
        }

        public void ReadTuFileXML(string file)
        {

            XmlDocument read = new XmlDocument();
            read.Load(file);
            XmlNodeList nodes = read.SelectNodes("/DachSachPhieu/IPhieu");

            foreach (XmlNode node in nodes)
            {
                IPhieu Ip;

                string loai = node["Loai"].InnerText;
                string ms = node["MaSach"].InnerText;
                string mDg = node["MaDocGia"].InnerText;
                int sl = int.Parse(node["SoLuongSach"].InnerText);

                if (loai == "Phiếu mượn")
                {


                    string mPm = node["MaPhieuMuon"].InnerText;


                    DateTime ngayM= new DateTime();/*= DateTime.Parse(node["NgayDangKi"].InnerText);*/
                    string ngayDangKiStr = node.SelectSingleNode("NgayMuon")?.InnerText;

                    ngayM = DateTime.ParseExact(ngayDangKiStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    Ip= new PhieuMuon(ms, mDg, sl,mPm, ngayM);
                    danhSachPhieu.Add(Ip);


                }

          else      if (loai == "Phiếu trả")
                {


                    string mPt = node["MaPhieuTra"].InnerText;


                    DateTime ngayT = new DateTime();/*= DateTime.Parse(node["NgayDangKi"]?.InnerText);*/
                    string ngayDangKiStr = node.SelectSingleNode("NgayTra")?.InnerText;

                    ngayT = DateTime.ParseExact(ngayDangKiStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    Ip = new PhieuMuon(ms, mDg, sl, mPt, ngayT);
                    danhSachPhieu.Add(Ip);


                }
            }
        }
                    public void ThemPhieu(IPhieu phieu)
        {
            danhSachPhieu.Add(phieu);
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
                foreach (IPhieu phieu in danhSachPhieu)
                {
                    phieu.XuatPhieu();
                    Console.WriteLine("--------------");
                }
            }
            else
            {
                Console.WriteLine("Danh sách phiếu trống.");
            }
        }

        public void WriteVaoFileXML(string file)
        {
            throw new NotImplementedException();
        }
    }
}
