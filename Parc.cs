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
            voitures.Add(new Voiture(2, "BMW", "X5", 2018, "Disponible"));
            voitures.Add(new Voiture(1, "Ford", "Focus", 2019, "Disponible"));
            voitures.Add(new Voiture(3, "Ford", "Fiesta", 2020, "Disponible"));
        }

        public void AjouterVoiture() 
        {   
            int id = voitures.Count + 1;

            string[] marques = dictionnaireVoitures.Keys.ToArray();
            string marque = MenuDeroulant(marques);


            string[] modeles = dictionnaireVoitures[marque].ToArray();
            string modele = MenuDeroulant(modeles);

            int annee_voiture;
            Console.WriteLine("Renseignez l'année de la voiture (entre 1900 et 2024)");

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
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
        }

        public void LouerVoiture()
        {
            var disponibles = voitures.Where(v => v.Statut == "Disponible").ToArray();
            if (!disponibles.Any())
            {
                Console.WriteLine("Aucune voiture disponible.");
                return;
            }

            string[] options = disponibles.Select(v => v.ToString()).ToArray();
            string selection = MenuDeroulant(options);

            var voitureLouee = disponibles.FirstOrDefault(v => v.ToString() == selection);
            if (voitureLouee != null)
            {
                voitureLouee.Statut = "Indisponible";
            }
            else
            {
                Console.WriteLine("Erreur lors de la location de la voiture.");
            }
        }

        public void RendreVoiture()
        {
            var indisponibles = voitures.Where(v => v.Statut == "Indisponible").ToArray();
            if (!indisponibles.Any())
            {
                Console.WriteLine("Aucune voiture à rendre");
                return;
            }
            string[] options = indisponibles.Select(v => v.ToString()).ToArray();
            string selection = MenuDeroulant(options);

             var voitureLouee = indisponibles.FirstOrDefault(v => v.ToString() == selection);
            if (voitureLouee != null)
            {
                voitureLouee.Statut = "Disponible";
            }
            else
            {
                Console.WriteLine("Erreur lors de la location de la voiture.");
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