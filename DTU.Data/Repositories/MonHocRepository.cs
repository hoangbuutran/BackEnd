using DTU.Data.Infrastructure;
using DTU.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTU.Data.Repositories
{
    public interface IMonHocRepository : IRepository<MonHoc>
    {
        IEnumerable<MonHoc> GetAllByTag(string timKiem, int pageIndex, int pageSize, out int totalRow);
        void KhoaMo(int id);
    }
    public class MonHocRepository : RepositoryBase<MonHoc>, IMonHocRepository
    {
        public MonHocRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
        public IEnumerable<MonHoc> GetAllByTag(string timKiem, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.MonHocs
                        where p.TenMonHoc.Contains(timKiem) ||
                              p.MaMonHoc.Contains(timKiem) ||
                              p.MoTa.Contains(timKiem)
                        select p;

            totalRow = query.Count();

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return query;
        }
        public void KhoaMo(int id)
        {
            var namHoc = DbContext.NhanViens.Find(id);
            namHoc.TrangThai = !namHoc.TrangThai;
        }
    }
}
