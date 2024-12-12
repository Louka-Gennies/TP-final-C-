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

        public void RendreVoiture()
        {
            var indisponibles = voitures.Where(v => v.Statut == "Indisponible").ToList();
            if (!indisponibles.Any())
            {
                Console.WriteLine("Aucune voiture à rendre");
                return;
            }
            indisponibles.ForEach(Console.WriteLine);

            int id_rendre;
            while (!int.TryParse(Console.ReadLine(), out id_rendre) || !indisponibles.Any(v => v.Id == id_rendre))
            {
                 Console.WriteLine("Entrée invalide. Veuillez entrer un ID valide.");
            }

            var voitureRendu = indisponibles.FirstOrDefault(v => v.Id == id_rendre);
            if (voitureRendu != null)
            {
                voitureRendu.Statut = "Disponible";
            }
            else 
            {
                Console.WriteLine("Voiture non trouvée.");
            }
        }

    }
}