using System;

namespace LocationVoiture 
{
    public class Parc 
    {
        public List<Voiture> voitures = new List<Voiture>();

        public Parc()
        {
            
        }

        public void AjouterVoiture(Voiture voiture) 
        {
            voitures.Add(voiture);
        }

        public void ListerVoiture()
        {
            
            foreach (Voiture voiture in voitures)
            {
                Console.WriteLine(voiture);
            }
        }

        public void LouerVoiture()
        {
            var disponibles = voitures.Where(v => v.Statut == "Disponible").ToList();
            if (!disponibles.Any())
            {
                Console.WriteLine("Aucune voiture disponible.");
                return;
            }
            disponibles.ForEach(Console.WriteLine);

            int id_louable;
            while (!int.TryParse(Console.ReadLine(), out id_louable) || !disponibles.Any(v => v.Id == id_louable))
            {
                Console.WriteLine("Entrée invalide. Veuillez entrer un ID valide.");
            }

            var voitureLouee = disponibles.FirstOrDefault(v => v.Id == id_louable);
            if (voitureLouee != null)
            {
                voitureLouee.Statut = "Indisponible";
            }
            else
            {
                Console.WriteLine("Voiture non trouvée.");
            }
        }

    }
}