using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GibCat
{
    
    public partial class Form1 : Form
    {
        string path;
        string url;
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            WebRequest wr = WebRequest.Create("https://api.thecatapi.com/v1/images/search");//+ string.Join("+", this.textBox1.Text.Split(' ')));
            WebResponse res = wr.GetResponse();
            using (StreamReader reader = new StreamReader(res.GetResponseStream()))
            {
                string json = reader.ReadToEnd();
               
                dynamic images = JsonConvert.DeserializeObject(json);
                
                string s = images.ToString();
                s = s.Replace("[", String.Empty);
                s = s.Replace("]", String.Empty);

                int n = 5;
                string[] lines = s
                    .Split(Environment.NewLine.ToCharArray())
                    .Skip(n)
                    .ToArray();

                string output = string.Join(Environment.NewLine, lines);
                output = "{" + output;
                try
                {
                    Cat c = JsonConvert.DeserializeObject<Cat>(output);
                  /*  pictureBox1.Width = c.width;
                    pictureBox1.Height = c.height;
                    this.Height = c.height + 100;
                    this.Width = c.width + 100;
                    pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
                    pictureBox1.Top = (this.ClientSize.Height - pictureBox1.Height) / 2;  */
                  //  button1.Left = (this.ClientSize.Width - button1.Width) / 2;
                  //  button1.Top = (this.ClientSize.Height - button1.Height) / 2;
                    // Form1.Size = new System.Drawing.Size(100, 100);
                    this.pictureBox1.Load(c.url);//(images["0"].imglink.Value);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom ;
                   // public void downloadImage()
                    {
                        //  WebClient webClient = new WebClient();
                        url = c.url;
                        if (url.EndsWith("gif"))
                        {
                            path = "C:\\Users\\admin.INL082\\source\\repos\\GibCat\\SavedImages\\" +  c.id + ".gif";
                        }
                        else
                        {
                            path = "C:\\Users\\admin.INL082\\source\\repos\\GibCat\\SavedImages\\"  + c.id + ".jpg";
                        }
                        //  webClient.DownloadFile(c.url, path);
                      //  richTextBox1.Text = output;

                    }



                }

                catch (Newtonsoft.Json.JsonReaderException )
                {
                   // richTextBox1.Text = output;
                }
                // Cat c = new Cat(images.breeds);
                //  s = s.Replace(" ", String.Empty);

                // s = s.Replace("\"", String.Empty);
                //   s = s.Replace(" ", String.Empty);

                // richTextBox1.Text = output;
                // richTextBox2.Text = s;
                
                    
                
                // pictureBox1.ImageLocation = imgLink;
                // pictureBox1.Image = Bitmap.FromStream(stream);
            }
            
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //downloadImage();
            Task.Run(() =>
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(url, path);
            });
        }
    }
}