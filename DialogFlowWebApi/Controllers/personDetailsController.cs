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
    [RoutePrefix("api/personDetails")]
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class personDetailsController : ApiController
    {
        DialogflowDataEntities7 db =new DialogflowDataEntities7();

        // GET: api/personDetails
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/personDetails/5
        [HttpGet]
        [Route("getPersonDetails/{id}")]
        public PersonDetails Get(int id)
        {
            using (DialogflowDataEntities7 db = new DialogflowDataEntities7())
            {
                try
                {
                    PersonDetails pd = db.PersonDetails.SingleOrDefault(e => e.Id == id);
                    return pd;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        // POST: api/personDetails
        [HttpPost]
        [Route("savePersonDetails")]
        public void Post([FromBody] JObject pd)
        {
            
            PersonDetails personDetails = new PersonDetails();
            personDetails.name= (string)pd.SelectToken("name");
            personDetails.age = (string)pd.SelectToken("age");
            personDetails.gender = (string)pd.SelectToken("gender");
            personDetails.Id = 0;

            using (DialogflowDataEntities7 db = new DialogflowDataEntities7())
            {
                try
                {
                    db.PersonDetails.Add(personDetails);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        // PUT: api/personDetails/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/personDetails/5
        public void Delete(int id)
        {
        }
    }
}
