using System.Threading.Tasks;

namespace Core.Framework.Repository
{
    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task SaveAsync();
    }
}
