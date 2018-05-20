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
    [RoutePrefix("api/hocky")]
    public class HocKyController : ApiControllerBase
    {
        IHocKyService _hocKyService;
        public HocKyController(IErrorService errorService, IHocKyService hocKyService)
            : base(errorService)
        {
            this._hocKyService = hocKyService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listHocKy = _hocKyService.GetAll();
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
                var modelHocKy = _hocKyService.GetById(id);
                var response = request.CreateResponse(HttpStatusCode.OK, modelHocKy);
                return response;
            });
        }

    }
}
