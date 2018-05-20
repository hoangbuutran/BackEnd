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
    #region Interface Tài khoản service 
    public interface ITaiKhoanService
    {
        TaiKhoan Add(TaiKhoan taiKhoan);

        void Update(TaiKhoan taiKhoan);

        TaiKhoan Delete(int id);

        void KhoaMo(int id);

        IEnumerable<TaiKhoan> GetAll();

        /// <summary>
        /// xóa với id quyền truyền vào
        /// </summary>
        /// <param name="id"></param>
        void DeleteMulti(int id);

        int listCountTaiKhoanGiaoVu();

        int listCountTaiKhoanSinhVien();

        TaiKhoan GetById(int id);

        TaiKhoan GetSingerCondition(string userName, string pass);

        int listCountTaiKhoanCheckLogin(string userName, string pass);

        TaiKhoan DoiMatKhau(string passNew, string passOld, string userName);

        TaiKhoan login(string userName, string pass);

        void SaveChange();
    }
    #endregion
    #region Tài khoản service
    public class TaiKhoanService : ITaiKhoanService
    {
        ITaiKhoanRepository _taiKhoanRepository;
        IUnitOfWork _unitOfWork;

        public TaiKhoanService(ITaiKhoanRepository taiKhoanRepository, IUnitOfWork unitOfWork)
        {
            this._taiKhoanRepository = taiKhoanRepository;
            this._unitOfWork = unitOfWork;
        }

        public int listCountTaiKhoanGiaoVu()
        {
            return _taiKhoanRepository.Count(x => x.IdQuyen == 2);
        }

        public int listCountTaiKhoanSinhVien()
        {
            return _taiKhoanRepository.Count(x => x.IdQuyen == 3);
        }

        public TaiKhoan GetById(int id)
        {
            return _taiKhoanRepository.GetSingleById(id);
        }

        public TaiKhoan GetSingerCondition(string userName, string pass)
        {
            return _taiKhoanRepository.GetSingleByCondition(x => x.UserName == userName && x.Pass == pass);
        }

        public int listCountTaiKhoanCheckLogin(string userName, string pass)
        {
            return _taiKhoanRepository.Count(x => x.UserName == userName && x.Pass == pass && x.TrangThai == true);
        }

        public TaiKhoan DoiMatKhau(string passNew, string passOld, string userName)
        {
            var taiKhoanModel = GetSingerCondition(userName, passOld);
            taiKhoanModel.Pass = passNew;
            _taiKhoanRepository.Update(taiKhoanModel);
            return taiKhoanModel;
        }

        public TaiKhoan Add(TaiKhoan taiKhoan)
        {
            return _taiKhoanRepository.Add(taiKhoan);
        }

        public void Update(TaiKhoan taiKhoan)
        {
            _taiKhoanRepository.Update(taiKhoan);
        }

        public TaiKhoan Delete(int id)
        {
            return _taiKhoanRepository.Delete(id);
        }

        public void KhoaMo(int id)
        {
            _taiKhoanRepository.KhoaMo(id);
        }

        public IEnumerable<TaiKhoan> GetAll()
        {
            return _taiKhoanRepository.GetAll(new string[] { "NhanVien", "Quyen", "SinhVien" });
        }


        public TaiKhoan login(string userName, string pass)
        {
            return GetSingerCondition(userName, pass);
        }


        public void SaveChange()
        {
            _unitOfWork.Commit();
        }


        public void DeleteMulti(int id)
        {
            _taiKhoanRepository.DeleteMulti(x => x.IdQuyen == id);
        }
    }
    #endregion
}
