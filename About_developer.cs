using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace SHIO
{
    public partial class About_developer : Form
    {
        public About_developer()
        {
            InitializeComponent();
            openFileDialog1.Filter = "PNG files(*.png)|*.png";
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            About_developer.ActiveForm.Hide();
            SHIO_app NewForm = new SHIO_app();
            NewForm.ShowDialog();
            Close();
        }

        private void save_Click(object sender, EventArgs e)
        {
            password_panel.Visible = false;
            password.Text = "";
            password.ForeColor = Color.Black;
            save.Visible = false;
            surname.Enabled = false;
            name.Enabled = false;
            last_name.Enabled = false;
            birthday.Enabled = false;
            university.Enabled = false;
            phone.Enabled = false;
            email.Enabled = false;
            img_button.Visible = false;
            hidden_button.Visible = true;
            SaveFile(surname.Text, "surname.txt");
            SaveFile(name.Text, "name.txt");
            SaveFile(last_name.Text, "last_name.txt");
            SaveFile(birthday.Text, "birthday.txt");
            SaveFile(university.Text, "university.txt");
            SaveFile(phone.Text, "phone.txt");
            SaveFile(email.Text, "email.txt");
            SaveFile(save_box.Text, "save.txt");
        }

        private void accept_button_Click(object sender, EventArgs e)
        {
            string pass = (string)password.Text;
            if (pass == "95nnlRH4")
            {
                password_panel.Visible = false;
                password.Text = "";
                surname.Enabled = true;
                name.Enabled = true;
                last_name.Enabled = true;
                birthday.Enabled = true;
                university.Enabled = true;
                phone.Enabled = true;
                email.Enabled = true;
                save.Visible = true;
                img_button.Visible = true;
                hidden_button.Visible = false;
            }
            else
            {
                password.ForeColor = Color.Red;
                MessageBox.Show("Неверный пароль");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            password_panel.Visible = false;
            password.Text = "";
            password.ForeColor = Color.Black;
        }

        private void img_button_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            image.Image = Image.FromFile(filename);
        }

        private void hidden_button_Click(object sender, EventArgs e)
        {
            password_panel.Visible = true;
            password.Text = "";
            password.ForeColor = Color.Black;
        }
        void SaveFile(string a, string b)
        {
            if (a.Count() > 1)
            {
                if (File.Exists(b))
                    File.Create(b).Close();
                File.WriteAllText(b, a);
            }
        }

        private void About_developer_Load(object sender, EventArgs e)
        {
            if (File.Exists("surname.txt"))
            {
                surname.Text = File.ReadAllText("surname.txt");
            }
            if (File.Exists("name.txt"))
            {
                name.Text = File.ReadAllText("name.txt");
            }
            if (File.Exists("last_name.txt"))
            {
                last_name.Text = File.ReadAllText("last_name.txt");
            }
            if (File.Exists("birthday.txt"))
            {
                birthday.Text = File.ReadAllText("birthday.txt");
            }
            if (File.Exists("university.txt"))
            {
                university.Text = File.ReadAllText("university.txt");
            }
            if (File.Exists("phone.txt"))
            {
                phone.Text = File.ReadAllText("phone.txt");
            }
            if (File.Exists("email.txt"))
            {
                email.Text = File.ReadAllText("email.txt");
            }
        }
    }
}
