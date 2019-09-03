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
    [RoutePrefix("api/smoking")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class smokingController : ApiController
    {
        // GET: api/smoking
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/smoking/5
        [HttpGet]
        [Route("getSmoking/{id}")]
        public smoking Get(int idPerson)
        {
            using (DialogflowDataEntities7 db = new DialogflowDataEntities7())
            {
                try
                {
                    return db.smoking.FirstOrDefault(e => e.idPerson == idPerson);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        // POST: api/smoking
        [HttpPost]
        [Route("saveSmoking")]
        public void Post([FromBody] JObject smoke)
        {
            smoking entity = new smoking();
            entity.id = 0;
            entity.idPerson = (int)smoke.SelectToken("idPerson");
            entity.brand = (string)smoke.SelectToken("brand");
            entity.isSmoking = (bool)smoke.SelectToken("isSmoking");
            entity.often= (string)smoke.SelectToken("often");
            entity.amountType = (string)smoke.SelectToken("amountType");
            using (DialogflowDataEntities7 db = new DialogflowDataEntities7())
            {
                try
                {
                    db.smoking.Add(entity);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        // PUT: api/smoking/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/smoking/5
        public void Delete(int id)
        {
        }
    }
}
