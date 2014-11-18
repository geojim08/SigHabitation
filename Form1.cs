using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;


namespace SigHabitation
{
    public partial class Form1 : Form
    {
        private const string URL = "http://www.centris.ca/sitemaps/properties-daily.xml";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                

                HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                XmlNode root = xmlDoc.DocumentElement;
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
                nsmgr.AddNamespace("cent", "http://www.sitemaps.org/schemas/sitemap/0.9");

                XmlNodeList locationElements = root.SelectNodes("//cent:loc", nsmgr);
                response.Close();

                Residences residences = new Residences();

                SigHabitation.Residence residence;

                SigHabitation.AccesPostGis accesPostGis = new AccesPostGis("Server=192.168.0.102;Port=5432;User Id=postgres;Password=qwer;Database=postgis20;Integrated Security=true;");


                foreach (XmlElement element in locationElements)
                {
                    residence = new SigHabitation.Residence();
                    residence.Url = element.InnerText;

                    String[] tabUrl = residence.Url.Split(new char[] { '~' });
                    String typeTransaction = tabUrl[1];
                    String region = tabUrl[3];
                    String[] urlContexte = tabUrl[0].Split(new char[] { '/' });
                    String langue = urlContexte[3];
                    residence.TypeBatiment = urlContexte[4];
                    
                    if (langue == "fr" &&
                        typeTransaction == "a-vendre" &&
                        (region.Contains("lanaudiere") || region.Contains("laval") || region.Contains("laurentides") || region.Contains("monteregie")) &&
                        residence.TypeBatiment != "batisse-commerciale")
                    {

                        residence.NoCentrix = Convert.ToInt32(tabUrl[4].Split(new char[] { '/' })[1]);
                        residence.Region = region;

                        PageHTMLResidence pageHTMLCentrix = new PageHTMLResidence(residence.Url);
                        residence.Localisation = pageHTMLCentrix.ParseLongitudeLatitude();
                        residence.Prix = pageHTMLCentrix.ParsePrix();
                        residence.NbPiece = pageHTMLCentrix.ParseNombrePiece();
                        residence.NbSalleBain = pageHTMLCentrix.ParseNombreSalleBain();
                        residence.NbChambre = pageHTMLCentrix.ParseNombreChambre();

                        residences.Add(residence);
                        accesPostGis.InsertResidence(residence.NoCentrix,
                                                    residence.Prix,
                                                    residence.TypeBatiment,
                                                    residence.NbPiece,
                                                    residence.NbChambre,
                                                    residence.NbSalleBain,
                                                    residence.Region,
                                                    residence.Localisation,
                                                    residence.Url);
                    }
                }
                accesPostGis.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }
    }
}
