using CopaApp.Domain;
using CopaApp.Domain.Repository.Abstract;
using CopaApp.Domain.Seletores;
using System;
using System.Collections.Generic;

namespace CopaApp.Application.Service.Abstract
{
    public abstract class ServiceBase<TRepository, TDomain, TSeletor>
    where TRepository : IRepositorySeletorBase<TDomain, TSeletor>
    where TDomain : DomainBase
    where TSeletor : SeletorBase
    {
        protected readonly TRepository _repository;

        public ServiceBase(TRepository repository)
        {
            _repository = repository;
        }

        public virtual void Delete(Guid id) 
                => _repository.Delete(id); 

        public virtual IEnumerable<TDomain> GetList(TSeletor seletor) 
                => _repository.GetList(seletor);

        public virtual TDomain GetById(Guid id) 
                => _repository.GetById(id);

        public int Count(TSeletor seletor) 
                => _repository.Count(seletor);

        public virtual TDomain Insert(TDomain obj)
                => _repository.Insert(obj);

        public abstract TDomain Update(TDomain domain);
    }
}
