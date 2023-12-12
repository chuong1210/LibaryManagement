using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVien;

namespace QuanLyThuVien
{
   public abstract class DocGia:DoiTuong
    {
        string maDg;
        string diaChi;

           
       
      
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



        public string MaDg1
        {
            get
            {
                if (maDg.Length <= 6)
                {
                    string DG = maDg.Substring(0, 2);
                    string so = maDg.Substring(2);

                    if (DG == "DG" && DoiTuong.ContainsNumber(so))
                    {
                        return maDg;
                    }
                    else
                    {
                        maDg = "DGI001";
                    }
                }
                else
                {
                    maDg = "DGI001";
                }

                return maDg;
            }
        }

        public abstract double PhiMuonSach();


    }
}
