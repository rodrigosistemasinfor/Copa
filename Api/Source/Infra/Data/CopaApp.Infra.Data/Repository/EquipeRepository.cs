using AutoMapper;
using CopaApp.Domain;
using CopaApp.Domain.Repository;
using CopaApp.Domain.Seletores;
using CopaApp.Infra.Data.Entities;
using CopaApp.Infra.Data.Interface;
using CopaApp.Infra.Data.Repository.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace CopaApp.Infra.Data.Repository
{
    public class EquipeRepository : RepositoryBase<EquipeEntity, EquipeDomain, EquipeSeletor>, IEquipeRepository
    {
        public EquipeRepository(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public override IEnumerable<EquipeEntity> CreateParameters(EquipeSeletor seletor, IEnumerable<EquipeEntity> query)
        {
            if (!string.IsNullOrEmpty(seletor.Nome))
                query = query.Where(x => x.Nome.Contains(seletor.Nome));

            return query;
        }

    }
}
