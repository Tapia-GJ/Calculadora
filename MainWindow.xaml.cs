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

namespace CalculadoraWPF
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
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                string value = (string)button.Content;
                if (IsNum(value))
                {
                    HandleNumber(value);
                }
                else if (IsOperator(value))
                {
                    HandleOperator(value);
                }else if (IsDelete(value))
                {
                    HandleDelete(value);
                }
                else if(value == ".")
                {
                    Other(value);
                }else if (value == "=")
                {
                    HandleEquals(Screen.Text);
                }
            }
            catch (Exception f)
            {
                throw new Exception ("Sucedio un error "+f.Message);
            }
        }
        //Metodo auxiliares
        private bool IsNum(string num)
        {
            /*
            if(double.TryParse(num, out _))
            {
                return true;
            }
            return false;*/
            return double.TryParse(num, out _);

        }
        private void HandleNumber(string value)
        {
            if (String.IsNullOrEmpty(Screen.Text))
            {
                Screen.Text = value;
            }
            else
            {
                Screen.Text += value;
            }
        }
        private bool IsOperator(string possibleOperator)
        {
            /*if(possibleOperator == "+" || possibleOperator == "-"
                || possibleOperator == "/" || possibleOperator == "*")
            {
                return true;
            }
            return false;*/
            return possibleOperator == "+" || possibleOperator == "-"
                || possibleOperator == "/" || possibleOperator == "*" || possibleOperator == "%";
        }
        private void HandleOperator(string value)
        {
            //string valordealado = Screen.Text[Screen.Text.Length-1].ToString();
            if(!String.IsNullOrEmpty(Screen.Text) && !Screen.Text.Contains("+") && !Screen.Text.Contains("-")
                && !Screen.Text.Contains("/") && !Screen.Text.Contains("*") && !Screen.Text.Contains("%"))
            {
                Screen.Text += value;
            }
        }
        private bool IsDelete(string value)
        {
            return value == "C" || value == "CE" || value == "<-";
        }
        private void HandleDelete(string value)
        {

            if (value == "CE")
            {
                if (Screen.Text.Length < 2)
                {
                    Screen.Text = "";
                    return;
                }
                Screen.Text = Screen.Text.Substring(0, Screen.Text.Length - 1);
            }else if(value == "C")
            {
                Screen.Text = "";
                return;
            }else if(value == "<-")
            {
                if (Screen.Text.Length < 2) {
                    Screen.Text = "";
                        return;
                }
                Screen.Text = Screen.Text.Substring(0, Screen.Text.Length - 1);
            }
        }
        private void Other(string value)
        {
            if (!String.IsNullOrEmpty(Screen.Text) && Screen.Text[Screen.Text.Length - 1].ToString() != ".")
            {
                Screen.Text += value;
            }
            else if(Screen.Text=="")
            {
                Screen.Text = "0.";
            }
        }
        
        private void HandleEquals(string screencontent)
        {
            
            string op = FindOperator(screencontent);
            if (!String.IsNullOrEmpty(op))
            {
                switch(op)
                {
                    case "+":
                        Screen.Text = Sum();
                        break;
                    case "-":
                        Screen.Text = Res();
                        break;
                    case "*":
                        Screen.Text = Multi();
                        break;
                    case "/":
                        Screen.Text = Divi();
                        break;
                    case "%":
                        Screen.Text = modulo();
                        break;
                }
            }
        }
        private string FindOperator(string screenContent)
        {
            foreach (var i in screenContent)
            {
                if (IsOperator(i.ToString()))
                {
                    return i.ToString();
                }
            }
            return "";
        }
        private string Sum()
        {
            string[] number = Screen.Text.Split('+');
            double.TryParse(number[0], out double n1);
            double.TryParse(number[1], out double n2);
            return Math.Round(n1 + n2, 12).ToString();
        }
        private string Res()
        {
            string[] number = Screen.Text.Split('-');
            double.TryParse(number[0], out double n1);
            double.TryParse(number[1], out double n2);
            return Math.Round(n1 - n2, 12).ToString();
        }
        private string Multi()
        {
            string[] number = Screen.Text.Split('*');
            double.TryParse(number[0], out double n1);
            double.TryParse(number[1], out double n2);
            return Math.Round(n1 * n2, 12).ToString();
        }
        private string Divi()
        {
            string[] number = Screen.Text.Split('/');
            double.TryParse(number[0], out double n1);
            double.TryParse(number[1], out double n2);
            return Math.Round(n1 / n2, 12).ToString();
        }
        private string modulo()
        {
            string[] number = Screen.Text.Split('%');
            double.TryParse(number[0], out double n1);
            double.TryParse(number[1], out double n2);
            return Math.Round(n1 % n2, 12).ToString();
        }
        private string dvd()
        {
            string[] number = Screen.Text.Split('-');
            double.TryParse(number[0], out double n1);
            double.TryParse(number[1], out double n2);
            return Math.Round(n1 - n2, 12).ToString();
        }

        //CAMBIO
    }
}
