using System.Text;
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
        public MainWindow()
        {
            InitializeComponent();
        }
        int ar_vanilia = 400;
        int ar_fekete = 250;
        int ar_cappuchino = 300;
        int ar_latta = 300;
        int ar_tejk = 400;
        int ar_jeges = 450;
        int ar_forrocs = 500;
        int ar_forrov = 50;
        int ar_cuk = 20;
        int menny_cuk = 0;
        int kávé = 0;

        private void vaniliaskave_Click(object sender, RoutedEventArgs e)
        {
            kávé = 400;              
        }

        private void Pluszcukor_Click(object sender, RoutedEventArgs e)
        {
            menny_cuk = menny_cuk + 1;
        }

        private void Minuszcukor_Click(object sender, RoutedEventArgs e)
        {
            if (menny_cuk != 0) 
            {
                menny_cuk = menny_cuk - 1;
            }
        }

        private void rendelés_Click(object sender, RoutedEventArgs e)
        {
            int osszeg = kávé + (menny_cuk*ar_cuk);
            MessageBox.Show((osszeg).ToString() + "ft");
            kávé = 0;
            menny_cuk = 0;
        }
    }
}