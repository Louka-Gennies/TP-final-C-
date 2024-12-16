using LocationVoiture;

namespace GameManager{

    public class Menu {
        public Parc parc = new Parc();
        public List<string> options;

        public Menu(){
            options = new List<string>
            {
                "Ajouter une voiture",
                "Lister les voitures",
                "Louer une voiture",
                "Rendre une voiture",
                "Quitter"
            };
        }

        public void GameManager(){
            while(true){
                string selection = parc.MenuDeroulant(options.ToArray());

                switch (selection)
                {
                    case "Ajouter une voiture":
                        parc.AjouterVoiture();
                        break;

                    case "Lister les voitures":
                        parc.ListerVoiture();
                        break;

                    case "Louer une voiture":
                        parc.LouerVoiture();
                        break;

                    case "Rendre une voiture":
                        parc.RendreVoiture();
                        break;

                    case "Quitter":
                        return;
                }
            }
        }
    };

    


}