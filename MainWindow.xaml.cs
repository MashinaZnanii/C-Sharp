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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string leftnum = "";
        string operation = "";
        string rightnum = "";

        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement c in LayotRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = (string)((Button)e.OriginalSource).Content;
            textBlock.Text += s;
            int num;
            bool result = Int32.TryParse(s, out num);

            if (result == true)
            {
                if (operation == "")
                {
                    leftnum += s;
                }
                else
                {
                    rightnum += s;
                }
            }
            else
            {
                if (s == "=")
                {
                    Update_RightOp();
                    textBlock.Text += rightnum;
                    operation = "";
                }
                else if (s == "CLEAR")
                {
                    leftnum = "";
                    rightnum = "";
                    operation = "";
                    textBlock.Text = "";
                }
                else
                {
                    if (rightnum != "")
                    {
                        Update_RightOp();
                        leftnum = rightnum;
                        rightnum = "";
                    }
                    operation = s;
                }
            }
        }
        private void Update_RightOp()
        {
            int num1 = Int32.Parse(leftnum);
            int num2 = Int32.Parse(rightnum);
            switch (operation)
            {
                case "+":
                    rightnum = (num1 + num2).ToString();
                    break;
                case "-":
                    rightnum = (num1 - num2).ToString();
                    break;
                case "*":
                    rightnum = (num1 * num2).ToString();
                    break;
                case "/":
                    try
                    {
                        rightnum = (num1 / num2).ToString();
                    }
                    catch(DivideByZeroException)
                    {
                        textBlock.Text = null;
                        rightnum = "Не дели на ноль, дурачок!";
                    }
                    break;
            }
        }
    }
}