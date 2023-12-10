using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
   public class DocGia:DoiTuong
    {
        string ma;
        string tenDocGia;
        int tuoi;
        string gioiTinh;
        string diaChi;

        public string TenDocGia
        {
            get
            {
                return tenDocGia;
            }

            set
            {
                tenDocGia = value;
            }
        }

        public int Tuoi
        {
            get
            {
                return tuoi;
            }

            set
            {
                tuoi = value;
            }
        }

        public string GioiTinh
        {
            get
            {
                return gioiTinh;
            }

            set
            {
                gioiTinh = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }

        public string Ma1
        {
            get
            {
                return ma;
            }

            set
            {
                ma = value;
            }
        }
    }
}
