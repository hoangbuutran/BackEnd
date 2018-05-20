using DTU.Data.Infrastructure;
using DTU.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTU.Data.Repositories
{
    public interface IQuyenRepository : IRepository<Quyen>
    {
        void KhoaMo(int id);
    }
    public class QuyenRepository : RepositoryBase<Quyen>, IQuyenRepository
    {
        public QuyenRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
        public void KhoaMo(int id)
        {
            var namHoc = DbContext.Quyens.Find(id);
            namHoc.TrangThai = !namHoc.TrangThai;
        }
    }
}
