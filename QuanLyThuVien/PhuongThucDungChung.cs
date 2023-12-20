using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
    internal class PhuongThucDungChung
    {

        public bool checkmaS(string MaSach)
        {
            if (MaSach.Length == 6)
            {
                string S = MaSach.Substring(0, 1);
                string so = MaSach.Substring(1, 4);

                if (S.Equals("S") && !ContainsNumber(so))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public bool checkmaDg(string MaDocGia)
        {
            if (MaDocGia.Length == 6)

            {
                string DG = MaDocGia.Substring(0, 2);
                string so = MaDocGia.Substring(2, 4);

                if (DG.Equals("DG") && !ContainsNumber(so))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }

        public static bool ContainsNumber(string input)
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
