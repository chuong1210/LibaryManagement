using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
 abstract  public class DoiTuong
    {
        string ten;
        int tuoi;
        string gioiTinh;

        public string Ten { get => ten; set => ten = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }

        public DoiTuong(string gt,string name,int age)
        {
            if (gt.ToLower() == "nam" || gt.ToLower() == "nữ")
                GioiTinh = gt;
            else
                gt = "Nam";


            this.tuoi = age;
            this.ten = name;   
        }

        public DoiTuong()
        {
            

        }
        public virtual void XuatThongTin()
        {
            Console.WriteLine("Họ tên: {0}", Ten);
            Console.WriteLine("Tuổi: {0}" ,Tuoi);
            Console.WriteLine("Giới tính: {0}", GioiTinh);
        }
        public    static bool ContainsNumber(string input)
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
    }



}
