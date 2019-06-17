using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MichalDzialekLab7_ZadDom.Models.DTO;

namespace MichalDzialekLab7_ZadDom.Models
{
    public class KatalogContext : DbContext
    {
        public KatalogContext(DbContextOptions<KatalogContext> options) : base(options)
        {

        }

        public DbSet<Przedmiot> Przedmioty { get; set; }

        public DbSet<Kategoria> Kategorie { get; set; }

        public DbSet<Typ> Typy { get; set; }

        public DbSet<Rodzaj> Rodzaje { get; set; }

        public DbSet<MichalDzialekLab7_ZadDom.Models.DTO.KategoriaDTO> KategoriaDTO { get; set; }

        public DbSet<MichalDzialekLab7_ZadDom.Models.DTO.PrzedmiotDTO> PrzedmiotDTO { get; set; }

    }
}
