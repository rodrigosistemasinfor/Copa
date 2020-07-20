using CopaApp.Infra.Data.Entities;
using CopaApp.Infra.Data.Interface;
using System.Collections.Generic;

namespace CopaApp.Infra.Data
{
    public class Context : IContext
    {
        public Context() {
            Equipe = new List<EquipeEntity>();
        }

        public List<EquipeEntity> Equipe { get; set; }

        public List<TEntity> Set<TEntity>() where TEntity : class
        {
            foreach (var prop in this.GetType().GetProperties())
            {
                if (prop.PropertyType.FullName.Contains(typeof(TEntity).Name))
                {
                    return (List<TEntity>)prop.GetValue(this, null);
                }
            }

            return null;
        }
    }
}
