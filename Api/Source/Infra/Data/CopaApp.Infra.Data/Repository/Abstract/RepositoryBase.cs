using AutoMapper;
using CopaApp.Domain;
using CopaApp.Domain.Repository.Abstract;
using CopaApp.Domain.Seletores;
using CopaApp.Infra.Data.Entities;
using CopaApp.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CopaApp.Infra.Data.Repository.Abstract
{
    public abstract class RepositoryBase<TEntity, TDomain, TSeletor> : IRepositoryBase<TDomain>
    where TEntity : EntityBase
    where TDomain : DomainBase
    where TSeletor : SeletorBase
    {
        /// <summary>
        /// A instance database
        /// </summary>
        protected IContext _context;
        protected IUnitOfWork _uow;
        protected IMapper _mapper;

        protected RepositoryBase(IUnitOfWork uow, IMapper mapper)
        {
            _context = uow.Context;
            this._uow = uow;
            _mapper = mapper;
        }

        /// <summary>
        /// Method for Insert
        /// </summary>
        /// <param name="obj"></param>
        public TDomain Insert(TDomain obj)
        {
            TEntity entity = MapperToEntity(obj);
            entity.Id = Guid.NewGuid();

            _context.Set<TEntity>().Add(entity);
            this.Save();

            return MapperToDomain(entity);
        }

        /// <summary>
        /// Method for update
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Update(TDomain obj)
        {
            TEntity entity = MapperToEntity(obj);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Method for delete
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Delete(Guid id)
        {
            TEntity entity = _context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
            _context.Set<TEntity>().Remove(entity);
            this.Save();
        }

        /// <summary>
        /// Return a entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TDomain GetById(Guid id)
        {
            var query = CreateQuery().FirstOrDefault(x => x.Id == id);

            return MapperToDomain(query);
        }

        /// <summary>
        /// Return a lits of entity by Ids
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual IEnumerable<TDomain> GetByIds(params Guid[] ids)
        {
            var query = CreateQuery().Where(x => ids.Contains(x.Id));

            return MapperToDomain(query);
        }

        /// <summary>
        /// Save actions
        /// </summary>
        public void Save() { }

        protected virtual TEntity MapperToEntity(object dto)
            => MapperToEntity<TEntity>(dto);

        protected virtual T MapperToEntity<T>(object dto) where T : EntityBase
        {
            T entity = (T)Activator.CreateInstance(typeof(T));
            Type entityTypes = entity.GetType();

            PropertyInfo[] propertyInfo = dto.GetType().GetProperties();
            foreach (PropertyInfo property in propertyInfo)
            {
                var value = property.GetValue(dto, null);
                var objectProperty = entityTypes.GetProperty(property.Name);

                if (objectProperty != null && objectProperty.PropertyType == property.PropertyType)
                {
                    objectProperty.SetValue(entity, value);
                }
            }

            return entity;
        }

        protected virtual TDomain MapperToDomain(TEntity entity)
        {
            return this._mapper.Map<TDomain>(entity);
        }

        protected virtual IEnumerable<TDomain> MapperToDomain(IEnumerable<TEntity> entity)
        {
            return _mapper.Map<IEnumerable<TDomain>>(entity);
        }

        public IQueryable<TEntity> CreateLimit(SeletorBase seletor, IEnumerable<TEntity> query)
        {
            if (seletor.Pagina < 0)
                seletor.Pagina = 1;

            int skip = ((seletor.Pagina - 1) * seletor.RegistroPorPagina);
            int take = seletor.RegistroPorPagina;

            return query.Skip(skip).Take(take).AsQueryable();
        }

        public virtual IEnumerable<TDomain> GetList(TSeletor seletor)
        {
            IEnumerable<TEntity> query = this.CreateQuery();

            query = this.CreateParameters(seletor, query);
            query = this.CreateLimit(seletor, query);

            return query.Select(x => MapperToDomain(x)).ToList();
        }

        public abstract IEnumerable<TEntity> CreateParameters(TSeletor seletor, IEnumerable<TEntity> query);

        public virtual IEnumerable<TEntity> CreateQuery()
        {
            return this._context.Set<TEntity>();
        }

        public int Count(TSeletor seletor)
        {
            var query = CreateQuery();
            query = CreateParameters(seletor, query);

            return query.Count();
        }
    }
}
