using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APlayer
{

    public partial class Form1 : Form
    {
        static string[] mediaExtensions = {
    ".AVI", ".MP4", ".DIVX", ".WMV", ".MKV" //etc
};
        static bool IsMediaFile(string path)
        {
            return -1 != Array.IndexOf(mediaExtensions, Path.GetExtension(path).ToUpperInvariant());
        }

        private string saveFile = "./saves";
        private string lastEpsiode = "./lastEpisode";

        public Form1()
        {
            InitializeComponent();

            if (File.Exists(saveFile))
            {
                using (StreamReader sr = File.OpenText(saveFile))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        seriesList.Items.Add(Path.GetFileName(s));
                        seriesList.SelectedIndex = 0;
                        processDirectory(s);
                    }
                    sr.Close();
                }
                UpdateForm();
            }
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;
                pathLabel.Text = Path.GetFileName(path);
                pathLabel.Visible = true;

                seriesList.Items.Add(Path.GetFileName(path));
                seriesList.SelectedIndex = seriesList.Items.Count - 1;

                bool found = false;
                if (File.Exists(saveFile))
                {
                    using (StreamReader sr = File.OpenText(saveFile))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null && !found)
                        {
                            Console.WriteLine(s);
                            if (s == path)
                            {
                                found = true;
                            }
                        }
                        sr.Close();
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Not Fund");
                    using (StreamWriter sw = File.AppendText(saveFile))
                    {
                        sw.WriteLine(path);
                        sw.Close();
                    }
                    processDirectory(path);
                }
                else
                {
                    Console.WriteLine("Series already red");
                }

            }
        }

        private void processDirectory(string path)
        {
            foreach (string episode in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))
            {
                if (File.Exists(episode) && IsMediaFile(episode))
                {
                    addEpisode(episode);
                }
                else if (Directory.Exists(episode))
                {
                    processDirectory(episode);
                }
            }
        }

        private void addEpisode(string path)
        {
            episodesList.Items.Add(path).Text = Path.GetFileName(path);
            episodesList.Items[episodesList.Items.Count - 1].Name = path;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(continueBtn.Text.Split(' ')[1]);
            Console.WriteLine(continueBtn.Tag);
            int index = episodesList.Items.IndexOfKey(continueBtn.Tag.ToString().Split('*')[0]);
            string nextEpisode = episodesList.Items[index + 1].Name;
            Form2 player = new Form2(continueBtn.Tag.ToString(), true, nextEpisode);
            player.Show();
            this.Hide();
        }

        private void episodeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Console.WriteLine(episodesList.SelectedItems[0].Name);
            int index = episodesList.Items.IndexOfKey(episodesList.SelectedItems[0].Name);
            string nextEpisode = episodesList.Items[index + 1].Name;
            Console.WriteLine($"{nextEpisode}");
            Form2 player = new Form2(episodesList.SelectedItems[0].Name, false, nextEpisode);
            player.Show();
            this.Hide();
        }

        public void UpdateForm()
        {
            if (File.Exists(lastEpsiode))
            {
                using (StreamReader sr = File.OpenText(lastEpsiode))
                {
                    string path = sr.ReadLine();
                    continueBtn.Text = "Continue: " + Path.GetFileName(path.Split('*')[0]);
                    continueBtn.Tag = path;
                    sr.Close();
                }
            }
        }
    }
}
