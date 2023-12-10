using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
    public class ThuThu : DoiTuong
    {
        string tenThuThu;
        int tuoi;
        string gioiTinh;
        int maSach;
        int maPhieuMuon;
        int maPhieuTra;
        int maDocGia;

        public string TenThuThu
        {
            get
            {
                return tenThuThu;
            }

            set
            {
                tenThuThu = value;
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

        public int MaSach
        {
            get
            {
                return maSach;
            }

            set
            {
                maSach = value;
            }
        }

        public int MaPhieuMuon
        {
            get
            {
                return maPhieuMuon;
            }

            set
            {
                maPhieuMuon = value;
            }
        }

        public int MaPhieuTra
        {
            get
            {
                return maPhieuTra;
            }

            set
            {
                maPhieuTra = value;
            }
        }

        public int MaDocGia
        {
            get
            {
                return maDocGia;
            }

            set
            {
                maDocGia = value;
            }
        }
    }
}
