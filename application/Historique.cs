using System;

class Historique
{
    // Propriétés (attributs)
    public int PatientId { get; set; } // Identifiant du patient associé à cet historique
    public DateTime DateVisite { get; set; } // Date de la visite
    public string Diagnostic { get; set; } // Diagnostic établi lors de la visite
    public string Traitement { get; set; } // Traitement prescrit

    // Méthode pour afficher les informations de l'historique
    public override string ToString()
    {
        return $"{DateVisite.ToShortDateString()}: Diagnostic: {Diagnostic}, Traitement: {Traitement}";
    }
}