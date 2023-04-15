using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TemaXIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Rent> rentList;
        string xmlPath, jsonPath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void XMLBtn_Clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Documents|*.xml";
            if (openFileDialog.ShowDialog() == true)
            {
                xmlPath = openFileDialog.FileName;
                ParserXML xmlParser = new ParserXML(xmlPath);
                xmlParser.Parse();
                rentList = xmlParser.Rents;

                /*RandTabel este o clasa pentru ca obiectul de tip DataGrid sa faca automat conversia de la numele campurilor din clasa la nume de celule
                 Are nevoie de toate campurile pe acelasi nivel nu de o structura ierarhizata precum clasa Rent*/
                List<RandTabel> rents = new List<RandTabel>();

                foreach (Rent rnt in rentList)
                {
                    RandTabel tr = new RandTabel
                    {
                        CNP = rnt.persoana.CNP,
                        Cod = rnt.bike.cod,
                        Tip = rnt.bike.tip,
                        Nume = rnt.persoana.nume,
                        Prenume = rnt.persoana.prenume,
                        Tarif_ora = rnt.bike.tarif.ora,
                        Tarif_zi = rnt.bike.tarif.zi,
                        Telefon = rnt.persoana.telefon,
                        Data_ora_start = rnt.data_ora_start,
                        Data_ora_final = rnt.data_ora_final

                    };

                    rents.Add(tr);
                }

                DG_rents.ItemsSource = rents;
            }
        }

        private void JSONBtn_Clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json Documents|*.json";
            if (openFileDialog.ShowDialog() == true)
            {
                jsonPath = openFileDialog.FileName;
                ConvertorJSON convertorJSON = new ConvertorJSON(jsonPath);
                convertorJSON.Convert();
                rentList = convertorJSON.bike_rent.Rents;

                List<RandTabel> rents = new List<RandTabel>();

                foreach (Rent rnt in rentList)
                {
                    RandTabel tr = new RandTabel
                    {
                        CNP = rnt.persoana.CNP,
                        Cod = rnt.bike.cod,
                        Tip = rnt.bike.tip,
                        Nume = rnt.persoana.nume,
                        Prenume = rnt.persoana.prenume,
                        Tarif_ora = rnt.bike.tarif.ora,
                        Tarif_zi = rnt.bike.tarif.zi,
                        Telefon = rnt.persoana.telefon,
                        Data_ora_start = rnt.data_ora_start,
                        Data_ora_final = rnt.data_ora_final

                    };

                    rents.Add(tr);
                }

                DG_rents.ItemsSource = rents;
            }
        }

        private void XSLBtn_Clicked(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XSL Documents|*.xsl";
            if (openFileDialog.ShowDialog() == true)
            {
                XslTransformer xsltr = new XslTransformer(openFileDialog.FileName, xmlPath);
                xsltr.Transform();
            }
        }
    }
}
