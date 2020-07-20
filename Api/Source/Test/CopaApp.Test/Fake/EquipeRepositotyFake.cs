using CopaApp.Domain;
using CopaApp.Domain.Repository;
using CopaApp.Domain.Repository.Abstract;
using CopaApp.Domain.Seletores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaApp.Test.Fake
{
    public class EquipeRepositotyFake : IEquipeRepository
    {
        private readonly List<EquipeDomain> _equipe;
        public EquipeRepositotyFake()
        {
            _equipe = new List<EquipeDomain>()
            {
               new EquipeDomain { Id = Guid.NewGuid(), Gols = 1, Nome = "Equipe 9", Sigla = "Eq9" },
               new EquipeDomain { Id = Guid.NewGuid(), Gols = 2, Nome = "Equipe 12", Sigla = "Eq12" },
               new EquipeDomain { Id = Guid.NewGuid(), Gols = 3, Nome = "Equipe 3", Sigla = "Eq3" },
               new EquipeDomain { Id = Guid.NewGuid(), Gols = 4, Nome = "Equipe 100", Sigla = "Eq100" },
               new EquipeDomain { Id = Guid.NewGuid(), Gols = 5, Nome = "Equipe 45", Sigla = "Eq45" },
               new EquipeDomain { Id = Guid.NewGuid(), Gols = 6, Nome = "Equipe 22", Sigla = "Eq22" },
               new EquipeDomain { Id = Guid.NewGuid(), Gols = 7, Nome = "Equipe 13", Sigla = "Eq13" },
               new EquipeDomain { Id = Guid.NewGuid(), Gols = 8, Nome = "Equipe 2", Sigla = "Eq2" }
            };
        }

        public int Count(EquipeSeletor seletor)
        {
            var query = _equipe.AsQueryable();

            if (!string.IsNullOrEmpty(seletor.Nome))
                query = query.Where(x => x.Nome == seletor.Nome);

            return query.Count();
        }

        public void Delete(Guid id)
        {
            var obj = _equipe.Where(x => x.Id == id).First();
            _equipe.Remove(obj);
        }

        public EquipeDomain GetById(Guid id)
        {
            return _equipe.First(x=> x.Id == id);
        }

        public IEnumerable<EquipeDomain> GetByIds(params Guid[] id)
        {
            return _equipe.Where(x => id.Any(y => y == x.Id));
        }

        public IEnumerable<EquipeDomain> GetList(EquipeSeletor seletor)
        {
            var query = _equipe.AsQueryable();

            if (!string.IsNullOrEmpty(seletor.Nome))
                query = query.Where(x => x.Nome == seletor.Nome);

            return query;
        }

        public EquipeDomain Insert(EquipeDomain obj)
        {
            _equipe.Add(obj);

            return obj;
        }

        void IRepositoryBase<EquipeDomain>.Save()
        {
            throw new NotImplementedException();
        }
        void IRepositoryBase<EquipeDomain>.Update(EquipeDomain obj)
        {
            throw new NotImplementedException();
        }
    }
}
