using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;

namespace SigHabitation
{
    class PageHTMLResidence
    {
        private Residence _residence;
        private String _pageHTML;
        private String _url;
        private XmlNode _racineSectionLatLonPrix;
        private XmlNode _racinePiece;

        

        public PageHTMLResidence(String url)
        {
            _residence = new Residence();
            _url = url;
            this.ChargerPageHTML();

        }
        
        #region PROPRIÉTÉS PUBLIQUES

        public String url
        {
            get
            {
                return _url;
            }
        }

        public String pageHTML
        {
            get
            {
                return _pageHTML;
            }
        }
       
        public Residence residence
        {
            get
            {
                return _residence;
            }
            set
            {
                _residence = value;
            }
        }

        #endregion

        #region MÉTHODES PUBLIQUES

        public void ChargerPageHTML()
        {
            HttpWebRequest requete;
            HttpWebResponse reponse;
            String sectionLatLonPrix;
            String sectionPiece;
            XmlDocument xmlSectionLatLonPrix;
            XmlDocument xmlPiece;
           

            requete = WebRequest.Create(this._url) as HttpWebRequest;
            reponse = requete.GetResponse() as HttpWebResponse;
            this._pageHTML = new StreamReader(reponse.GetResponseStream(), System.Text.Encoding.UTF8).ReadToEnd();
            sectionLatLonPrix = this._pageHTML.Substring(this._pageHTML.IndexOf("<div class=\"header\">"));
            sectionLatLonPrix = sectionLatLonPrix.Substring(0, sectionLatLonPrix.IndexOf("</h1>"));
            sectionLatLonPrix += "</h1></div>";
            sectionLatLonPrix = sectionLatLonPrix.Replace("&", String.Empty);

            xmlSectionLatLonPrix = new XmlDocument();
            xmlSectionLatLonPrix.LoadXml(sectionLatLonPrix);

            this._racineSectionLatLonPrix = xmlSectionLatLonPrix.DocumentElement;
              
            sectionPiece = this._pageHTML.Substring(this._pageHTML.IndexOf("<div class=\"col1\">"));
            sectionPiece = sectionPiece.Substring(0, sectionPiece.IndexOf("<div class=\"col2\">"));
            int index1erA = sectionPiece.IndexOf("<a");
            int index2eA = sectionPiece.IndexOf("/a");
            sectionPiece = sectionPiece.Remove(index1erA, index2eA - index1erA + 3);
            sectionPiece = sectionPiece.Remove(sectionPiece.IndexOf("<div class=\"tools\""));
            sectionPiece += "</div>";

            xmlPiece = new XmlDocument();
            xmlPiece.LoadXml(sectionPiece);

            this._racinePiece = xmlPiece.DocumentElement;
            
        }

        public SigHabitation.Point ParseLongitudeLatitude()
        {
            XmlNodeList noeudLatLon = this._racineSectionLatLonPrix.SelectNodes("//a");
            String urlGoogle = noeudLatLon.Item(0).Attributes[1].Value;
            String urlGoogleLatLonBrute = urlGoogle.Substring(urlGoogle.IndexOf("q=") + 2);
            String[] latLonBrute = urlGoogleLatLonBrute.Split(new Char[] { ',', 'h' });
            Double lat = Convert.ToDouble(latLonBrute[0].Replace('.', ','));
            Double lon = Convert.ToDouble(latLonBrute[1].Replace('.', ','));
            return new SigHabitation.Point(lon, lat);
            //this._residence.Localisation = emplacementResidence;
        }

        public int ParsePrix()
        {
            XmlNode noeudDivPrix = this._racineSectionLatLonPrix.SelectNodes("//div[@id='lblBuyPrice']").Item(0);
            String prixNonFormate = noeudDivPrix.InnerText;
            String prixAvecEspaceMilieu = prixNonFormate.Remove(prixNonFormate.IndexOf(" "));

            int prix;
            
            switch (prixAvecEspaceMilieu.Length)
            {
                case 6:
                    prix = Convert.ToInt32(prixAvecEspaceMilieu.Substring(0, 2) + prixAvecEspaceMilieu.Substring(3));
                    break;
                case 7:
                    prix = Convert.ToInt32(prixAvecEspaceMilieu.Substring(0, 3) + prixAvecEspaceMilieu.Substring(4));
                    break;
                case 9:
                    prix = Convert.ToInt32(prixAvecEspaceMilieu.Substring(0, 1) + prixAvecEspaceMilieu.Substring(2, 3) + prixAvecEspaceMilieu.Substring(6));
                    break;
                default:
                    throw new Exception("Le prix est supérieur à 999 999 $ ou inférieur à 100 000$.");

            }

            return prix;
        }

        public short ParseNombrePiece()
        {
            return Convert.ToInt16(this._racinePiece.SelectNodes("//div[@title='Pièce(s)']/span")[0].InnerText);
        }

        public short ParseNombreChambre()
        {
            return Convert.ToInt16(this._racinePiece.SelectNodes("//div[@title='Chambre(s) à coucher']/span")[0].InnerText);

        }

        public short ParseNombreSalleBain()
        {
            return Convert.ToInt16(this._racinePiece.SelectNodes("//div[@class='boxIcProp']")[2].ChildNodes[1].InnerText);

        }

        #endregion
    }
}
