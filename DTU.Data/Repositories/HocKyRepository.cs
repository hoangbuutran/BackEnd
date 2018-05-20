using DTU.Data.Infrastructure;
using DTU.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTU.Data.Repositories
{
    public interface IHocKyRepository : IRepository<HocKy>
    {

    }

    public class HocKyRepository : RepositoryBase<HocKy>, IHocKyRepository
    {
        public HocKyRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
