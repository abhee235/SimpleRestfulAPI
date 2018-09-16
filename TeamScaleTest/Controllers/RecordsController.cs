using DataProvider;
using DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TeamScaleTest.Controllers
{
    public class RecordsController : ApiController
    {
        public IPersonRecordServices _service;
        public RecordsController(IPersonRecordServices service)
        {
            _service = service;
        }
        // GET: api/Records
        public IEnumerable<RecordsModel> Get()
        {
            return _service.GetUSPersonRecords();
        }

        public RecordsModel Get(int id)
        {
            return _service.GetUSPersonRecordbyId(id);
        }

        public IEnumerable<RecordsModel> Get(int inbound, int limit)
        {
            int actualinbound = inbound - 1;
            return _service.GetLimitedUSPersonRecords(actualinbound, limit);
        }

        // PUT: api/Records/5
        public HttpResponseMessage Post([FromBody]RecordsModel recModel)
        {
            _service.UpdateUserRecord(recModel);
            var response = Request.CreateResponse(HttpStatusCode.Moved);
            response.Headers.Location = new Uri("http://localhost:54196/ApiHarness.html");
            return response;
        }

    }
}
