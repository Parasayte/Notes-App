using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;


namespace menustrip
{
    public partial class Form1 : Form
    {
        string path;
        string savetext;
        Random random = new Random();
        public Form1(string path1)
        {
            InitializeComponent();
            path = path1;
          
        }
        public class Settings
        {
            public string ForeColor { get; set; }
            public string BackColor { get; set; }
            public string Font { get; set; }
            public string MenuStripBackColor { get; set; }
            public string MenuStripForeColor { get; set; }
        }

       private void SaveSettings()
{
    Settings settings = new Settings
    {
        ForeColor = $"{rcbx.ForeColor.R},{rcbx.ForeColor.G},{rcbx.ForeColor.B}",
        BackColor = $"{rcbx.BackColor.R},{rcbx.BackColor.G},{rcbx.BackColor.B}",
        Font = rcbx.Font.Name + "," + rcbx.Font.SizeInPoints,
        MenuStripBackColor = $"{menuStrip1.BackColor.R},{menuStrip1.BackColor.G},{menuStrip1.BackColor.B}",
        MenuStripForeColor = $"{menuStrip1.ForeColor.R},{menuStrip1.ForeColor.G},{menuStrip1.ForeColor.B}"
    };

    using (StreamWriter writer = new StreamWriter("settings.txt"))
    {
        writer.WriteLine(settings.ForeColor);
        writer.WriteLine(settings.BackColor);
        writer.WriteLine(settings.Font);
        writer.WriteLine(settings.MenuStripBackColor);
        writer.WriteLine(settings.MenuStripForeColor);
    }
}

        private void LoadSettings()
        {
            if (File.Exists("settings.txt"))
            {
                using (StreamReader reader = new StreamReader("settings.txt"))
                {
                    string foreColorLine = reader.ReadLine();
                    string backColorLine = reader.ReadLine();
                    string fontLine = reader.ReadLine();
                    string menuStripBackColorLine = reader.ReadLine();
                    string menuStripForeColorLine = reader.ReadLine();

                    if (foreColorLine != null && backColorLine != null && fontLine != null && menuStripBackColorLine != null && menuStripForeColorLine != null)
                    {
                        // Parse the RGB colors for RichTextBox
                        string[] foreColorParts = foreColorLine.Split(',');
                        string[] backColorParts = backColorLine.Split(',');
                        int foreR = int.Parse(foreColorParts[0]);
                        int foreG = int.Parse(foreColorParts[1]);
                        int foreB = int.Parse(foreColorParts[2]);
                        rcbx.ForeColor = Color.FromArgb(foreR, foreG, foreB);

                        int backR = int.Parse(backColorParts[0]);
                        int backG = int.Parse(backColorParts[1]);
                        int backB = int.Parse(backColorParts[2]);
                        rcbx.BackColor = Color.FromArgb(backR, backG, backB);

                        // Parse the font
                        string[] fontParts = fontLine.Split(',');
                        string fontName = fontParts[0];
                        float fontSize = float.Parse(fontParts[1]);
                        rcbx.Font = new Font(fontName, fontSize);

                        // Parse the MenuStrip colors
                        string[] menuStripBackColorParts = menuStripBackColorLine.Split(',');
                        string[] menuStripForeColorParts = menuStripForeColorLine.Split(',');
                        int menuStripBackR = int.Parse(menuStripBackColorParts[0]);
                        int menuStripBackG = int.Parse(menuStripBackColorParts[1]);
                        int menuStripBackB = int.Parse(menuStripBackColorParts[2]);
                        menuStrip1.BackColor = Color.FromArgb(menuStripBackR, menuStripBackG, menuStripBackB);

                        int menuStripForeR = int.Parse(menuStripForeColorParts[0]);
                        int menuStripForeG = int.Parse(menuStripForeColorParts[1]);
                        int menuStripForeB = int.Parse(menuStripForeColorParts[2]);
                        menuStrip1.ForeColor = Color.FromArgb(menuStripForeR, menuStripForeG, menuStripForeB);
                    }
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(path);
            rcbx.Text = sr.ReadToEnd();
            sr.Close();
            rcbx.BackColor = Color.White;
            rcbx.ForeColor = Color.Black;
           fileNameToolStripMenuItem.Text=Path.GetFileName(path);
            LoadSettings();
            newNameToolStripMenuItem.Text=Path.GetFileName(path);
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
            string colorHex1= "#ffffff";
            string rgb1 = "255, 255, 255";
           

            savehtml(rgb1,colorHex1);

        }

     private void savehtml(string rgb,string colorhex)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "HTML Files (*.html)|*.html|All Files (*.*)|*.*",
                Title = "Save an HTML File"
            };
            string text = rcbx.Text;


            string background = "https://i.imgur.com/aZznY5D.png";
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
            color: {colorhex}; /* Bright green color */
            margin: 20px 0; /* Add spacing around the title */
            text-shadow: 
                  0 0 10px rgba({rgb}, 1), 
                0 0 15px rgba({rgb}, 0.9), 
                0 0 20px rgba({rgb}, 0.7), 
                0 0 30px rgba({rgb}, 0.5); /* Focused glow with higher intensity */
        }}

