using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Xml;
namespace XMLtest
{
    class Program
    {
        static void Main(string[] args)
        {  
       // Console.WriteLine("Value for db:" + ConfigurationManager.AppSettings.Get("db"));
            foreach(string k in ConfigurationManager.AppSettings.AllKeys)
                Console.WriteLine("Value for key "+k+" is "+ConfigurationManager.AppSettings.Get(k));

            XmlTextReader reader = new XmlTextReader("catalog.xml");
            while (reader.Read())
                Console.WriteLine(reader.ReadString());

            reader.Close();

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load("catalog.xml");
            XmlNodeList titleList = xmldoc.SelectNodes("/CATALOG/CD/TITLE");
            foreach (XmlNode tnode in titleList)
            {
                Console.WriteLine(tnode.InnerText);
            }





        Console.ReadKey();
        }
    }
}
