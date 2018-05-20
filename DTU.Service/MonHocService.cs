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
    public interface IMonHocService
    {

        void Update(MonHoc monHoc);


        IEnumerable<MonHoc> GetAll();


        //IEnumerable<MON_HOC> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow);

        MonHoc GetById(int id);

        IEnumerable<MonHoc> GetAllByTimKiemPaging(string timKiem, int page, int pageSize, out int totalRow);
        void KhoaMo(int id);
        void SaveChange();
    }

    public class MonHocService : IMonHocService
    {
        IMonHocRepository _monHocRepository;
        IUnitOfWork _unitOfWork;

        public MonHocService(IMonHocRepository monHocRepository, IUnitOfWork unitOfWork)
        {
            this._monHocRepository = monHocRepository;
            this._unitOfWork = unitOfWork;
        }


        public IEnumerable<MonHoc> GetAll()
        {
            return _monHocRepository.GetAll(new string[] { "CHUYENNGANH_MONHOC", "CT_PHIEU_DANG_KY" });
        }

        public IEnumerable<MonHoc> GetAllByTimKiemPaging(string timKiem, int page, int pageSize, out int totalRow)
        {
            return _monHocRepository.GetAllByTag(timKiem, page, pageSize, out totalRow);
        }

        public MonHoc GetById(int id)
        {
            return _monHocRepository.GetSingleByCondition(x => x.IdMonHoc == id, new string[] { "CHUYENNGANH_MONHOC", "CT_PHIEU_DANG_KY" });
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public void Update(MonHoc MON_HOC)
        {
            _monHocRepository.Update(MON_HOC);
        }


        //public void KhoaMo(int id)
        //{
        //    _monHocRepository.KhoaMo(id);
        //}


        public void KhoaMo(int id)
        {
            _monHocRepository.KhoaMo(id);
        }

    }
}
