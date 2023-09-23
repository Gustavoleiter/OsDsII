
namespace OsDsii.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync();
    }
}