using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APlayer
{
    public partial class Form2 : Form
    {
        private string episodePath;
        private string nextEpisode;
        private bool isNext = false;
        public Form2(string episodePath, bool cont, string nextEpisode)
        {
            InitializeComponent();
            this.episodePath = episodePath;
            this.nextEpisode = nextEpisode;
            label1.Text = "Episode: " + Path.GetFileName(episodePath); 

            player.URL= episodePath.Split('*')[0];
            if (cont)
            {
                player.Ctlcontrols.currentPosition = Convert.ToDouble(episodePath.Split('*')[1]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isNext = false;
            this.Close();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isNext)
            {
                string lastEpisode = "./lastEpisode";
                double time = player.Ctlcontrols.currentPosition;
                if (time >= 1350)
                {
                    using (StreamWriter sw = File.CreateText(lastEpisode))
                    {

                        sw.WriteLine(this.nextEpisode + "*" + 0);
                    }
                }
                else
                {
                    time -= 5;

                    using (StreamWriter sw = File.CreateText(lastEpisode))
                    {

                        sw.WriteLine(episodePath.Split('*')[0] + "*" + time);
                    }
                }
                Form1 main = (Form1)Application.OpenForms[0];
                main.Show();
                main.UpdateForm();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            isNext = true;
            Form1 main = (Form1)Application.OpenForms[0];
            int index = main.episodesList.Items.IndexOfKey(this.nextEpisode);
            string nextEpisode = main.episodesList.Items[index + 1].Name;
            Form2 form = new Form2(this.nextEpisode, false, nextEpisode);
            form.Show();
            this.Close();
        }
    }
}
