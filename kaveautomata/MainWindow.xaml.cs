using System.Text;
using System.Text.Json;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kaveautomata
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ingredients alapanyagok;
        int ar_vanilia = 400;
        int ar_fekete = 250;
        int ar_cappuchino = 300;
        int ar_latte = 300;
        int ar_tejk = 400;
        int ar_jeges = 450;
        int ar_forrocs = 500;
        int ar_forrov = 50;
        int ar_cuk = 20;
        int menny_cuk = 0;
        int kávé = 0;
        // Mentés txt-be
        string utvonal = "alapanyagok.txt";

        public MainWindow()
        {
            InitializeComponent();
            LoadIngredients();
        }

        private void LoadIngredients()
        {
            alapanyagok = new Ingredients();
            if (File.Exists(utvonal))
            {
                var sorok = File.ReadAllLines(utvonal);
                foreach (var sor in sorok)
                {
                    var parts = sor.Split('=');
                    if (parts.Length == 2)
                    {
                        int value = int.TryParse(parts[1], out var v) ? v : 0;
                        switch (parts[0].Trim())
                        {
                            case "Vanilia": alapanyagok.Vanilia = value; break;
                            case "Fekete": alapanyagok.Fekete = value; break;
                            case "Cappuchino": alapanyagok.Cappuchino = value; break;
                            case "Latte": alapanyagok.Latte = value; break;
                            case "Tejeskave": alapanyagok.Tejeskave = value; break;
                            case "Jeges": alapanyagok.Jeges = value; break;
                            case "Forrocsoki": alapanyagok.Forrocsoki = value; break;
                            case "Forroviz": alapanyagok.Forroviz = value; break;
                            case "Cukor": alapanyagok.Cukor = value; break;
                        }
                    }
                }
            }
            else
            {
                alapanyagok = new Ingredients
                {
                    Vanilia = 10,
                    Fekete = 10,
                    Cappuchino = 10,
                    Latte = 10,
                    Tejeskave = 10,
                    Jeges = 10,
                    Forrocsoki = 10,
                    Forroviz = 10,
                    Cukor = 20
                };
                SaveIngredients();
            }
        }

        private void SaveIngredients()
        {
            var sorok = new[]
            {
                $"Vanilia={alapanyagok.Vanilia}",
                $"Fekete={alapanyagok.Fekete}",
                $"Cappuchino={alapanyagok.Cappuchino}",
                $"Latte={alapanyagok.Latte}",
                $"Tejeskave={alapanyagok.Tejeskave}",
                $"Jeges={alapanyagok.Jeges}",
                $"Forrocsoki={alapanyagok.Forrocsoki}",
                $"Forroviz={alapanyagok.Forroviz}",
                $"Cukor={alapanyagok.Cukor}"
            };
            File.WriteAllLines(utvonal, sorok);
        }

        private void Pluszcukor_Click(object sender, RoutedEventArgs e)
        {
            if (alapanyagok.Cukor > menny_cuk)
            {
                menny_cuk++;
            }
            else
            {
                MessageBox.Show("Nincs elég cukor!");
            }
        }

        private void Minuszcukor_Click(object sender, RoutedEventArgs e)
        {
            if (menny_cuk > 0)
            {
                menny_cuk--;
            }
        }

        private void rendelés_Click(object sender, RoutedEventArgs e)
        {
            bool siker = false;
            string uzenet = "";

            if (kávé == ar_vanilia && alapanyagok.Vanilia > 0) { alapanyagok.Vanilia--; siker = true; }
            else if (kávé == ar_fekete && alapanyagok.Fekete > 0) { alapanyagok.Fekete--; siker = true; }
            else if (kávé == ar_cappuchino && alapanyagok.Cappuchino > 0) { alapanyagok.Cappuchino--; siker = true; }
            else if (kávé == ar_latte && alapanyagok.Latte > 0) { alapanyagok.Latte--; siker = true; }
            else if (kávé == ar_tejk && alapanyagok.Tejeskave > 0) { alapanyagok.Tejeskave--; siker = true; }
            else if (kávé == ar_jeges && alapanyagok.Jeges > 0) { alapanyagok.Jeges--; siker = true; }
            else if (kávé == ar_forrocs && alapanyagok.Forrocsoki > 0) { alapanyagok.Forrocsoki--; siker = true; }
            else if (kávé == ar_forrov && alapanyagok.Forroviz > 0) { alapanyagok.Forroviz--; siker = true; }
            else
            {
                uzenet = "Nincs elég hozzávaló!";
            }

            if (siker)
            {
                if (alapanyagok.Cukor >= menny_cuk)
                {
                    alapanyagok.Cukor -= menny_cuk;
                    int osszeg = kávé + (menny_cuk * ar_cuk);
                    uzenet = osszeg.ToString() + "ft";
                }
                else
                {
                    uzenet = "Nincs elég cukor!";
                }
                SaveIngredients();
            }

            MessageBox.Show(uzenet);
            kávé = 0;
            menny_cuk = 0;
        }   

        private void vaniliakaverad_Checked(object sender, RoutedEventArgs e)
        {
            kávé = ar_vanilia;
        }

        private void cappucinorad_Checked(object sender, RoutedEventArgs e)
        {
            kávé = ar_cappuchino;
        }
        private void feketekaverad_Checked(object sender, RoutedEventArgs e)
        {
            kávé = ar_fekete;
        }
        private void tejeskaverad_Checked(object sender, RoutedEventArgs e)
        {
            kávé = ar_tejk;
        }
        private void latterad_Checked(object sender, RoutedEventArgs e)
        {
            kávé = ar_latte;
        }
        private void jegeskaverad_Checked(object sender, RoutedEventArgs e)
        {
            kávé = ar_jeges;
        }
        private void forrocsokirad_Checked(object sender, RoutedEventArgs e)
        {
            kávé = ar_forrocs;
        }
        private void forrovizrad_Checked(object sender, RoutedEventArgs e)
        {
            kávé = ar_forrov;
        }
    }
}