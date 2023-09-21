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
    public partial class About_6KA : Form
    {
        public About_6KA()
        {
            InitializeComponent();
        }

        private void exit_about_button_Click(object sender, EventArgs e)
        {
            About_6KA.ActiveForm.Hide();
            KA6 NewForm = new KA6();
            NewForm.ShowDialog();
            Close();
        }
    }
}
