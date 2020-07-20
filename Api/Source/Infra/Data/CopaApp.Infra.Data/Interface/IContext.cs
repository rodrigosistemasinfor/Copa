using CopaApp.Infra.Data.Entities;
using System.Collections.Generic;

namespace CopaApp.Infra.Data.Interface
{
    public interface IContext
    {
        List<TEntity> Set<TEntity>() where TEntity : class;

        List<EquipeEntity> Equipe { get; set; }
    }
}
