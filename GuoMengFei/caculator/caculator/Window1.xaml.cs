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
using System.IO;
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
            try
            {
                Log log = new Log(showPanel.Text, showResultPanel.Text);
                log.AddLog();
                Log.CurrentLog = 1;
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
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
            if (showPanel.Text.Length > 0)
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
        public void showResult(string result)
        {
            showResultPanel.Text = result;
        }
        public void showFormula(string formula)
        {
            showPanel.Text = formula;
        }
        private void createNewCalculate()
        {
            showPanel.Text = "";
            AlreayFinished = false;
        }

        private void lastLog(object sender, RoutedEventArgs e)
        {
            try
            {
                UpDirectionButton upDirectionButton = new UpDirectionButton();
                Log.CurrentLog += 1;
                string logContent = upDirectionButton.ResultChange();
                Log log = new Log();
                string formula = log.getFormulaFromLog(logContent);
                string result = log.GetResultFromLog(logContent);
                showResult(result);
                showFormula(formula);
            }
            catch (Exception e1)
            {
                MessageBox.Show("记录不存在!");
                Log.CurrentLog -= 1;
            }
        }

        private void nextLog(object sender, RoutedEventArgs e)
        {
            try
            {
                DownDirectionButton downDirectionButton = new DownDirectionButton();
                Log.CurrentLog -= 1;
                string logContent = downDirectionButton.ResultChange();
                Log log = new Log();
                string formula = log.getFormulaFromLog(logContent);
                string result = log.GetResultFromLog(logContent);
                showResult(result);
                showFormula(formula);
            }
            catch (Exception e1)
            {
                MessageBox.Show("记录不存在!");
                Log.CurrentLog += 1;
            }
        }

        private void MoveLeft(object sender, RoutedEventArgs e)
        {

            showPanel.Select(showPanel.SelectionStart - 1, 0);

        }
    }
}
