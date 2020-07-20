using System.Collections.Generic;

namespace CopaApp.Domain.Service
{
    public interface ICopaService
    {
        IEnumerable<EquipeDomain> ProcessarCopa(IEnumerable<EquipeDomain> equipes);
    }
}
