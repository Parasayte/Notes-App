using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menustrip
{
    public partial class AddNewDirectory : Form 
    {
        public AddNewDirectory()
        {
            InitializeComponent();
        }

        private void AddNewDirectory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            directories directories = new directories("D:\\Program Files\\Notes");
            directories.CreatnewFile(richTextBox1.Text);
            Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            directories directories = new directories("D:\\Program Files\\Notes");
            directories.Show();
            Hide();
        }
    }
}
