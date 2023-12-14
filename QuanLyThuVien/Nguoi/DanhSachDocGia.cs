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
            foreach (var item in ListDG)
            {
                item.XuatThongTin();
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

                    Console.WriteLine("Ten truong"+tt);

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
        

        //public void WriteVaoFileXML(string file)
        //{
        //    XmlDocument doc = new XmlDocument();

        //    XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        //    XmlElement root = doc.DocumentElement;
        //    doc.InsertBefore(xmlDeclaration, root);

        //    XmlElement danhSachDoiTuongElement = doc.CreateElement("DanhSachDoiTuong");
        //    doc.AppendChild(danhSachDoiTuongElement);

        //    foreach (DocGia dg in ListDT)
        //    {

        //        XmlElement doiTuongElement = doc.CreateElement("DoiTuong");
        //        danhSachDoiTuongElement.AppendChild(doiTuongElement);

        //        XmlElement loaiElement = doc.CreateElement("Loai");

        //        Console.WriteLine("Nhập đối tượng cần quản lí:");
        //        Console.WriteLine("1 - Độc giả || 2 - Thủ Thư:");

        //        int option;
        //        option = int.Parse(Console.ReadLine());


        //        if (option == 1)
        //        {
        //            loaiElement.InnerText = "Độc giả";
        //            doiTuongElement.AppendChild(loaiElement);

        //            XmlElement gioiTinhElement = doc.CreateElement("GioiTinh");
        //            gioiTinhElement.InnerText = dg.GioiTinh;
        //            doiTuongElement.AppendChild(gioiTinhElement);

        //            XmlElement tenElement = doc.CreateElement("HoTen");
        //            tenElement.InnerText = dg.Ten;
        //            doiTuongElement.AppendChild(tenElement);

        //            XmlElement tuoiElement = doc.CreateElement("Tuoi");
        //            tuoiElement.InnerText = dg.Tuoi.ToString();
        //            doiTuongElement.AppendChild(tuoiElement);

        //            XmlElement maElement = doc.CreateElement("Ma");
        //            maElement.InnerText = dg.MaDg1;
        //            Console.WriteLine(dg.MaDg1);
        //            doiTuongElement.AppendChild(maElement);

        //            XmlElement diaChiElement = doc.CreateElement("DiaChi");
        //            diaChiElement.InnerText = dg.DiaChi;
        //            doiTuongElement.AppendChild(diaChiElement);

        //            XmlElement ngayDangKiElement = doc.CreateElement("NgayDangKi");
        //            ngayDangKiElement.InnerText = dg.NgayDangki.ToString("yyyy/MM/dd");
        //            doiTuongElement.AppendChild(ngayDangKiElement);

        //            XmlElement soCmtElement = doc.CreateElement("SoCMT");
        //            soCmtElement.InnerText = dg.SoCmt;
        //            doiTuongElement.AppendChild(soCmtElement);

        //            XmlElement danhSachSachMuonElement = doc.CreateElement("DanhSachSachMuon");
        //            doiTuongElement.AppendChild(danhSachSachMuonElement);

        //            foreach (Sach sach in dg.DanhSachSachMuon)
        //            {
        //                XmlElement sachElement = doc.CreateElement("Sach");
        //                danhSachSachMuonElement.AppendChild(sachElement);

        //                XmlElement maSachElement = doc.CreateElement("MaSach");
        //                maSachElement.InnerText = sach.MaSach;
        //                sachElement.AppendChild(maSachElement);

        //                XmlElement tenSachElement = doc.CreateElement("TenSach");
        //                tenSachElement.InnerText = sach.TenSach;
        //                Console.WriteLine( sach.TenSach);
        //                sachElement.AppendChild(tenSachElement);

        //                XmlElement namSanXuatElement = doc.CreateElement("NamSanXuat");
        //                namSanXuatElement.InnerText = sach.NamSanXuat.ToString();
        //                sachElement.AppendChild(namSanXuatElement);

        //                XmlElement tacGiaElement = doc.CreateElement("TacGia");
        //                tacGiaElement.InnerText = sach.TacGia;
        //                sachElement.AppendChild(tacGiaElement);

        //                XmlElement theLoaiElement = doc.CreateElement("TheLoai");
        //                theLoaiElement.InnerText = sach.TheLoai;
        //                sachElement.AppendChild(theLoaiElement);

        //                XmlElement soLuongElement = doc.CreateElement("SoLuong");
        //                soLuongElement.InnerText = sach.SoLuong.ToString();
        //                sachElement.AppendChild(soLuongElement);
        //            }
        //        }
        //    }

        //    doc.Save(file);
        //}

        public void WriteVaoFileXML(string file)
        {
            XmlDocument doc = new XmlDocument();

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

            int n ;
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
                {
                XmlElement doiTuongElement = doc.CreateElement("DocGia");
                danhSachDoiTuongElement.AppendChild(doiTuongElement);



                XmlElement gioiTinhElement = doc.CreateElement("GioiTinh");
                    Console.WriteLine("Nhập giới tính độc giả (Nam/Nữ):");

                     string  gioitinh=   Console.ReadLine();
                    gioiTinhElement.InnerText = gioitinh;
                    doiTuongElement.AppendChild(gioiTinhElement);

                    XmlElement tenElement = doc.CreateElement("HoTen");
                    Console.WriteLine("Nhập họ tên độc giả:");

                    string ht = Console.ReadLine();
                    tenElement.InnerText = ht;
                    doiTuongElement.AppendChild(tenElement);

                    XmlElement tuoiElement = doc.CreateElement("Tuoi");
                    Console.WriteLine("Nhập tuổi độc giả:");

                    int tuoi =int.Parse ( Console.ReadLine());
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






                        
                        XmlElement sachElement = doc.CreateElement("Sach");
                        danhSachSachMuonElement.AppendChild(sachElement);


             XmlElement tenSachElement = doc.CreateElement("TenSach");
                Console.WriteLine("Nhập tên sách đã đọc");
                string TenSach = Console.ReadLine();
                    tenSachElement.InnerText = TenSach;
                       sachElement.AppendChild(tenSachElement);

                if (options == 0)
                {
                   XmlElement loaiElement = doc.CreateElement("Loai");
                    
                    loaiElement.InnerText = "Sinh viên";
                    doiTuongElement.AppendChild(loaiElement);

                    XmlElement truongElement = doc.CreateElement("TenTruong");
                    Console.WriteLine("Nhập tên trường");
                    string tentruong=Console.ReadLine();
                    truongElement.InnerText=tentruong;
                    doiTuongElement.AppendChild(truongElement);


                    XmlElement lopElement = doc.CreateElement("TenLop");
                    Console.WriteLine("Nhập tên lớp");
                    string tenlop = Console.ReadLine();
                    lopElement.InnerText = tenlop;
                    doiTuongElement.AppendChild(lopElement);


                }

              else  if (options == 2)
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

            else    if (options == 1)
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


                }



            doc.Save(file);
            ReadTuFileXML(file);

        }

    }

}


