using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributeurBoissons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialisation des ingrédients avec leurs prix (selon l'énoncé)
            var cafe = new Ingredient("Café", 1.0m);
            var sucre = new Ingredient("Sucre", 0.1m);
            var creme = new Ingredient("Crème", 0.5m);
            var the = new Ingredient("Thé", 2.0m);
            var eau = new Ingredient("Eau", 0.2m);
            var chocolat = new Ingredient("Chocolat", 1.0m);
            var lait = new Ingredient("Lait", 0.4m);

            // Création du distributeur
            var distributeur = new Distributeur();

            // Création des recettes (selon l'énoncé)
            var expresso = new Recette("Expresso");
            expresso.AjouterIngredient(cafe, 1);
            expresso.AjouterIngredient(eau, 1);
            distributeur.AjouterRecette(expresso);

            var allonge = new Recette("Allongé");
            allonge.AjouterIngredient(cafe, 1);
            allonge.AjouterIngredient(eau, 2);
            distributeur.AjouterRecette(allonge);

            var capuccino = new Recette("Capuccino");
            capuccino.AjouterIngredient(cafe, 1);
            capuccino.AjouterIngredient(chocolat, 1);
            capuccino.AjouterIngredient(eau, 1);
            capuccino.AjouterIngredient(creme, 1);
            distributeur.AjouterRecette(capuccino);

            var chocolatBoisson = new Recette("Chocolat");
            chocolatBoisson.AjouterIngredient(chocolat, 3);
            chocolatBoisson.AjouterIngredient(lait, 2);
            chocolatBoisson.AjouterIngredient(eau, 1);
            chocolatBoisson.AjouterIngredient(sucre, 1);
            distributeur.AjouterRecette(chocolatBoisson);

            var theBoisson = new Recette("Thé");
            theBoisson.AjouterIngredient(the, 1);
            theBoisson.AjouterIngredient(eau, 2);
            distributeur.AjouterRecette(theBoisson);

            // Interface utilisateur
            Console.WriteLine("=== Distributeur de boissons chaudes ===");
            distributeur.AfficherMenu();

            while (true)
            {
                Console.Write("\nEntrez le nom de la boisson désirée (ou 'quitter' pour sortir) : ");
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                if (input.Equals("quitter", StringComparison.OrdinalIgnoreCase))
                    break;

                Recette recette = distributeur.TrouverRecette(input);
                if (recette == null)
                {
                    Console.WriteLine("Désolé, cette boisson n'est pas disponible. Veuillez réessayer.");
                    continue;
                }

                decimal prixVente = distributeur.CalculerPrixVente(recette);
                Console.WriteLine($"Prix de vente du {recette.Nom} : {prixVente:F2} € (coût : {recette.CalculerPrixCoutant():F2} € + marge 30%).");
            }

            Console.WriteLine("Merci et à bientôt !");
        }
    }


    // Classe représentant un ingrédient
    public class Ingredient
    {
        public string Nom { get; }
        public decimal PrixParDose { get; }

        public Ingredient(string nom, decimal prixParDose)
        {
            Nom = nom;
            PrixParDose = prixParDose;
        }
    }

    // Classe représentant une recette
    public class Recette
    {
        public string Nom { get; }
        private Dictionary<Ingredient, int> Ingredients { get; }

        public Recette(string nom)
        {
            Nom = nom;
            Ingredients = new Dictionary<Ingredient, int>();
        }

        public void AjouterIngredient(Ingredient ingredient, int doses)
        {
            Ingredients.Add(ingredient, doses);
        }

        // Calcule le prix coûtant de la recette (somme des doses * prix unitaire)
        public decimal CalculerPrixCoutant()
        {
            decimal total = 0;
            foreach (var kvp in Ingredients)
                total += kvp.Key.PrixParDose * kvp.Value;
            return total;
        }
    }

    // Classe principale du distributeur
    public class Distributeur
    {
        private List<Recette> Recettes { get; } = new List<Recette>();

        public void AjouterRecette(Recette recette)
        {
            Recettes.Add(recette);
        }

        // Recherche une recette par nom (insensible à la casse)
        public Recette TrouverRecette(string nom)
        {
            return Recettes.FirstOrDefault(r => r.Nom.Equals(nom, StringComparison.OrdinalIgnoreCase));
        }

        // Calcule le prix de vente (coût + marge 30%)
        public decimal CalculerPrixVente(Recette recette)
        {
            if (recette == null) throw new ArgumentNullException(nameof(recette));
            return recette.CalculerPrixCoutant() * 1.30m;
        }

        // Affiche le menu des boissons disponibles
        public void AfficherMenu()
        {
            Console.WriteLine("Boissons disponibles :");
            foreach (var recette in Recettes)
                Console.WriteLine($"- {recette.Nom}");
        }
    }
}
