using System;

class Patient
{
    // Propriétés
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public DateTime DateNaissance { get; set; }
    public string Adresse { get; set; }
    public string Telephone { get; set; }

    // Constructeur
    public Patient(int id, string nom, string prenom, DateTime dateNaissance, string adresse, string telephone)
    {
        Id = id;
        Nom = !string.IsNullOrEmpty(nom) ? nom : throw new ArgumentException("Le nom ne peut pas être vide.");
        Prenom = !string.IsNullOrEmpty(prenom) ? prenom : throw new ArgumentException("Le prénom ne peut pas être vide.");
        DateNaissance = dateNaissance;
        Adresse = !string.IsNullOrEmpty(adresse) ? adresse : throw new ArgumentException("L'adresse ne peut pas être vide.");
        Telephone = !string.IsNullOrEmpty(telephone) ? telephone : throw new ArgumentException("Le téléphone ne peut pas être vide.");
    }

    // Méthode pour afficher les informations du patient
    public override string ToString()
    {
        return $"{Id}: {Prenom} {Nom}, Né(e) le {DateNaissance.ToShortDateString()}, {Adresse}, {Telephone}";
    }
}