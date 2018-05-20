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
    public interface ISinhVienService
    {
        SinhVien Add(SinhVien sinhVien);

        void Update(SinhVien sinhVien);

        void Delete(int id);
        void KhoaMo(int id);
        IEnumerable<SinhVien> GetAll();

        IEnumerable<SinhVien> GetAllPaging(int page, int pageSize, out int totalRow);

        SinhVien GetById(int id);

        IEnumerable<SinhVien> GetAllByTimKiemPaging(string timKiem, int page, int pageSize, out int totalRow);

        string ThayDoiChuoi(string text);

        string[] XoaKyTuTrang(string[] chuoi);

        void SaveChange();
    }

    public class SinhVienService : ISinhVienService
    {
        ISinhVienRepository _sinhVienRepository;
        IUnitOfWork _unitOfWork;

        public SinhVienService(ISinhVienRepository sinhVienRepository, IUnitOfWork unitOfWork)
        {
            this._sinhVienRepository = sinhVienRepository;
            this._unitOfWork = unitOfWork;
        }

        public SinhVien Add(SinhVien sinhVien)
        {
            return _sinhVienRepository.Add(sinhVien);
        }

        public void Delete(int id)
        {
            _sinhVienRepository.Delete(id);
        }

        public IEnumerable<SinhVien> GetAll()
        {
            return _sinhVienRepository.GetAll(new string[] { "ChuyenNganh", "PhieuDangKy", "TaiKhoan" });
        }

        public IEnumerable<SinhVien> GetAllByTimKiemPaging(string timKiem, int page, int pageSize, out int totalRow)
        {
            return _sinhVienRepository.GetAllByTag(timKiem, page, pageSize, out totalRow);
        }

        public IEnumerable<SinhVien> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _sinhVienRepository.GetMultiPaging(x => x.TrangThai == true || x.TrangThai == false, out totalRow, page, pageSize);
        }

        public SinhVien GetById(int id)
        {
            return _sinhVienRepository.GetSingleByCondition(x => x.IdSinhVien == id, new string[] { "ChuyenNganh", "PhieuDangKy", "TaiKhoan" });
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public void Update(SinhVien sinhVien)
        {
            _sinhVienRepository.Update(sinhVien);
        }


        public void KhoaMo(int id)
        {
            _sinhVienRepository.KhoaMo(id);
        }


        public string ThayDoiChuoi(string text)
        {
            return _sinhVienRepository.ThayDoiChuoi(text);
        }


        public string[] XoaKyTuTrang(string[] chuoi)
        {
            return _sinhVienRepository.XoaKyTuTrang(chuoi);
        }
    }
}
