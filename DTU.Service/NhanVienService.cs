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
    public interface INhanVienService
    {
        NhanVien Add(NhanVien nhanVien);

        void Update(NhanVien nhanVien);

        void Delete(int id);
        void KhoaMo(int id);
        IEnumerable<NhanVien> GetAll();

        IEnumerable<NhanVien> GetAllPaging(int page, int pageSize, out int totalRow);

        NhanVien GetById(int id);

        IEnumerable<NhanVien> GetAllByTimKiemPaging(string timKiem, int page, int pageSize, out int totalRow);

        string ThayDoiChuoi(string text);

        string[] XoaKyTuTrang(string[] chuoi);

        void SaveChange();
    }


    public class NhanVienService : INhanVienService
    {
        INhanVienRepository _nhanVienRepository;
        IUnitOfWork _unitOfWork;

        public NhanVienService(INhanVienRepository nhanVienRepository, IUnitOfWork unitOfWork)
        {
            this._nhanVienRepository = nhanVienRepository;
            this._unitOfWork = unitOfWork;
        }

        public NhanVien Add(NhanVien nhanVien)
        {
            return _nhanVienRepository.Add(nhanVien);
        }

        public void Delete(int id)
        {
            _nhanVienRepository.Delete(id);
        }

        public IEnumerable<NhanVien> GetAll()
        {
            return _nhanVienRepository.GetAll(new string[] { "TaiKhoan"});
        }

        public IEnumerable<NhanVien> GetAllByTimKiemPaging(string timKiem, int page, int pageSize, out int totalRow)
        {
            return _nhanVienRepository.GetAllByTag(timKiem, page, pageSize, out totalRow);
        }

        public IEnumerable<NhanVien> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _nhanVienRepository.GetMultiPaging(x => x.TrangThai == true || x.TrangThai == false, out totalRow, page, pageSize);
        }

        public NhanVien GetById(int id)
        {
            return _nhanVienRepository.GetSingleByCondition(x => x.IdNhanVien == id, new string[] { "TaiKhoan" });
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(NhanVien nhanVien)
        {
            _nhanVienRepository.Update(nhanVien);
        }


        public void KhoaMo(int id)
        {
            _nhanVienRepository.KhoaMo(id);
        }


        public string ThayDoiChuoi(string text)
        {
            return _nhanVienRepository.ThayDoiChuoi(text);
        }


        public string[] XoaKyTuTrang(string[] chuoi)
        {
            return _nhanVienRepository.XoaKyTuTrang(chuoi);
        }


        public void SaveChange()
        {
            _unitOfWork.Commit();
        }
    }
}
