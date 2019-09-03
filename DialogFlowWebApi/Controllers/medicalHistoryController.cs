using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DialogFlowWebApi.Models;
namespace DialogFlowWebApi.Controllers
{
    [RoutePrefix("api/smoking")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class medicalHistoryController : ApiController
    {
        // GET: api/medicalHistory
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/medicalHistory/5
        [HttpGet]
        [Route("getMedicalHistory/{id}")]
        public MedicalHistory Get(int id)
        {
            using (DialogflowDataEntities7 db = new DialogflowDataEntities7())
            {
                try
                {
                    return db.MedicalHistory.FirstOrDefault(e => e.idPerson == id);
                }
                catch (Exception)
                {
                    throw;
                }
            }
         
        }

        // POST: api/medicalHistory
        [HttpPost]
        [Route("saveMedicalHistory")]
        public void Post([FromBody]MedicalHistory medicalHistory)
        {
            using (DialogflowDataEntities7 db = new DialogflowDataEntities7())
            {
                db.MedicalHistory.Add(medicalHistory);
                db.SaveChanges();
            }
        }

        // PUT: api/medicalHistory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/medicalHistory/5
        public void Delete(int id)
        {
        }
    }
}
