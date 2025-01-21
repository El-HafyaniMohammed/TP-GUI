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
                    SupprimerPatient();
                    break;
                case "5":
                    MettreAJourPatient();
                    break;
                case "6":
                    SupprimerHistorique();
                    break;
                case "7":
                    MettreAJourHistorique();
                    break;
                case "8":
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

            gestionPatients.AjouterPatient(patient1);
            gestionPatients.AjouterPatient(patient2);

            Historique historique1 = new Historique(1, 1, new DateTime(2023, 10, 1), "Grippe", "Repos et paracétamol");
            Historique historique2 = new Historique(2, 1, new DateTime(2023, 10, 10), "Contrôle", "Aucun");
            Historique historique3 = new Historique(3, 2, new DateTime(2023, 9, 20), "Allergie", "Antihistaminiques");

            gestionPatients.AjouterHistorique(historique1);
            gestionPatients.AjouterHistorique(historique2);
            gestionPatients.AjouterHistorique(historique3);

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
        Console.WriteLine("║ 4. Supprimer un patient                       ║");
        Console.WriteLine("║ 5. Mettre à jour un patient                   ║");
        Console.WriteLine("║ 6. Supprimer un historique                    ║");
        Console.WriteLine("║ 7. Mettre à jour un historique                ║");
        Console.WriteLine("║ 8. Quitter                                    ║");
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

            Patient patient = new Patient(gestionPatients.Patient.Count + 1, nom, prenom, dateNaissance, adresse, telephone);

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

    static void SupprimerPatient()
    {
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║          SUPPRIMER UN PATIENT                 ║");
            Console.WriteLine("╠════════════════════════════════════════════════╣");
            Console.ResetColor();

            Console.Write("ID du patient à supprimer : ");
            int id = int.Parse(Console.ReadLine());
            gestionPatients.Patient.RemoveAll(p => p.Id == id);
            gestionPatients.Historiques.RemoveAll(h => h.PatientId == id);
            AfficherMessageSucces("Patient supprimé avec succès !");
            AttendreAppuiTouche();
        }
        catch (Exception ex)
        {
            AfficherMessageErreur($"Erreur : {ex.Message}");
            AttendreAppuiTouche();
        }
    }

    static void MettreAJourPatient()
    {
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║          METTRE À JOUR UN PATIENT             ║");
            Console.WriteLine("╠════════════════════════════════════════════════╣");
            Console.ResetColor();

            Console.Write("ID du patient à mettre à jour : ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nouveau nom : ");
            string nom = Console.ReadLine();
            Console.Write("Nouveau prénom : ");
            string prenom = Console.ReadLine();
            Console.Write("Nouvelle date de naissance (yyyy-mm-dd) : ");
            DateTime dateNaissance = DateTime.Parse(Console.ReadLine());
            Console.Write("Nouvelle adresse : ");
            string adresse = Console.ReadLine();
            Console.Write("Nouveau téléphone : ");
            string telephone = Console.ReadLine();

            Patient patient = gestionPatients.GetPatientById(id);
            if (patient != null)
            {
                patient.Nom = nom;
                patient.Prenom = prenom;
                patient.DateNaissance = dateNaissance;
                patient.Adresse = adresse;
                patient.Telephone = telephone;
            }

            AfficherMessageSucces("Patient mis à jour avec succès !");
            AttendreAppuiTouche();
        }
        catch (Exception ex)
        {
            AfficherMessageErreur($"Erreur : {ex.Message}");
            AttendreAppuiTouche();
        }
    }

    static void SupprimerHistorique()
    {
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║          SUPPRIMER UN HISTORIQUE              ║");
            Console.WriteLine("╠════════════════════════════════════════════════╣");
            Console.ResetColor();

            Console.Write("ID de l'historique à supprimer : ");
            int id = int.Parse(Console.ReadLine());
            gestionPatients.Historiques.RemoveAll(h => h.Id == id);
            AfficherMessageSucces("Historique supprimé avec succès !");
            AttendreAppuiTouche();
        }
        catch (Exception ex)
        {
            AfficherMessageErreur($"Erreur : {ex.Message}");
            AttendreAppuiTouche();
        }
    }

    static void MettreAJourHistorique()
    {
        try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════════════════╗");
            Console.WriteLine("║          METTRE À JOUR UN HISTORIQUE          ║");
            Console.WriteLine("╠════════════════════════════════════════════════╣");
            Console.ResetColor();

            Console.Write("ID de l'historique à mettre à jour : ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nouveau diagnostic : ");
            string diagnostic = Console.ReadLine();
            Console.Write("Nouveau traitement : ");
            string traitement = Console.ReadLine();

            Historique historique = gestionPatients.Historiques.Find(h => h.Id == id);
            if (historique != null)
            {
                historique.Diagnostic = diagnostic;
                historique.Traitement = traitement;
            }

            AfficherMessageSucces("Historique mis à jour avec succès !");
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