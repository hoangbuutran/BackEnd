using DTU.Common.Class_Chung;
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
    [RoutePrefix("api/taikhoan")]
    public class TaiKhoanController : ApiControllerBase
    {
        #region Khởi tạo
        ITaiKhoanService _taiKhoanService;
        public TaiKhoanController(IErrorService errorService, ITaiKhoanService taiKhoanService)
            : base(errorService)
        {
            this._taiKhoanService = taiKhoanService;
        }
        #endregion

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listQuyen = _taiKhoanService.GetAll();
                HttpResponseMessage reponse = request.CreateResponse(HttpStatusCode.OK, listQuyen);
                return reponse;
            });
        }

        [Route("listCountTaiKhoanGiaoVu")]
        public HttpResponseMessage listCountTaiKhoanGiaoVu(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCountTaiKhoanGiaoVu = _taiKhoanService.listCountTaiKhoanGiaoVu();
                HttpResponseMessage reponse = request.CreateResponse(HttpStatusCode.OK, listCountTaiKhoanGiaoVu);
                return reponse;
            });
        }

        [Route("listCountTaiKhoanSinhVien")]
        public HttpResponseMessage listCountTaiKhoanSinhVien(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCountTaiKhoanSinhVien = _taiKhoanService.listCountTaiKhoanSinhVien();
                HttpResponseMessage reponse = request.CreateResponse(HttpStatusCode.OK, listCountTaiKhoanSinhVien);
                return reponse;
            });
        }

        [Route("getbyid/{id:int}")]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var QuyenSingler = _taiKhoanService.GetById(id);
                HttpResponseMessage reponse = request.CreateResponse(HttpStatusCode.OK, QuyenSingler);
                return reponse;
            });
        }

        [Route("login")]
        public HttpResponseMessage GetById(HttpRequestMessage request, LoginModel Login)
        {
            return CreateHttpResponse(request, () =>
            {
                var taiKhoanModel = _taiKhoanService.login(Login.UserName, Login.Pass);
                HttpResponseMessage reponse = request.CreateResponse(HttpStatusCode.OK, taiKhoanModel);
                return reponse;
            });
        }

        [Route("getsingercondition")]
        [HttpPost]
        public HttpResponseMessage GetSingerCondition(HttpRequestMessage request, LoginModel Login)
        {
            return CreateHttpResponse(request, () =>
            {
                var GetSingerCondition = _taiKhoanService.GetSingerCondition(Login.UserName, Login.Pass);
                HttpResponseMessage reponse = request.CreateResponse(HttpStatusCode.OK, GetSingerCondition);
                return reponse;
            });
        }

        [Route("DoiMatKhau")]
        [HttpPost]
        public HttpResponseMessage DoiMatKhau(HttpRequestMessage request, DoiMatKhauModel model)
        {
            return CreateHttpResponse(request, () =>
            {
                var DoiMatKhauTaiKhoan = _taiKhoanService.DoiMatKhau(model.PassNew, model.PassOld, model.UserName);
                HttpResponseMessage reponse = request.CreateResponse(HttpStatusCode.OK, DoiMatKhauTaiKhoan);
                return reponse;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, TaiKhoan taiKhoan)
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
                    var ModelTaiKhoan = _taiKhoanService.Add(taiKhoan);
                    _taiKhoanService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.Created, ModelTaiKhoan);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage Update(HttpRequestMessage request, TaiKhoan taiKhoan)
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
                    _taiKhoanService.Update(taiKhoan);
                    _taiKhoanService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.Created);
                }
                return response;
            });
        }

        [Route("khoamo")]
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
                    _taiKhoanService.KhoaMo(id);
                    _taiKhoanService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.Created);
                }
                return response;
            });
        }
    }
}
