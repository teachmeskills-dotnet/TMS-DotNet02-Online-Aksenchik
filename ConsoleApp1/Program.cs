using System;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int idRating = 468373;

            Uri baseURI = new Uri("https://rating.kinopoisk.ru/");
            Uri newURI = new Uri(baseURI, $"{idRating}.xml");
            string xmlStr;
            using (var wc = new WebClient())
            {
                xmlStr = wc.DownloadString(newURI);
            }
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);

            if (xmlDoc is not null)
            {
                XmlNodeList saveItems = xmlDoc.SelectNodes("rating");
                XmlNode kinopoisk = saveItems.Item(0).SelectSingleNode("kp_rating");
                XmlNode imdb = saveItems.Item(0).SelectSingleNode("imdb_rating");
                var kinopoiskData = kinopoisk.InnerText;
                var ImdbData = imdb.InnerText;
                Console.WriteLine(ImdbData);
            }

            Console.ReadKey();
        }
    }
}
