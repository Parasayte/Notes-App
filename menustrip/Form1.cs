using System;
using System.Drawing;
using System.Windows.Forms;

namespace menustrip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void setColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            using (Form2 form = new Form2())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    rcbx.BackColor = form.SelectedBackColor;
                    rcbx.ForeColor = form.SelectedFontColor;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            rcbx.BackColor = Color.White;
            rcbx.ForeColor = Color.Black;
        }
    }
}
