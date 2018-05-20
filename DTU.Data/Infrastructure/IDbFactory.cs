using System;

namespace DTU.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        CoSoDuLieuDbContext Init();
    }
}