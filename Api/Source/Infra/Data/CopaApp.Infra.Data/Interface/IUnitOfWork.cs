namespace CopaApp.Infra.Data.Interface
{
    public interface IUnitOfWork
    {
        IContext Context { get; }

        void Commit();

        void Rollbak();
    }
}
