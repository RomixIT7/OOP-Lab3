using System;
using System.Collections.Generic;
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

namespace One_dimentional_array_wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateAndProcess_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Input.Text, out int n) && n > 0)
            {
                double[] array = new double[n];
                Random r = new Random();

                for (int i = 0; i < n; i++)
                {
                    double randomNumber = Math.Round((r.NextDouble() * (3.59 + 7.51) - 7.51), 2);
                    array[i] = randomNumber;
                }

                MessageBox.Show($"Початковий масив: {string.Join(", ", array)}");

                double sumOfMods = 0;
                foreach (var element in array)
                {
                    if (Math.Abs(element % 1) < 0.5)
                    {
                        sumOfMods += Math.Abs(element);
                    }
                }

                MessageBox.Show($"Сума модулів елементів з дробовою частиною менше 0.5: {sumOfMods}");

                int minIndex = Array.IndexOf(array, array.Min());

                Array.Sort(array, minIndex + 1, array.Length - minIndex - 1);
                Array.Reverse(array, minIndex + 1, array.Length - minIndex - 1);

                MessageBox.Show($"Масив після виконання операцій: {string.Join(", ", array)}");
            }
            else
            {
                MessageBox.Show("Введіть коректне ціле число більше 0.");
            }
        }
    }
}
