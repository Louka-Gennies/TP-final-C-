using System;

namespace LocationVoiture
{
    public class Voiture
    {
        public int Id { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public int Annee { get; set; }
        public string Statut { get; set; }

        public Voiture(int id, string marque, string modele, int annee, string statut)
        {
            Id = id;
            Marque = marque;
            Modele = modele;
            Annee = annee;
            Statut = statut;
        }

        public override string ToString()
        {
            return $"Voiture n°{Id} : {Marque} {Modele} ({Annee}) - {Statut}";
        }
    }
}