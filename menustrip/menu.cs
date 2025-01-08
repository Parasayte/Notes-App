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
using menustrip.Properties;
using System.Xml.Linq;

namespace menustrip
{
    public partial class menu : Form
    {
         string path;
        bool selected;
        List<string> SelectedlabelList = new List<string>();
        List<Label> LabelLis = new List<Label>();

        public menu(string path1)
        {
            InitializeComponent();
            path = path1;
            if (string.IsNullOrEmpty(label3.Text))
            {
                label3.Text = path;
                
            }


        }
        public void Showfilesonmenu() {
            Hide();
            Show();
            int x = 10, y = 120;
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                
                if(x%810==0)
                 { x = 10;y += 100; }
                Label label = new Label();
                label.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
                label.Location = new System.Drawing.Point(x, y);
                label.Name = Path.GetFileName(file);
                label.Tag = file;
                label.Size = new System.Drawing.Size(90, 93);
                label.TabIndex = 0;
                label.Text = Path.GetFileName(file);
                label.Image = Resources.T;
                label.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                this.Controls.Add(label);
                LabelLis.Add(label);
                x += 100;


                label.DoubleClick += new System.EventHandler(this.label_DoubleClick);
                label.Click += new System.EventHandler(this.label_Click);
                label3.Text.Trim();
                label3.Text= Path.GetFullPath(path);
               

            }

        }
        private bool isDoubleClick = false;

        private void label_Click(object sender, EventArgs e)
        {
            if (!isDoubleClick)
            {
                
                Task.Delay(200).ContinueWith(_ =>
                {
                    if (!isDoubleClick)
                    {
                        this.Invoke(new Action(() => SingleClickHandler(sender , e)));
                    }
                    isDoubleClick = false;
                });
            }
        }

        private void label_DoubleClick(object sender, EventArgs e)
        {
            isDoubleClick = true;
            DoubleClickHandler(sender,e);
        }

        private void SingleClickHandler(Object sender, EventArgs e)
        {
            Label clickedButton = sender as Label;

            if (clickedButton == null) return;

            if (SelectedlabelList.Contains(clickedButton.Tag.ToString()))
            {
                label3.Text = Path.GetFullPath(path);
                clickedButton.BackColor = SystemColors.Control;
                SelectedlabelList.Remove(clickedButton.Tag.ToString());
            }
            else
            {
                label3.Text = clickedButton.Tag.ToString(); 
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


        private void DoubleClickHandler(Object sender , EventArgs e)
        {  
            Label clickedButton = sender as Label;
            if (clickedButton != null)
            {
                string buttonPath = clickedButton.Tag as string; 
                Form1 form = new Form1(buttonPath);
                form.Show();
               Hide();
            }
        }
      
        private void menu_Load(object sender, EventArgs e)
        {
            newNameToolStripMenuItem.Text = Path.GetFileName(path);

            fileNameToolStripMenuItem.Text = Path.GetFileName(path);
            Showfilesonmenu();
        }
   


        private void menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        
           AddNewFile file = new AddNewFile(path);
            Hide();
            file.Show();
         
        }
        public void CreatnewFile(string name,string path1)
        {
          

            if (File.Exists($"{path1}\\{name}.txt"))
            {
                MessageBox.Show("The name is taken ,Try Another One!", "Rejected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Show();
              
            }
            else
            {
            File.Create($"{path1}\\{name}.txt").Close();
                MessageBox.Show("The Files Created Succefuly", "Succeful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Hide();
            Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            directories directories = new directories(Path.GetDirectoryName(path));
            directories.Show();
            Hide();
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

                  File.Delete($"{a}");

 
            }

            MessageBox.Show("The Files Deleted Succefuly","Succeful",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Hide();
                menu menu=new menu(path);
                menu.Show();

        }

   

      

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Selectall_Click(object sender, EventArgs e)
        {
            label3.Text = path;

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

        private void label3_Click(object sender, EventArgs e)
        {
           OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = label3.Text;
            ofd.ShowDialog();
            
            
            
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sourceFilePath = path;
            string destinationFilePath = Path.Combine(Path.GetDirectoryName(path), newNameToolStripMenuItem.Text ); 

            try
            {


                Directory.Move(sourceFilePath, destinationFilePath);
                path = destinationFilePath;
                fileNameToolStripMenuItem.Text = Path.GetFileName(path);
                MessageBox.Show("File renamed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }
    }
    }
