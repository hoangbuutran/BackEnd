namespace DTU.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private CoSoDuLieuDbContext dbContext;

        public CoSoDuLieuDbContext Init()
        {
            return dbContext ?? (dbContext = new CoSoDuLieuDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}