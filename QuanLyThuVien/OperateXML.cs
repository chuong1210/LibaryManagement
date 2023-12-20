using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
    internal interface OperateXML
    {

        void ReadTuFileXML(string tenfile);
        void WriteVaoFileXML(string file);
         bool checkMa(string ma);

    }
}