        /* Content container with stronger glowing effect */
        .note-content {{
            font-size: 18px;
            color:{colorhex}; /* Bright green color */
            line-height: 1.6;
            letter-spacing: 0.5px;
            text-shadow: 
                0 0 10px rgba({rgb}, 1), 
                0 0 15px rgba({rgb}, 0.9), 
                0 0 20px rgba({rgb}, 0.7), 
                0 0 30px rgba({rgb}, 1.2); /* Focused glow with higher intensity */
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

                File.WriteAllText(saveFile.FileName, htmlcode);
            }
        }

        private void currentDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           
            rcbx.Text += "\n"+DateTime.Now.ToString();
        }

       
        private void fontToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = rcbx.Font;
            fontDialog.ShowDialog();
            rcbx.Font = fontDialog.Font;
            SaveSettings();
        }

       

        private void foreColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
          ColorDialog colorDialog = new ColorDialog();
          
            colorDialog.ShowDialog();
            rcbx.ForeColor = colorDialog.Color;
            SaveSettings();
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            colorDialog.ShowDialog();
            rcbx.BackColor = colorDialog.Color;
            SaveSettings();
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(rcbx.ZoomFactor<=64)
           { rcbx.ZoomFactor += 0.1F; }
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try    {
                rcbx.ZoomFactor -= 0.1F;
            }catch(Exception ex) { MessageBox.Show("This is the min Value!","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); }
        }

        private void defaultZommToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rcbx.ZoomFactor = 1.3F;
        }
        bool mod;
        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rcbx.ForeColor = Color.Black;
            rcbx.BackColor= Color.White;
            menuStrip1.BackColor = Color.FromArgb(240, 240, 240);
            menuStrip1.ForeColor = Color.Black;
            mod = false;
            SaveSettings();
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            rcbx.ForeColor = Color.WhiteSmoke;
            rcbx.BackColor = Color.FromArgb(28, 28, 28);
            menuStrip1.BackColor = Color.FromArgb(50, 50, 50);
          menuStrip1.ForeColor= Color.WhiteSmoke;
            mod=true;
            SaveSettings();
        }

        private void SearchText()
        {
            string searchText = searchToolStripMenuItem.Text;

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please enter text to search.");
                return;
            }

            rcbx.SelectAll();
          

            int startIndex = 0;
            bool found = false;

            while (startIndex < rcbx.TextLength)
            {
                int foundIndex = rcbx.Find(searchText, startIndex, RichTextBoxFinds.None);

                if (foundIndex == -1)
                    break;


                rcbx.Select(foundIndex, searchText.Length);
                rcbx.SelectionBackColor = Color.Yellow;

                startIndex = foundIndex + searchText.Length;

                found = true;
            }

            rcbx.Select(0, 0);

            if (!found)
            {
                MessageBox.Show("Text not found.");
            }
        }





        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savetext=rcbx.Text;
           rcbx.Text= string.Empty;
            restoreToolStripMenuItem.Enabled = true;
        }

       

     

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SearchText();
        }

       

        private void clearSelectedResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rcbx.SelectAll();
            if(mod)
            rcbx.SelectionBackColor = Color.FromArgb(28, 28, 28);
            else
            rcbx.SelectionBackColor = Color.White;
            rcbx.Select(0, 0);
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rcbx.Text += savetext;
            
        }

        private void exportAstxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
           
            string text = rcbx.Text;
          

            if (saveFile.ShowDialog() == DialogResult.OK)
            {

                File.WriteAllText(saveFile.FileName, text);
            }
        }

        private void foreColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string colorHex1 = "";
            string rgb1 = "";
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    Color color = colorDialog.Color;
                    colorHex1 = ColorTranslator.ToHtml(color);
                    rgb1 = $"{color.R}, {color.G}, {color.B}";
                   

                }
            }

            savehtml(rgb1, colorHex1);
        }

        private void fileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Path.GetFullPath(path));
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sourceFilePath = path;
            string destinationFilePath = Path.Combine(Path.GetDirectoryName(path), newNameToolStripMenuItem.Text + ".txt"); // Construct new file path

            try
            {
               
              
                File.Move(sourceFilePath, destinationFilePath);
                path = destinationFilePath;
                fileNameToolStripMenuItem.Text = Path.GetFileName(path);
                MessageBox.Show("File renamed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }
       
        private void randomEmojiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void randomFlagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int minCodePoint = 0x1F1E6; 
            int maxCodePoint = 0x1F1FF;  

            int firstLetter = random.Next(minCodePoint, maxCodePoint + 1);
            int secondLetter = random.Next(minCodePoint, maxCodePoint + 1);

            string flagEmoji = char.ConvertFromUtf32(firstLetter) + char.ConvertFromUtf32(secondLetter);

            rcbx.Text += flagEmoji;
        }

        private void randomFaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int minCodePoint = 0x1F600;  
            int maxCodePoint = 0x1F64F;  
            int randomCodePoint = random.Next(minCodePoint, maxCodePoint + 1);
            rcbx.Text += char.ConvertFromUtf32(randomCodePoint);
        }

        private void randomPlaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int minCodePoint = 0x1F3E0;  
            int maxCodePoint = 0x1F3FF;  
            int randomCodePoint = random.Next(minCodePoint, maxCodePoint + 1);
            rcbx.Text += char.ConvertFromUtf32(randomCodePoint);
        }

        private void randomAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int minCodePoint = 0x1F400; 
            int maxCodePoint = 0x1F43E;  
            int randomCodePoint = random.Next(minCodePoint, maxCodePoint + 1);
            rcbx.Text += char.ConvertFromUtf32(randomCodePoint);
        }

        private void randomFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int minCodePoint = 0x1F34F; 
            int maxCodePoint = 0x1F37F;  
            int randomCodePoint = random.Next(minCodePoint, maxCodePoint + 1);
            rcbx.Text += char.ConvertFromUtf32(randomCodePoint);
        }

        private void randomNatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int minCodePoint = 0x1F33F;  
            int maxCodePoint = 0x1F3F4;  
            int randomCodePoint = random.Next(minCodePoint, maxCodePoint + 1);
            rcbx.Text += char.ConvertFromUtf32(randomCodePoint);
        }

        private void randomObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int minCodePoint = 0x1F4A0;  
            int maxCodePoint = 0x1F9F8;  
            int randomCodePoint = random.Next(minCodePoint, maxCodePoint + 1);
            string hexCodePoint = randomCodePoint.ToString("X");

            rcbx.Text += char.ConvertFromUtf32(randomCodePoint);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void pathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Path.GetFullPath(path));
        }
    }
}
