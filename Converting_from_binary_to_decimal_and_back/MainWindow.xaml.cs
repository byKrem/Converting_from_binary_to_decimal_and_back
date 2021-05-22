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

namespace Converting_from_binary_to_decimal_and_back
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string BinaryDecimal(int number)
        {
            double result = 0;
            List<int> numbers = new List<int>();
            for(int i = 0; i < number.ToString().Length; i++)
                numbers.Add(int.Parse(number.ToString()[i].ToString()));
            for(int i = 0; i < number.ToString().Length; i++)
            {
                // 2^2*1 + 2^1*0 + 2^0*1
                result += Math.Pow(2,i) * numbers[number.ToString().Length - 1 - i];
            }
            return result.ToString();
        }

        private string DecimalBinary(int number)
        {
            string result = "";
            do
            {
                result += $"{number%2}";
                if (number / 2 == 0)
                    break;
                number /= 2;
            } while (true);
            return result;
        }

        private void btn_Start_Click(object sender, RoutedEventArgs e)
        {
            int[] result = { 0, 0 };
            int.TryParse(txtBox_binary.Text, out result[0]);
            int.TryParse(txtBox_decimal.Text, out result[1]);
            txtBox_decimal.Text = (result[1] + 1).ToString();
            txtBox_binary.Text = Convert.ToString(result[1], 2);
            //txtBox_decimal.Text = BinaryDecimal(result[0]);
            //txtBox_binary.Text = DecimalBinary(result[1]);
            //txtBox_decimal.Text = Convert.ToString(result[0], 10);
        }
    }
}
