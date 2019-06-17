using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MichalDzialekLab7_ZadDom.Models
{
    public class Kategoria
    {
        [Key]
        public int ID { get; set; }

        [Required, MinLength(3, ErrorMessage ="Nazwa kategorii przedmiotu musi mieć conajmniej 3 znaki"), Display(Name = "Nazwa kategorii")]
        public string Name { get; set; }

        [Display(Name = "Opis kategorii")]
        public string Description { get; set; }

        public virtual ICollection<Przedmiot> Przedmioty { get; set; }
    }
}
