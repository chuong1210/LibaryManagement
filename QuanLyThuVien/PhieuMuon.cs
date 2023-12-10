using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
    public class PhieuMuon : DoiTuong, IPhieu
    {
        int maSach;
        int maDocGia;
        DateTime ngayMuon;
        DateTime ngayTra;
        int soLuongSach;

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

        public DateTime NgayMuon
        {
            get
            {
                return ngayMuon;
            }

            set
            {
                ngayMuon = value;
            }
        }

        public DateTime NgayTra
        {
            get
            {
                return ngayTra;
            }

            set
            {
                ngayTra = value;
            }
        }

        public int SoLuongSach
        {
            get
            {
                return soLuongSach;
            }

            set
            {
                soLuongSach = value;
            }
        }
    }
}
