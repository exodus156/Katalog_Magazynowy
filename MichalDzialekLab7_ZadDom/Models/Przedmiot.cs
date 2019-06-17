using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MichalDzialekLab7_ZadDom.Models
{
    public class Przedmiot
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Nazwa przedmiotu musi mieć conajmniej 3 znaki"), MinLength(3, ErrorMessage ="Nazwa przedmiotu musi mieć conajmniej 3 znaki"), Display(Name ="Nazwa przedmiotu")]
        public string Nazwa { get; set; }

        [ForeignKey("KategoriaID"), Display(Name = "Kategoria przedmiotu")]
        public int KategoriaID { get; set; }
        public Kategoria Kategoria { get; set; }

        [ForeignKey("TypID"), Display(Name = "Typ przedmiotu")]
        public int TypID { get; set; }
        public Typ Typ { get; set; }

        [ForeignKey("RodzajID"), Display(Name = "Rodzaj przedmiotu")]
        public int RodzajID { get; set; }
        public Rodzaj Rodzaj { get; set; }

        [Required(ErrorMessage = "Wartość nie może być pusta"), Display(Name = "Ilość przedmiotów")]
        [Range(1, 400000000, ErrorMessage = "Minimalna ilość przedmiotów to 1, a maksymalna to 400 000 000")]
        public int Ilosc { get; set; }

        [Required(ErrorMessage = "Wartość nie może być pusta"), Display(Name = "Cena przedmiotu")]
        [Range(0.01, 1000000000.00, ErrorMessage = "Cena musi być w granicach 0.01 i 1 000 000 000.00")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Długość kodu seryjnego wynosi dokładnie 12 znaków"), MinLength(12, ErrorMessage ="Długość kodu seryjnego wynosi dokładnie 12 znaków"), MaxLength(12, ErrorMessage = "Długość kodu seryjnego wynosi dokładnie 12 znaków"), Display(Name = "Kod seryjny", Description = "Kod seryjny składa się z dwóch pierwszych liter z nazwy kategorii przedmiotu, nazwy typu przedmiotu i nazwy rodzaju przedmiotu, a do tego 6 unikalnych cyfr dla danego przedmiotu")]
        public string SerialNumber { get; set; }

        [Display(Name = "Data utworzenia")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Opis produktu")]
        public string Description { get; set; }
    }
}
