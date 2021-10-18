using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace 猜字游戏0._1
{
    public partial class Form1 : Form
    {
        int min, max, fuckyou, cishu, ModeType;
        [DllImport("Dll1.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getArea(int a, int b);
        private void chongzihi()
        {
            fuckyou = getArea(min, max);
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void chongzhicishu()
        {
            switch (ModeType)
            {
                case 1:
                    cishu = 10;
                    break;
                case 2:
                    cishu = 5;
                    break;
                case 3:
                    cishu = 3;
                    break;
                case 4:
                    cishu = 1;
                    break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("开始游戏前请选择难度");
            min = -1;
            max = 31;
            cishu = 10;
            ModeType = 1;
            chongzihi();
            MessageBox.Show("默认为简单模式\n简单模式：范围0 - 30，十次机会");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(label1, "输入拆弹密码说不定会有什么事情发生");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (cishu > 0)
            {
                int a = fuckyou, b, i;
                b = Convert.ToInt32(textBoxSRSJ.Text);
                i = Math.Abs(a - b);
                if (b == 7355608)
                {
                    button1.Visible = true;
                }
                else if (i == 0)
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
                    MessageBox.Show(cishu.ToString(), "你还有下面那么多次机会" );
                    cishu--;
                }
                else if (b > fuckyou)
                {
                    MessageBox.Show("这个答案有点大了吧  QWQ");
                    MessageBox.Show(cishu.ToString(), "你还有下面那么多次机会");
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

        private void 困难ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            min = -1;
            max = 31;
            cishu = 3;
            ModeType = 3;
            chongzihi();
            MessageBox.Show("困难模式：范围0 - 30，三次机会");
        }


        private void 简单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            min = -1;
            max = 31;
            cishu = 10;
            ModeType = 1;
            chongzihi();
            MessageBox.Show("简单模式：范围0 - 30，十次机会");
        }

        private void 赌神ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("想成为赌神吗？\n成败在此一举\n范围0-25，只有一次机会");
            min = -1;
            max = 26;
            cishu = 1;
            ModeType = 4;
            chongzihi();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button1.Text = button1.Text = fuckyou.ToString();
        }

        private void 普通ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            min = -1;
            max = 26;
            cishu = 5;
            ModeType = 2;
            chongzihi();
            MessageBox.Show("普通模式：范围0 - 25，五次机会");
        }

        private void 自定义ToolStripMenuItem_Click(object sender, EventArgs e)

        {
            this.Hide();
            Form2 obj = new Form2();
            obj.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // int shuru = 0;
            //long shurul=-2147483647;
            /*shurul = long.Parse(textBoxSRSJ.Text);
            if (shurul < 2147483647 && shurul > -2147483648) {
                shuru = (int)shurul;
            }
            else
            {
                MessageBox.Show("数据溢出");
            }*/
            button1.Text = fuckyou.ToString();
            timer2.Enabled = true;
            timer2.Interval = 50;
        }
    }
}
