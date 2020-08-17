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
            //Удаляем всё лишнее из текстбоксов
            Clear(sender, e);
            //Передаём введенные данные в RCLData(проверка на 0 проходит внутри)
            var data = new RCLData(Convert.ToDouble(textBox1.Text),
                                   Convert.ToDouble(textBox2.Text),
                                   Convert.ToDouble(textBox3.Text),
                                   Convert.ToDouble(textBox4.Text),
                                   Convert.ToDouble(textBox5.Text),
                                   Convert.ToDouble(textBox6.Text),
                                   Convert.ToDouble(textBox7.Text),
                                   Convert.ToDouble(textBox8.Text));
            //Вычисляем и показываем результат
            var result = new RCLController(data).Result;
            label9.Text = result.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Перебираем все текстбоксы
            foreach (TextBox tb in Controls.Cast<Control>().Where(x => x is TextBox).Select(x => x as TextBox))
            {
                tb.Text = "0";
                tb.KeyPress += CheckInput;
                tb.MouseLeave += Clear;
            }
            button1.MouseEnter += Clear;
            label9.Text = "0";
        }

        //Обработка ввода в текстбоксы
        private void CheckInput(object sender, KeyPressEventArgs e)
        {
            
            char number = e.KeyChar;
            //Если нажата любая клавиша кроме цифр, backspace и delete
            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != 127)
            {
                //Отменяем нажатие
                e.Handled = true;
                //Подсказываем пользователю
                toolTip1.SetToolTip(sender as Control, "Введите цифры или один разделитель " + ",");
            }
            //Тоже самое, плюс проверка на два разделителя
            else if (!Char.IsDigit(number) && number != 8 && number != 127 && (sender as Control).Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                toolTip1.SetToolTip(sender as Control, "Введите цифры или один разделитель " + ",");
            }
            else
            {
                //Сбрасываем подсказку
                toolTip1.SetToolTip(sender as Control, "");
            }

        }

        // Обработка приводит в порядок текстбоксы
        private void Clear(object sender, EventArgs e)
        {
            //Перебираем все текстбоксы
            foreach (TextBox tb in Controls.Cast<Control>().Where(x => x is TextBox).Select(x => x as TextBox))
            {
                //Не смог реализовать логику возврата коретки при удалении лишних 0 в начале. Забил и перенес фокус на кнопку.

                //Если есть 0 в начале, удаляем эти 0
                if (tb.Text.StartsWith("0"))
                    tb.Text = tb.Text.TrimStart(new Char[] { '0' });
                //Если в начале разделитель, добавляем 0
                if (tb.Text.StartsWith(","))
                    tb.Text = "0" + tb.Text;
                //Если текстбокс пустой, ставим 0
                if (tb.Text == "")
                    tb.Text = "0";
                //Если текстбокс не равен 0 и содержит разделитель - удаляем лишние 0 в конце
                if (!(tb.Text == "0") && tb.Text.Contains(","))
                    tb.Text = tb.Text.TrimEnd(new Char[] { '0' });
                //Если текстбокс заканчивается на разделитель, убираем разделитель
                if (tb.Text.EndsWith(","))
                    tb.Text = tb.Text.TrimEnd(new Char[] { ',' });
            }

            //Смена фокуса на кнопку
            button1.Select();
        }

    }
}
