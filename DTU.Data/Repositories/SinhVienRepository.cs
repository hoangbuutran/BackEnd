using DTU.Data.Infrastructure;
using DTU.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DTU.Data.Repositories
{
    public interface ISinhVienRepository : IRepository<SinhVien>
    {
        IEnumerable<SinhVien> GetAllByTag(string timKiem, int pageIndex, int pageSize, out int totalRow);
        void KhoaMo(int id);
        string ThayDoiChuoi(string text);
        string[] XoaKyTuTrang(string[] chuoi);
    }

    public class SinhVienRepository : RepositoryBase<SinhVien>, ISinhVienRepository
    {
        public SinhVienRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
        public IEnumerable<SinhVien> GetAllByTag(string timKiem, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.SinhViens
                        join pt in DbContext.ChuyenNganhs
                        on p.IdChuyenNganh equals pt.IDChuyenNganh
                        where p.TenSinhVien.Contains(timKiem) ||
                              p.MaSinhVien.Contains(timKiem) ||
                              p.Email.Contains(timKiem) ||
                              p.DiaChi.Contains(timKiem) ||
                              pt.TenChuyenNganh.Contains(timKiem)
                        select p;

            totalRow = query.Count();

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return query;
        }
        public void KhoaMo(int id)
        {
            var namHoc = DbContext.SinhViens.Find(id);
            namHoc.TrangThai = !namHoc.TrangThai;
        }

        public string ThayDoiChuoi(string text)
        {
            string[] pattern = new string[7];
            pattern[0] = "a|á|ả|à|ạ|ã|ă|ắ|ẳ|ằ|ặ|ẵ|â|ấ|ẩ|ầ|ậ|ẫ";
            pattern[1] = "o|ó|ỏ|ò|ọ|õ|ô|ố|ổ|ồ|ộ|ỗ|ơ|ớ|ở|ờ|ợ|ỡ";
            pattern[2] = "e|é|è|ẻ|ẹ|ẽ|ê|ế|ề|ể|ệ|ễ";
            pattern[3] = "u|ú|ù|ủ|ụ|ũ|ư|ứ|ừ|ử|ự|ữ";
            pattern[4] = "i|í|ì|ỉ|ị|ĩ";
            pattern[5] = "y|ý|ỳ|ỷ|ỵ|ỹ";
            pattern[6] = "d|đ";
            for (int i = 0; i < pattern.Length; i++)
            {
                char replaceChar = pattern[i][0];
                MatchCollection matchs = Regex.Matches(text, pattern[i]);
                foreach (Match m in matchs)
                {
                    text = text.Replace(m.Value[0], replaceChar);
                }
            }
            return text;
        }
        public string[] XoaKyTuTrang(string[] chuoi)
        {
            string[] user = chuoi;
            for (int i = 0; i <= user.Length; i++)
            {
                if (user[i] == " ")
                {
                    for (int j = i; j < user.Length; j++)
                    {
                        user[j] = user[j + 1];
                    }
                }
            }
            return user;
        }
    }
}
