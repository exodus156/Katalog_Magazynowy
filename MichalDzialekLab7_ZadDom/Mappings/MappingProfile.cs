using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MichalDzialekLab7_ZadDom.Models;
using MichalDzialekLab7_ZadDom.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace MichalDzialekLab7_ZadDom.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Kategoria, KategoriaDTO>();

            CreateMap<Przedmiot, PrzedmiotDTO>();

            CreateMap<Rodzaj, RodzajDTO>();

            CreateMap<Typ, TypDTO>();
        }
    }
}
