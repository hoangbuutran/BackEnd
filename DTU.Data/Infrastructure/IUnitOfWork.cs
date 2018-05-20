namespace DTU.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}