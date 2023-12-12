using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
    public class PhieuMuon: IPhieu
    {
        int maPhieuMuon;

        public int MaPhieuMuon { get => maPhieuMuon; set => maPhieuMuon = value; }
    }
}
