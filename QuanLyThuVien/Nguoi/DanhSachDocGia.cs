using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using QuanLyThuVien.Phieu;

namespace QuanLyThuVien.Nguoi
{
    internal class DanhSachDocGia:OperateXML
    {
        List<DocGia> ListDG = new List<DocGia>();
        DanhSachSach listS = new DanhSachSach();
        DanhSachPhieu listP= new DanhSachPhieu();
        List<string> dgs=new List<string>() { "Sinh viên","Thiếu nhi", "Người lớn"};

        public void XuatList()
        {
            int i = 1;

            foreach (var item in ListDG)
            {
                Console.WriteLine("*-------------------------------------------------------*");
                Console.WriteLine("Thông tin của độc giả thứ {0}: ", i);
                i++;

                item.XuatThongTin();
            }
        }


        public void TimDocGiaTheoDiaChi(string diaChi)
        {
            string dc = diaChi.Trim().ToLowerInvariant();
            List<DocGia> dsTimKiem = ListDG.Where(dg => dg.DiaChi.Trim().ToLowerInvariant().Equals(dc)).ToList();
            Console.WriteLine("\nKết quả tìm kiếm:");
            if (dsTimKiem.Count>0)
            {
                foreach (DocGia docGia in dsTimKiem)
                {

                    docGia.XuatThongTin();
                    Console.WriteLine("----------------------------------");

                }
            }
            else
            {
                Console.WriteLine("Không tìm thây độc giả có địa chỉ {0}", diaChi);
            }
        }

public double TinhTuoiTrungBinh()
        {
            if (ListDG.Count == 0)
                return 0;

            int tongTuoi = 0;
            foreach (var docGia in ListDG)
            {
                tongTuoi += docGia.Tuoi;
            }

            return (double)tongTuoi / ListDG.Count;
        }

        public void XuatDocGiaChuaTraSach()
        {
            Console.WriteLine("Danh sách độc giả chưa trả sách:");
            foreach (var docGia in ListDG)
            {
                if (docGia.DanhSachSachMuon.Count > 0)
                {
                    docGia.XuatThongTin();
                    Console.WriteLine("-----------------------------");
                }
             
            }
        }

        public void XoaAllThongTinDocGiaCoTheHetHan()
        {

            for (int i = ListDG.Count - 1; i >= 0; i--)
            {
                DocGia dg = ListDG[i];
                DateTime ngayHienTai = DateTime.Now;

                TimeSpan thoiGianSuDung = ngayHienTai - dg.NgayDangki;
                int soNgaySuDung = thoiGianSuDung.Days;
                int songaycothedung=0;
                if (dg is SinhVien)
                {
                    songaycothedung = 720 - soNgaySuDung;
                }
              else  if (dg is NguoiLon)
                {
                     songaycothedung = 360 - soNgaySuDung;
                }
                else if (dg is ThieuNhi)
                {
                    songaycothedung = 180 - soNgaySuDung;
                }
                if (songaycothedung < 0)
                {
                    ListDG.RemoveAt(i);
                }
            }
        }
        public void XoaThongTinDocGiaDautien(string mdg)
        {
            string mdocgia = mdg.Trim().ToLower();
            DocGia dgCanXoa = ListDG.FirstOrDefault(sach => sach.MaDg1.Trim().ToLower() == mdocgia  );

            if (dgCanXoa != null)
            {
                ListDG.Remove(dgCanXoa);
                Console.WriteLine("Xóa độc giả có mã {0} thành công.", mdg);

            }
            else
            {
                Console.WriteLine("Không tìm thấy độc có mã số {0} để xóa.", mdg);
            }
        }
        public void UpdateDiachiDocGiaTheoMa(string maDocGia, string diachi)
        {
            DocGia docGiaCanSua = ListDG.FirstOrDefault(dg => dg.MaDg1.Trim().ToLower() == maDocGia.Trim().ToLower());

            if (docGiaCanSua != null)
            {
                docGiaCanSua.DiaChi = diachi;

                Console.WriteLine("Sửa địa chỉ thành công!");
                Console.WriteLine("Thông tin mới của độc giả:");
                docGiaCanSua.XuatThongTin();
            }
            else
            {
                Console.WriteLine("Không tìm thấy độc giả có mã {0}.", maDocGia);
            }
        }
        public void docgiaNguoilonGV()
        {
         
                Console.WriteLine("Danh sách người lớn là giáo viên:");
            int i = 0;
            foreach (DocGia dg in ListDG)
            {

                if (dg is NguoiLon)
                {
                    i++;
                    NguoiLon t = (NguoiLon)dg;
                    if (t.Congviec.Trim().ToLowerInvariant() == "Giao vien" || t.Congviec.Trim().ToLowerInvariant() == "giao vien" ||
                        t.Congviec.Trim().ToLowerInvariant() == "Giáo viên"||t.Congviec.Trim().ToLowerInvariant() == "giáo viên")
                            {


                        dg.XuatThongTin();
                        Console.WriteLine("---------------------------------");
                    }
                }
              }

            Console.WriteLine(  "Có tổng cộng {0} giáo viên trong danh sách", i);



        }

