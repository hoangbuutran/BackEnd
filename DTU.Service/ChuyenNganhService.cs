using DTU.Data.Infrastructure;
using DTU.Data.Repositories;
using DTU.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTU.Service
{
    public interface IChuyenNganhService
    {
        IEnumerable<ChuyenNganh> GetAll();
    }
    public class ChuyenNganhService : IChuyenNganhService
    {
        IChuyenNganhRepository _chuyenNganhRepository;
        IUnitOfWork _unitOfWork;

        public ChuyenNganhService(IChuyenNganhRepository chuyenNganhRepository, IUnitOfWork unitOfWork)
        {
            this._chuyenNganhRepository = chuyenNganhRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<ChuyenNganh> GetAll()
        {
            return _chuyenNganhRepository.GetAll(new string[] { "CHUYENNGANH_MONHOC", "SINH_VIEN" });
        }
    }
}
