using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TemaXIS
{
    class ParserXML
    {
        public string DocPath { get; }
        public List<Rent> Rents { get; }

        public ParserXML(string path) { this.DocPath = path; Rents = new List<Rent>(); }

        public void Parse()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(DocPath);

            /*lista cu nodurile principale de tip rent*/
            XmlNodeList rentsNodes = doc.DocumentElement.SelectNodes("/bike_rent/rent");
            foreach(XmlNode node in rentsNodes)
            {
                Bike bke = new Bike();
                Persoana prs = new Persoana();

                var bikeNode = node.SelectSingleNode("bike");
                bke.cod = int.Parse(bikeNode.Attributes.GetNamedItem("cod").InnerText);
                bke.tip = bikeNode.SelectSingleNode("tip").InnerText;
                
                var tarifNode = bikeNode.SelectSingleNode("tarif");
                Tarif tarif = new Tarif();
                tarif.ora = int.Parse(tarifNode.SelectSingleNode("ora").InnerText);
                tarif.zi = int.Parse(tarifNode.SelectSingleNode("zi").InnerText);
                bke.tarif = tarif;

                var persoanaNode = node.SelectSingleNode("persoana");
                prs.CNP = persoanaNode.Attributes.GetNamedItem("CNP").InnerText;
                prs.nume = persoanaNode.SelectSingleNode("nume").InnerText;
                prs.prenume = persoanaNode.SelectSingleNode("prenume").InnerText;
                prs.telefon = persoanaNode.SelectSingleNode("telefon").InnerText;

                /*parsare data dupa formatul ales de mine dd/MM/yyyy HH:mm */
                string startD = node.SelectSingleNode("data_ora_start").InnerText;
                DateTime startDate = DateTime.ParseExact(startD, " dd/MM/yyyy HH:mm ", CultureInfo.InvariantCulture);

                string finalD = node.SelectSingleNode("data_ora_final").InnerText;
               
                DateTime finalDate = new DateTime();
                if (finalD.Length != 0)
                    finalDate = DateTime.ParseExact(finalD, " dd/MM/yyyy HH:mm ", CultureInfo.InvariantCulture);

                Rents.Add(new Rent { bike = bke, persoana = prs, data_ora_start = startDate, data_ora_final = finalDate });
            }
        }
    }
}
