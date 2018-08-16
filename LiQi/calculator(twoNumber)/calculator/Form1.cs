using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        double a = 0;
        double b = 0;
        bool c = false;
        string d;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//对应我的7键
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "7";
        }

        private void button2_Click(object sender, EventArgs e)//对应我的8键
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)//对应我的1键
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "1";
        }

        private void button10_Click(object sender, EventArgs e)//对应我的2键
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "2";
        }

        private void button11_Click(object sender, EventArgs e)//对应我的3键
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "3";
        }

        private void button5_Click(object sender, EventArgs e)//对应我的4键
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "4";
        }

        private void button6_Click(object sender, EventArgs e)//对应我的5键
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "5";
        }

        private void button7_Click(object sender, EventArgs e)//对应我的6键
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "6";
        }

        private void button3_Click(object sender, EventArgs e)//对应我的9键
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "9";
        }

        private void button13_Click(object sender, EventArgs e)//对应我0的键，增加了除数不能为0的判断
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "0";
            if (d == "/")
            {
                textBox1.Clear();
                MessageBox.Show("除数不能为零","错误提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)//对应我的+键
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "+";
        }

        private void button8_Click(object sender, EventArgs e)//对应我的-键
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "-";
        }

        private void button12_Click(object sender, EventArgs e)//对应我的*键
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "*";
        }

        private void button16_Click(object sender, EventArgs e)//对应我的/键
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "/";
        }

        private void button17_Click(object sender, EventArgs e)//对应我的平方键
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "x2";
        }

        private void button18_Click(object sender, EventArgs e)//对应我的开方键
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "sqrt";
        }

        private void button19_Click(object sender, EventArgs e)//对应我的log键
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "log";
        }

        private void button20_Click(object sender, EventArgs e)//对应我的ln键
        {
            c = true;
            b = double.Parse(textBox1.Text);
            d = "ln";
        }

        private void button15_Click(object sender, EventArgs e)//对应我的=键
        {
            switch (d)
            {
                case "+": a = b + double.Parse(textBox1.Text); break;
                case "-": a = b - double.Parse(textBox1.Text); break;
                case "*": a = b * double.Parse(textBox1.Text); break;
                case "/": a = b / double.Parse(textBox1.Text); break;
                case "x2": a = b * double.Parse(textBox1.Text); break;
                case "sqrt": a = Math.Sqrt(b); break;
                case "log": a = Math.Log(double.Parse(textBox1.Text), b); break;
                case "ln": a = Math.Log(b, Math.E); break;
            }
            textBox1.Text = a + "";
            c = true;
        }

        private void button14_Click(object sender, EventArgs e)//对应我的c键,实现了清零的功能
        {
            textBox1.Text = "";
        }
    }
}
