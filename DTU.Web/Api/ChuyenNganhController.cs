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
    [RoutePrefix("api/chuyennganh")]
    public class ChuyenNganhController : ApiControllerBase
    {
        IChuyenNganhService _chuyenNganhService;
        public ChuyenNganhController(IErrorService errorService, IChuyenNganhService chuyenNganhService)
            : base(errorService)
        {
            this._chuyenNganhService = chuyenNganhService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listChuyenNganh = _chuyenNganhService.GetAll();
                HttpResponseMessage reponse = request.CreateResponse(HttpStatusCode.OK, listChuyenNganh);
                return reponse;
            });
        }
    }
}
