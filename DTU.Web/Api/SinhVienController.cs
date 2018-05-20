using DTU.Model.Models;
using DTU.Service;
using DTU.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DTU.Web.Api
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/sinhvien")]
    public class SinhVienController : ApiControllerBase
    {
        ISinhVienService _sinhVienService;
        ITaiKhoanService _taiKhoanService;
        public SinhVienController(IErrorService errorService, ISinhVienService sinhVienService, ITaiKhoanService taiKhoanService)
            : base(errorService)
        {
            this._sinhVienService = sinhVienService;
            this._taiKhoanService = taiKhoanService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listHocKy = _sinhVienService.GetAll();
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
                var modelsinhVien = _sinhVienService.GetById(id);

                var response = request.CreateResponse(HttpStatusCode.OK, modelsinhVien);

                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, SinhVien sinhVien)
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
                    var tentaikhoan1 = sinhVien.TenSinhVien.ToLower();
                    var tentaikhoan2 = _sinhVienService.ThayDoiChuoi(tentaikhoan1);
                    var tentaikhoan3 = tentaikhoan2.Replace(" ", "");
                    var pass = sinhVien.DienThoai.Substring(6);//01266625412
                    var taikhoan = new TaiKhoan
                    {
                        UserName = tentaikhoan3,
                        Pass = pass,
                        IdQuyen = 2
                    };
                    var taiKhoan = _taiKhoanService.Add(taikhoan);
                    if (taiKhoan.IdTaiKhoan != 0)
                    {
                        var ModelQuyen = _sinhVienService.Add(sinhVien);
                        _sinhVienService.SaveChange();
                        response = request.CreateResponse(HttpStatusCode.Created, ModelQuyen);
                    }
                }
                return response;
            });
        }
        [Route("update")]
        [HttpPost]
        public HttpResponseMessage Update(HttpRequestMessage request, SinhVien sinhVien)
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
                    _sinhVienService.Update(sinhVien);
                    _sinhVienService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.Created);
                }
                return response;
            });
        }

        [Route("UploadExcel")]
        [HttpPost]
        public HttpResponseMessage UploadExcel(HttpRequestMessage request, SinhVien sinhVien, HttpPostedFileBase FileUpload)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                response = request.CreateResponse(HttpStatusCode.Created);

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
                    _sinhVienService.KhoaMo(id);
                    _sinhVienService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.Created);
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
                    _sinhVienService.Delete(id);
                    _sinhVienService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.Created);
                }
                return response;
            });
        }
    }
}
