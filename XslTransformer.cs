using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace TemaXIS
{
    class XslTransformer
    {
        public string xslPath { get; }
        public string xmlPath { get; }

        public XslTransformer(string xslPath, string xmlPath)
        {
            this.xslPath = xslPath;
            this.xmlPath = xmlPath;
        }
        public void Transform()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xslPath);
            string newPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(xmlPath), System.IO.Path.GetFileNameWithoutExtension(xmlPath) + ".html");
            try
            {
                xslt.Transform(xmlPath, newPath);
                MessageBox.Show(string.Format("HTML file succesfully created at {0}", newPath), "", MessageBoxButton.OK, MessageBoxImage.Information);

            }catch(Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            
            
        }
    }
}
