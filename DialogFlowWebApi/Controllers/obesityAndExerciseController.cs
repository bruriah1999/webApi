using Newtonsoft.Json.Linq;
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
    [RoutePrefix("api/oae")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
        public class obesityAndExerciseController : ApiController
    {
        // GET: api/obesityAndExercise
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/obesityAndExercise/5
        [HttpGet]
        [Route("getOae/{id}")]
        public obesityAndExercise Get(int idPerson)
        {
            using (DialogflowDataEntities7 db = new DialogflowDataEntities7())
            {
                try
                {
                    return db.obesityAndExercise.FirstOrDefault(e => e.idPerson == idPerson);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        // POST: api/obesityAndExercise
        [HttpPost]
        [Route("saveOae")]
        public void Post([FromBody] JObject oae)
        {
            obesityAndExercise entity = new obesityAndExercise();
            entity.id = 0;
            entity.idPerson = (int)oae.SelectToken("idPerson");
            entity.Exercise = (string)oae.SelectToken("Exercise");
            entity.obesity = (string)oae.SelectToken("obesity");
            if (oae.SelectToken("ExerciseOften")!=null)
                 entity.ExerciseOften = (string)oae.SelectToken("ExerciseOften");
            if (oae.SelectToken("dateExercise") != null)
                entity.dateExercise = (string)oae.SelectToken("dateExercise");
            using (DialogflowDataEntities7 db = new DialogflowDataEntities7())
            {
                try
                {
                    db.obesityAndExercise.Add(entity);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        // PUT: api/obesityAndExercise/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/obesityAndExercise/5
        public void Delete(int id)
        {
        }
    }
}
