﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien
{
    public class PhieuMuon: IPhieu
    {
        string  maPhieuMuon;

        public string MaPhieuMuon { get => maPhieuMuon; set => maPhieuMuon = value; }
    }
}
