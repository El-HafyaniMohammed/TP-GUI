using System;

class Patient
{
    // Propriétés (attributs)
    public int Id { get; set; } // Identifiant unique du patient
    public string Nom { get; set; } // Nom du patient
    public string Prenom { get; set; } // Prénom du patient
    public DateTime DateNaissance { get; set; } // Date de naissance du patient
    public string Adresse { get; set; } // Adresse du patient
    public string Telephone { get; set; } // Numéro de téléphone du patient

    // Méthode pour afficher les informations du patient
    public override string ToString()
    {
        return $"{Id}: {Prenom} {Nom}, Né(e) le {DateNaissance.ToShortDateString()}, {Adresse}, {Telephone}";
    }
}