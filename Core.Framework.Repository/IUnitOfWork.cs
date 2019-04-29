namespace Core.Framework.Repository
{
    public interface IUnitOfWork
    {
        void Save();
        void Rollback();
    }
}
