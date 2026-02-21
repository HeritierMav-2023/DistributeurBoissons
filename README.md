Explication étape par étape

1. Classe Ingredient
Stocke le nom et le prix par dose.

Utilisée comme brique de base pour toutes les recettes.

2. Classe Recette
Contient un nom et un dictionnaire associant chaque ingrédient au nombre de doses nécessaires.

La méthode AjouterIngredient permet de construire la recette de manière fluide.

CalculerPrixCoutant parcourt les ingrédients et calcule le coût total.

3. Classe Distributeur
Maintient une liste de recettes disponibles.

AjouterRecette pour enregistrer une nouvelle boisson.

TrouverRecette effectue une recherche insensible à la casse.

CalculerPrixVente applique la marge de 30% sur le coût.

AfficherMenu liste les boissons.

4. Programme principal (Main)
Crée tous les ingrédients avec leurs prix (donnés dans l'énoncé).

Instancie le distributeur.

Crée chaque recette en ajoutant les ingrédients un par un, puis les ajoute au distributeur.

Affiche un menu et attend une saisie utilisateur.

Boucle jusqu'à ce que l'utilisateur tape "quitter".

Pour chaque saisie, recherche la recette correspondante et affiche le prix (formaté avec deux décimales).

Évolutivité
Ajout d'une nouvelle recette : il suffit de créer un objet Recette, d'y ajouter les ingrédients avec leurs doses, et de l'ajouter au distributeur via AjouterRecette. Aucune autre modification n'est nécessaire.

Ajout d'un nouvel ingrédient : créez une instance d'Ingredient avec son prix, puis utilisez-le dans les recettes.

Modification des prix : changez la valeur dans le constructeur de l'ingrédient.

Chargement dynamique : on pourrait facilement remplacer la création en dur par une lecture depuis un fichier JSON/XML sans changer la logique métier.

Exécution
L'utilisateur lance le programme, voit le menu, saisit par exemple "Expresso" et obtient :

text
Prix de vente du Expresso : 1.56 € (coût : 1.20 € + marge 30%).
(Coût : 1 dose café (1€) + 1 dose eau (0.2€) = 1.2€, majoré de 30% → 1.56€)

Améliorations possibles (hors scope mais envisageables)
Gestion des stocks pour vérifier la disponibilité.

Interface utilisateur plus ergonomique (WPF, web).

Possibilité de choisir par numéro plutôt que par nom.

Sauvegarde des recettes dans un fichier de configuration.

Cette solution répond aux exigences : code clair, modulaire, et facile à étendre.

<img width="1121" height="432" alt="image" src="https://github.com/user-attachments/assets/ec995344-c3c7-401e-98d6-090432540564" />

