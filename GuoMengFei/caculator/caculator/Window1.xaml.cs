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
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
namespace caculator
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public bool AlreayFinished = false;
        public Window1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (AlreayFinished == true)
            {
                createNewCalculate();
            }
            if (showPanel.Text.Length < 160)
            {
                Button button = (Button)sender;
                showPanel.Text += button.Content.ToString();
            }
        }
        private void easyCalculate()
        {
            try
            {
                string expression = showPanel.Text;
                object datatable = new DataTable().Compute(expression, "");
                showResult(datatable.ToString());
                AlreayFinished = true;
            }
            catch (Exception)
            {
                MessageBox.Show("请检查输入");
            }
        }
        protected void equal(object sender, RoutedEventArgs e)
        {
            easyCalculate();
        }
        private void clearContent(object sender, RoutedEventArgs e)
        {
            showPanel.Text = "";
        }

        private void deleteContent(object sender, RoutedEventArgs e)
        {
            if (showPanel.Text.Length>0)
            {
                string text = showPanel.Text;
                showPanel.Text = text.Remove(text.Length - 1);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (AlreayFinished == true)
            {
                createNewCalculate();
            }
            if (e.Key.ToString().Equals("Return"))
            {
                easyCalculate();
            }
        }
        private void showResult(string result)
        {
            showResultPanel.Text = result;
        }

        private void createNewCalculate()
        {
            showPanel.Text = "";
            AlreayFinished = false;
        }
    }
}
