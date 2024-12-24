using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace menustrip
{
    public partial class Form1 : Form
    {
        string path;

        public Form1(string path1)
        {
            InitializeComponent();
            path = path1;
        }

        private void setColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(path);
            rcbx.Text = sr.ReadToEnd();
            sr.Close();
            rcbx.BackColor = Color.White;
            rcbx.ForeColor = Color.Black;
        }
        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            Directory.CreateDirectory("D:\\selam9");
             StreamWriter streamWriter = new StreamWriter(path);
             streamWriter.WriteLine(rcbx.Text);
             streamWriter.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           directories a= new directories();
            a.Show();
            Hide();
        }
    }
}
