using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPLOCAL1.Models
{
    public class Form
    {
        //Informations personnelles
        //On utilise Required afin d'assurer le contrôle des champs
        [Required(ErrorMessage = "Champ obligatoire.")]
        public string? Nom { get; set; }
        [Required(ErrorMessage = "Champ obligatoire.")]
        public string? Prenom { get; set; }
        [Required(ErrorMessage = "Champ obligatoire.")]
        public string? Sexe { get; set; }
        [Required(ErrorMessage = "Champ obligatoire.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Adresse invalide")]
        public string? Adresse { get; set; }
        [Required(ErrorMessage = "Champ obligatoire.")]
        [RegularExpression(@"^(\d{5})$", ErrorMessage = "Code Postal invalide.")]
        public int CodePos { get; set; }
        [Required(ErrorMessage = "Champ obligatoire.")]
        public string? Ville { get; set; }
        [Required(ErrorMessage = "Champ obligatoire.")]
        [RegularExpression(@"^([\w]+)@([\w]+)\.([\w]+)$",ErrorMessage ="Adresse email invalide.")]
        public string? Email { get; set; }

        //Information Formation
        [Required(ErrorMessage = "Champ obligatoire.")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime),"1900-01-01","2021-01-01", ErrorMessage ="Date de début de formation invalide.")]
        public DateTime DateDeb { get; set; }
        [Required(ErrorMessage = "Champ obligatoire.")]
        public string? Formation { get; set; }

        //Avis formation
        [Required(ErrorMessage = "Champ obligatoire.")]
        public string? AvisCOBOL { get; set; }
        [Required(ErrorMessage = "Champ obligatoire.")]
        public string? AvisCsharp { get; set; }
    }
}
