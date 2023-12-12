using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
   public class DoiTuong
    {
        string ten;
        int tuoi;
        string gioiTinh;

        public string Ten { get => ten; set => ten = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }

    public    static bool ContainsNumber(string input)
        {
            foreach (char character in input)
            {
                if (char.IsDigit(character))
                {
                    return false; 
                }
            }
            return true; 
        }
    }



}
