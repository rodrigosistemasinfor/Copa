using CopaApp.Domain.Seletores;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaApp.Domain.Service
{
    public interface IService<TDomain, TSeletor>
       where TDomain : DomainBase
       where TSeletor : SeletorBase
    {
        TDomain GetById(Guid id);
        TDomain Insert(TDomain obj);
        int Count(TSeletor seletor);
        IEnumerable<TDomain> GetList(TSeletor seletor);
        TDomain Update(TDomain obj);
        void Delete(Guid id);
    }
}
