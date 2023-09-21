using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHIO
{
    public partial class SHIO_app : Form
    {
        public SHIO_app()
        {
            InitializeComponent();
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            SHIO_app.ActiveForm.Hide();
            KA6 NewForm = new KA6();
            NewForm.ShowDialog();
            Close();
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            SHIO_app.ActiveForm.Hide();
            BMI_calculator NewForm = new BMI_calculator();
            NewForm.ShowDialog();
            Close();
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            SHIO_app.ActiveForm.Hide();
            About_developer NewForm = new About_developer();
            NewForm.ShowDialog();
            Close();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
