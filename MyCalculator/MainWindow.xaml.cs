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

namespace MyCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region properties
        double lastNumber, result;
        SelectedOperations selectedOp;
        #endregion
        public MainWindow()
        {
            InitializeComponent();

            acButton.Click += AcButton_Click;
            negativeBtn.Click += NegativeBtn_Click;
            percentageBtn.Click += PercentageBtn_Click; 
            equalBtn.Click += EqualBtn_Click; 
        }



        private void EqualBtn_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            //newNumber = (double)sender;
            if (double.TryParse(resetLabel.Content.ToString(), out newNumber))
            {
                switch(selectedOp)
                {
                    case SelectedOperations.addition:
                        result = simpleMath.add(lastNumber,newNumber);
                        break;
                    case SelectedOperations.subtraction:
                        result = simpleMath.Sub(lastNumber,newNumber);
                        break;
                    case SelectedOperations.multiplication:
                        result = simpleMath.Multiply(lastNumber,newNumber);
                        break;
                    case SelectedOperations.division:
                        result = simpleMath.Div(lastNumber,newNumber);
                        break;
                }

                resetLabel.Content = result.ToString();
            }
        }
        private void PercentageBtn_Click(object sender, RoutedEventArgs e)
        {
            double tempNum;
            if (double.TryParse(resetLabel.Content.ToString(), out tempNum))
            {
                tempNum = (tempNum / 100);
                if(tempNum!=0)
                {
                    tempNum *= lastNumber;
                }
                resetLabel.Content = tempNum.ToString();
            }
        }

        private void NegativeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resetLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resetLabel.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resetLabel.Content="0";
            lastNumber = 0;
            result = 0;

        }        

        private void operationsbtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resetLabel.Content.ToString(), out lastNumber))
            {
                resetLabel.Content = "0";
            }

            if (sender == division) selectedOp = SelectedOperations.division;            
            if (sender == multiply) selectedOp = SelectedOperations.multiplication;
            if (sender == add) selectedOp = SelectedOperations.addition;
            if (sender == subtract) selectedOp = SelectedOperations.subtraction;
        }

        private void numberBtn_Click(object sender, RoutedEventArgs e)
        {
            int selectedval = int.Parse((sender as Button).Content.ToString());

            if(resetLabel.Content.ToString() == "0")
            {
                resetLabel.Content = $"{selectedval}";
            }
            else
            {
                resetLabel.Content = $"{resetLabel.Content}{selectedval}";
            }
        }

        private void pointBtn_Click(object sender, RoutedEventArgs e)
        {
            if(resetLabel.Content.ToString().Contains("."))
            {
                // do nothing
            }
            else
            {
                resetLabel.Content = $"{resetLabel.Content}.";
            }
        }

        public enum SelectedOperations
        {
            addition,
            subtraction,
            multiplication,
            division
        }

        public class simpleMath
        {
            public static double add(double n1,double n2) 
            {
                return n1 + n2;
            }
            public static double Sub(double n1, double n2)
            {
                return n1 - n2;
            }

            public static double Div(double n1, double n2)
            {
                if (n2 == 0)
                {
                    MessageBox.Show("Invalid entry - no number is divisible by Zero");
                }
                return n1 / n2;
                
            }
            public static double Multiply(double n1, double n2)
            {
                return n1 * n2;
            }
        }
    }
}
