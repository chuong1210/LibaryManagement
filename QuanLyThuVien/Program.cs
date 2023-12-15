using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVien.Nguoi;
using QuanLyThuVien.Phieu;

namespace QuanLyThuVien
{
    class Program
    {
        static void Menu(string fileDSDocGia, string fileDSSach, string fileDSPhieu,
                            DanhSachDocGia danhSachDocGia, DanhSachSach danhSachSach, DanhSachPhieu danhSachPhieu)
        {
            int mainChoice;
            do
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("\nMenu chính:");
                Console.WriteLine("1. Quản lý danh sách độc giả");
                Console.WriteLine("2. Quản lý danh sách sách");
                Console.WriteLine("3. Quản lý danh sách phiếu");
                Console.WriteLine("0. Thoát");

                Console.Write("Chọn một tác vụ (0-3): ");
            } while (!int.TryParse(Console.ReadLine(), out mainChoice));

            switch (mainChoice)
            {
                case 1:
                    ManageDocGiaMenu(fileDSDocGia, danhSachDocGia);
                    break;

                case 2:
                    ManageSachMenu(fileDSSach, danhSachSach);
                    break;

                case 3:
                    ManagePhieuMenu(fileDSPhieu, danhSachPhieu);
                    break;
                    case 0:
                    Console.WriteLine("Thoát chương trình.");
                    break;

                default:
                    Console.WriteLine("Chọn không hợp lệ. Vui lòng chọn lại.");
                    break;
            }
        }



