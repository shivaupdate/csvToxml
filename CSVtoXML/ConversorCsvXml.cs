using System;
using System.Xml.Linq;

namespace TestTechnical
{
    /// <summary>
    /// Conversion the input file from csv format to XML
    /// </summary>
    public static class ConversorCsvXml
    {
        /// <summary>
        /// Conversion Method
        /// </summary>
        /// <param name="csvString">cvs string to converted</param>
        /// <param name="separatorField">separator used by the csv file</param>
        /// <returns>XDocument with the content of csv file in Xml Format</returns>
        public static XDocument ConvertCsvToXML(string csvString, string[] separatorField)

        {
            //split the rows
            var sep = new[] {"\r\n"};
            string[] rows = csvString.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            //Create the declaration
            var xsurvey = new XDocument(
                new XDeclaration("1.0", "UTF-8", "yes"));
            var xroot = new XElement("root"); //Create the root
            for (int i = 0; i < rows.Length; i++)
            {
                //Create each row
                if (i > 0)
                {
                    xroot.Add(rowCreator(rows[i], rows[0], separatorField));
                }
            }
            xsurvey.Add(xroot);
            return xsurvey;
        }

        /// <summary>
        /// Private. Take a csv line and convert in a row - var node
        /// with the fields values as attributes. 
        /// </summary>
        /// <param name="row">csv row to process</param>
        /// <param name="firstRow">First row with the fields names</param>
        /// <param name="separatorField">separator string use in the csv fields</param>
        /// <returns>XElement with the csv information of the inputed row</returns>
        private static XElement rowCreator(string row, string firstRow, string[] separatorField)
        {
            //var sep = new[] { "\t" };
            string[] temp = row.Split(separatorField, StringSplitOptions.None);
            string[] names = firstRow.Split(separatorField, StringSplitOptions.None);
            var xrow = new XElement("Order");
            for (int i = 0; i < temp.Length ; i++)
            {
                //Create the element var and Attributes with the field name and value
                var xvar = new XElement("var",
                                        new XAttribute("name", names[i]),
                                        new XAttribute("value", temp[i]));
                xrow.Add(xvar);
            }
            return xrow;
        }
    }
}