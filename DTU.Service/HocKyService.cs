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
    public interface IHocKyService
    {
        IEnumerable<HocKy> GetAll();
        HocKy GetById(int id);
    }
    public class HocKyService : IHocKyService
    {
        IHocKyRepository _hocKyRepository;
        IUnitOfWork _unitOfWork;

        public HocKyService(IHocKyRepository hocKyRepository, IUnitOfWork unitOfWork)
        {
            this._hocKyRepository = hocKyRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<HocKy> GetAll()
        {
            return _hocKyRepository.GetAll(new string[] { "PHIEU_DANG_KY"});
        }


        public HocKy GetById(int id)
        {
            return _hocKyRepository.GetSingleById(id);
        }
    }
}
