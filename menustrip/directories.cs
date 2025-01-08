using System;
using System.Collections.Generic;

using System.Drawing;
using System.IO;

using System.Threading.Tasks;
using System.Windows.Forms;
using menustrip.Properties;
namespace menustrip
{
    public partial class directories : Form
    {
        bool selected;
        List<string> SelectedlabelList = new List<string>();
        List<Label> LabelLis = new List<Label>();
        string path1 = "D:\\Program Files\\Notes";
        public directories(string path)
        {
            InitializeComponent();
            path1 = path;

        }

        private void directories_Load(object sender, EventArgs e)
        {
          
           if(!Directory.Exists(path1))
            {
                MessageBox.Show("The Folder Not Found,The Folder Will Create", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Directory.CreateDirectory("D:\\Program Files\\Notes");
                Showfilesonmenu(path1);
            }
            textBox1.Text=Path.GetFullPath(path1);

           Showfilesonmenu(path1);
        }
        public void Showfilesonmenu(string path)
        {
            int x = 10, y = 120;
            string[] files = Directory.GetDirectories(path);

            foreach (var file in files)
            {
                if (x % 810 == 0)
                { x = 10; y += 100; }
                Label label = new Label();
                label.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                label.Location = new System.Drawing.Point(x, y);
                label.Name = Path.GetFileName(file);
                label.Tag = file;
                label.Size = new System.Drawing.Size(90, 93);
                label.TabIndex = 0;
                label.Text = Path.GetFileName(file);
                label.Image = Resources.D;
                label.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                this.Controls.Add(label);
                LabelLis.Add(label);
                x += 100;



                label.DoubleClick += new System.EventHandler(this.label_DoubleClick);
                label.Click += new System.EventHandler(this.label_Click);


            }
        }
        private bool isDoubleClick = false;

        private void label_Click(object sender, EventArgs e)
        {
            if (!isDoubleClick)
            {

                Task.Delay(100).ContinueWith(_ =>
                {
                    if (!isDoubleClick)
                    {
                        this.Invoke(new Action(() => SingleClickHandler(sender, e)));
                    }
                    isDoubleClick = false;
                });
            }
        }

        private void label_DoubleClick(object sender, EventArgs e)
        {
            isDoubleClick = true;
            DoubleClickHandler(sender, e);
        }

        private void SingleClickHandler(Object sender, EventArgs e)
        {
            Label clickedButton = sender as Label;

            if (clickedButton == null) return;

            if (SelectedlabelList.Contains(clickedButton.Tag.ToString()))
            {
                clickedButton.BackColor = SystemColors.Control;
                SelectedlabelList.Remove(clickedButton.Tag.ToString());
            }
            else
            {
                SelectedlabelList.Add(clickedButton.Tag.ToString());
                clickedButton.BackColor = Color.MediumPurple;
            }

            if (SelectedlabelList.Count == 0)
            {
                label2.Enabled = false;
            }
            else
            {
                label2.Enabled = true;
            }
        }

        private void DoubleClickHandler(Object sender, EventArgs e)
        {
            Label clickedButton = sender as Label;
            if (clickedButton != null)
            {
                string buttonPath = clickedButton.Tag as string;
               menu menu = new menu(buttonPath);
                menu.Show();
                Hide();
            }
        }

        private void button_Click(Object sender, EventArgs e)
        {
            Label clickedButton = sender as Label;
            if (clickedButton != null)
            {
                string buttonPath = clickedButton.Tag as string;
               string path= Path.GetFullPath(buttonPath);
               
              menu menu = new menu(path);
           menu.Show();
              
                Hide();
            }
        }

      

        private void directories_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AddNewDirectory addNewDirectory = new AddNewDirectory();
            addNewDirectory.Show();
            Hide();
            Showfilesonmenu(path1);
        }
        public void CreatnewFile(string name)
        {


            if (Directory.Exists($"{path1}\\{name}"))
            {
                MessageBox.Show("The name is taken ,Try Another One!", "Rejected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Show();
            }
            else
            {
                Directory.CreateDirectory($"{path1}\\{name}");
                MessageBox.Show("The Folder Created Succefuly", "Succeful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Hide();
                Show();

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("The Folder Will Delete,\n Are You Sure ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Cancel)
            {
                return;
            }


            foreach (string a in SelectedlabelList)
            {
                if (Directory.Exists(a))
                {
                 
                    foreach (string file in Directory.GetFiles(a))
                    {
                        File.Delete(file);
                    }

         
                    foreach (string dir in Directory.GetDirectories(a))
                    {
                        Directory.Delete(dir, true); 
                    }

             
                    Directory.Delete(a);
                }
            }

            MessageBox.Show("The Folders Deleted Succefuly","Succeful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Hide();
            directories directories = new directories(path1);
            directories.Show();
        }

        private void Selectall_Click(object sender, EventArgs e)
        {

            label2.Enabled = true;



            if (selected)
            {
                label2.Enabled = true;
                selected = false;

                foreach (Label a in LabelLis)
                {
                    SelectedlabelList.Remove(a.Tag.ToString());

                    a.BackColor = SystemColors.Control; 
                  
                }
            }
            else
            {
                selected = true;

                foreach (Label a in LabelLis)
                {
                    SelectedlabelList.Add(a.Tag.ToString());
                    a.BackColor = Color.MediumPurple;
                }
            }


            if (SelectedlabelList.Count == 0)
            {
                label2.Enabled = false;
            }
        }

       

        private void label4_Click(object sender, EventArgs e)
        {
            path1 = textBox1.Text;
            directories d=new directories(path1);
            d.Show();
            Hide();
        }
    }
    
}

