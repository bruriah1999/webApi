using DialogFlowWebApi.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DialogFlowWebApi.Controllers
{

    [RoutePrefix("api/users")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class usersController : ApiController
    {
        [HttpGet]
        [Route("getUser/{id}")]
        public users Get(int id)
        {
            using (DialogflowDataEntities9 db = new DialogflowDataEntities9())
            {
                try
                {
                    users pd = db.users.SingleOrDefault(e => e.id == id);
                    return pd;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        [HttpPost]
        [Route("saveUser")]
        public void Post([FromBody] JObject pd)
        {

            users user = new users();
            user.id = 0;
            user.name = (string)pd.SelectToken("name");
            user.age = (string)pd.SelectToken("age");
            user.gender = (string)pd.SelectToken("gender");
            user.isDiabetes = (string)pd.SelectToken("isDiabetes");
            user.isCholesterol=(string)pd.SelectToken("isCholesterol");
            user.heart_disease=(string)pd.SelectToken("heart_disease");
            user.isObesity=(string)pd.SelectToken("isObesity");
            user.isExercise=(string)pd.SelectToken("isExercise");
            user.exerciseOften=(string)pd.SelectToken("exerciseOften");
            user.dateExercise=(string)pd.SelectToken("dateExercise");
            user.isDrug=(string)pd.SelectToken("isDrug");
            user.nameDrug=(string)pd.SelectToken("nameDrug");
            user.isSmoking=(string)pd.SelectToken("isSmoking");
            user.oftenSmoke=(string)pd.SelectToken("oftenSmoke");
            user.brandSmoke=(string)pd.SelectToken("brandSmoke");
            user.amountTypeSmoke=(string)pd.SelectToken("amountTypeSmoke");
            user.amountSmoke=(string)pd.SelectToken("amountSmoke");
            using (DialogflowDataEntities9 db = new DialogflowDataEntities9())
            {
                try
                {
                    db.users.Add(user);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }


    }
}
