using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using HtmlAgilityPack;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Player checker by Jeffrey Li");
            Console.ForegroundColor = ConsoleColor.Blue;
            StreamReader sr = new StreamReader("startcommand.txt");
            string contents = sr.ReadToEnd();
            if (contents.Contains("Start"))
            {
                 string staff;
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Choose Staff or Manual");
                staff = Console.ReadLine();
                if (staff == "Staff")
                {
                    Mods();
                }
                else if (staff == "Manual")
                {
                    manual();
                }
            } while (staff == "Staff" || staff == "Manual");//checking stuff goes here
            }
            /*  StreamReader sr = new StreamReader("startcommand.txt");
              string contents = sr.ReadToEnd();
              if (contents.Contains("Start"))
              {

              }*/
           
           
            }
        static void Mods()
        {
            //staff checking 
            //reading names in from the pastebin
            //Mods
            Console.ForegroundColor = ConsoleColor.White;
            string webpagedata;
            int i = 0;
            var ign = "";
            int maxLines = 0;
            bool _isAllowed = false;
            string[] linefrompastebin = new string[1000];
            //mods list
            var url = "https://pastebin.com/raw/Nie86iXb";
            var client = new WebClient();
            //read in name
            using (var stream = client.OpenRead(url))
            using (var reader = new StreamReader(stream))
            {
                linefrompastebin[0] = " ";
                while ((linefrompastebin[i] = reader.ReadLine()) != null)
                {
                    i++;
                }
                maxLines = i;
            }
            for (i = 0; i < maxLines; i++)
            {
                Console.WriteLine(linefrompastebin[i]);
                ign = linefrompastebin[i];
                //sets url use to website set
                using (System.Net.WebClient webClient = new System.Net.WebClient())
                    webpagedata = webClient.DownloadString("https://plancke.io/hypixel/player/stats/" + ign);

                Console.ForegroundColor = ConsoleColor.White;
                HtmlWeb web = new HtmlWeb();

                var statusnameC = webpagedata.Contains("Members" + ign);
                var status = webpagedata.Contains("GameType");
                if (status == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                var status2 = webpagedata.Contains("Members");
                Console.WriteLine(ign + " is In-Game: " + status);
                string Url = "https://plancke.io/hypixel/player/stats/" + ign;
                HtmlWeb website = new HtmlWeb();
                HtmlDocument doc = web.Load(Url);
                string xpath = "//*[@id=\"wrapper\"]/div[3]/div/div/div[2]/div[1]/div[2]/div";
                if (status2 == true)
                {
                    xpath = "//*[@id=\"wrapper\"]/div[3]/div/div/div[2]/div[1]/div[3]";
                }
                string modtotal = doc.DocumentNode.SelectNodes(xpath)[0].InnerText;
                if (status == false)
                {
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine(modtotal);
                    Console.WriteLine(" ");

                }
                Console.ForegroundColor = ConsoleColor.White;
            }


        }




        
        static void manual()
        {
            string webpagedata;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Type the specified player that you want:");
            string ign = Console.ReadLine();
            using (System.Net.WebClient webClient = new System.Net.WebClient())
                webpagedata = webClient.DownloadString("https://plancke.io/hypixel/player/stats/" + ign);

            Console.ForegroundColor = ConsoleColor.White;
            HtmlWeb web = new HtmlWeb();

            var statusnameC = webpagedata.Contains("Members" + ign);
            var status = webpagedata.Contains("GameType");
            if (status == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            var status2 = webpagedata.Contains("Members");
            Console.WriteLine(ign + " is In-Game: " + status);
            string Url = "https://plancke.io/hypixel/player/stats/" + ign;
            HtmlWeb website = new HtmlWeb();
            HtmlDocument doc = web.Load(Url);
            string xpath = "//*[@id=\"wrapper\"]/div[3]/div/div/div[2]/div[1]/div[2]/div";
            if (status2 == true)
            {
                xpath = "//*[@id=\"wrapper\"]/div[3]/div/div/div[2]/div[1]/div[3]";
            }
            string admintotal = doc.DocumentNode.SelectNodes(xpath)[0].InnerText;
            if (status == false)
            {
                Console.WriteLine(" ");
            }
            else
            {
                Console.WriteLine(admintotal);
                Console.WriteLine(" ");

            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        }





    }


