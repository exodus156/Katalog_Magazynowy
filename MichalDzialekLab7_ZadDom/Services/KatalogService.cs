using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MichalDzialekLab7_ZadDom.Models;
using MichalDzialekLab7_ZadDom.Models.DTO;

namespace MichalDzialekLab7_ZadDom.Services
{
    public class KatalogService : IKatalogService
    {
        private readonly KatalogContext _context;

        private readonly IMapper _mapper;

        public KatalogService(KatalogContext context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
        }

        public KategoriaDTO KategoriaDTO(int id)
        {
            var kategoria = _context.Kategorie.FirstOrDefault(k => k.ID == id);

            var detailsKategoria = _mapper.Map<KategoriaDTO>(kategoria);

            return detailsKategoria;
        }

        public PrzedmiotDTO PrzedmiotDTO(int id)
        {
            var przedmiot = _context.Przedmioty.FirstOrDefault(k => k.ID == id);

            var detailsPrzedmiot = _mapper.Map<PrzedmiotDTO>(przedmiot);

            return detailsPrzedmiot;
        }

        public RodzajDTO RodzajDTO(int id)
        {
            var rodzaj = _context.Rodzaje.FirstOrDefault(k => k.ID == id);

            var detailsRodzaj = _mapper.Map<RodzajDTO>(rodzaj);

            return detailsRodzaj;
        }

        public TypDTO TypDTO(int id)
        {
            var typ = _context.Typy.FirstOrDefault(k => k.ID == id);

            var detailsTyp = _mapper.Map<TypDTO>(typ);

            return detailsTyp;
        }
    }
}
