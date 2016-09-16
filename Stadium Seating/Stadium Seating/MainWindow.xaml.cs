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


namespace Stadium_Seating
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int classAPrice = 15;
        private int classBPrice = 12;
        private int classCPrice = 9;

        private TextBox currentBox;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            String tag = button.Tag.ToString();

            if (currentBox != null)
            {
                currentBox.AppendText(tag);
                currentBox.Focus();
            }
            
        }

        private void backspaceButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentBox != null)
            {
                string currentText = currentBox.Text;

                if (currentText.Length > 1)
                {
                    currentText = currentText.Substring(0, currentText.Length - 1);
                }
                else
                {
                    currentText = "";
                }

                currentBox.Text = currentText;
                currentBox.Focus();
            }
        }

        private void gotFocus(object sender, RoutedEventArgs e)
        {
            currentBox = (TextBox)sender;
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            prepareTextBoxesToParse();
            int aClassTickets;
            int bClassTickets;
            int cClassTickets;
            if (int.TryParse(classASoldBox.Text, out aClassTickets) &&
                int.TryParse(classBSoldBox.Text, out bClassTickets) &&
                int.TryParse(classCSoldBox.Text, out cClassTickets))
            {
                int totalAPrice = aClassTickets * classAPrice;
                int totalBPrice = bClassTickets * classBPrice;
                int totalCPrice = cClassTickets * classCPrice;
                int totalPrice = totalAPrice + totalBPrice + totalCPrice;

                

                string output = "Price: \n" +
                    "\nA Class:      $" + spacesforNumber(totalAPrice) + totalAPrice + ".00" +
                    "\nB Class:      $" + totalBPrice + ".00" +
                    "\nC Class:      $" + totalCPrice + ".00" +
                    "\nTotal price: $"  + totalPrice  + ".00";
                displayLabel.Content = output;
            } else
            {
                MessageBox.Show("Wrong input! You can only use integer numbers without floating point");

            }
        }

        private void prepareTextBoxesToParse()
        {
            TextBox[] textBoxes = new TextBox[] { classASoldBox, classBSoldBox, classCSoldBox };
            foreach (TextBox textBox in textBoxes) {
                if (textBox.Text.Length < 1)
                {
                    textBox.Text = "0";
                }
            }
        }

        private string spacesforNumber(int number)
        {
            int exponent = 0;
            string spaces = "";
            for (int total = number; total > 0; total /= 10)
            {
                exponent++;
                spaces = spaces + " ";
            }
            return spaces;
        }
    }
}
