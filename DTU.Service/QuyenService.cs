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
    public interface IQuyenService
    {
        Quyen GetById(int id);
        IEnumerable<Quyen> GetAll();
        Quyen Add(Quyen quyen);
        void Update(Quyen quyen);
        void KhoaMo(int id);
        Quyen Delete(int id);
        void SaveChange();
    }
    public class QuyenService : IQuyenService
    {
        IQuyenRepository _quyenRepository;
        IUnitOfWork _unitOfWork;

        public QuyenService(IQuyenRepository quyenRepository, IUnitOfWork unitOfWork)
        {
            this._quyenRepository = quyenRepository;
            this._unitOfWork = unitOfWork;
        }

        public Quyen GetById(int id)
        {
            return _quyenRepository.GetSingleById(id);
        }

        public IEnumerable<Quyen> GetAll()
        {
            return _quyenRepository.GetAll(new string[] { "TaiKhoan" });
        }

        public Quyen Add(Quyen quyen)
        {
            return _quyenRepository.Add(quyen);
        }

        public void Update(Quyen quyen)
        {
            _quyenRepository.Update(quyen);
        }

        public void KhoaMo(int id)
        {
            _quyenRepository.KhoaMo(id);
        }


        public void SaveChange()
        {
            _unitOfWork.Commit();
        }


        public Quyen Delete(int id)
        {
            return _quyenRepository.Delete(id);
        }
    }
}
