using CopaApp.Domain.Seletores;
using System.Collections.Generic;

namespace CopaApp.Domain.Service
{
    public interface IEquipeService : IService<EquipeDomain, EquipeSeletor>
    {
       IEnumerable<EquipeDomain> Ordenar(IEnumerable<EquipeDomain> lista);
    }
}
