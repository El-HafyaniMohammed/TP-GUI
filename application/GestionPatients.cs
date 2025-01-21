using System;
using System.Collections.Generic;

class GestionPatients
{
    // Liste des patients
    public List<Patient> Patients { get; set; } = new List<Patient>();

    // Liste des historiques
    public List<Historique> Historiques { get; set; } = new List<Historique>();

    // Méthode pour ajouter un patient
    public void AjouterPatient(Patient patient)
    {
        Patients.Add(patient);
    }

    // Méthode pour ajouter un historique
    public void AjouterHistorique(Historique historique)
    {
        Historiques.Add(historique);
    }

    // Méthode pour récupérer un patient par son ID
    public Patient GetPatientById(int id)
    {
        return Patients.Find(p => p.Id == id);
    }

    // Méthode pour récupérer l'historique d'un patient par son ID
    public List<Historique> GetHistoriqueByPatientId(int id)
    {
        return Historiques.FindAll(h => h.PatientId == id);
    }

    // Méthode pour afficher la liste des patients
    public void AfficherPatients()
    {
        foreach (var patient in Patients)
        {
            Console.WriteLine(patient);
        }
    }

    // Méthode pour afficher l'historique d'un patient
    public void AfficherHistorique(int patientId)
    {
        var historique = GetHistoriqueByPatientId(patientId);
        foreach (var h in historique)
        {
            Console.WriteLine(h);
        }
    }
}