using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DialogFlowWebApi.Models;
using Newtonsoft.Json.Linq;

namespace DialogFlowWebApi.Controllers
{
    [RoutePrefix("api/drugs")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class drugsController : ApiController
    {
        // GET: api/drugs
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/drugs/5
        [HttpGet]
        [Route("getDrugs/{id}")]
        public drugs Get(int idPerson)
        {
            using (DialogflowDataEntities7 db = new DialogflowDataEntities7())
            {
                try
                {
                    return db.drugs.FirstOrDefault(e => e.idPerson == idPerson);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        // POST: api/drugs
        [HttpPost]
        [Route("saveDrugs")]
        public void Post([FromBody] JObject drug)
        {
            drugs entity= new drugs();
            entity.id = 0;
            entity.idPerson = (int)drug.SelectToken("idPerson");
            entity.nameDrug = (string)drug.SelectToken("nameDrug");
            entity.isDrugs = (bool)drug.SelectToken("isDrugs");
            using (DialogflowDataEntities7 db = new DialogflowDataEntities7())
            {
                try
                {
                    db.drugs.Add(entity);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        // PUT: api/drugs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/drugs/5
        public void Delete(int id)
        {
        }
    }
}
