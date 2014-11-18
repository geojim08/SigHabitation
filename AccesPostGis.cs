using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Globalization;

namespace SigHabitation
{
    class AccesPostGis
    {
        private NpgsqlConnection _connexion;
        
        public AccesPostGis(String connectionString)
        {
            this._connexion = new NpgsqlConnection(connectionString);
            this._connexion.Open();

        }


        public int InsertResidence(int no_centrix,
                                   int prix,
                                   String type_bat,
                                   Int16 nb_piece,
                                   Int16 nb_chambre,
                                   Int16 nb_salle_bain, 
                                   String region,
                                   SigHabitation.Point geom,
                                   String url)
        {
            StringBuilder strBuilder = new StringBuilder();
            NpgsqlCommand commande;
            Int32 rangeeAffectees;
            
            strBuilder.Append("INSERT INTO domicile(no_centrix, prix, type_bat, nb_piece, nb_chambre, nb_salle_bain, region, geom, url, date_debut) VALUES (");
            strBuilder.Append(no_centrix);
            strBuilder.Append(","); 
            strBuilder.Append(prix);
            strBuilder.Append(",'"); 
            strBuilder.Append(type_bat);
            strBuilder.Append("',"); 
            strBuilder.Append(nb_piece);
            strBuilder.Append(","); 
            strBuilder.Append(nb_chambre);
            strBuilder.Append(","); 
            strBuilder.Append(nb_salle_bain);
            strBuilder.Append(",'"); 
            strBuilder.Append(region);
            strBuilder.Append("', ST_GeomFromText('POINT(");
            strBuilder.Append(geom.X.ToString(CultureInfo.InvariantCulture.NumberFormat));
            strBuilder.Append(" ");
            strBuilder.Append(geom.Y.ToString(CultureInfo.InvariantCulture.NumberFormat));
            strBuilder.Append(")', 4326),'");
            strBuilder.Append(url);
            strBuilder.Append("', current_timestamp)");

            commande = new NpgsqlCommand(strBuilder.ToString(), this._connexion);
            
            rangeeAffectees = commande.ExecuteNonQuery();

            return rangeeAffectees;
        }

        public void Close()
        {
            this._connexion.Close();
        }

    }
}
