using System.Windows;
using System.Windows.Controls;

namespace Sprawdz_karty_TM
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void C1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Lista.Items.Clear();
            string kolor = C1.Text;
            int poziom = int.Parse(C2.Text);
            int iloscKart = int.Parse(T2.Text);
            int start = 0;
            int[] zielone = { 2, 4, 10, 20, 40, 80, 140, 200, 280, 360, 460, 560, 700, 1000, 1300, 1600, 2000, 2500, 3000, 5000, 8000, 20000 };
            int[] niebieskie = { 2, 4, 10, 20, 40, 50, 70, 90, 120, 140, 180, 250, 350, 400, 500, 600, 800, 1300, 2100, 5200 };
            int[] fioletowe = { 2, 4, 6, 10, 14, 20, 25, 30, 40, 50, 60, 80, 100, 120, 200, 320, 800 };
            int[] złote = { 2, 4, 6, 8, 10, 12, 14, 16, 20, 22, 25, 45, 80, 200 };
            int[] koszty = { 5, 10, 30, 70, 150, 350, 700, 1000, 1600, 2500, 3600, 5000, 7000, 10000, 15000, 22000, 32000, 45000, 60000, 80000, 100000, 200000 }; 
            int[] przeszukiwane = zielone;
            int wydaneZłoto = 0;
            if (kolor == "Zielony")
            {
                start = 1;
            }
            if (kolor == "Niebieski")
            {
                start = 3;
                przeszukiwane = niebieskie;
            }
            if (kolor == "Fioletowy")
            {
                start = 6;
                przeszukiwane = fioletowe;
            }
            if (kolor == "Złoty")
            {
                start = 9;
                przeszukiwane = złote;
            }
            bool stan = true;
            while (stan is true && poziom < 23 )
            {
                int wymagania = przeszukiwane[poziom - start];
                int koszt = koszty[poziom - 1];
                if (iloscKart >= wymagania)
                {
                    poziom++;
                    wydaneZłoto += koszt;
                    iloscKart -= wymagania;
                }
                else
                {
                    stan = false;
                }
            }
            Lista.Items.Add($"Możesz awansować potwora na {poziom} poziom." );
            Lista.Items.Add($"Zostanie ci {iloscKart} kart.");
            Lista.Items.Add($"Wydasz {wydaneZłoto} złota.");

        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
