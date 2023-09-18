using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfKutyak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<KutyaNevek> kutyaNevek = new List<KutyaNevek>();
        static List<KutyaFajtak> kutyaFajtak = new List<KutyaFajtak>();
        static List<Kutya> kutyak = new List<Kutya>();

        public MainWindow()
        {
            InitializeComponent();

            kutyaNevek = File.ReadAllLines("Adatok\\KutyaNevek.csv").Skip(1).Select(x => new KutyaNevek(x)).ToList();
            kutyaFajtak = File.ReadAllLines("Adatok\\KutyaFajtak.csv").Skip(1).Select(x => new KutyaFajtak(x)).ToList();
            kutyak = File.ReadAllLines("Adatok\\Kutyak.csv").Skip(1).Select(x => new Kutya(x)).ToList();
        }

        private void btnFeladat3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"3. feladat: Kutyanevek száma: {kutyaNevek.Count}");
        }

        private void btnFeladat6_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"6. feladat: Kutyák átlag életkora: {Math.Round(kutyak.Average(x => x.Kor), 2)}");
        }

        private void btnFeladat7_Click(object sender, RoutedEventArgs e)
        {
            Kutya legidosebb = kutyak.OrderByDescending(x => x.Kor).ToList()[0];
            string legidosebbNev = "";
            string legidosebbFaj = "";

            foreach (var item in kutyaNevek)
            {
                if (item.ID == legidosebb.NevID)
                {
                    legidosebbNev = item.Nev;
                }
            }
            foreach (var item in kutyaFajtak)
            {
                if (item.ID == legidosebb.FajID)
                {
                    legidosebbFaj = item.Nev;
                }
            }

            MessageBox.Show($"7. feladat: Legidősebb kutya neve és fajtája: {legidosebbNev}, {legidosebbFaj}");
        }

        private void btnFeladat8_Click(object sender, RoutedEventArgs e)
        {
            string vizsgaltKutyakStr = "";
            List<Kutya> vizsgaltKutyak = kutyak.Where(x => x.UtolsoOrvos == "2018.01.10").ToList();

            foreach (Kutya kutya in vizsgaltKutyak)
            {
                foreach (KutyaFajtak kutyaFajta in kutyaFajtak)
                {
                    if (kutyaFajta.ID == kutya.FajID)
                    {
                        vizsgaltKutyakStr += $"{kutyaFajta.Nev}: 1 kutya\n"; // nem tudom hogy kell hogy hány kutya van
                        break;
                    }
                }
            }

            MessageBox.Show($"8. feladat: Január 10.-én vizsgált kutya fajták:\n{vizsgaltKutyakStr}");
        }

        private void btnFeladat9_Click(object sender, RoutedEventArgs e)
        {
            var legterheltebbNap = kutyak.OrderByDescending(x => x.UtolsoOrvos).ToList()[0];
            MessageBox.Show($"9. feladat: Legjobban leterhelt nap: {legterheltebbNap}");
        }

        private void btnFeladat10_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, int> kutyaNevekDict = new Dictionary<string, int>();

            foreach (Kutya kutya in kutyak)
            {
                string nev = kutyaNevek.Where(x => x.ID == kutya.NevID).ToList()[0].Nev;

                if (kutyaNevekDict.ContainsKey(nev))
                {
                    kutyaNevekDict[nev] ++;
                }
                else
                {
                    kutyaNevekDict.Add(nev, 1);
                }
            }
        }
    }
}
