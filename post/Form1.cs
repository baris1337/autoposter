using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Remote;
using System.IO;
using Microsoft.Win32;
using System.Net;
using OpenQA.Selenium.Interactions;
using post.Properties;

namespace post
{//baris1337
    public partial class Form1 : MaterialForm
    {
        
        IWebDriver driver = new ChromeDriver();


        private readonly MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        int siktirpic = 5000;
        int hesap = -1;
        int sa = -1;
        int ass = -1;
        int amcik = 0;
        int zombi = 0;
        int bariskral = 0;
        private int index;
        private int index2;
        int beklepic = 0;

        string yarraq = "";
        public Form1()
        {

            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
           

            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)
           
        {
            this.TopMost = true;



            try
            {
                WebClient discord = new WebClient();
                string link = discord.DownloadString("https://textbin.net/raw/r0crci2tqn");

                yarraq = link;
            }
            catch (Exception ex)
            {

            }

            this.TopMost = false;

            string getFiles = "friends.txt";

            List<string> textlines = File.ReadAllLines(getFiles).ToList();

            foreach (var line in textlines)
            {
                listBox1.Items.Add(line);
            }

            materialMultiLineTextBox1.AppendText("[HTTP] Chromedriver.exe Found.");
            materialMultiLineTextBox1.Text += Environment.NewLine;

            materialMultiLineTextBox2.AppendText("[HTTP] Chromedriver.exe Found.");
            materialMultiLineTextBox2.Text += Environment.NewLine;
        }


        private void materialButton3_Click(object sender, EventArgs e)
        {
            backgroundWorker3.RunWorkerAsync();

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {




            if (listBox2.Items.Count == 0)
            {
                MessageBox.Show("You have to tag atleast 1 person", "barisposter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {
                startpost.Enabled = false;
                materialButton4.Enabled = true;
                materialButton8.Enabled = false;
                materialButton6.Enabled = false;


                startnumbertext.Enabled = false;
                stopnumbertext.Enabled = false;
                linktext.Enabled = false;
                teamnametext.Enabled = false;
                listBox2.Enabled = false;
                materialCheckbox1.Enabled = false;
                group.Enabled = false;


                try
                {
                    listBox2.SelectedIndex = -1;
                    amcik = 0;
                    backgroundWorker2.RunWorkerAsync();

                }
                catch (Exception ex)
                {

                }
            }
        }

        private void stoppost_Click(object sender, EventArgs e)
        {
          
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listBox1.Items.Count > 0)

                using (TextWriter TW = new StreamWriter("friends.txt"))
                {

                    foreach (string itemText in listBox1.Items)
                    {
                        TW.WriteLine(itemText);

                    }
                }
            driver.Quit();
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
                if (p.ProcessName == "chromedriver")
                    p.Kill();
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
                if (p.ProcessName == "Google Crash Handler")
                    p.Kill();
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
                if (p.ProcessName == "barispost")
                    p.Kill();
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
                if (p.ProcessName == "barisposter")
                    p.Kill();

        }
        private void materialButton1_Click_2(object sender, EventArgs e)
        {
            if (entername.Text == "")
            {
                ;
            }               
            else
            {
                listBox1.Items.Add(entername.Text);
                entername.Text = "";
            }
        }
        private void materialButton2_Click(object sender, EventArgs e)
        {
            materialButton2.Enabled = false;
            materialButton5.Enabled = true;
            listBox1.Enabled = false;

            yolla.Enabled = false;
            yolla2.Enabled = false;
            yolla3.Enabled = false;
            check1.Enabled = false;
            check2.Enabled = false;
            check3.Enabled = false;


            try

            {
                zombi = 1;
                backgroundWorker1.RunWorkerAsync();
            }
           catch (Exception ex)
            {

            }
        }
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    index = listBox1.IndexFromPoint(e.Location);
                    {
                        if (index == listBox1.SelectedIndex)
                        {
                            contextMenuStrip1.Show();
                        }
                    }
                }
            }
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            materialButton2.Enabled = true;
            materialButton5.Enabled = false;
            listBox1.Enabled = true;
            check1.Enabled = true;
            check2.Enabled = true;
            check3.Enabled = true;
            yolla.Enabled = true;




            if (check2.Checked == true)
            {
                if (check3.Checked == false)
                {
                   
                    yolla2.Enabled = true;

                }
            }

