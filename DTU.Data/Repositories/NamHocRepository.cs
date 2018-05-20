using DTU.Data.Infrastructure;
using DTU.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DTU.Data.Repositories
{
    public interface INamHocRepository : IRepository<NamHoc>
    {
        IEnumerable<NamHoc> GetAllByTag(string timKiem, int pageIndex, int pageSize, out int totalRow);
        void KhoaMo(int id);
    }

    public class NamHocRepository : RepositoryBase<NamHoc>, INamHocRepository
    {
        public NamHocRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
        public IEnumerable<NamHoc> GetAllByTag(string timKiem, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.NamHocs
                        where p.TenNamHoc == timKiem
                        select p;

            totalRow = query.Count();

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return query;
        }


        public void KhoaMo(int id)
        {
            var namHoc = DbContext.NamHocs.Find(id);
            namHoc.TrangThai = !namHoc.TrangThai;
        }
    }
}