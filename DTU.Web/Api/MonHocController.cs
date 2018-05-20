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
    [RoutePrefix("api/monhoc")]
    public class MonHocController : ApiControllerBase
    {
        #region Khởi tạo
        IMonHocService _monHocService;
        public MonHocController(IErrorService errorService, IMonHocService monHocService)
            : base(errorService)
        {
            this._monHocService = monHocService;
        }
        #endregion

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listHocKy = _monHocService.GetAll();
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
                var modelNhanVien = _monHocService.GetById(id);

                var response = request.CreateResponse(HttpStatusCode.OK, modelNhanVien);

                return response;
            });
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage Update(HttpRequestMessage request, MonHoc monHoc)
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
                    _monHocService.Update(monHoc);
                    _monHocService.SaveChange();
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
                    _monHocService.KhoaMo(id);
                    _monHocService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.Created);
                }
                return response;
            });
        }

    }
}
