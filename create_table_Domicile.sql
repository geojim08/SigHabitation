CREATE TABLE public.Domicile
(
   NO_CENTRIX integer,
   PRIX numeric(10,0),
   TYPE_BAT varchar(50),
   NB_PIECE smallint, 
   NB_CHAMBRE smallint, 
   NB_SALLE_BAIN smallint,
   REGION varchar(50),
   GEOM geometry,
   URL varchar(200),
   DATE_DEBUT date
) 
WITH (
  OIDS = FALSE
)
;

ALTER TABLE domicile
  ADD CONSTRAINT domicile_pk PRIMARY KEY (no_centrix);