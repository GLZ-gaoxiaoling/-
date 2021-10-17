using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace 猜字游戏0._1
{
    public partial class Form2 : Form
    {
        int min, max, fuckyou, cishu;
        [DllImport("Dll1.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getArea(int a, int b);
        private void chongzihi()
        {
            fuckyou = getArea(min, max);
        }
        private void chongzhicishu()
        {
            try
            {
                cishu = int.Parse(textBox1.Text);
            }
            catch(System.FormatException)
            {
                MessageBox.Show("宁好歹输点东西进去啊");
                MessageBox.Show("我先闪了（您重开吧");
                System.Environment.Exit(0);
            }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj = new Form1();
            obj.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cishu = -2147483648;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chongzhicishu();
            min = int.Parse(textBox2.Text) - 1;
            max = int.Parse(textBox3.Text) + 1;
            chongzihi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cishu == -2147483648)
            {
                MessageBox.Show("运行前点一下保存啊✘_✘");
            }
            else
            {
                if (cishu > 0)
                {
                    int a = fuckyou, b, i;
                    b = Convert.ToInt32(textBoxSRSJ.Text);
                    i = Math.Abs(a - b);
                    if (i == 0)
                    {
                        progressBar1.Value = 0;
                    }
                    else if (i < 2)
                    {
                        progressBar1.Value = 5;
                    }
                    else if (i < 5)
                    {
                        progressBar1.Value = 20;
                    }
                    else if (i < 10)
                    {
                        progressBar1.Value = 50;
                    }
                    else if (i < 15)
                    {
                        progressBar1.Value = 80;
                    }
                    else
                    {
                        progressBar1.Value = 100;
                    }
                    if (b < fuckyou)
                    {
                        MessageBox.Show("这个答案有点小了吧  QWQ");
                        MessageBox.Show("你还有下面那么多次机会", cishu.ToString());
                        cishu--;
                    }
                    else if (b > fuckyou)
                    {
                        MessageBox.Show("这个答案有点大了吧  QWQ");
                        MessageBox.Show("你还有下面那么多次机会", cishu.ToString());
                        cishu--;
                    }
                    else if (b == fuckyou)
                    {
                        MessageBox.Show("哦吼!!!\n居然猜对了");
                        MessageBox.Show("再来一遍？\n不你没得选:)");
                        chongzihi();
                        chongzhicishu();
                    }

                }
                else
                {
                    MessageBox.Show("实力不行呀\n就是逊啊\n想知道答案吗  QWQ\n就不告诉你  QWQ");
                    MessageBox.Show("再来一遍？\n不你没得选");
                    chongzihi();
                    chongzhicishu();
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
