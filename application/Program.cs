using System;

class Program
{
    // Instance de la classe GestionPatients pour gérer les patients et leurs historiques
    static GestionPatients gestionPatients = new GestionPatients();

    // Point d'entrée de l'application
    static void Main(string[] args)
    {
        // Ajouter des patients par défaut au démarrage
        InitialiserDonneesParDefaut();

        while (true)
        {
            AfficherMenu(); // Afficher le menu principal
            string choix = Console.ReadLine(); // Lire le choix de l'utilisateur

            switch (choix)
            {
                case "1":
                    AjouterPatient(); // Ajouter un patient
                    break;
                case "2":
                    AfficherTableauBord(); // Afficher le tableau de bord (liste des patients)
                    break;
                case "3":
                    AfficherHistoriquePatient(); // Afficher l'historique d'un patient
                    break;
                case "4":
                    return; // Quitter l'application
                default:
                    Console.WriteLine("Choix invalide, veuillez réessayer.");
                    break;
            }
        }
    }

    // Méthode pour initialiser des patients par défaut
    static void InitialiserDonneesParDefaut()
    {
        // Ajouter des patients par défaut
        Patient patient1 = new Patient
        {
            Id = 1,
            Nom = "Dupont",
            Prenom = "Jean",
            DateNaissance = new DateTime(1985, 5, 15),
            Adresse = "123 Rue de Paris",
            Telephone = "0123456789"
        };

        Patient patient2 = new Patient
        {
            Id = 2,
            Nom = "Martin",
            Prenom = "Marie",
            DateNaissance = new DateTime(1990, 8, 22),
            Adresse = "456 Avenue des Champs",
            Telephone = "0987654321"
        };

        // Ajouter les patients à la liste
        gestionPatients.AjouterPatient(patient1);
        gestionPatients.AjouterPatient(patient2);

        // Ajouter des historiques par défaut
        Historique historique1 = new Historique
        {
            PatientId = 1,
            DateVisite = new DateTime(2023, 10, 1),
            Diagnostic = "Grippe",
            Traitement = "Repos et paracétamol"
        };

        Historique historique2 = new Historique
        {
            PatientId = 1,
            DateVisite = new DateTime(2023, 10, 10),
            Diagnostic = "Contrôle",
            Traitement = "Aucun"
        };

        Historique historique3 = new Historique
        {
            PatientId = 2,
            DateVisite = new DateTime(2023, 9, 20),
            Diagnostic = "Allergie",
            Traitement = "Antihistaminiques"
        };

        // Ajouter les historiques à la liste
        gestionPatients.AjouterHistorique(historique1);
        gestionPatients.AjouterHistorique(historique2);
        gestionPatients.AjouterHistorique(historique3);

        Console.WriteLine("Données par défaut initialisées avec succès !");
    }

    // Méthode pour afficher le menu principal
    static void AfficherMenu()
    {
        Console.WriteLine("1. Ajouter un patient");
        Console.WriteLine("2. Afficher le tableau de bord");
        Console.WriteLine("3. Afficher l'historique d'un patient");
        Console.WriteLine("4. Quitter");
        Console.Write("Choix : ");
    }

    // Méthode pour ajouter un patient
    static void AjouterPatient()
    {
        Console.Write("Nom : ");
        string nom = Console.ReadLine();
        Console.Write("Prénom : ");
        string prenom = Console.ReadLine();
        Console.Write("Date de naissance (yyyy-mm-dd) : ");
        DateTime dateNaissance = DateTime.Parse(Console.ReadLine());
        Console.Write("Adresse : ");
        string adresse = Console.ReadLine();
        Console.Write("Téléphone : ");
        string telephone = Console.ReadLine();

        Patient patient = new Patient
        {
            Id = gestionPatients.Patients.Count + 1, // Générer un ID unique
            Nom = nom,
            Prenom = prenom,
            DateNaissance = dateNaissance,
            Adresse = adresse,
            Telephone = telephone
        };

        gestionPatients.AjouterPatient(patient); // Ajouter le patient à la liste
        Console.WriteLine("Patient ajouté avec succès !");
    }

    // Méthode pour afficher le tableau de bord (liste des patients)
    static void AfficherTableauBord()
    {
        gestionPatients.AfficherPatients();
    }

    // Méthode pour afficher l'historique d'un patient
    static void AfficherHistoriquePatient()
    {
        Console.Write("ID du patient : ");
        int id = int.Parse(Console.ReadLine());
        gestionPatients.AfficherHistorique(id);
    }
}