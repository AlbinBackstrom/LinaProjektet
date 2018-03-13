using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LINAprojektet.Models
{
    public class ProjectModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Projektnamn måste fyllas i")]
        [StringLength(100, ErrorMessage = "Projektnamnet får inte vara längre än 100 tecken")]
        public string Projektnamn { get; set; }

        [StringLength(200, ErrorMessage = "Projektbeskrivningen får inte vara längre än 200 tecken")]
        [Required(ErrorMessage = "Beskrivning måste fyllas i")]
        public string Beskrivning { get; set; }

        [DisplayName("Startdatum")]
        [Required(ErrorMessage = "Startdatum måste fyllas i")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Starttid { get; set; }

        [DisplayName("Slutdatum")]
        [Required(ErrorMessage = "Slutdatum måste fyllas i")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Sluttid { get; set; }

        [StringLength(100, ErrorMessage = "Huvudansvarig får inte vara längre än 100 tecken")]
        [Required(ErrorMessage = "Huvudansvarig måste fyllas i")]
        public string Huvudansvarig { get; set; }

        [StringLength(100, ErrorMessage = "Diarienummer får inte vara längre än 100 tecken")]
        [Required(ErrorMessage = "Diarienummer måste fyllas i")]
        public string Diarienummer { get; set; }

        [StringLength(18, ErrorMessage = "Sökt belopp får inte vara längre än 18 tecken")]
        [DisplayName("Sökt belopp (använd punkt vid decimaler)")]
        [Required(ErrorMessage = "Sökt belopp måste fyllas i")]
        public decimal SoktBelopp { get; set; }

        [StringLength(100, ErrorMessage = "Huvudfinansiär får inte vara längre än 100 tecken")]
        [DisplayName("Huvudfinansiär")]
        [Required(ErrorMessage = "Huvudfinansiär måste fyllas i")]
        public string Huvudfinansiar { get; set; }

        [Required(ErrorMessage = "Projekttyp måste fyllas i")]
        public string Projekttyp { get; set; }

        [Required(ErrorMessage = "Projektstatus måste fyllas i")]
        public int Projektstatus { get; set; }

      
        public bool Beviljat { get; set; }
        public bool HVSomHuvudansvarig { get; set; }

        [Required(ErrorMessage = "Kommuniceringsstatus måste fyllas i")]
        public int Kommuniceringsstatus { get; set; }
        public string TillagdAv { get; set; }
        public string MedverkandeFranHV { get; set; }
        public string Nyckelord { get; set; }

    }
}