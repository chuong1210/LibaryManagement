using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVien.Phieu;

namespace QuanLyThuVien
{
    public class ThuThu : DoiTuong
    {
        string maThuThu;
        string maSach;
        string maDocGia;
        public List<IPhieu> DanhSachPhieu;

        DanhSachPhieu dsp= new DanhSachPhieu();
        public ThuThu(string gt, string name, int age, string matt, string ms, string Mdg) : base(gt, name, age)
        {
            this.maThuThu = matt;
            this.maSach = ms;
            this.maDocGia = Mdg;
            DanhSachPhieu = new List<IPhieu>();





        }

        public void ThemPhieuQuanLi(IPhieu phieu )
        {
            if (DanhSachPhieu == null)
            {
                DanhSachPhieu = new List<IPhieu>();
            }

        
            DanhSachPhieu.Add(phieu);
        }

      


        public string MaThuThu
        {
            get
            {

            
            if (maThuThu.Length == 4)
            {
                string DG = maThuThu.Substring(0, 2);
                string so = maThuThu.Substring(2);

                if (DG == "DG" && DoiTuong.ContainsNumber(so))
                {
                    return maThuThu;
                }
                else
                {
                        maThuThu = "TTI1";
                }
            }
            else
            {
                    maThuThu = "TTI1";
            }

            return maThuThu;

            }

        }

        public string MaSach { get => maSach; set => maSach = value; }
       
        public string MaDocGia { get => maDocGia; set => maDocGia = value; }
    }
}
