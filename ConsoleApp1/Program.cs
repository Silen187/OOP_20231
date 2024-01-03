using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BTT12_TranDucAnh20216797
{
    class Nhatuyendung
    {
        private string Ma_cv;
        private string ten;

        public Nhatuyendung(string ma_cv, string _ten)
        {
            Ma_cv = ma_cv;
            ten = _ten;
        }
        public void ungTuyen(Ungvien _ungvien)
        {
            _ungvien.SukienGuiTin += new Ungvien.GuiCV(_ungvien_SukienGuiCV);
        }

        void _ungvien_SukienGuiCV(Ungvien _nguoigui, string s)
        {
            if (s == Ma_cv)
            {
                Console.WriteLine("Chuc mung {0} trung tuyen voi ma cv {1} tai {2}", _nguoigui.Ten, s, ten);
            }
            else
            {
                Console.WriteLine("Rat tiec {0} truot ung tuyen voi ma cv {1} tai {2}!", _nguoigui.Ten, s, ten);
            }
        }

    }
    class Ungvien

    {
        public Ungvien()
        {

        }
        public Ungvien(string i_Ten)
        {

            _Ten = i_Ten;

        }
        private string _Ten;

        public string Ten
        {
            set
            {
                _Ten = value;
            }
            get
            {
                return _Ten;
            }
        }
        public delegate void GuiCV(Ungvien _nguoigui, string s);
        public event GuiCV SukienGuiTin;
        public void GuiTinNhan(string _tinnhan)
        {
            if (SukienGuiTin != null)
            {
                SukienGuiTin(this, _tinnhan);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Nhatuyendung _nhatuyendung1 = new Nhatuyendung("0000", "cong ty 1");
            Nhatuyendung _nhatuyendung2 = new Nhatuyendung("0001", "cong ty 2");
            Ungvien _nguoigui1 = new Ungvien("A");
            Ungvien _nguoigui2 = new Ungvien("B");
            _nhatuyendung1.ungTuyen(_nguoigui1);
            _nhatuyendung1.ungTuyen(_nguoigui2);
            _nhatuyendung2.ungTuyen(_nguoigui1);
            _nhatuyendung2.ungTuyen(_nguoigui2);
            _nguoigui1.GuiTinNhan("0000");
            _nguoigui1.GuiTinNhan("0001");
            _nguoigui2.GuiTinNhan("0000");
            _nguoigui2.GuiTinNhan("0001");
            Console.ReadLine();
        }
    }
}

