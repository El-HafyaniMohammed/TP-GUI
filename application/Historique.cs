using System;

class Historique
{
    // Propriétés
    public int Id { get; set; }
    public int PatientId { get; set; }
    public DateTime DateVisite { get; set; }
    public string Diagnostic { get; set; }
    public string Traitement { get; set; }

    // Constructeur
    public Historique(int id, int patientId, DateTime dateVisite, string diagnostic, string traitement)
    {
        Id = id;
        PatientId = patientId;
        DateVisite = dateVisite;
        Diagnostic = !string.IsNullOrEmpty(diagnostic) ? diagnostic : throw new ArgumentException("Le diagnostic ne peut pas être vide.");
        Traitement = !string.IsNullOrEmpty(traitement) ? traitement : throw new ArgumentException("Le traitement ne peut pas être vide.");
    }

    // Méthode pour afficher les informations de l'historique
    public override string ToString()
    {
        return $"{DateVisite.ToShortDateString()}: Diagnostic: {Diagnostic}, Traitement: {Traitement}";
    }
}