using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;



namespace menustrip
{
    public partial class Form1 : Form
    {
        string path;

        public Form1(string path1)
        {
            InitializeComponent();
            path = path1;
            // Path to the Chrome executable. Modify this path if needed.
          
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(path);
            rcbx.Text = sr.ReadToEnd();
            sr.Close();
            rcbx.BackColor = Color.White;
            rcbx.ForeColor = Color.Black;
        }
      

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string parentPath = Path.GetDirectoryName(path);
            menu a = new menu(parentPath);
            a.Show();
            Hide();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("D:\\selam9");
            StreamWriter streamWriter = new StreamWriter(path);
            streamWriter.WriteLine(rcbx.Text);
            streamWriter.Close();
            MessageBox.Show("Saved Succefuly", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exportAsHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "HTML Files (*.html)|*.html|All Files (*.*)|*.*",
                Title = "Save an HTML File"
            };
            string text=rcbx.Text;
            string background = "https://thumbs2.imgbox.com/c5/20/UGltLs1g_t.png";
            string htmlcode = $@"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Note Display</title>
    <style>
        /* Global styles */
        body {{
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            padding: 0;
            display: flex;
            flex-direction: column; /* Stack elements vertically */
            justify-content: flex-start; /* Align items to the top */
            align-items: center;
            height: 100vh;
            color: #FFFFFF;
            margin: 0;
            overflow: hidden;
        }}

        /* Background image */
        body::before {{
            content: """";
            position: fixed; /* Keeps the background fixed in place */
            top: -20px; /* Expands the background beyond the viewport */
            left: -20px;
            right: -20px;
            bottom: -20px;
            background-image: url(""{background}"");
            background-attachment: fixed;
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
            z-index: -1; /* Ensures the background stays behind the content */
            margin: 0; /* Ensures no margin around the body */
            box-shadow: none; /* Removes shadow effects */
        }}

        /* Title styling with stronger glowing effect */
        .note-title {{
            font-size: 28px;
            font-weight: 600;
            color: #9ACD32; /* Bright green color */
            margin: 20px 0; /* Add spacing around the title */
            text-shadow: 
                0 0 40px rgba(154, 205, 50, 1), 
                0 0 80px rgba(154, 205, 50, 0.8), 
                0 0 120px rgba(154, 205, 50, 0.6),
                0 0 160px rgba(154, 205, 50, 0.4); /* Intensified glow */
        }}

        /* Content container with stronger glowing effect */
        .note-content {{
            font-size: 18px;
            color: #9ACD32; /* Bright green color */
            line-height: 1.6;
            letter-spacing: 0.5px;
            text-shadow: 
                0 0 40px rgba(154, 205, 50, 1), 
                0 0 80px rgba(154, 205, 50, 0.8), 
                0 0 120px rgba(154, 205, 50, 0.6),
                0 0 160px rgba(154, 205, 50, 0.4); /* Intensified glow */
            margin: 0 20px; /* Add horizontal spacing */
            text-align: center; /* Center-align content */
        }}

        /* Responsive design */
        @media (max-width: 600px) {{
            .note-title {{
                font-size: 24px;
            }}
            .note-content {{
                font-size: 16px;
            }}
        }}
    </style>
</head>
<body>
    <div class=""note-title"">{Path.GetFileName(path)}</div>
    <div class=""note-content"">
        {text}
    </div>
</body>
</html>";


            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                // Write the htmlcode to the selected file
                File.WriteAllText(saveFile.FileName, htmlcode);
            }

        }
    }
}
