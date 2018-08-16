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

namespace caculate
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private string str = "";              // a string to save data
        private static double temp = 0;         // a temp variable to save calculated data
        // private string text;

        private int GetSignPriority(char sign)  // get sign priority
        {
            switch (sign)
            {
                case '(':                       // when in stack, the priority of '(' is smallest
                    return 0;
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
            }
            return -1;
        }

        private int GetObjectTypeFromPostfixExpression(string obj)
        {
            // if obj is a sign
            if (obj == "+")
            {
                return '+';
            }
            else if (obj == "-")
            {
                return '-';
            }
            else if (obj == "*")
            {
                return '*';
            }
            else if (obj == "/")
            {
                return '/';
            }
            else                // is a number
            {
                return 0;
            }
        }

        // UI Events
        #region simple input Button
        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            str += "0";
            InputTextBox.Text = str;
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            str += "1";
            InputTextBox.Text = str;
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            str += "2";
            InputTextBox.Text = str;
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            str += "3";
            InputTextBox.Text = str;
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            str += "4";
            InputTextBox.Text = str;
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            str += "5";
            InputTextBox.Text = str;
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            str += "6";
            InputTextBox.Text = str;
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            str += "7";
            InputTextBox.Text = str;
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            str += "8";
            InputTextBox.Text = str;
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            str += "9";
            InputTextBox.Text = str;
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            str += "+";
            InputTextBox.Text = str;
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            str += "-";
            InputTextBox.Text = str;
        }

        private void BtnMultiple_Click(object sender, RoutedEventArgs e)
        {
            str += "*";
            InputTextBox.Text = str;
        }

        private void BtnDivision_Click(object sender, RoutedEventArgs e)
        {
            str += "/";
            InputTextBox.Text = str;
        }

        private void BtnDot_Click(object sender, RoutedEventArgs e)
        {
            str += ".";
            InputTextBox.Text = str;
        }

        private void BtnLeftBracket_Click(object sender, RoutedEventArgs e)
        {
            str += "(";
            InputTextBox.Text = str;
        }

        private void BtnRightBracket_Click(object sender, RoutedEventArgs e)
        {
            str += ")";
            InputTextBox.Text = str;
        }

        private void BtnDEL_Click(object sender, RoutedEventArgs e)
        {
            if (str.Length > 0)
            {
                str = str.Substring(0, str.Length - 1);
                InputTextBox.Text = str;
            }
        }

        private void BtnAC_Click(object sender, RoutedEventArgs e)
        {
            str = "";
            InputTextBox.Text = str;
        }
        #endregion

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {

            Stack<double> tempStack = new Stack<double>();                  // help to calculate postfix expression
            Queue<string> postfixExpressionQueue = new Queue<string>();     // save postfix expression
            Stack<char> signStack = new Stack<char>();                      // save signs
            string tempStr = "";                                            // save numbers
            int objType;
            double tempDouble;

            #region translate to postfix expression
            // collect into postfixExpressionStack
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] <= '9' && str[i] >= '0' || str[i] == '.')
                {
                    tempStr += str[i];
                }
                else
                {
                    if (tempStr.Length > 0)             // if there is a number before the sign, add to stack
                    {
                        postfixExpressionQueue.Enqueue(tempStr);
                        tempStr = "";
                    }
                    if (signStack.Count == 0)           // sign stack is empty
                    {
                        signStack.Push(str[i]);
                    }
                    else                                // isn't empty
                    { 
                        if (str[i] == '(')
                        {
                            signStack.Push('(');
                        }
                        else if (str[i] == ')')
                        {
                            // pop until ')'
                            char tempSign;
                            while (true)
                            {
                                tempSign = signStack.Pop();
                                if (tempSign != '(')
                                {
                                    postfixExpressionQueue.Enqueue(Convert.ToString(tempSign));
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (GetSignPriority(str[i]) > GetSignPriority(signStack.Peek()))
                            {
                                signStack.Push(str[i]);
                            }
                            else
                            {
                                while (true)
                                {
                                    postfixExpressionQueue.Enqueue(Convert.ToString(signStack.Pop()));
                                    if (signStack.Count == 0)
                                        break;
                                    else if (GetSignPriority(str[i]) > GetSignPriority(signStack.Peek()))
                                        break;
                                }
                                signStack.Push(str[i]);
                            }
                        }

                    }
                }
            }   // end for
            if (tempStr.Length > 0)
            {
                postfixExpressionQueue.Enqueue(tempStr);
                tempStr = "";
            }
            while (signStack.Count > 0)
            {
                postfixExpressionQueue.Enqueue(Convert.ToString(signStack.Pop()));
            }
            #endregion
            signStack.Clear();
            tempStr = "";

            #region calculate the answer by postfix expression

            while (postfixExpressionQueue.Count > 0)
            {
                objType = GetObjectTypeFromPostfixExpression(postfixExpressionQueue.Peek());
                switch (objType)
                {
                    case 0:                 // if is a number, save to tempStack
                        tempStack.Push(Convert.ToDouble(postfixExpressionQueue.Dequeue()));
                        break;
                    case '+':
                        postfixExpressionQueue.Dequeue();
                        tempStack.Push(tempStack.Pop() + tempStack.Pop());
                        break;
                    case '-':
                        postfixExpressionQueue.Dequeue();
                        tempDouble = tempStack.Pop();
                        tempStack.Push(tempStack.Pop() - temp);
                        break;
                    case '*':
                        postfixExpressionQueue.Dequeue();
                        tempStack.Push(tempStack.Pop() * tempStack.Pop());
                        break;
                    case '/':
                        postfixExpressionQueue.Dequeue();
                        tempDouble = tempStack.Pop();
                        if (tempDouble != 0.0)
                            tempStack.Push(tempStack.Pop() / tempDouble);
                        else
                        {
                            MessageBox.Show("Error: zero divisor.");
                        }
                        break;
                    default:
                        MessageBox.Show("Unknown Error.");
                        break;
                }
            }
            #endregion

            str = Convert.ToString(tempStack.Pop());
            InputTextBox.Text = str;
        }

    }


}



