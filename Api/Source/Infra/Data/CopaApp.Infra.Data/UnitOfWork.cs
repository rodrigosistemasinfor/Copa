using CopaApp.Infra.Data.Interface;
using Newtonsoft.Json;

namespace CopaApp.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IContext context)
        {
            this.Context = context;
        }

        public UnitOfWork(string contextJSON)
        {
            this.Context = JsonConvert.DeserializeObject<Context>(contextJSON);
        }

        public IContext Context { get; }

        public void Commit() { }

        public void Rollbak() { }
    }
}
