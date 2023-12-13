using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.Phong
{
    internal class Phong
    {
        string maPhong;
        string soTang;
        string tenKhu;
        string tenPhong;
        int slCho;

        public string MaPhong { get => maPhong; set => maPhong = value; }
        public string SoTang { get => soTang; set => soTang = value; }
        public string TenKhu { get => tenKhu; set => tenKhu = value; }
        public string TenPhong { get => tenPhong; set => tenPhong = value; }
        public int SlCho { get => slCho; set => slCho = value; }
    }
}
