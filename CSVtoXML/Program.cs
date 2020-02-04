using System;
using System.IO;
using System.Xml.Linq;

namespace TestTechnical
{
    class Program
    {
        static void Main(string[] args)
        {
            string csv = File.ReadAllText(@"C:\Users\DELL\source\repos\TestTechnical\TestTechnical\CandidateTest_ManifestExample.csv");
            XDocument doc = ConversorCsvXml.ConvertCsvToXML(csv, new[] { "," });
            doc.Save("outputxml.xml");
            Console.WriteLine(doc.Declaration);
            foreach (XElement c in doc.Elements())
            {
                Console.WriteLine(c);
            }
            Console.ReadLine();
        }
    }
}
