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
    }
}
