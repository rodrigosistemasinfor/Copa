using CopaApp.Application.Service.Abstract;
using CopaApp.Domain;
using CopaApp.Domain.Extensions;
using CopaApp.Domain.Repository;
using CopaApp.Domain.Seletores;
using CopaApp.Domain.Service;
using System.Collections.Generic;
using System.Linq;

namespace CopaApp.Application.Service
{
    public class EquipeService : ServiceBase<IEquipeRepository, EquipeDomain, EquipeSeletor>, IEquipeService
    {
        public EquipeService(IEquipeRepository repository) : base(repository) { }

        public override EquipeDomain Update(EquipeDomain domain)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EquipeDomain> Ordenar(IEnumerable<EquipeDomain> lista)
        {
            return lista.OrderBy(x => x.Nome.ValueKeyString()).ThenBy(x => x.Nome.ValueKeyInt());
        }
    }
}
