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
using System.Net;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Net;

namespace post
{
    public partial class Form2 : MaterialForm
    {
        string hwid;
        private readonly MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        public Form2()
        {
            InitializeComponent();
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

           
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            hwid = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;

            hwidsa.Text = hwid;


            {

                string sa = "friends.txt";
                

                bool fileExist = File.Exists(sa);
                if (fileExist)
                {

                }

                else

                {
                    using (StreamWriter sw = File.CreateText(sa)) ;
                }

                
                }
            }

        private void timer1_Tick(object sender, EventArgs e)
        {
         
        }

        private void ok_Click(object sender, EventArgs e)
        {
          
        }

      

        private void materialButton1_Click(object sender, EventArgs e)
        {

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (!File.Exists("WebdDriver.dll"))
            {
                WebClient zortt = new WebClient();
               zortt.DownloadFile("https://cdn.discordapp.com/attachments/807651439346319413/908764163281670174/WebDriver.dll", "WebDriver.dll");
            }

            WebClient sa = new WebClient();
            string hwidlist = sa.DownloadString("https://github.com/baris1337/hwid/blob/main/hwid.txt");
            if (hwidlist.Contains(hwidsa.Text))
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Your hwid is not whitelisted. Dm baris#6966 to purchase.", "Hwid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void hwidsa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hwid copied to clipboard.", "barisposter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clipboard.SetText(hwidsa.Text);
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hwid copied to clipboard.", "barisposter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clipboard.SetText(hwidsa.Text);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            backgroundWorker1.CancelAsync();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void hwidsa_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

