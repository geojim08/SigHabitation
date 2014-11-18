INSERT INTO domicile(
            no_centrix, prix, type_bat, nb_piece, nb_chambre, nb_salle_bain, 
            region, geom, url, date_debut)
    VALUES (10207346, 375000, 'condo', 4, 2, 1, 
            'montreal-ile', ST_GeomFromText('POINT(-73.56010983 45.49200938)', 4326),
            'http://www.centris.ca/fr/condo~a-vendre~le-sud-ouest-montreal~montreal-ile~225-rue-de-la-montagne-apt.-501/10207346',
            current_timestamp );

INSERT INTO domicile(no_centrix, prix, type_bat, nb_piece, nb_chambre, nb_salle_bain, region, geom, url, date_debut) VALUES (9171627,469000,'maison',9,3,2,'montreal-ile', ST_GeomFromText('POINT(-73,55908871 45,51905214)', 4326),'http://www.centris.ca/fr/maison~a-vendre~ville-marie-montreal~montreal-ile~1690-rue-wolfe/9171627', current_timestamp)