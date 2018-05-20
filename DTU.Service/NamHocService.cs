using System;
using System.Collections.Generic;
using DTU.Data.Infrastructure;
using DTU.Data.Repositories;
using DTU.Model.Models;
using System.Linq;

namespace DTU.Service
{
    public interface INamHocService
    {
        NamHoc Add(NamHoc NAM_HOC);

        void Update(NamHoc NAM_HOC);

        void Delete(int id);
        void KhoaMo(int id);
        IEnumerable<NamHoc> GetAll();

        //IEnumerable<NAM_HOC> GetAllPaging(int page, int pageSize, out int totalRow);

        //IEnumerable<NAM_HOC> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow);

        NamHoc GetById(int id);

        IEnumerable<NamHoc> GetAllByTimKiemPaging(string timKiem, int page, int pageSize, out int totalRow);

        void SaveChanges();
    }

    public class NamHocService : INamHocService
    {
        INamHocRepository _namHocRepository;
        IUnitOfWork _unitOfWork;

        public NamHocService(INamHocRepository namHocRepository, IUnitOfWork unitOfWork)
        {
            this._namHocRepository = namHocRepository;
            this._unitOfWork = unitOfWork;
        }

        public NamHoc Add(NamHoc NAM_HOC)
        {
            return _namHocRepository.Add(NAM_HOC);
        }

        public void Delete(int id)
        {
            _namHocRepository.Delete(id);
        }

        public IEnumerable<NamHoc> GetAll()
        {
            return _namHocRepository.GetAll(new string[] { "PHIEU_DANG_KY" });
        }

        //public IEnumerable<NAM_HOC> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow)
        //{
        //    return _namHocRepository.GetMultiPaging(x => x.Status && x.CategoryID == categoryId, out totalRow, page, pageSize, new string[] { "NAM_HOCCategory" });
        //}

        public IEnumerable<NamHoc> GetAllByTimKiemPaging(string timKiem, int page, int pageSize, out int totalRow)
        {
            return _namHocRepository.GetAllByTag(timKiem, page, pageSize, out totalRow);
        }

        public IEnumerable<NamHoc> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _namHocRepository.GetMultiPaging(x => x.TrangThai == true || x.TrangThai == false, out totalRow, page, pageSize);
        }

        public NamHoc GetById(int id)
        {
            return _namHocRepository.GetSingleByCondition(x => x.IdNamHoc == id, new string[] { "PHIEU_DANG_KY" });
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(NamHoc NAM_HOC)
        {
            _namHocRepository.Update(NAM_HOC);
        }


        public void KhoaMo(int id)
        {
            _namHocRepository.KhoaMo(id);
        }
    }
}