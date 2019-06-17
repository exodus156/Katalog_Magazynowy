using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MichalDzialekLab7_ZadDom.Models.DTO
{
    public class PrzedmiotDTO
    {
        public int ID { get; set; }

        [Display(Name = "Nazwa")]
        public string Nazwa { get; set; }

        [Display(Name = "Ilość")]
        public int Ilosc { get; set; }

        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Display(Name = "Numer seryjny")]
        public string SerialNumber { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }
    }
}
