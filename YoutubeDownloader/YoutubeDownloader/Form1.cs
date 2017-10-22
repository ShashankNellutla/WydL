using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;



namespace YoutubeDownloader
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);


        }




        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
           string url = (string)e.Data.GetData(DataFormats.Text);
            tb.Text = url;
           dwb.PerformClick();
        }



        private void dwb_Click(object sender, EventArgs e)
        {

            string filename = @"D:\youtube-dl.exe";
            string args = "--no-check-certificate " + tb.Text + " -o " + "\"" + textBox1.Text + @"\" + getfilename(tb.Text) + "\"";

            string output = null;
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = filename,
                    Arguments = args,
                    UseShellExecute = false
                    //RedirectStandardOutput = true,
                  //  RedirectStandardError = true
                   // CreateNoWindow = true
                }
            };
          //  MessageBox.Show(filename + " " + args);
            proc.Start();
            proc.WaitForExit();

            /*
            while (!proc.StandardOutput.EndOfStream)
            {
                output = proc.StandardOutput.ReadToEnd() + proc.StandardError.ReadToEnd();
            }
            */

            MessageBox.Show("Success!", "WydL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(textBox1.Text);
          //  MessageBox.Show(output);



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public string getfilename(string url)
        {
            string filename = @"D:\youtube-dl.exe";
            string args = "--no-check-certificate --get-filename " + tb.Text;
            string output = null;
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = filename,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();


            
            while (!proc.StandardOutput.EndOfStream)
            {
                output = proc.StandardOutput.ReadToEnd();
            }
            return output.Trim();



        }




        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.ShowDialog();

            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\WydL Downloads";
            Directory.CreateDirectory(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(getfilename(tb.Text));
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            if (tb.Text.Contains("youtube.com")) {
                MessageBox.Show("now get qualities");
            }
        }

        private void restartWydLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void visitWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ShashankNellutla/WydL");
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WydL v1.0\n\nA simple interface for the popular youtube-dl console application\n\nVisit https://github.com/ShashankNellutla/WydL\n\nCopyrights © 2017 Shashank Nellutla", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}