        public void SapXepDocGiaTheoTen()
        {
            var dsSapXep = ListDG.OrderBy(dg => dg.Hoten).ToList();
            int i = 1;

            if (dgs.Count > 0)
            {
                Console.WriteLine("Danh sách sau khi sắp xếp theo tên:");
                foreach (var docGia in dsSapXep)
                {
                    
                    Console.WriteLine("Tên độc giả thứ {0} : {1} ",i, docGia.Hoten);
                    Console.WriteLine("---------------------------------");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Danh sách rỗng.");
            }
        }

        public void SapXepDGTheoNhomVaTen()
        {
            List<DocGia> dsNguoiLon = new List<DocGia>();
            List<DocGia> dsSinhVien = new List<DocGia>();
            List<DocGia> dsThieuNhi = new List<DocGia>();

            foreach (DocGia dg in ListDG)
            {
                if (dg is NguoiLon)
                {
                    dsNguoiLon.Add(dg);
                }
                else if (dg is SinhVien)
                {
                    dsSinhVien.Add(dg);
                }
                else if (dg is ThieuNhi)
                {
                    dsThieuNhi.Add(dg);
                }
            }

            dsNguoiLon = dsNguoiLon.OrderBy(dg => dg.Hoten).ToList();
            dsSinhVien = dsSinhVien.OrderBy(dg => dg.Hoten).ToList();
            dsThieuNhi = dsThieuNhi.OrderBy(dg => dg.Hoten).ToList();

            if (dsNguoiLon.Count > 0)
            {
                Console.WriteLine("Danh sách người lớn sau khi sắp xếp theo tên:");
                foreach (DocGia nguoiLon in dsNguoiLon)
                {
                    nguoiLon.XuatThongTin();
                    Console.WriteLine("---------------------------------");
                }
            }

            if (dsSinhVien.Count > 0)
            {
                Console.WriteLine("Danh sách sinh viên sau khi sắp xếp theo tên:");
                foreach (DocGia sinhVien in dsSinhVien)
                {
                    sinhVien.XuatThongTin();
                    Console.WriteLine("---------------------------------");
                }
            }

            if (dsThieuNhi.Count > 0)
            {
                Console.WriteLine("Danh sách thiếu nhi sau khi sắp xếp theo tên:");
                foreach (DocGia ThieuNhi in dsThieuNhi)
                {
                    ThieuNhi.XuatThongTin();
                    Console.WriteLine("---------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Không có độc giả trong danh sách.");
            }
        }

        public void ReadTuFileXML(string file)
        {

            XmlDocument read = new XmlDocument();
            read.Load(file);
            XmlNodeList nodes = read.SelectNodes("/DanhSachDocGia/DocGia");
            foreach (XmlNode node in nodes)
            {

                DocGia dg;

                string loai = node["Loai"].InnerText;
                string gioitinh = node["GioiTinh"].InnerText;
                string ten = node["HoTen"].InnerText;
                int tuoi = int.Parse(node["Tuoi"].InnerText);
                DateTime ngayDk = new DateTime();/*= DateTime.Parse(node["NgayDangKi"]?.InnerText);*/
                string ngayDangKiStr = node.SelectSingleNode("NgayDangKi")?.InnerText;

                ngayDk = DateTime.ParseExact(ngayDangKiStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                string madg = node["Ma"].InnerText;

                string diachi = node["DiaChi"].InnerText;
                string soCmt = node["SoCMT"].InnerText;

                
                if (loai == dgs[2])
                {



                    string cv = node["CongViec"].InnerText;


                    dg = new NguoiLon(gioitinh, ten, tuoi, madg, diachi, ngayDk, soCmt, cv);
                    XmlNodeList sachNodes = node.SelectNodes("DanhSachSachMuon/Sach");

                    if (sachNodes != null)
                    {
                        foreach (XmlNode sn in sachNodes)
                        {
                            string Sach = sn["TenSach"].InnerText;
                            dg.themsachMuon(Sach);
                        }
                        ListDG.Add(dg);

                    }



                }







                else if (loai == dgs[0])
                {
                    string tt = node["TenTruong"].InnerText;
                    string tl = node["TenLop"].InnerText;


                    dg = new SinhVien(gioitinh, ten, tuoi, madg, diachi, ngayDk, soCmt, tt, tl);

                    XmlNodeList sachNodes = node.SelectNodes("DanhSachSachMuon/Sach");

                    if (sachNodes != null)
                    {
                        foreach (XmlNode sn in sachNodes)
                        {
                            string Sach = sn["TenSach"].InnerText;
                            dg.themsachMuon(Sach);
                        }

                        ListDG.Add(dg);
                    }
                }

                else if (loai == "Thiếu nhi")
                {
                    string ngh = node["NguoiGiamHo"].InnerText;


                    dg = new ThieuNhi(gioitinh, ten, tuoi, madg, diachi, ngayDk, soCmt, ngh);


                    XmlNodeList sachNodes = node.SelectNodes("DanhSachSachMuon/Sach");

                    if (sachNodes != null)
                    {
                        foreach (XmlNode sn in sachNodes)
                        {
                            string Sach = sn["TenSach"].InnerText;
                            dg.themsachMuon(Sach);
                        }

                        ListDG.Add(dg);
                    }

                }
                

            }
            



        

                
        }



        public void WriteVaoFileXML(string file)
        {
            XmlDocument doc = new XmlDocument();

            if (System.IO.File.Exists(file))
            {
                Console.WriteLine("--------------------- THÔNG BÁO ---------------------  ");
                Console.WriteLine( "Không thể ghi vào file vì đã tồn tại đối tượng trước đó");
                doc.Load(file);
                ReadTuFileXML(file);
            }
            else
            {
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

                XmlElement danhSachDoiTuongElement = doc.CreateElement("DanhSachDocGia");
                doc.AppendChild(danhSachDoiTuongElement);






                //Console.WriteLine("Nhập đối tượng cần quản lí:");
                //Console.WriteLine("1 - Độc giả || 2 - Thủ Thư:");




                Console.WriteLine("Cho biết Đối tượng độc giả cần quản lí:");
                int options;

                Console.WriteLine("0 - Sinh viên   || 1 - Thiếu nhi || 2 - Người lớn");

                options = int.Parse(Console.ReadLine());
                while (options < 0 || options > 2)
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại:");
                    int.TryParse(Console.ReadLine(), out options);
                }
                Console.WriteLine($"Nhập phần tử cần thêm cho đối tượng {dgs[options]}");

                int n;
                n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    XmlElement doiTuongElement = doc.CreateElement("DocGia");
                    danhSachDoiTuongElement.AppendChild(doiTuongElement);



                    XmlElement gioiTinhElement = doc.CreateElement("GioiTinh");
                    Console.WriteLine("Nhập giới tính độc giả (Nam/Nữ):");

                    string gioitinh = Console.ReadLine();
                    gioiTinhElement.InnerText = gioitinh;
                    doiTuongElement.AppendChild(gioiTinhElement);

                    XmlElement tenElement = doc.CreateElement("HoTen");
                    Console.WriteLine("Nhập họ tên độc giả:");

                    string ht = Console.ReadLine();
                    tenElement.InnerText = ht;
                    doiTuongElement.AppendChild(tenElement);

                    XmlElement tuoiElement = doc.CreateElement("Tuoi");
                    Console.WriteLine("Nhập tuổi độc giả:");

                    int tuoi = int.Parse(Console.ReadLine());
                    tuoiElement.InnerText = tuoi.ToString();
                    doiTuongElement.AppendChild(tuoiElement);

                    XmlElement maElement = doc.CreateElement("Ma");
                    Console.WriteLine("Nhập mã độc giả (Vui lòng nhập đủ 6 kí tự):");

                    string ma = Console.ReadLine();
                    maElement.InnerText = ma;
                    doiTuongElement.AppendChild(maElement);

                    XmlElement diaChiElement = doc.CreateElement("DiaChi");
                    Console.WriteLine("Nhập địa chỉ độc giả:");

                    string diachi = Console.ReadLine();
                    diaChiElement.InnerText = diachi;
                    doiTuongElement.AppendChild(diaChiElement);


                    XmlElement ngayDangKiElement = doc.CreateElement("NgayDangKi");
                    Console.Write("Nhập ngày đăng kí theo định dạng (yyyy-MM-dd): ");
                    DateTime NgayDk = new DateTime();
                    string ngayDkStr = Console.ReadLine();

                    NgayDk = DateTime.ParseExact(ngayDkStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    ngayDangKiElement.InnerText = NgayDk.ToString("yyyy-MM-dd");
                    doiTuongElement.AppendChild(ngayDangKiElement);

                    XmlElement soCmtElement = doc.CreateElement("SoCMT");
                    Console.WriteLine("Nhập số CMT độc giả:");

                    string cmt = Console.ReadLine();
                    soCmtElement.InnerText = cmt;
                    doiTuongElement.AppendChild(soCmtElement);

                    XmlElement danhSachSachMuonElement = doc.CreateElement("DanhSachSachMuon");
                    doiTuongElement.AppendChild(danhSachSachMuonElement);








                    int m;
                    Console.Write("Nhập phần tử sách đã đọc cần thêm: ");
                    m = int.Parse(Console.ReadLine());
                    for (int j = 0; j < m; j++)
                    {
                        XmlElement tenSachElement = doc.CreateElement("TenSach");
                        Console.WriteLine("Nhập tên sách đã đọc");
                        XmlElement sachElement = doc.CreateElement("Sach");
                        danhSachSachMuonElement.AppendChild(sachElement);

                        string TenSach = Console.ReadLine();
                        tenSachElement.InnerText = TenSach;
                        sachElement.AppendChild(tenSachElement);
                    }



                    if (options == 0)
                    {
                        XmlElement loaiElement = doc.CreateElement("Loai");

                        loaiElement.InnerText = "Sinh viên";
                        doiTuongElement.AppendChild(loaiElement);

                        XmlElement truongElement = doc.CreateElement("TenTruong");
                        Console.WriteLine("Nhập tên trường");
                        string tentruong = Console.ReadLine();
                        truongElement.InnerText = tentruong;
                        doiTuongElement.AppendChild(truongElement);


                        XmlElement lopElement = doc.CreateElement("TenLop");
                        Console.WriteLine("Nhập tên lớp");
                        string tenlop = Console.ReadLine();
                        lopElement.InnerText = tenlop;
                        doiTuongElement.AppendChild(lopElement);


                    }

                    else if (options == 2)
                    {

                        XmlElement loaiElement = doc.CreateElement("Loai");

                        loaiElement.InnerText = "Người lớn";
                        doiTuongElement.AppendChild(loaiElement);
                        XmlElement cvElement = doc.CreateElement("CongViec");

                        Console.WriteLine("Nhập tên công việc");
                        string cv = Console.ReadLine();
                        cvElement.InnerText = cv;
                        doiTuongElement.AppendChild(cvElement);




                    }

                    else if (options == 1)
                    {
                        XmlElement loaiElement = doc.CreateElement("Loai");

                        loaiElement.InnerText = "Thiếu nhi";
                        doiTuongElement.AppendChild(loaiElement);
                        XmlElement nghElement = doc.CreateElement("NguoiGiamHo");

                        Console.WriteLine("Nhập tên người giám hộ");
                        string ngh = Console.ReadLine();
                        nghElement.InnerText = ngh;
                        doiTuongElement.AppendChild(nghElement);
                    }

                    Console.WriteLine("Lưu danh sách độc giả thành công");

                }



                doc.Save(file);
                ReadTuFileXML(file);

            }
        }

    }

}


