﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace menustrip
{
    public partial class AddNewFile : Form
    {
        public string fileName;
        string path;
        public AddNewFile(string path1)
        {
            InitializeComponent();
            path = path1;
        }

    
        private void label1_Click(object sender, EventArgs e)
        {
            Folders_menu m=new Folders_menu(path);
           
            m.CreatnewFile(richTextBox1.Text, path);
            Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Folders_menu m = new Folders_menu(path);
            m.Show();

            Hide();
        }
    }
}
