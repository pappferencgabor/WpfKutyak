using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKutyak
{
    internal class Kutya
    {
        public int ID { get; set; }
        public int FajID { get; set; }
        public int NevID { get; set; }
        public int Kor { get; set; }
        public string UtolsoOrvos { get; set; }

        public Kutya(string sor)
        {
            ID = int.Parse(sor.Split(";")[0]);
            FajID = int.Parse(sor.Split(";")[1]);
            NevID = int.Parse(sor.Split(";")[2]);
            Kor = int.Parse(sor.Split(";")[3]);
            UtolsoOrvos = sor.Split(";")[4];
        }
    }

    internal class KutyaNevek
    {
        public int ID { get; set; }
        public string Nev { get; set; }

        public KutyaNevek(string sor)
        {
            ID = int.Parse(sor.Split(";")[0]);
            Nev = sor.Split(";")[1];
        }
    }

    internal class KutyaFajtak
    {
        public int ID { get; set; }
        public string Nev { get; set; }
        public string EredetiNev { get; set; }

        public KutyaFajtak(string sor)
        {
            ID = int.Parse(sor.Split(";")[0]);
            Nev = sor.Split(";")[1];
            EredetiNev = sor.Split(";")[2];
        }
    }
}
