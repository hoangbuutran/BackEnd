using DTU.Model.Models;
using DTU.Service;
using DTU.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DTU.Web.Api
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/nhanvien")]
    public class NhanVienController : ApiControllerBase
    {
        INhanVienService _nhanVienService;
        ITaiKhoanService _taiKhoanService;
        public NhanVienController(IErrorService errorService, INhanVienService nhanVienService, ITaiKhoanService taiKhoanService)
            : base(errorService)
        {
            this._nhanVienService = nhanVienService;
            this._taiKhoanService = taiKhoanService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listHocKy = _nhanVienService.GetAll();
                HttpResponseMessage reponse = request.CreateResponse(HttpStatusCode.OK, listHocKy);
                return reponse;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var modelNhanVien = _nhanVienService.GetById(id);

                var response = request.CreateResponse(HttpStatusCode.OK, modelNhanVien);

                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, NhanVien nhanVien)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var tentaikhoan1 = nhanVien.TenNhanVien.ToLower();
                    var tentaikhoan2 = _nhanVienService.ThayDoiChuoi(tentaikhoan1);
                    var tentaikhoan3 = tentaikhoan2.Replace(" ", "");
                    var pass = nhanVien.DienThoai.Substring(6);//01266625412
                    var taikhoan = new TaiKhoan
                    {
                        UserName = tentaikhoan3,
                        Pass = pass,
                        IdQuyen = 2,
                        TrangThai = true,
                    };
                    var taiKhoan = _taiKhoanService.Add(taikhoan);
                    _nhanVienService.SaveChange();
                    if (taiKhoan.IdTaiKhoan != 0)
                    {
                        nhanVien.IdTaiKhoan = taikhoan.IdTaiKhoan;
                        var ModelQuyen = _nhanVienService.Add(nhanVien);
                        _nhanVienService.SaveChange();
                        response = request.CreateResponse(HttpStatusCode.Created, ModelQuyen);
                    }
                }
                return response;
            });
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, NhanVien nhanVien)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _nhanVienService.Update(nhanVien);
                    _nhanVienService.SaveChange();
                    var nhanVienFind = _nhanVienService.GetById(nhanVien.IdNhanVien);
                    response = request.CreateResponse(HttpStatusCode.Created, nhanVienFind);
                }
                return response;
            });
        }

        [Route("khoamo/{id:int}")]
        [HttpGet]
        public HttpResponseMessage KhoaMo(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _nhanVienService.KhoaMo(id);
                    _nhanVienService.SaveChange();
                    var nhanVienFind = _nhanVienService.GetById(id);
                    response = request.CreateResponse(HttpStatusCode.Created, nhanVienFind);
                }
                return response;
            });
        }
        [Route("delete/{id:int}")]
        [HttpGet]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var nhanVien = _nhanVienService.GetById(id);
                    var taiKhoan =_taiKhoanService.Delete((int)nhanVien.IdTaiKhoan);
                    _taiKhoanService.SaveChange();
                    _nhanVienService.Delete(id);
                    _nhanVienService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.Created, "Delete susscess");
                }
                return response;
            });
        }
    }
}
