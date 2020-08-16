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
            delZeroEnd(sender, e);
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
                tb.KeyPress += checkInput;
                tb.Click += emptyText;
                tb.MouseLeave += delZero;
            }
            button1.MouseEnter += delZeroEnd;
            label9.Text = "0";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "");
        }

        private void checkInput(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != 127)
            {
                e.Handled = true;
                toolTip1.SetToolTip(sender as Control, "Введите цифры или один разделитель " + ",");
            }
            else if (!Char.IsDigit(number) && number != 8 && number != 127 && (sender as Control).Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                toolTip1.SetToolTip(sender as Control, "Введите цифры или один разделитель " + ",");
            }
            else
            {
                toolTip1.SetToolTip(sender as Control, "");
            }

        }

        private void emptyText(object sender, EventArgs e)
        {
            if ((sender as Control).Text == "0")
                (sender as Control).Text = "";
        }
        private void delZero(object sender, EventArgs e)
        {
            (sender as Control).Text = (sender as Control).Text.TrimStart(new Char[] { '0' });

            if ((sender as Control).Text.StartsWith(","))
                (sender as Control).Text = "0" + (sender as Control).Text;
            if ((sender as Control).Text == "")
                (sender as Control).Text = "0";
            (sender as TextBox).SelectionStart = (sender as Control).Text.Length;
        }
        private void delZeroEnd(object sender, EventArgs e)
        {
            foreach (TextBox tb in Controls.Cast<Control>().Where(x => x is TextBox).Select(x => x as TextBox))
            {
                if (!(tb.Text == "0") && tb.Text.Contains(","))
                    tb.Text = tb.Text.TrimEnd(new Char[] { '0' });
                if (tb.Text.EndsWith(","))
                    tb.Text = tb.Text.TrimEnd(new Char[] { ',' });
                tb.SelectionStart = tb.Text.Length;
            }
        }


    }
}
