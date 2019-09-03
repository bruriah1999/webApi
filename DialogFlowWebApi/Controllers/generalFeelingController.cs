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
    [RoutePrefix("api/GeneralFeeling")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class generalFeelingController : ApiController
    {

        // GET: api/generalFeeling
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/generalFeeling/5
        [HttpGet]
        [Route("getGeneralFeeling/{id}")]
        public generalFeeling Get(int idPerson)
        {
            using (DialogflowDataEntities7 db = new DialogflowDataEntities7())
            {
                try
                {
                    return db.generalFeeling.FirstOrDefault(e => e.idPerson == idPerson);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        // POST: api/generalFeeling
        [HttpPost]
        [Route("saveGenFeel")]
        public void Post([FromBody] JObject genFeel)
        {
            generalFeeling entity = new generalFeeling();
            entity.id = 0;
            entity.idPerson = (int)genFeel.SelectToken("idPerson");
            entity.describe = (string)genFeel.SelectToken("describe");
            using (DialogflowDataEntities7 db = new DialogflowDataEntities7())
            {
                try
                {
                    db.generalFeeling.Add(entity);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        // PUT: api/generalFeeling/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/generalFeeling/5
        public void Delete(int id)
        {
        }
    }
}
