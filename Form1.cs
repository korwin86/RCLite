using ShooterBL.RCLiteBL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RCLite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var data = new RCLData(Convert.ToDouble(textBox1.Text),
                                   Convert.ToDouble(textBox2.Text),
                                   Convert.ToDouble(textBox3.Text),
                                   Convert.ToDouble(textBox4.Text),
                                   Convert.ToDouble(textBox5.Text),
                                   Convert.ToDouble(textBox6.Text),
                                   Convert.ToDouble(textBox7.Text),
                                   Convert.ToDouble(textBox8.Text));
            var result = new RCLController(data).Result;
            label9.Text = result.ToString();
            if (textBox4.Text == "0")
            {
                toolTip1.SetToolTip(button1, "Количество пороха в банке должно быть больше 0");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (TextBox tb in Controls.Cast<Control>().Where(x => x is TextBox).Select(x => x as TextBox))
            {
                tb.Text = "0";
            }

            label9.Text = "0";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "");
        }
    }
}
