using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;

namespace Sprawdz_karty_TM
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dictionary<string, int> colorOptions = new Dictionary<string, int>
        {
            { "Zielony", 1 }, { "Niebieski", 3 }, { "Fioletowy", 6 }, { "Złoty", 9 }
        };
        private readonly Dictionary<int, int> green = new Dictionary<int, int>()
        {
            {2, 2}, {3, 4}, {4, 10}, {5, 20}, {6, 40}, {7, 80}, {8, 140}, {9, 200}, {10, 280},
            {11, 360}, {12, 460}, {13, 560}, {14, 700}, {15, 1000}, {16, 1300}, {17, 1600},
            {18, 2000}, {19, 2500}, {20, 3000},{21, 5000}, {22, 8000}, {23, 20000}
        };
        private readonly Dictionary<int, int> blue = new Dictionary<int, int>()
        { {4, 2}, {5, 4}, {6, 10}, {7, 20}, {8, 40}, {9, 50}, {10, 70}, {11, 90}, {12, 120}, {13, 140},
            {14, 180}, {15, 250}, {16, 350}, {17, 400}, {18, 500}, {19, 600}, {20, 800}, {21, 1300}, {22, 2100}, {23, 5200} 
        };
        private readonly Dictionary<int, int> purple = new Dictionary<int, int>()
        { {7, 2}, {8, 4}, {9, 6}, {10, 10}, {11, 14}, {12, 20}, {13, 25}, {14, 30}, {15, 40}, {16, 50},
            {17, 60}, {18, 80}, {19, 100}, {20, 120}, {21, 200}, {22, 320}, {23, 800} 
        };
        private readonly Dictionary<int, int> yellow = new Dictionary<int, int>()
        { {10, 2}, {11, 4}, {12, 6}, {13, 8}, {14, 10}, {15, 12}, {16, 14}, {17, 16}, {18, 20}, {19, 22},
            {20, 25}, {21, 45}, {22, 80}, {23, 200} 
        };
        private readonly int[] costs = { 5, 10, 30, 70, 150, 350, 700, 1000, 1600, 2500, 3600, 5000, 7000, 10000,
            15000, 22000, 32000, 45000, 60000, 80000, 100000, 200000 };
        private readonly Dictionary<string, Dictionary<int, int>> colorDictionary;


        public MainWindow()
        {
            InitializeComponent();
            colorDictionary = new Dictionary<string, Dictionary<int, int>>()
            {
                { "Zielony", green }, { "Niebieski", blue }, { "Fioletowy", purple }, { "Złoty", yellow }
            };
        }

        private void C1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string color = C1.SelectedItem.ToString();
            int index = color.IndexOf(":") + 2;
            color = color.Substring(index);
            int start = colorOptions[color];
            if (C2 != null)
            {
                List<int> numbers = Enumerable.Range(start, 23-start).ToList();
                C2.Items.Clear();
                foreach (int number in numbers)
                {
                    C2.Items.Add(number);
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Lista.Items.Clear();
            string color = C1.Text;
            int level = int.Parse(C2.Text);
            int cardNumber = int.Parse(T2.Text);
            Dictionary<int, int> selectedColor = colorDictionary[color];
            int goldSpent = 0;
            int missedCards = 0;

            while (missedCards == 0 && level < 23)
            {
                int required = selectedColor[level + 1];
                int cost = costs[level - 1];
                if (cardNumber >= required)
                {
                    level++;
                    goldSpent += cost;
                    cardNumber -= required;
                }
                else
                {
                    missedCards = required - cardNumber;
                }
            }
            if (goldSpent > 0)
            {
                Lista.Items.Add($"Możesz awansować potwora na {level} poziom.");
                Lista.Items.Add($"Zostanie ci {cardNumber} kart.");
                Lista.Items.Add($"Wydasz {goldSpent} złota.");
            }
            else
            {
                Lista.Items.Add($"Nie możesz awansować potwora. Brakuje ci {missedCards} kart.");
            }

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

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void C2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
