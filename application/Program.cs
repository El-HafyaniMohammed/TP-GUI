using System;

class Program
{
    static GestionPatients gestionPatients = new GestionPatients();

    static void Main(string[] args)
    {
        InitialiserDonneesParDefaut();

        while (true)
        {
            AfficherMenuStylise();
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AjouterPatient();
                    break;
                case "2":
                    AfficherTableauBord();
                    break;
                case "3":
                    AfficherHistoriquePatient();
                    break;
                case "4":
                    QuitterApplication();
                    break;
                default:
                    AfficherMessageErreur("Choix invalide, veuillez réessayer.");
                    break;
            }
        }
    }

    static void InitialiserDonneesParDefaut()
    {
        try
        {
            Patient patient1 = new Patient(1, "Dupont", "Jean", new DateTime(1985, 5, 15), "123 Rue de Paris", "0123456789");
            Patient patient2 = new Patient(2, "Martin", "Marie", new DateTime(1990, 8, 22), "456 Avenue des Champs", "0987654321");
            Patient patient3 = new Patient(3, "Mohammed", "elhafyani", new DateTime(1490, 3, 02), "45 Avenue des Champs", "09874564321");
            Patient patient4 = new Patient(4, "Salma", "salmi", new DateTime(1990, 8, 22), "456 Avenue des Champs", "0987654321");

            gestionPatients.AjouterPatient(patient1);
            gestionPatients.AjouterPatient(patient2);
            gestionPatients.AjouterPatient(patient3);
            gestionPatients.AjouterPatient(patient4);

            Historique historique1 = new Historique(1, new DateTime(2023, 10, 1), "Grippe", "Repos et paracétamol");
            Historique historique2 = new Historique(1, new DateTime(2023, 10, 10), "Contrôle", "Aucun");
            Historique historique3 = new Historique(2, new DateTime(2023, 9, 20), "Allergie", "Antihistaminiques");
            Historique historique4 = new Historique(3, new DateTime(2023, 9, 20), "Maroc", "Antihistaminiques");
            Historique historique5 = new Historique(4, new DateTime(2023, 9, 20), "etali", "Antihistaminiques");

            gestionPatients.AjouterHistorique(historique1);
            gestionPatients.AjouterHistorique(historique2);
            gestionPatients.AjouterHistorique(historique3);
            gestionPatients.AjouterHistorique(historique4);
            gestionPatients.AjouterHistorique(historique5);

            AfficherMessageSucces("Données par défaut initialisées avec succès !");
        }
        catch (Exception ex)
        {
            AfficherMessageErreur($"Erreur lors de l'initialisation des données : {ex.Message}");
        }
    }

    static void AfficherMenuStylise()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════════╗");
        Console.WriteLine("║          GESTION DES PATIENTS                 ║");
        Console.WriteLine("╠════════════════════════════════════════════════╣");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("║ 1. Ajouter un patient                         ║");
        Console.WriteLine("║ 2. Afficher le tableau de bord                ║");
        Console.WriteLine("║ 3. Afficher l'historique d'un patient         ║");
        Console.WriteLine("║ 4. Quitter                                    ║");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╚════════════════════════════════════════════════╝");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nVotre choix : ");
        Console.ResetColor();
    }

    static void AjouterPatient()
    {
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║          AJOUTER UN PATIENT                   ║");
            Console.WriteLine("╠════════════════════════════════════════════════╣");
            Console.ResetColor();

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

            Patient patient = new Patient(gestionPatients.Patients.Count + 1, nom, prenom, dateNaissance, adresse, telephone);
            gestionPatients.AjouterPatient(patient);

            AfficherMessageSucces("Patient ajouté avec succès !");
            AttendreAppuiTouche();
        }
        catch (Exception ex)
        {
            AfficherMessageErreur($"Erreur : {ex.Message}");
            AttendreAppuiTouche();
        }
    }

    static void AfficherTableauBord()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════════╗");
        Console.WriteLine("║          TABLEAU DE BORD                      ║");
        Console.WriteLine("╠════════════════════════════════════════════════╣");
        Console.ResetColor();

        gestionPatients.AfficherPatients();

        AttendreAppuiTouche();
    }

    static void AfficherHistoriquePatient()
    {
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║          HISTORIQUE D'UN PATIENT              ║");
            Console.WriteLine("╠════════════════════════════════════════════════╣");
            Console.ResetColor();

            Console.Write("ID du patient : ");
            int id = int.Parse(Console.ReadLine());
            gestionPatients.AfficherHistorique(id);

            AttendreAppuiTouche();
        }
        catch (Exception ex)
        {
            AfficherMessageErreur($"Erreur : {ex.Message}");
            AttendreAppuiTouche();
        }
    }

    static void QuitterApplication()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔════════════════════════════════════════════════╗");
        Console.WriteLine("║          QUITTER L'APPLICATION                ║");
        Console.WriteLine("╠════════════════════════════════════════════════╣");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("║ Merci d'avoir utilisé l'application !         ║");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╚════════════════════════════════════════════════╝");
        Console.ResetColor();

        Environment.Exit(0);
    }

    static void AfficherMessageSucces(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n{message}");
        Console.ResetColor();
    }

    static void AfficherMessageErreur(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nErreur : {message}");
        Console.ResetColor();
    }

    static void AttendreAppuiTouche()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
        Console.ResetColor();
        Console.ReadKey();
    }
}