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
            foreach (Voiture voiture in voitures)
            {   
                if (voiture.Statut == "Disponible"){
                    Console.WriteLine(voiture);
                }
            }
            int id_louable;
            while (true)
            {
                try 
                {
                    id_louable = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrée invalide. Veuillez entrer un ID valide.");
                }
            }
            
            Voiture voitureLouee = voitures.Find(v => v.Id == id_louable);

            voitureLouee.Statut = "Indisponible";
                
        }

    }
}