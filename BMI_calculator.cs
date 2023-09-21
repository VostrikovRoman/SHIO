using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace SHIO
{
    public partial class BMI_calculator : Form
    {
        public BMI_calculator()
        {
            InitializeComponent();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            BMI_calculator.ActiveForm.Hide();
            SHIO_app NewForm = new SHIO_app();
            NewForm.ShowDialog();
            Close();
        }

        private void button_main_Click(object sender, EventArgs e)
        {
            page1.Visible = true;
            main.Visible = false;
            page2_box.Value = 1;
            page3_box.Value = 1;
            height.Value = 1;
            weight.Value = 1;
            gender.Text = "";
            accept_button.Checked = false;
            box_data_name.Text = "";
            box_data_phone.Text = "";
        }

        private void page1_button_man_Click(object sender, EventArgs e)
        {
            about_data.Visible = true;
            page1.Visible = false;
            gender.Text = "man";
        }

        private void page1_button_woman_Click(object sender, EventArgs e)
        {
            about_data.Visible = true;
            page1.Visible = false;
            gender.Text = "woman";
        }

        private void page1_button_back_Click(object sender, EventArgs e)
        {
            page1.Visible = false;
            main.Visible = true;
            gender.Text = "";
        }

        private void page2_button_back_Click(object sender, EventArgs e)
        {
            about_data.Visible = true;
            page2.Visible = false;
            weight.Value = 1;
        }

        private void page2_next_Click(object sender, EventArgs e)
        {
            try
            {
                page3.Visible = true;
                page2.Visible = false;
                weight.Value = page2_box.Value;
            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!");
            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void page3_button_back_Click(object sender, EventArgs e)
        {
            page2.Visible = true;
            page3.Visible = false;
            height.Value = 1;
            man.Visible = false;
            woman.Visible = false;
            tall_man.Visible = false;
            tall_woman.Visible = false;
            fat_man.Visible = false;
            fat_woman.Visible = false;
        }

        private void page3_next_Click(object sender, EventArgs e)
        {
            string name = (string)box_data_name.Text;
            string phone = "+7 " + (string)box_data_phone.Text;
            try
            {
                MailAddress from = new MailAddress("fortestIMT@gmail.com");
                MailAddress to = new MailAddress("rmnvstrkv@gmail.com");
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Новый пользователь!";
                m.IsBodyHtml = false;
                m.Body = "Имя: " + name + "\nНомер телефона: " + phone;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("fortestIMT@gmail.com", "pexzozphwawhzbog"),
                    //Credentials = new NetworkCredential("fortestIMT@gmail.com", "osazmjbjywktkvjo"),

                    EnableSsl = true
                };
                smtp.Send(m);

            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат электронной почты. Почта должна иметь окончания - @gmail/yandex/mail/bk/list и другие");

            }
            catch (ArgumentException)
            {
                MessageBox.Show("Строка с адресом не должна быть пуста");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            try
            {
                if (gender.Text == "man")
                {
                    end.Visible = true;
                    page3.Visible = false;
                    height.Value = page3_box.Value;
                    double h = (double)height.Value / 100;
                    int m = (int)weight.Value;
                    double imt = m / (h * h);
                    imt = (double)Math.Round(imt, 2, MidpointRounding.AwayFromZero);
                    if (imt < 18)
                    {
                        end_label.Text = "У вас недостаточный вес";
                        tall_man.Visible = true;
                        man.Visible = false;
                        woman.Visible = false;
                        tall_woman.Visible = false;
                        fat_man.Visible = false;
                        fat_woman.Visible = false;
                        MessageBox.Show("Ваш ИМТ равен " + imt);
                    }
                    else
                    {
                        if (imt > 24)
                        {
                            end_label.Text = "У вас избыточный вес";
                            fat_man.Visible = true;
                            man.Visible = false;
                            woman.Visible = false;
                            tall_man.Visible = false;
                            tall_woman.Visible = false;
                            fat_woman.Visible = false;
                            MessageBox.Show("Ваш ИМТ равен " + imt);
                        }
                        else
                        {
                            end_label.Text = "У вас нормальный вес";
                            man.Visible = true;
                            woman.Visible = false;
                            tall_man.Visible = false;
                            tall_woman.Visible = false;
                            fat_man.Visible = false;
                            fat_woman.Visible = false;
                            MessageBox.Show("Ваш ИМТ равен " + imt);
                        }
                    }
                }
                if (gender.Text == "woman")
                {
                    end.Visible = true;
                    page3.Visible = false;
                    height.Value = page3_box.Value;
                    double h = (double)height.Value / 100;
                    int m = (int)weight.Value;
                    double imt = m / (h * h);
                    imt = (double)Math.Round(imt, 2, MidpointRounding.AwayFromZero);
                    if (imt < 20)
                    {
                        end_label.Text = "У вас недостаточный вес";
                        tall_woman.Visible = true;
                        man.Visible = false;
                        woman.Visible = false;
                        tall_man.Visible = false;
                        fat_man.Visible = false;
                        fat_woman.Visible = false;
                        MessageBox.Show("Ваш ИМТ равен " + imt);
                    }
                    else
                    {
                        if (imt > 26)
                        {
                            end_label.Text = "У вас избыточный вес";
                            fat_woman.Visible = true;
                            man.Visible = false;
                            woman.Visible = false;
                            tall_man.Visible = false;
                            tall_woman.Visible = false;
                            fat_man.Visible = false;
                            MessageBox.Show("Ваш ИМТ равен " + imt);
                        }
                        else
                        {
                            end_label.Text = "У вас нормальный вес";
                            woman.Visible = true;
                            man.Visible = false;
                            tall_man.Visible = false;
                            tall_woman.Visible = false;
                            fat_man.Visible = false;
                            fat_woman.Visible = false;
                            MessageBox.Show("Ваш ИМТ равен " + imt);
                        }
                    }
                }



            }
            catch (FormatException a)
            {
                MessageBox.Show("Ошибка!");
            }
            catch (Exception a)
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void about_data_back_Click(object sender, EventArgs e)
        {
            about_data.Visible = false;
            page1.Visible = true;
        }

        private void about_data_next_Click(object sender, EventArgs e)
        {
            if (box_data_name.Text != "")
            {
                if (box_data_phone.Text != "")
                {

                    if (accept_button.Checked == true)
                    {
                        about_data.Visible = false;
                        page2.Visible = true;


                    }
                    else
                    {
                        MessageBox.Show("Подтвердите, пожалуйста, Ваше согласие на обработку персональных данных.");
                    }
                }
                else
                {
                    MessageBox.Show("Введите, пожалуйста, Ваши контактные данные.");
                }
            }
            else
            {
                MessageBox.Show("Введите, пожалуйста, Ваши контактные данные.");
            }
        }

        private void end_button_back_Click(object sender, EventArgs e)
        {
            end.Visible = false;
            page3.Visible = true;
        }

        private void end_button_beback_Click(object sender, EventArgs e)
        {
            main.Visible = true;
            end.Visible = false;
            page2_box.Value = 1;
            page3_box.Value = 1;
            height.Value = 1;
            weight.Value = 1;
            gender.Text = "";
            man.Visible = false;
            woman.Visible = false;
            tall_man.Visible = false;
            tall_woman.Visible = false;
            fat_man.Visible = false;
            fat_woman.Visible = false;
            accept_button.Checked = false;
            box_data_name.Text = "";
            box_data_phone.Text = "";
        }
    }
}
