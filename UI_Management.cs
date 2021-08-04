using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Threading;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label5.Text = " ";
            Thread.Sleep(500);
            label8.Text = " ";
            label9.Text = " ";
            label11.Text = " ";
            label6.Text = " ";
            label7.Text = " ";
           
            label10.Text = " ";
            label12.Text = " ";
            label14.Text = " ";
            label4.Text = " ";
            label13.Text = " ";
            Thread.Sleep(500);
            label16.Text = " ";
            label2.Text = " ";
            
        }
         


        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter outputFile = new StreamWriter("startcommand.txt"))
            {
                outputFile.Write("Start");
                outputFile.Close();
            }
            Thread.Sleep(5000);
            Process.Start("ConsoleApp1");
            Thread.Sleep(5000);
            File.Delete("startcommand.txt");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            using (StreamWriter outputFile = new StreamWriter("initialize.txt"))
            {
                outputFile.Write("Begin");
                Thread.Sleep(500);
                outputFile.Close();
            }
            Process.Start("ConsoleApp2");


            Thread.Sleep(9000);
            File.Delete("initialize.txt");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void namecheck()
        {
            Info.ClearSelected();
            Thread.Sleep(500);
            textBox1.Text = " ";
            label16.Text = "Name Does Not Exist";
            Thread.Sleep(15);
            label16.Text = "";
            label5.Text = " ";
            label8.Text = " ";
            label9.Text = " ";
            label11.Text = " ";

            label6.Text = " ";
            label7.Text = " ";
            label10.Text = " ";
            label12.Text = " ";
            label14.Text = " ";
            label4.Text = " ";
            label13.Text = " ";
            label16.Text = " ";
        }
        private void Info_SelectedIndexChanged(object sender, EventArgs e)
        {
            //guild
            if (Info.GetItemChecked(0) == true)
            {
                try
                {
                    string webpagedata;
                    String ign = textBox1.Text;
                    using (System.Net.WebClient webClient = new System.Net.WebClient())
                        webpagedata = webClient.DownloadString("https://plancke.io/hypixel/player/stats/" + ign);
                    string Url = "https://plancke.io/hypixel/player/stats/" + ign;

                    if (webpagedata.Contains("Player does not exist!"))
                    {
                        Info.ClearSelected();
                        Thread.Sleep(500);
                        textBox1.Text = "";
                        label16.Text = "Name Does Not Exist";
                        Thread.Sleep(15);
                        label16.Text = " ";
                        label5.Text = " ";
                        label8.Text = " ";
                        label9.Text = " ";
                        label11.Text = " ";

                        label6.Text = " ";
                        label7.Text = " ";
                        label10.Text = " ";
                        label12.Text = " ";
                        label14.Text = " ";
                        label4.Text = " ";
                        label13.Text = " ";
                        label16.Text = " ";
                    }
                    else
                    {
                        label5.Text = "Guild:";
                        HtmlWeb web = new HtmlWeb();
                        HtmlWeb website = new HtmlWeb();
                        HtmlAgilityPack.HtmlDocument doc = web.Load(Url);
                        var status = webpagedata.Contains("Members:");
                        Thread.Sleep(500);
                        string xpath = "//*[@id=\"wrapper\"]/div[3]/div/div/div[2]/div[1]/div[2]/div/h4";

                        if (status == true)
                        {
                        
                            xpath = "//*[@id=\"wrapper\"]/div[3]/div/div/div[2]/div[1]/div[2]/div/a";
                            string admintotal = doc.DocumentNode.SelectNodes(xpath)[0].InnerText;
                            label6.Text = admintotal;
                        }
                        else
                        {
                            label6.Text = "No Guild";
                        }
                       
                    }
                }

                catch (WebException ex)
                {
                    if (ex.Status != WebExceptionStatus.ProtocolError)
                    {
                        throw ex;
                    }
                }



                }
            
            else
            {
                label6.Text = " ";
                label5.Text = " ";
            }
            //last login
            if (Info.GetItemChecked(1) == true)
            {
                try
                {
                    String webpaged;
                    String ign = textBox1.Text;
                    using (System.Net.WebClient webClient = new System.Net.WebClient())
                        webpaged = webClient.DownloadString("https://plancke.io/hypixel/player/stats/" + ign);
                    string Urls = "https://plancke.io/hypixel/player/stats/" + ign;

                    if (webpaged.Contains("Player does not exist!"))
                    {
                        Info.ClearSelected();
                        Thread.Sleep(500);
                        textBox1.Text = " ";
                        label16.Text = "Name Does Not Exist";
                        Thread.Sleep(15);
                        label16.Text = " ";
                        label5.Text = " ";
                        label8.Text = " ";
                        label9.Text = " ";
                        label11.Text = " ";

                        label6.Text = " ";
                        label7.Text = " ";
                        label10.Text = " ";
                        label12.Text = " ";
                        label14.Text = " ";
                        label4.Text = " ";
                        label13.Text = " ";
                        label16.Text = " ";
                    }
                    else
                    {
                        label8.Text = "Last Login:";
                        HtmlWeb webs = new HtmlWeb();
                        HtmlWeb websit = new HtmlWeb();
                        Thread.Sleep(500);
                        HtmlAgilityPack.HtmlDocument docs = webs.Load(Urls);
                        Thread.Sleep(500);
                        var status2 = webpaged.Contains("Lastlogin");

                        string xpath2 = "//*[@id=\"wrapper\"]/div[3]/div/div/div[2]/div[1]/div[1]/div/b[7]";

                        if (status2 == true)
                        {

                            xpath2 = "//*[@id=\"wrapper\"]/div[3]/div/div/div[2]/div[1]/div[1]/div/text()[9]";
                        }
                        string modtotal = docs.DocumentNode.SelectNodes(xpath2)[0].InnerText;

                        if (status2 == false)
                        {

                            label7.Text = " ";
                        }
                        else
                        {
                            label7.Text = modtotal;
                        }
                    }

                }
                catch (WebException ex)
                {
                    if (ex.Status != WebExceptionStatus.ProtocolError)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                label7.Text = " ";

                label8.Text = " ";
            }
            //first login                                                                                                                                                                                                                                                                                                      
            if (Info.GetItemChecked(2) == true)
            {
                try
                {
                    String webpaged;
                    Thread.Sleep(500);
                    String ign = textBox1.Text;
                    using (System.Net.WebClient webClient = new System.Net.WebClient())
                        webpaged = webClient.DownloadString("https://plancke.io/hypixel/player/stats/" + ign);
                    string Urls = "https://plancke.io/hypixel/player/stats/" + ign;
                    if (webpaged.Contains("Player does not exist!"))
                    {
                        Info.ClearSelected();
                        Thread.Sleep(500);
                        textBox1.Text = " ";
                        label16.Text = "Name Does Not Exist";
                        Thread.Sleep(15);
                        label16.Text = " ";
                        label5.Text = " ";
                        label8.Text = " ";
                        label9.Text = " ";
                        label11.Text = " ";

                        label6.Text = " ";
                        label7.Text = " ";
                        label10.Text = " ";
                        label12.Text = " ";
                        label14.Text = " ";
                        label4.Text = " ";
                        label13.Text = " ";
                        label16.Text = " ";
                    }
                    else
                    {
                        label9.Text = "First Login:";
                        HtmlWeb webs = new HtmlWeb();
                        Thread.Sleep(500);
                        HtmlWeb websit = new HtmlWeb();
                        HtmlAgilityPack.HtmlDocument docs = webs.Load(Urls);

                        var status2 = webpaged.Contains("Firstlogin");
                        Thread.Sleep(500);
                        string xpath2 = "//*[@id=\"wrapper\"]/div[3]/div/div/div[2]/div[1]/div[1]/div/b[6]";

                        if (status2 == true)
                        {

                            xpath2 = "//*[@id=\"wrapper\"]/div[3]/div/div/div[2]/div[1]/div[1]/div/text()[8]";
                        }
                        string modtotal = docs.DocumentNode.SelectNodes(xpath2)[0].InnerText;

                        if (status2 == false)
                        {
                            label10.Text = " ";
                        }
                        else
                        {
                            label10.Text = modtotal;

                        }
                    }
                }
                catch (WebException ex)
                {
                    if (ex.Status != WebExceptionStatus.ProtocolError)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                label10.Text = " ";
                label9.Text = " ";
            }
            //levels
            if (Info.GetItemChecked(3) == true)
            {

                String webpaged;
                String ign = textBox1.Text;
                Thread.Sleep(500);
                try
                {
                    using (System.Net.WebClient webClient = new System.Net.WebClient())
                        webpaged = webClient.DownloadString("https://plancke.io/hypixel/player/stats/" + ign);
                    string Urls = "https://plancke.io/hypixel/player/stats/" + ign;
                    if (webpaged.Contains("Player does not exist!"))
                    {
                        Info.ClearSelected();
                        Thread.Sleep(500);
                        textBox1.Text = " ";
                        label16.Text = "Name Does Not Exist";
                        Thread.Sleep(15);
                        label16.Text = " ";
                        label5.Text = " ";
                        label8.Text = " ";
                        label9.Text = " ";
                        label11.Text = " ";

                        label6.Text = " ";
                        label7.Text = " ";
                        label10.Text = " ";
                        label12.Text = " ";
                        label14.Text = " ";
                        label4.Text = " ";
                        label13.Text = " ";
                        label16.Text = " ";
                    }
                    else
                    {
                        HtmlWeb webs = new HtmlWeb();
                        HtmlWeb websit = new HtmlWeb();
                        Thread.Sleep(500);
                        HtmlAgilityPack.HtmlDocument docs = webs.Load(Urls);

                        var status2 = webpaged.Contains("Level");
                        string xpath2 = "//*[@id=\"wrapper\"]/div[3]/div/div/div[2]/div[1]/div[1]/div/b[4]";
                        Thread.Sleep(500);
                        if (status2 == true)
                        {

                            xpath2 = "//*[@id=\"wrapper\"]/div[3]/div/div/div[2]/div[1]/div[1]/div/text()[4]";
                        }
                        string modtotal = docs.DocumentNode.SelectNodes(xpath2)[0].InnerText;
                        if (status2 == false)
                        {
                            label12.Text = " ";
                        }
                        else
                        {
                            label11.Text = "Level:";

                            label12.Text = modtotal;

                        }
                    }

                }

                catch (WebException ex)
                {
                    if (ex.Status != WebExceptionStatus.ProtocolError)
                    {
                        label16.Text = "Name does not Exist";
                        throw ex;
                    
                    }
                }
            }
            else
            {
                label11.Text = " ";
                label12.Text = " ";
            }
               
             
                
            
            //Status
            if (Info.GetItemChecked(4) == true)
            {

                try
                {
                    String ign = textBox1.Text;

                    string webpagedata;
                    Thread.Sleep(500);
                    using (System.Net.WebClient webClient = new System.Net.WebClient())
                        webpagedata = webClient.DownloadString("https://plancke.io/hypixel/player/stats/" + ign);
                    if (webpagedata.Contains("Player does not exist!"))
                    {
                        Info.ClearSelected();
                        Thread.Sleep(500);
                        textBox1.Text = " ";
                        label16.Text = "Name Does Not Exist";
                        Thread.Sleep(15);
                        label16.Text = " ";
                        label5.Text = " ";
                        label8.Text = " ";
                        label9.Text = " ";
                        label11.Text = " ";

                        label6.Text = " ";
                        label7.Text = " ";
                        label10.Text = " ";
                        label12.Text = " ";
                        label14.Text = " ";
                        label4.Text = " ";
                        label13.Text = " ";
                        label16.Text = " ";
                    }
                    else
                    {
                        HtmlWeb web = new HtmlWeb();

                        var statusnameC = webpagedata.Contains("Members" + ign);
                        Thread.Sleep(500);
                        var status = webpagedata.Contains("GameType");
                        var status2 = webpagedata.Contains("Members");
                        Thread.Sleep(500);
                        var status3 = webpagedata.Contains("Offline");

                        string Url = "https://plancke.io/hypixel/player/stats/" + ign;
                        HtmlWeb website = new HtmlWeb();
                        HtmlAgilityPack.HtmlDocument doc = web.Load(Url);
                        Thread.Sleep(500);
                        string xpath = "//*[@id=\"wrapper\"]/div[3]/div/div/div[2]/div[1]/div[2]/div";
                        if (status2 == true)
                        {
                            Thread.Sleep(500);
                            xpath = "//*[@id=\"wrapper\"]/div[3]/div/div/div[2]/div[1]/div[3]";
                        }
                        string modtotal = doc.DocumentNode.SelectNodes(xpath)[0].InnerText;
                        if (status3 == true)
                        {
                            label13.Text = "Status:";

                            label14.Text = "Offline";
                        }
                        else
                        {
                            label13.Text = "Status: ";

                            label14.Text = modtotal;
                        }
                    }
                }
                catch (WebException ex)
                {
                    if (ex.Status != WebExceptionStatus.ProtocolError)
                    {
                        throw ex;
                    }
                }

            }
            else
            {
                label13.Text = " ";
                Thread.Sleep(500);
                label14.Text = " ";
            }
        

}
    
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Output_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Text = textBox1.Text;
            String ign=textBox1.Text;
            label2.Text = "Player Name: ";
            if (textBox1.Text == "") 
            {
                label2.Text = " ";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
           
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {   
            Info.ClearSelected();
            Thread.Sleep(5);
            textBox1.Text = " ";
            Thread.Sleep(15);
            label5.Text = " ";
            label8.Text = " ";
            label9.Text = " ";
            label11.Text = " ";
            Thread.Sleep(5);
            label6.Text = " ";
            label7.Text = " ";
            label10.Text = " ";
            label12.Text = " ";
            Thread.Sleep(5);
            label14.Text = " ";
            label4.Text = " ";
            label13.Text = " ";
            label16.Text = " ";
            label2.Text = " ";
            
        }
    }
}
    

