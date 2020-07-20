using System;
using System.Collections.Generic;

namespace CopaApp.Domain.Repository.Abstract
{
    public interface IRepositoryBase<TDomain>
       where TDomain : DomainBase
    {
        TDomain Insert(TDomain obj);

        void Update(TDomain obj);

        void Delete(Guid id);

        TDomain GetById(Guid id);

        IEnumerable<TDomain> GetByIds(params Guid[] id);

        void Save();
    }
}