        static void ManageDocGiaMenu(string fileDSDocGia, DanhSachDocGia danhSachDocGia)
        {
            int docGiaChoice;

           
            do
            {
                Console.WriteLine("\nQuản lý danh sách độc giả:");
                Console.WriteLine("1. Xuất danh sách độc giả");
                Console.WriteLine("2. Lưu danh sách độc giả vào file");
                Console.WriteLine("3. Tính tuổi trung bình");
                Console.WriteLine("4. Tìm độc giả theo địa chỉ");
                Console.WriteLine("5. Tìm độc giả là người lớn và có nghề nghiệp là giáo viên");
                Console.WriteLine("6. Tìm độc giả chưa trả sách");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn một tác vụ (0-6): ");
                docGiaChoice = int.Parse(Console.ReadLine());


                switch (docGiaChoice)
                {

                    case 1:
                        Console.WriteLine("\nDanh sách độc giả:");
                        danhSachDocGia.XuatList();
                        break;

                    case 2:
                        danhSachDocGia.WriteVaoFileXML(fileDSDocGia);
                        break;

                    case 3:
                        double tb = danhSachDocGia.TinhTuoiTrungBinh();
                        Console.WriteLine("Tuổi trung bình: {0}", tb);
                        break;

                    case 4:
                        Console.Write("Nhập địa chỉ cần tìm: ");

                        string diaChi =  Console.ReadLine();
                        danhSachDocGia.TimDocGiaTheoDiaChi(diaChi);
                        break;
                    case 5:
                        danhSachDocGia.docgiaNguoilonGV();
                        break;
                    case 6:
                        danhSachDocGia.XuatDocGiaChuaTraSach();
                        break;

                    case 0:
                        Console.WriteLine("Quay lại menu chính.");
                        break;

                    default:
                        Console.WriteLine("Chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
            while (docGiaChoice != 0);
            
            
    } 
    static void ManageSachMenu(string fileDSSach, DanhSachSach danhSachSach)
    {
        int sachChoice;
        do
        {
            Console.WriteLine("\nQuản lý danh sách sách:");
            Console.WriteLine("1. Xuất danh sách sách");
            Console.WriteLine("2. Lưu danh sách sách vào File mới hoặc ghi đè file cũ");
            Console.WriteLine("3. Lưu danh sách sách vào File đã có sẵn thông tin");
            Console.WriteLine("4. Xóa tất cả thông tin sách");
            Console.WriteLine("5. Xóa thông tin sách đầu tiên");
            Console.WriteLine("6. Tổng số lượng sách");
            Console.WriteLine("7. Tìm sách có thể loại thiếu nhi và có chất lượng tốt");

            Console.WriteLine("0. Quay lại");

            Console.Write("Chọn một tác vụ (0-7): ");
                sachChoice=int.Parse( Console.ReadLine());
        switch (sachChoice)
        {
            case 1:
                Console.WriteLine("\nDanh sách sách:");
                danhSachSach.xuatSach();
                break;

            case 2:
                danhSachSach.WriteVaoFileXML(fileDSSach);
                Console.WriteLine("Lưu danh sách sách thành công.");
                break;
            case 3:
               danhSachSach.WriteVaoFileXMLkoOverride(fileDSSach);
                Console.WriteLine("Lưu danh sách sách thành công.");
                break;


                    case 4:
                Console.Write("Nhập mã sách cần xóa: ");
                string maSachCanXoa = Console.ReadLine();
                danhSachSach.XoaAllThongTinSach(maSachCanXoa);
                break;

              case 5:
                    Console.Write("Nhập mã sách cần xóa: ");
                   string ms = Console.ReadLine();
                  danhSachSach.XoaThongTinSachDautien(ms);
                    break;

            case 6:
                int tongSoLuong = danhSachSach.sumSach();
                Console.WriteLine("Tổng số lượng sách: {0}", tongSoLuong);
                break;
           case 7:
                danhSachSach.TimSachTrinhThamChatLuongTot();
                break;
            case 0:
                Console.WriteLine("Quay lại menu chính.");
                break;

            default:
                Console.WriteLine("Chọn không hợp lệ. Vui lòng chọn lại.");
                break;
        }
      } while (sachChoice!=0);

    }

    static void ManagePhieuMenu(string fileDSPhieu, DanhSachPhieu danhSachPhieu)
    {
        int phieuChoice;
        do
        {
            Console.WriteLine("\nQuản lý danh sách phiếu:");
            Console.WriteLine("1. Xuất danh sách phiếu");
            Console.WriteLine("2. Lưu danh sách phiếu vào file");
            Console.WriteLine("3. Xóa phiếu theo mã");
            Console.WriteLine("0. Quay lại");

            Console.Write("Chọn một tác vụ (0-3): ");
                phieuChoice = int.Parse(Console.ReadLine());


        switch (phieuChoice)
        {
            case 1:
                Console.WriteLine("\nDanh sách phiếu:");
                danhSachPhieu.XuatDanhSachPhieu();
                break;

            case 2:
                danhSachPhieu.WriteVaoFileXML(fileDSPhieu);
                Console.WriteLine("Lưu danh sách phiếu thành công.");
                break;

            case 3:
                Console.Write("Nhập mã phiếu cần xóa: ");
                string maPhieuCanXoa = Console.ReadLine();
                danhSachPhieu.XoaPhieuTheoMa(maPhieuCanXoa);
                break;

            case 0:
                Console.WriteLine("Quay lại menu chính.");
                break;

            default:
                Console.WriteLine("Chọn không hợp lệ. Vui lòng chọn lại.");
                break;
                }
            } while (phieuChoice!=0);

        }

        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string fileDSDocGia = "../../Nguoi/DanhSachDoiTuong.xml";
            string fileDSSach = "../../Sach/sachxml2.xml";
            string fileDSPhieu = "../../Phieu/DSP2.xml";

            DanhSachDocGia danhSachDocGia = new DanhSachDocGia();
            danhSachDocGia.ReadTuFileXML(fileDSDocGia);

            DanhSachSach danhSachSach = new DanhSachSach();
            danhSachSach.ReadTuFileXML(fileDSSach);

            DanhSachPhieu danhSachPhieu = new DanhSachPhieu();
            danhSachPhieu.ReadTuFileXML(fileDSPhieu);

            Menu(fileDSDocGia, fileDSSach, fileDSPhieu, danhSachDocGia, danhSachSach, danhSachPhieu);

           

        }
    }
}
