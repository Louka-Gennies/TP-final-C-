using System;

namespace LocationVoiture 
{
    public class Parc 
    {
        public List<Voiture> voitures = new List<Voiture>();

        private Dictionary<string, List<string>> dictionnaireVoitures = new Dictionary<string, List<string>>
        {
            { "Toyota", new List<string> { "Corolla", "Camry", "Prius" } },
            { "Honda", new List<string> { "Civic", "Accord", "Fit" } },
            { "Ford", new List<string> { "Focus", "Mustang", "Fiesta" } },
            { "BMW", new List<string> { "X5", "X3", "3 Series" } },
            { "Audi", new List<string> { "A4", "A6", "Q5" } }
        };

        public Parc()
        {
            
        }

        public void AjouterVoiture() 
        {   
            int id = voitures.Count + 1;

            string[] marques = dictionnaireVoitures.Keys.ToArray();
            string marque = MenuDeroulant(marques);

            string[] modeles = dictionnaireVoitures[marque].ToArray();
            string modele = MenuDeroulant(modeles);

            int annee_voiture;
            while (!int.TryParse(Console.ReadLine(), out annee_voiture) || annee_voiture < 1900 || annee_voiture > 2024)
            {
                Console.WriteLine("Veuillez entrer une année valide entre 1900 et 2024.");
            }

            voitures.Add(new Voiture(id, marque, modele, annee_voiture, "Disponible"));
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


        public string MenuDeroulant(string[] options)
        {
            int currentSelection = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Utilisez les flèches haut/bas pour naviguer et appuyez sur Entrée pour sélectionner.");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"> {options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {options[i]}");
                    }
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    currentSelection = (currentSelection == 0) ? options.Length - 1 : currentSelection - 1;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    currentSelection = (currentSelection == options.Length - 1) ? 0 : currentSelection + 1;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine($"Vous avez sélectionné : {options[currentSelection]}");
                    return options[currentSelection];
                }
            }
        }
    }
}