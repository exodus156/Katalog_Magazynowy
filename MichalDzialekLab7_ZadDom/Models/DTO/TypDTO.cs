using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MichalDzialekLab7_ZadDom.Models.DTO
{
    public class TypDTO
    {
        public int ID { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }
    }
}