            if (check3.Checked == true)
            {
                
                yolla2.Enabled = true;
                yolla3.Enabled = true;

            }



            try
            {
                zombi = 0;
            }

            catch(Exception ex) { }
          
        }
        private void materialButton7_Click(object sender, EventArgs e)
        {
            backgroundWorker4.RunWorkerAsync();
    }

        private void materialButton6_Click_1(object sender, EventArgs e)
        {
            int me = 0;
            driver.Navigate().GoToUrl("https://www.facebook.com/friends/list");
            IWebElement find = driver.FindElement(By.XPath("  (//div[contains(@tabindex,'0')])[7]"));
            find.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            try
            {
                IWebElement remove = driver.FindElement(By.XPath("(//span[contains(@dir,'auto')])[88]"));

                remove.Click();
            }
            catch (Exception ex)

            {            
                find.Click();
                IWebElement remove = driver.FindElement(By.XPath("(//span[contains(@dir,'auto')])[89]"));
                remove.Click();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                entername.Text = listBox1.SelectedItem.ToString();
                update.Show();
               materialButton1.Hide();
            }

            catch (Exception ex)
            {
            }
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.RemoveAt(index);
            }
            catch (Exception ex)
            {
            }

        }

        private void update_Click(object sender, EventArgs e)
        {
            try

            {
                int index = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(index);
                listBox1.Items.Insert(index, entername.Text);
                update.Hide();
                materialButton1.Show();
                entername.Text = "";
                index = -1;

            }

            catch
            {
                update.Hide();
                materialButton1.Show();
            }



        }
        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] getFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            List<string> textlines = File.ReadAllLines(getFiles[0]).ToList();

            foreach (var line in textlines)
            {
                listBox1.Items.Add(line);
            }
        }

        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (zombi == 0)
            {

            }

            else
            {


                sa++;
                try
                {
                    listBox1.SelectedIndex = sa;
                }
                catch (Exception ex)

                {
                    //  MessageBox.Show("The message has been sent to all users.");
                    //materialButton5.PerformClick();

                    if (listBox1.SelectedIndex == listBox1.Items.Count - 1)
                    {
                        //    MessageBox.Show("The message has been sent to all users.");
                    }
                    else
                    {
                        sa++;
                    }
                }
                if (sa == -1)
                {
                    //
                }
                else
                {
                    try
                    {
                        IWebElement findtarget = driver.FindElement(By.XPath("(//span[contains(.,'" + (listBox1.SelectedItem) + "')])[4]"));
                        Actions actions = new Actions(driver);
                        actions.MoveToElement(findtarget);
                        actions.Perform();
                        findtarget.Click();
                        Thread.Sleep(1000);
                        IWebElement textsend = driver.FindElement(By.XPath("//div[contains(@class,'1mj')]"));


                        if (check2.Checked == false)
                        {
                            try
                            {
                                textsend.SendKeys(yolla.Text);
                                textsend.SendKeys(OpenQA.Selenium.Keys.Enter);
                                materialMultiLineTextBox2.AppendText("[LOG] Message Sent to [" + listBox1.SelectedItem + "]");
                                materialMultiLineTextBox2.Text += Environment.NewLine;
                            }

                            catch
                            {
                                sa++;
                            }

                        }



                        if (check2.Checked == true)
                        {
                            if (check3.Checked == false)
                            {
                                try
                                {
                                    textsend.SendKeys(yolla.Text);
                                    textsend.SendKeys(OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter);
                                    textsend.SendKeys(yolla2.Text);
                                    textsend.SendKeys(OpenQA.Selenium.Keys.Enter);
                                    materialMultiLineTextBox2.AppendText("[LOG] Message Sent to [" + listBox1.SelectedItem + "]");
                                    materialMultiLineTextBox2.Text += Environment.NewLine;
                                }

                                catch
                                {
                                    sa++;
                                }
                            }

                            else
                            {

                            }


                        }


                        if (check3.Checked == true)
                        {
                            try
                            {
                                textsend.SendKeys(yolla.Text);
                                textsend.SendKeys(OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter);
                                textsend.SendKeys(yolla2.Text);
                                textsend.SendKeys(OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter);
                                textsend.SendKeys(yolla3.Text);
                                textsend.SendKeys(OpenQA.Selenium.Keys.Enter);
                                materialMultiLineTextBox2.AppendText("[LOG] Message Sent to [" + listBox1.SelectedItem + "]");
                                materialMultiLineTextBox2.Text += Environment.NewLine;
                            }
                            catch
                            {
                                sa++;
                            }

                        }



                        //z
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (listBox1.SelectedIndex != listBox1.Items.Count - 1)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                materialButton5.PerformClick();
                sa = -1;
            }
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (amcik == 1)
            {

            }

            else
            {

            
            double sa = Convert.ToDouble(startnumbertext.Text);
            double ass = Convert.ToDouble(stopnumbertext.Text);
            checkBox1.Checked = false;
                try
                {
                    listBox2.SelectedIndex++;

                    if (group.Checked == true)
                    {
                        IWebElement postclickx = driver.FindElement(By.XPath("(//div[contains(@class,'5xu4')])[4]"));
                        postclickx.Click();

                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //5
                        IWebElement textarea = driver.FindElement(By.XPath("//textarea[@data-sigil='composer-textarea m-textarea-input']"));
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //5
                        textarea.SendKeys("#" + teamnametext.Text);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //5
                        textarea.SendKeys(OpenQA.Selenium.Keys.Enter);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //5

                        if (materialCheckbox1.Checked == true)
                        {
                            textarea.SendKeys(linktext.Text);
                            textarea.SendKeys(OpenQA.Selenium.Keys.Enter);
                            textarea.SendKeys(linktext.Text);
                        }

                        else
                        {
                            textarea.SendKeys(linktext.Text);

                        }


                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //5
                        textarea.SendKeys(OpenQA.Selenium.Keys.Enter);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //5
                        textarea.SendKeys("#" + sa++.ToString());
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //5
                        textarea.SendKeys(OpenQA.Selenium.Keys.Enter);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //hata olabri


                        textarea.SendKeys("barisposter.xyz");


                        if (listBox2.Items.Count == 1)
                        {
                            IWebElement tagfindz = driver.FindElement(By.XPath("(//div[@class='_4g34 _6ity'])[2]"));
                            tagfindz.Click();

                            IWebElement tagtextz = driver.FindElement(By.XPath("(//input[contains(@type,'search')])[2]"));
                            tagtextz.SendKeys(listBox2.SelectedItem.ToString());

                            IWebElement tagclickz = driver.FindElement(By.XPath("(//div[@class='_5rme _4g34 _5i2i  _52we'])[1]"));
                            tagclickz.Click();

                            IWebElement bittiz = driver.FindElement(By.XPath("//button[@class='btn btnI bgb mfss touchable']"));
                            bittiz.Click();
                            listBox2.SelectedIndex = -1;
                        }


                        if (listBox2.Items.Count == 2)
                        {
                            IWebElement tagfindq = driver.FindElement(By.XPath("(//div[@class='_4g34 _6ity'])[2]"));
                            tagfindq.Click();

                            IWebElement tagtextq = driver.FindElement(By.XPath("(//input[contains(@type,'search')])[2]"));
                            tagtextq.SendKeys(listBox2.SelectedItem.ToString());

                            IWebElement tagclickq = driver.FindElement(By.XPath("(//div[@class='_5rme _4g34 _5i2i  _52we'])[1]"));
                            tagclickq.Click();
                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                            listBox2.SelectedIndex++;

                            IWebElement tagtext2q = driver.FindElement(By.XPath("(//input[contains(@type,'search')])[2]"));
                            tagtext2q.SendKeys(listBox2.SelectedItem.ToString());

                            IWebElement tagclick2q = driver.FindElement(By.XPath("(//div[@class='_5rme _4g34 _5i2i  _52we'])[1]"));

                            tagclick2q.Click();
                            IWebElement bittiq = driver.FindElement(By.XPath("//button[@class='btn btnI bgb mfss touchable']"));
                            bittiq.Click();

                            listBox2.SelectedIndex = -1;
                        }


                        if (listBox2.Items.Count == 3)
                        {

                            IWebElement tagfind = driver.FindElement(By.XPath("(//div[@class='_4g34 _6ity'])[2]"));
                            tagfind.Click();

                            IWebElement tagtext = driver.FindElement(By.XPath("(//input[contains(@type,'search')])[2]"));
                            tagtext.SendKeys(listBox2.SelectedItem.ToString());

                            IWebElement tagclick = driver.FindElement(By.XPath("(//div[@class='_5rme _4g34 _5i2i  _52we'])[1]"));
                            tagclick.Click();
                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                            listBox2.SelectedIndex++;

                            IWebElement tagtext2 = driver.FindElement(By.XPath("(//input[contains(@type,'search')])[2]"));
                            tagtext2.SendKeys(listBox2.SelectedItem.ToString());

                            IWebElement tagclick2 = driver.FindElement(By.XPath("(//div[contains(@class,'_5rmf')])[1]"));

                            tagclick2.Click();

                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                            listBox2.SelectedIndex++;

                            IWebElement tagtext3 = driver.FindElement(By.XPath("(//input[contains(@type,'search')])[2]"));
                            tagtext3.SendKeys(listBox2.SelectedItem.ToString());

                            IWebElement tagclick3 = driver.FindElement(By.XPath("(//div[@class='_5rme _4g34 _5i2i  _52we'])[1]"));
                            tagclick3.Click();

                            IWebElement bitti = driver.FindElement(By.XPath("//button[@class='btn btnI bgb mfss touchable']"));
                            bitti.Click();

                            listBox2.SelectedIndex = -1;
                        }

                        //  Thread.Sleep(2500); //YARRRRRAAAAL

                        startnumbertext.Text = sa.ToString();

                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        IWebElement sharebutton = driver.FindElement(By.XPath("(//button[contains(@data-sigil,'composer')])[5]"));

                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);




                        sharebutton.Click();
                        System.Threading.Thread.Sleep(1000);
                        materialMultiLineTextBox1.AppendText("[LOG] Sent post [" + sa + "]");
                        materialMultiLineTextBox1.Text += Environment.NewLine;
                        startnumbertext.Text = sa++.ToString();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                        Thread.Sleep(siktirpic);


                        if (listBox2.SelectedIndex + 1 == listBox2.Items.Count)
                        {
                            listBox2.SelectedIndex = -1;
                        }



                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                    }

                    else
                    {
                        IWebElement postclick = driver.FindElement(By.XPath("(//div[@class='_5xu4'])[2]"));
                        postclick.Click();

                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //5
                        IWebElement textarea = driver.FindElement(By.XPath("//textarea[contains(@id,'uniqid_1')]"));
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //5
                        textarea.SendKeys("#" + teamnametext.Text);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //5
                        textarea.SendKeys(OpenQA.Selenium.Keys.Enter);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //5

                        if (materialCheckbox1.Checked == true)
                        {
                            textarea.SendKeys(linktext.Text);
                            textarea.SendKeys(OpenQA.Selenium.Keys.Enter);
                            textarea.SendKeys(linktext.Text);
                        }

                        else
                        {
                            textarea.SendKeys(linktext.Text);

                        }


                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //5
                        textarea.SendKeys(OpenQA.Selenium.Keys.Enter);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //5
                        textarea.SendKeys("#" + sa++.ToString());
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //5
                        textarea.SendKeys(OpenQA.Selenium.Keys.Enter);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //hata olabri


                        textarea.SendKeys("barisposter.xyz");


                        if (listBox2.Items.Count == 1)
                        {
                            IWebElement tagfindz = driver.FindElement(By.XPath("(//div[@class='_4g34 _6ity'])[2]"));
                            tagfindz.Click();

                            IWebElement tagtextz = driver.FindElement(By.XPath("(//input[contains(@type,'search')])[2]"));
                            tagtextz.SendKeys(listBox2.SelectedItem.ToString());

                            IWebElement tagclickz = driver.FindElement(By.XPath("(//div[contains(@class,'_5rmf')])[1]"));
                            tagclickz.Click();

                            IWebElement bittiz = driver.FindElement(By.XPath("//button[@class='btn btnI bgb mfss touchable']"));
                            bittiz.Click();
                            listBox2.SelectedIndex = -1;
                        }


                        if (listBox2.Items.Count == 2)
                        {
                            IWebElement tagfindq = driver.FindElement(By.XPath("(//div[@class='_4g34 _6ity'])[2]"));
                            tagfindq.Click();

                            IWebElement tagtextq = driver.FindElement(By.XPath("(//input[contains(@type,'search')])[2]"));
                            tagtextq.SendKeys(listBox2.SelectedItem.ToString());

                            IWebElement tagclickq = driver.FindElement(By.XPath("(//div[contains(@class,'_5rmf')])[1]"));
                            tagclickq.Click();
                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                            listBox2.SelectedIndex++;

                            IWebElement tagtext2q = driver.FindElement(By.XPath("(//input[contains(@type,'search')])[2]"));
                            tagtext2q.SendKeys(listBox2.SelectedItem.ToString());

                            IWebElement tagclick2q = driver.FindElement(By.XPath("(//div[contains(@class,'_5rmf')])[1]"));

                            tagclick2q.Click();
                            IWebElement bittiq = driver.FindElement(By.XPath("//button[@class='btn btnI bgb mfss touchable']"));
                            bittiq.Click();

                            listBox2.SelectedIndex = -1;
                        }


                        if (listBox2.Items.Count == 3)
                        {

                            IWebElement tagfind = driver.FindElement(By.XPath("(//div[@class='_4g34 _6ity'])[2]"));
                            tagfind.Click();

                            IWebElement tagtext = driver.FindElement(By.XPath("(//input[contains(@type,'search')])[2]"));
                            tagtext.SendKeys(listBox2.SelectedItem.ToString());

                            IWebElement tagclick = driver.FindElement(By.XPath("(//div[contains(@class,'_5rmf')])[1]"));
                            tagclick.Click();
                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                            listBox2.SelectedIndex++;

                            IWebElement tagtext2 = driver.FindElement(By.XPath("(//input[contains(@type,'search')])[2]"));
                            tagtext2.SendKeys(listBox2.SelectedItem.ToString());

                            IWebElement tagclick2 = driver.FindElement(By.XPath("(//div[contains(@class,'_5rmf')])[1]"));

                            tagclick2.Click();

                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                            listBox2.SelectedIndex++;

                            IWebElement tagtext3 = driver.FindElement(By.XPath("(//input[contains(@type,'search')])[2]"));
                            tagtext3.SendKeys(listBox2.SelectedItem.ToString());

                            IWebElement tagclick3 = driver.FindElement(By.XPath("(//div[contains(@class,'_5rmf')])[1]"));
                            tagclick3.Click();

                            IWebElement bitti = driver.FindElement(By.XPath("//button[@class='btn btnI bgb mfss touchable']"));
                            bitti.Click();

                            listBox2.SelectedIndex = -1;
                        }

                        //  Thread.Sleep(2500); //YARRRRRAAAAL

                        startnumbertext.Text = sa.ToString();

                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        IWebElement sharebutton = driver.FindElement(By.XPath("(//button[contains(@data-sigil,'composer')])[5]"));

                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);




                        sharebutton.Click();
                        System.Threading.Thread.Sleep(1000);
                        materialMultiLineTextBox1.AppendText("[LOG] Sent post [" + sa + "]");
                        materialMultiLineTextBox1.Text += Environment.NewLine;
                        startnumbertext.Text = sa++.ToString();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                        Thread.Sleep(siktirpic);


                        if (listBox2.SelectedIndex + 1 == listBox2.Items.Count)
                        {
                            listBox2.SelectedIndex = -1;
                        }


                    }

                }
            catch (Exception ex)
            {

            }

            }
        }



        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //  double sa = Convert.ToDouble(startnumbertext.Text);
            //  double ass = Convert.ToDouble(stopnumbertext.Text);

            if (startnumbertext.Text == stopnumbertext.Text)
            {
                try
                {

                    materialButton4.PerformClick();
                    backgroundWorker2.CancelAsync();
                }
                catch (Exception ex) { }

            }
            else
            {
                backgroundWorker2.RunWorkerAsync();


            }


        
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            {
                driver.Navigate().GoToUrl("https://m.facebook.com/");
                try
                {
                    IWebElement gmail = driver.FindElement(By.Name("email"));
                    gmail.SendKeys(gmailtext.Text);
                    IWebElement pass = driver.FindElement(By.Name("pass"));
                    pass.SendKeys(passtext.Text);
                    IWebElement login = driver.FindElement(By.Name("login"));
                    login.Click();

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //5
                    IWebElement loginfail = driver.FindElement(By.XPath("//a[contains(@class,'_54k8 _56bs _26vk _56b_ _56bw _56bt')]"));

                    try
                    {
                        loginfail.Click();
                        materialMultiLineTextBox1.AppendText("[SELENIUM] User Authenticate Success.");

                    }
                    catch
                    {
                        materialMultiLineTextBox1.AppendText("[SELENIUM] User Authenticate Failed. Wrong Password or Email.");
                    }


                    materialMultiLineTextBox1.Text += Environment.NewLine;
                    backgroundWorker3.CancelAsync();

                }
                catch (Exception ex)
                {
                }

            }
        }

       
        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            driver.Navigate().GoToUrl("https://facebook.com/messages/");
            try
            {
                IWebElement gmail = driver.FindElement(By.Name("email"));
                gmail.SendKeys(materialTextBox4.Text);
                IWebElement pass = driver.FindElement(By.Name("pass"));
                pass.SendKeys(materialTextBox3.Text);
                pass.SendKeys(OpenQA.Selenium.Keys.Enter);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //5

                materialMultiLineTextBox2.AppendText("[SELENIUM] User Authenticate Success.");
                materialMultiLineTextBox1.Text += Environment.NewLine;

            }
            catch (Exception ex)
            {
            }

            backgroundWorker4.CancelAsync();
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            startpost.Enabled = true;
            materialButton4.Enabled = false;
            materialButton8.Enabled = true;
            materialButton6.Enabled = true;

            startnumbertext.Enabled = true;
            stopnumbertext.Enabled = true;
            linktext.Enabled = true;
            teamnametext.Enabled = true;
            listBox2.Enabled = true;
            materialCheckbox1.Enabled = true;
            group.Enabled = true;

            try
            {
                amcik = 1;
                backgroundWorker2.CancelAsync();
            }
            catch (Exception ex)
            {
                
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         
        }

        private void tagadd_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count == 3)
            {
                tagadd.Hide();
                taggUpdate.Show();

            }

            if (listBox2.Items.Count < 3)
            {
                if (tagname.Text == "")
                {
                    ;
                }
                else
                {
                    listBox2.Items.Add(tagname.Text);
                    tagname.Text = "";
                }


            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void listBox2_MouseDown(object sender, MouseEventArgs e)
        {
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    index2 = listBox2.IndexFromPoint(e.Location);
                    {
                        if (index2 == listBox2.SelectedIndex)
                        {
                            contextMenuStrip2.Show();
                        }
                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                tagname.Text = listBox2.SelectedItem.ToString();
                taggUpdate.Show();
               tagadd.Hide();
            }

            catch (Exception ex)
            {
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.RemoveAt(index2);
            }
            catch (Exception ex)
            {
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void taggUpdate_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count < 3)
            {
                tagadd.Show();
                taggUpdate.Hide();

            }

            if (listBox2.Items.Count == 3)
            {
                tagadd.Hide();
                taggUpdate.Show();

            }



            try
            {
                int index2 = listBox2.SelectedIndex;
                listBox2.Items.RemoveAt(index2);
                listBox2.Items.Insert(index2, tagname.Text);
                taggUpdate.Hide();
                tagadd.Show();
                tagname.Text = "";
            }
            catch (Exception ex)
            {

            }

        }


        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {

                hesap++;
                try
                {
                    listBox2.SelectedIndex = hesap;
                }
                catch (Exception ex)

                {
               

                    if (listBox2.SelectedIndex == listBox2.Items.Count - 1)
                    {
                        //    MessageBox.Show("The message has been sent to all users.");
                    }
                    else
                    {
                        hesap++;
                    }
                }
                if (hesap == -1)
                {
                    //
                }
                else
                {
                    try
                    {
                        IWebElement findtarget = driver.FindElement(By.XPath("(//span[contains(.,'" + (listBox1.SelectedItem) + "')])[4]"));
                        Actions actions = new Actions(driver);
                        actions.MoveToElement(findtarget);
                        actions.Perform();
                        findtarget.Click();
                        Thread.Sleep(1000);
                        IWebElement textsend = driver.FindElement(By.XPath("//div[contains(@class,'1mj')]"));
                        textsend.SendKeys(yolla.Text);
                        textsend.SendKeys(OpenQA.Selenium.Keys.Enter);
                        materialMultiLineTextBox2.AppendText("[LOG] Message Sent to [" + listBox1.SelectedItem + "]");
                        materialMultiLineTextBox2.Text += Environment.NewLine;
                        //z
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
       

        private void backgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (listBox2.SelectedIndex == listBox2.Items.Count - 1)
            {
                listBox2.SelectedIndex = 0;
                backgroundWorker5.CancelAsync();
            }

            else
            {
                backgroundWorker5.RunWorkerAsync();
              
            }


        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {



        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            if (materialTextBox2.Text == "1000")
            {

            }
            else
            {
                int x = Int32.Parse(materialTextBox2.Text);
                siktirpic = x - 1000;

                materialTextBox2.Text = siktirpic.ToString();
            }



        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(materialTextBox2.Text);
            siktirpic = x + 1000;

            materialTextBox2.Text = siktirpic.ToString();
        }

        private void check1_CheckedChanged(object sender, EventArgs e)
        {
            if (check1.Checked == true)
            {
                yolla.Enabled = true;
                check1.Checked = true;
            }

            else
            {
                yolla.Enabled = true;
                check1.Checked = true;
            }

        }

        private void check2_CheckedChanged(object sender, EventArgs e)
        {
            if (check2.Checked == true)
            {
                yolla2.Enabled = true;
            }

            else
            {
                yolla2.Enabled = false;
                check3.Checked = false;
                yolla3.Enabled = false;

            }

        }

        private void check3_CheckedChanged(object sender, EventArgs e)
        {

            if (check2.Checked == true)
            {

                if (check3.Checked == true)
                {
                    yolla3.Enabled = true;
                }

                else
                {
                    yolla3.Enabled = false;

                }

            }

            else
            {

                check3.Checked = false;
            }

        }

        private void group_CheckedChanged(object sender, EventArgs e)
        {
            if (group.Checked == true)
            {
                driver.Navigate().Refresh();

            }
            else
            {
                driver.Navigate().Refresh();
            }


        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialButton10_Click(object sender, EventArgs e)
        {

        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            backgroundWorker3.RunWorkerAsync();
        }

        private void materialButton12_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker6_DoWork(object sender, DoWorkEventArgs e)
        {
            if (bariskral == 0)
            {

            }

            else
            {


               ass++;
                try
                {
                    listBox3.SelectedIndex = ass;
                }
                catch (Exception ex)

                {
                    //  MessageBox.Show("The message has been sent to all users.");
                    //materialButton5.PerformClick();

                    if (listBox3.SelectedIndex == listBox3.Items.Count - 1)
                    {
                        //    MessageBox.Show("The message has been sent to all users.");
                    }
                    else
                    {
                        ass++;
                    }
                }
                if (ass == -1)
                {
                    //
                }
                else
                {
                    try
                    {
                        IWebElement findtarget = driver.FindElement(By.XPath("(//span[contains(.,'" + (listBox1.SelectedItem) + "')])[4]"));
                        Actions actions = new Actions(driver);
                        actions.MoveToElement(findtarget);
                        actions.Perform();
                        findtarget.Click();
                        Thread.Sleep(1000);
                        IWebElement textsend = driver.FindElement(By.XPath("//div[contains(@class,'1mj')]"));


                        if (check2.Checked == false)
                        {
                            try
                            {
                                textsend.SendKeys(yolla.Text);
                                textsend.SendKeys(OpenQA.Selenium.Keys.Enter);
                                materialMultiLineTextBox2.AppendText("[LOG] Message Sent to [" + listBox1.SelectedItem + "]");
                                materialMultiLineTextBox2.Text += Environment.NewLine;
                            }

                            catch
                            {
                                sa++;
                            }

                        }



                        if (check2.Checked == true)
                        {
                            if (check3.Checked == false)
                            {
                                try
                                {
                                    textsend.SendKeys(yolla.Text);
                                    textsend.SendKeys(OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter);
                                    textsend.SendKeys(yolla2.Text);
                                    textsend.SendKeys(OpenQA.Selenium.Keys.Enter);
                                    materialMultiLineTextBox2.AppendText("[LOG] Message Sent to [" + listBox1.SelectedItem + "]");
                                    materialMultiLineTextBox2.Text += Environment.NewLine;
                                }

                                catch
                                {
                                    sa++;
                                }
                            }

                            else
                            {

                            }


                        }


                        if (check3.Checked == true)
                        {
                            try
                            {
                                textsend.SendKeys(yolla.Text);
                                textsend.SendKeys(OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter);
                                textsend.SendKeys(yolla2.Text);
                                textsend.SendKeys(OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter);
                                textsend.SendKeys(yolla3.Text);
                                textsend.SendKeys(OpenQA.Selenium.Keys.Enter);
                                materialMultiLineTextBox2.AppendText("[LOG] Message Sent to [" + listBox1.SelectedItem + "]");
                                materialMultiLineTextBox2.Text += Environment.NewLine;
                            }
                            catch
                            {
                                sa++;
                            }

                        }



                        //z
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
    }
    }

