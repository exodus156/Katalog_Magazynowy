using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MichalDzialekLab7_ZadDom.Models;
using MichalDzialekLab7_ZadDom.Models.DTO;

namespace MichalDzialekLab7_ZadDom.Services
{
    public interface IKatalogService
    {
        PrzedmiotDTO PrzedmiotDTO(int id);

        KategoriaDTO KategoriaDTO(int id);

        RodzajDTO RodzajDTO(int id);

        TypDTO TypDTO(int id);
    }
}
