using DTU.Data.Infrastructure;
using DTU.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTU.Data.Repositories
{
    public interface IChuyenNganhRepository : IRepository<ChuyenNganh>
    {

    }

    public class ChuyenNganhRepository : RepositoryBase<ChuyenNganh>, IChuyenNganhRepository
    {
        public ChuyenNganhRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
