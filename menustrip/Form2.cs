using System;
using System.Drawing;
using System.Windows.Forms;

namespace menustrip
{
    public partial class Form2 : Form
    {
        public Color SelectedBackColor { get; private set; } = Color.White;
        public Color SelectedFontColor { get; private set; } = Color.Black;

        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (cd.ShowDialog() == DialogResult.OK)
            {
                SelectedFontColor = cd.Color;
                fontlabel.BackColor = SelectedFontColor;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            if (cd.ShowDialog() == DialogResult.OK)
            {
                SelectedBackColor = cd.Color;
                backlabel.BackColor = SelectedBackColor;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
