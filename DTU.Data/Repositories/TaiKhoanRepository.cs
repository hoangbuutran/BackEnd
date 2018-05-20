using DTU.Data.Infrastructure;
using DTU.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTU.Data.Repositories
{
    public interface ITaiKhoanRepository : IRepository<TaiKhoan>
    {
        void KhoaMo(int id);
    }
    public class TaiKhoanRepository : RepositoryBase<TaiKhoan>, ITaiKhoanRepository
    {
        public TaiKhoanRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public void KhoaMo(int id)
        {
            var namHoc = DbContext.TaiKhoans.Find(id);
            namHoc.TrangThai = !namHoc.TrangThai;
        }
    }
}
