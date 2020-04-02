using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Double resultValue = 0;
        String operation = "";
        bool isOperation = false;
        bool isError = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (!isError)
            {
                if (Entry.Text == "0" || isOperation)
                { Entry.Clear(); }

                isOperation = false;
                Button button = (Button)sender;
                if (button.Content.ToString() == ".")
                {
                    if (!Entry.Text.Contains("."))
                        Entry.Text = Entry.Text + button.Content;
                }
                else
                    Entry.Text = Entry.Text + button.Content;
            }


        }
        private void operator_Click(object sender, RoutedEventArgs e)
        {
            if (!isError)
            {
                if (Entry.Text != "")
                {
                    if (Entry.Text.Last() != '/' && Entry.Text.Last() != '*' && Entry.Text.Last() != '+' && Entry.Text.Last() != '-' && Entry.Text.Last() != '.')
                    {
                        if (Entry.Text != "")
                        {
                            Button button = (Button)sender;
                            if (resultValue != 0)
                            {

                                operation = button.Content.ToString();
                                Entry.Text = resultValue + " " + operation;
                                isOperation = true;
                            }
                            else
                            {
                                operation = button.Content.ToString();
                                resultValue = Double.Parse(Entry.Text, CultureInfo.InvariantCulture);
                                Entry.Text = resultValue + " " + operation;
                                isOperation = true;
                            }
                        }
                    }
                }
            }
         
        }
        private void result_Click(object sender, RoutedEventArgs e)
        {
            if (!isError)
            {
                if (Entry.Text.Last() != '/' && Entry.Text.Last() != '*' && Entry.Text.Last() != '+' && Entry.Text.Last() != '-' && Entry.Text.Last() != '.')
                {
                    switch (operation)
                    {

                        case "+":
                            Entry.Text = (resultValue + Double.Parse(Entry.Text, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);
                            break;
                        case "-":
                            Entry.Text = (resultValue - Double.Parse(Entry.Text, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);
                            break;
                        case "*":
                            Entry.Text = (resultValue * Double.Parse(Entry.Text, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);
                            break;
                        case "/":
                            if (Double.Parse(Entry.Text, CultureInfo.InvariantCulture) == 0) { Entry.Text = "NIEDOZWOLONE"; isError = true; break; }//
                            else
                            {
                                Entry.Text = (resultValue / Double.Parse(Entry.Text, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);
                            }
                            break;

                        default:
                            break;
                    }

                    if (!isError)
                    {
                        if (Entry.Text != "")
                        {
                            resultValue = Double.Parse(Entry.Text, CultureInfo.InvariantCulture);
                        } //
                    }
                }
            }
           
        }
        private void point_Click(object sender, RoutedEventArgs e)
        {
            if (!isError)
            {
                if (Entry.Text != "")
                {
                    Button button = (Button)sender;
                    if (!Entry.Text.Contains("."))
                    { Entry.Text = Entry.Text + button.Content; }
                }

            }
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        { 
            Button button = (Button)sender;
            resultValue = 0;
             operation = "";
            isOperation = false;
            Entry.Text = 0.ToString(CultureInfo.InvariantCulture);
            isError = false;

        }

    }
}
