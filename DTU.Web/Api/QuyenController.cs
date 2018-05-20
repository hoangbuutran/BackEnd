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
using System.Web.Script.Serialization;

namespace DTU.Web.Api
{
    #region api/quyen
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/quyen")]
    public class QuyenController : ApiControllerBase
    {
        #region Khởi tạo
        IQuyenService _quyenService;
        ITaiKhoanService _taiKhoanService;
        INhanVienService _nhanVienService;
        ISinhVienService _sinhVienService;
        public QuyenController(IErrorService errorService, IQuyenService quyenService, ITaiKhoanService taiKhoanService, INhanVienService nhanVienService, ISinhVienService sinhVienService)
            : base(errorService)
        {
            this._quyenService = quyenService;
            this._taiKhoanService = taiKhoanService;
            this._nhanVienService = nhanVienService;
            this._sinhVienService = sinhVienService;
        }
        #endregion

        #region GetAll
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listQuyen = _quyenService.GetAll();
                HttpResponseMessage reponse = request.CreateResponse(HttpStatusCode.OK, listQuyen);
                return reponse;
            });
        }
        #endregion

        #region getbyid
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var QuyenSingler = _quyenService.GetById(id);
                HttpResponseMessage reponse = request.CreateResponse(HttpStatusCode.OK, QuyenSingler);
                return reponse;
            });
        }
        #endregion


        #region create
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, Quyen quyen)
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
                    var ModelQuyen = _quyenService.Add(quyen);
                    _quyenService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.Created, ModelQuyen);
                }
                return response;
            });
        }
        #endregion


        #region update
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, Quyen quyen)
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
                    _quyenService.Update(quyen);
                    _quyenService.SaveChange();
                    var quyenFind = _quyenService.GetById(quyen.IdQuyen);
                    response = request.CreateResponse(HttpStatusCode.Created, quyenFind);
                }
                return response;
            });
        }
        #endregion


        #region khoamo
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
                    _quyenService.KhoaMo(id);
                    _quyenService.SaveChange();
                    var quyenFind = _quyenService.GetById(id);
                    response = request.CreateResponse(HttpStatusCode.Created, quyenFind);
                }
                return response;
            });
        }
        #endregion


        #region delete
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
                    var listNhanVien = _nhanVienService.GetAll();
                    foreach (var item in listNhanVien)
                    {
                        if (item.TaiKhoan.IdQuyen == id)
                        {
                            var nhanVien = _nhanVienService.GetById(item.IdNhanVien);
                            _taiKhoanService.Delete((int)item.IdTaiKhoan);
                            _nhanVienService.Delete(nhanVien.IdNhanVien);
                        }
                    }
                    _quyenService.SaveChange();
                    var listSinhVien = _sinhVienService.GetAll();
                    foreach (var item in listSinhVien)
                    {
                        if (item.TaiKhoan.IdQuyen == id)
                        {
                            var sinhVien = _sinhVienService.GetById(item.IdSinhVien);
                            _taiKhoanService.Delete((int)item.IdTaiKhoan);
                            _sinhVienService.Delete(sinhVien.IdSinhVien);
                        }
                    }
                    _quyenService.SaveChange();
                    var QuyenModel = _quyenService.Delete(id);
                    _quyenService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.Created, QuyenModel);
                }
                return response;
            });
        }
        #endregion

    }
    #endregion
}
