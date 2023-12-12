using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
    public class ThuThu : DoiTuong
    {
        string maThuThu;
        string maSach;
        string maPhieuMuon;
        string maPhieuTra;
        string maDocGia;
        public List<IPhieu> DanhSachPhieu;
        public List<DocGia> DanhSachDocGia;

        public ThuThu(string gt, string name, int age) : base(gt, name, age)
        {
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






    }
}
