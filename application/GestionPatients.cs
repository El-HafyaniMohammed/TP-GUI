using System;
using System.Collections.Generic;

class GestionPatients
{
    // Liste des patients et historiques
    public List<Patient> Patients { get; set; } = new List<Patient>();
    public List<Historique> Historiques { get; set; } = new List<Historique>();

    // Ajouter un patient
    public void AjouterPatient(Patient patient)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient), "Le patient ne peut pas être null.");

        Patients.Add(patient);
    }

    // Ajouter un historique
    public void AjouterHistorique(Historique historique)
    {
        if (historique == null)
            throw new ArgumentNullException(nameof(historique), "L'historique ne peut pas être null.");

        Historiques.Add(historique);
    }

    // Récupérer un patient par son ID
    public Patient GetPatientById(int id)
    {
        return Patients.Find(p => p.Id == id);
    }

    // Récupérer l'historique d'un patient par son ID
    public List<Historique> GetHistoriqueByPatientId(int id)
    {
        return Historiques.FindAll(h => h.PatientId == id);
    }

    // Afficher la liste des patients sous forme de tableau
    public void AfficherPatients()
    {
        Console.WriteLine("\n--- Liste des Patients ---");
        Console.WriteLine("-----------------------------------------------------------------------------");
        Console.WriteLine("| ID  | Nom           | Prénom        | Date de Naissance | Adresse         |");
        Console.WriteLine("-----------------------------------------------------------------------------");

        foreach (var patient in Patients)
        {
            Console.WriteLine($"| {patient.Id,-4} | {patient.Nom,-13} | {patient.Prenom,-13} | {patient.DateNaissance.ToShortDateString(),-17} | {patient.Adresse,-15} |");
        }

        Console.WriteLine("-----------------------------------------------------------------------------\n");
    }

    // Afficher l'historique d'un patient sous forme de tableau
    public void AfficherHistorique(int patientId)
    {
        var historique = GetHistoriqueByPatientId(patientId);

        if (historique.Count == 0)
        {
            Console.WriteLine("Aucun historique trouvé pour ce patient.\n");
            return;
        }

        Console.WriteLine("\n--- Historique du Patient ---");
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine("| Date de Visite | Diagnostic          | Traitement         |");
        Console.WriteLine("-------------------------------------------------------------");

        foreach (var h in historique)
        {
            Console.WriteLine($"| {h.DateVisite.ToShortDateString(),-15} | {h.Diagnostic,-20} | {h.Traitement,-19} |");
        }

        Console.WriteLine("-------------------------------------------------------------\n");
    }
}