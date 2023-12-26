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

        static void Menu(string fileDsDocGia, string fileDSSach, string fileDSPhieu,
                            DanhSachDocGia danhSachDocGia, DanhSachSach danhSachSach, DanhSachPhieu danhSachPhieu)
        {
            int mainChoice;
            do
            {
                Console.WriteLine("*************************************** QUẢN LÍ THƯ VIỆN ***************************************\n");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("|                 Menu chính:                  |");
                Console.WriteLine("|          1.Quản lý danh sách độc giả         |");
                Console.WriteLine("|          2.Quản lý danh sách sách            |");
                Console.WriteLine("|          3.Quản lý danh sách phiếu           |");
                Console.WriteLine("|          0.Thoát                             |");
                Console.WriteLine("------------------------------------------------");


                Console.Write("Chọn một tác vụ (0-3): ");
                while (!int.TryParse(Console.ReadLine(), out mainChoice))
                {
                    Console.WriteLine("Vui lòng nhập số nguyên.");
                    Console.Write("Chọn một tác vụ (0-3): ");
                }
                switch (mainChoice)
            {
                case 1:
                    ManageDocGiaMenu(fileDsDocGia, danhSachDocGia);

                        
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
            } while (mainChoice!=0);
        }



        static void ManageDocGiaMenu(string fileDsDocGia, DanhSachDocGia danhSachDocGia)
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
                Console.WriteLine("7. Sắp xép theo tên độc giả và lưu lại xuống file");
                Console.WriteLine("8. Sắp xép theo Nhóm và tên độc giả theo List");
                Console.WriteLine("9. Cập nhật địa chỉ mới của độc giả");
                Console.WriteLine("10. Xóa thông tin độc giả ");
                Console.WriteLine("11. Xóa thông tin độc giả từ file XML ");
                Console.WriteLine("12. Xóa tất cả độc gỉả hết hạn sử dụng thẻ ");




                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn một tác vụ (0-12): ");
                docGiaChoice = int.Parse(Console.ReadLine());


                switch (docGiaChoice)
                {

                    case 1:
                        Console.WriteLine("\nDanh sách độc giả:");
                        danhSachDocGia.XuatList();
                        danhSachDocGia.CapNhatThongTinDocGia("../../Phieu/DanhSachPhieu.xml", "../../Sach/DanhSachSach.xml");
                        break;

                    case 2:
                        danhSachDocGia.WriteVaoFileXML(fileDsDocGia);
                        break;

                    case 3:
                        double tb = danhSachDocGia.TinhTuoiTrungBinh();
                        Console.WriteLine("Tuổi trung bình: {0:0.00}", tb);
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
                    case 7:
                        danhSachDocGia.SapXepVaLuuTheoTen(fileDsDocGia);
                        break;

                    case 8:
                        danhSachDocGia.SapXepDGTheoNhomVaTen();
                        break;
                    case 9:

                        Console.Write("Nhập mã độc giả của địa chỉ cần sửa: ");

                        string mdg = Console.ReadLine();
                        Console.Write("Nhập địa chỉ mới: ");
                        string dc = Console.ReadLine();

                       
                        danhSachDocGia.UpdateDiachiDocGiaTheoMa(mdg,dc);
                        break;
                    case 10:
                        Console.WriteLine("Nhập mã độc giả cần xóa ");
                        string mDG = Console.ReadLine();
                        danhSachDocGia.XoaThongTinDocGiaDautien(mDG);
                        break;
                    case 11:
                        Console.WriteLine("Nhập mã độc giả cần xóa ");
                        string maDG = Console.ReadLine();
                        danhSachDocGia.XoaThongTinDocGiatufileXml(maDG);
                        break;
                    case 12:
                        Console.WriteLine("Đã Xóa tất cả độc gỉả đã hết hạn sử dụng thẻ  ");
                        danhSachDocGia.XoaAllThongTinDocGiaCoTheHetHan();
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
            Console.WriteLine("7. Tìm sách có thể loại trinh thám và có chất lượng tốt");
            Console.WriteLine("8. Thêm sách vô List");
            Console.WriteLine("9. Cập nhật tên mới của sách theo Mã sách");
             Console.WriteLine("10. Sắp sếp theo tên sách");
                Console.WriteLine("11. Xóa thông tin sách đầu tiên ra khỏi file Xml");





                Console.WriteLine("0. Quay lại");

            Console.Write("Chọn một tác vụ (0-11): ");
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
                    case 8:
                        Console.WriteLine("Nhập phần tử cần thêm");
                      int  n = int.Parse(Console.ReadLine());
                        danhSachSach.ThemSach(n);
                        break;
                    case 9:
                        Console.Write("Nhập mã của sách cần sửa: ");

                        string ma = Console.ReadLine();
                        Console.Write("Nhập tên sách mới: ");
                        string names = Console.ReadLine();

                     
                        danhSachSach.CapNhatTenSach(ma, names);
                        break;
                    case 10:
                        danhSachSach.SapXepVaLuuTheoTen(fileDSSach);
                       
                        break;
                    case 11:
                        Console.Write("Nhập mã sách cần xóa ra khỏi file xml: ");
                        string mscx = Console.ReadLine();
                        danhSachSach.XoaThongTinSachrakhoifileXml(mscx);
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
            Console.WriteLine("4. Xóa tất cả phiếu trong danh sách");
            Console.WriteLine("5. Thêm phiếu vào danh sách");


                Console.WriteLine("0. Quay lại");

            Console.Write("Chọn một tác vụ (0-5): ");
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
             case 4:
                danhSachPhieu.xoaTatCaPhieu();
               Console.WriteLine("Đã xóa tất cả các phiếu trong danh sách");
                break;
              case 5:
                 Console.WriteLine(  "Nhập số lượng phiếu muốn thêm");
                 int n = int.Parse(Console.ReadLine());
                 danhSachPhieu.ThemPhieu(n);
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
            string fileDsDocGia = "../../Nguoi/DanhSachDocGia.xml";
            string fileDSSach = "../../Sach/DanhSachSach.xml";
            string fileDSPhieu = "../../Phieu/DanhSachPhieu.xml";

            DanhSachDocGia danhSachDocGia = new DanhSachDocGia();
            danhSachDocGia.ReadTuFileXML(fileDsDocGia);


            DanhSachSach danhSachSach = new DanhSachSach();
            danhSachSach.ReadTuFileXML(fileDSSach);

            DanhSachPhieu danhSachPhieu = new DanhSachPhieu();
            danhSachPhieu.ReadTuFileXML(fileDSPhieu);





            Menu(fileDsDocGia, fileDSSach, fileDSPhieu, danhSachDocGia, danhSachSach, danhSachPhieu);

            //ThuThu tt = new ThuThu();
            //tt.ReadTuFileXML("../../ThuThu/sasasa.xml");
            //tt.XuatThongTin();
            //tt.WriteVaoFileXML("../../ThuThu/sasasa.xml");



        }
    }
}
