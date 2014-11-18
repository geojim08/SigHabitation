using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigHabitation
{
    class Residence
    {

        private String region;
        public String Region
        {
            get
            {
                return region;
            }
            set
            {
                region = value;
            }
        }

        private int noCentrix;
        public int NoCentrix
        {
            get
            {
                return noCentrix;
            }
            set
            {
                noCentrix = value;
            }
        }

        private String typeBatiment;
        public String TypeBatiment
        {
            get
            {
                return typeBatiment;
            }
            set
            {
                typeBatiment = value;
            }
        }

        private string url;
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }

        private int prix;
        public int Prix
        {
            get
            {
                return prix;
            }
            set
            {
                prix = value;
            }
        }

        private SigHabitation.Point localisation;
        public SigHabitation.Point Localisation
        {
            get
            {
                return localisation;
            }
            set
            {
                localisation = value;
            }
        }

        private Int16 nbPiece;
        public Int16 NbPiece
        {
            get
            {
                return nbPiece;
            }
            set
            {
                nbPiece = value;
            }
        }

        private Int16 nbChambre;
        public Int16 NbChambre
        {
            get
            {
                return nbChambre;
            }
            set
            {
                nbChambre = value;
            }
        }

        private Int16 nbSalleBain;
        public Int16 NbSalleBain
        {
            get
            {
                return nbSalleBain;
            }
            set
            {
                nbSalleBain = value;
            }
        }
    }
}
