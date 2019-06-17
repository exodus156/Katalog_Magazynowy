using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MichalDzialekLab7_ZadDom.Models
{
    public class Rodzaj
    {
        [Key]
        public int ID { get; set; }

        [Required, MinLength(3, ErrorMessage ="Rodzaj przedmiotu musi mieć conajmnniej 3 znaki"), Display(Name ="Nazwa rodzaju")]
        public string Name { get; set; }

        [Display(Name = "Opis rodzaju")]
        public string Description { get; set; }

        public virtual ICollection<Przedmiot> Przedmioty { get; set; }

    }
}
