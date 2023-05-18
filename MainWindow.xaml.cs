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

namespace WpfApp1
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
      
        string vector = "";
        string meters = "";
        int sumRight = 0;
        int sumLeft = 0;
        int sumDown = 0;
        int sumUp = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] getvalues = {txt1.Text, txt2.Text, txt3.Text, txt4.Text,txt5.Text, txt6.Text, txt7.Text, txt8.Text,
                                    txt9.Text, txt10.Text, txt11.Text,txt12.Text,txt13.Text,txt14.Text,txt15.Text, };
          
            if (isEmptyStringArray(getvalues))
            {
                return;
            }

            var finalValues = getvalues.Where(x => !string.IsNullOrEmpty(x));
            var vecList = new Dictionary<string, int>();

            foreach (var item in finalValues)
            {
                vector = item.Split(new char[] { ' ' })[0];
                meters = item.Split(new char[] { ' ' })[1];
                bool isNumber = int.TryParse(meters, out int numericValue)&& int.Parse(meters)>=0;
               
                if (!isNumber)
                {
                    lblError.Content = "Second Argument must be a number and greater than 0";
                    return;
                }
                switch (vector.ToLower())
                {
                    case "right":
                        sumRight +=int.Parse(meters);
                        break;
                    case "left":
                        sumLeft += int.Parse(meters);
                        break;
                    case "up":
                        sumDown += int.Parse(meters);
                        break;
                    case "down":
                        sumUp += int.Parse(meters);
                        break;
                    default:
                        lblError.Content = "please rewrite instructions as follows: right/left/up/down and than one space and a number";
                        return;
                }
            }

            int totalRightLeft = sumRight - sumLeft;
            int totalUpDown = sumDown -sumUp;
            lblError.Content = "The robot position is " + totalRightLeft + " and " + totalUpDown;
        }
        
        static bool isEmptyStringArray(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    return false;
                }
            }
            return true;
        }

    }

}
