using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Dal1;
using DinkToPdf;
using pdf.Utility;
using System.IO;
using DinkToPdf.Contracts;

namespace DialogFlowWebApi.Controllers
{
    [RoutePrefix("api/user")]
    public  class UsersController : ApiController
    {
        
        [HttpGet]
        [Route("getAllName")]
        public IEnumerable<userWeb> getAllName()
        {

            DBConnect c = new DBConnect();
            try
            {
               return c.getAllName();
            }
            catch (Exception e) { throw e; }
        }
        [HttpGet]
        [Route("getpdfByname/{id}")]
        public IEnumerable<userWeb> getpdfByname(string id)
        {
            DBConnect c = new DBConnect();
            try {
                return c.getpdfByname(id);
            }
            catch (Exception e) {
                throw;
            }
        }
        [HttpGet]
        [Route("getAllNotChecked")]
        public IEnumerable<userWeb> getAllNotChecked()
        {
            DBConnect c = new DBConnect();
            try
            {
                return c.getAllNotChecked();
            }
            catch (Exception e)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("updateCheckedUser/{id}")]
        public bool updateCheckedUser(int id)
        {
            DBConnect c = new DBConnect();
            try
            {
                return c.updateCheckedUser(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //public IHttpActionResult Post([FromBody] JObject pd)
        //{

        //    users user = new users();
        //    user.id = 0;
        //    user.name = (string)pd.SelectToken("personalDetails").SelectToken("name").SelectToken("name1");
        //    user.age = (int)pd.SelectToken("personalDetails").SelectToken("age").SelectToken("amount");
        //    user.gender = (string)pd.SelectToken("personalDetails").SelectToken("gender");
        //    user.isDiabetes = string.Equals((string)pd.SelectToken("heartRelatedDiseases").SelectToken("diabetes"), "diabetes");
        //    user.isCholesterol = string.Equals((string)pd.SelectToken("heartRelatedDiseases").SelectToken("cholesterol"), "cholesterol");
        //    user.heart_disease = (string)pd.SelectToken("heartRelatedDiseases").SelectToken("heart_disease");
        //    user.isObesity = string.Equals((string)pd.SelectToken("obesityAndExercise").SelectToken("obesity"), "obesity");
        //    user.isExercise = string.Equals((string)pd.SelectToken("obesityAndExercise").SelectToken("exercise"), "exercise");
        //    user.exerciseOften = (string)pd.SelectToken("obesityAndExercise").SelectToken("exercise_often");
        //    user.dateExercise = (string)pd.SelectToken("obesityAndExercise").SelectToken("date-period");
        //    user.isDrug = string.Equals((string)pd.SelectToken("drugs").SelectToken("drugs"), "drugs");
        //    user.nameDrug = (string)pd.SelectToken("nameDrug");
        //    user.isSmoking = string.Equals((string)pd.SelectToken("smokingHabits").SelectToken("smoke"), "smoke"); ;
        //    user.oftenSmoke = (string)pd.SelectToken("smokingHabits").SelectToken("SmokingOften");
        //    user.brandSmoke = (string)pd.SelectToken("smokingHabits").SelectToken("SmokingType");
        //    user.amountTypeSmoke = (string)pd.SelectToken("smokingHabits").SelectToken("SmokingAmountType");
        //    user.amountSmoke = (string)pd.SelectToken("smokingHabits").SelectToken("SmokingAmount");
        //    user.painLevel = (string)pd.SelectToken("generalFeeling").SelectToken("painLevel");
        //    user.feeling = (string)pd.SelectToken("generalFeeling").SelectToken("feeling");
        //    user.bloodPressure = (string)pd.SelectToken("generalFeeling").SelectToken("bloodPressure");
        //    user.trauma = (string)pd.SelectToken("generalFeeling").SelectToken("trauma");
        //    user.vomitAmount = (string)pd.SelectToken("generalFeeling").SelectToken("vomitAmount");
        //    user.feverDgree = (string)pd.SelectToken("generalFeeling").SelectToken("feverDgree");
        //    user.painLocation = (string)pd.SelectToken("generalFeeling").SelectToken("painLocation");
        //    user.timeOfPain = (string)pd.SelectToken("generalFeeling").SelectToken("timeOfPain");
        //    user.havaFever = (string)pd.SelectToken("generalFeeling").SelectToken("havaFever");
        //    user.disease = (string)pd.SelectToken("generalFeeling").SelectToken("disease");
        //    user.diastolic= (int)pd.SelectToken("generalFeeling").SelectToken("diastolic");
        //    user.systolic = (int)pd.SelectToken("generalFeeling").SelectToken("systolic");
        //    try
        //    {
        //        Class1 c = new Class1();

        //        user = Class1.Score(user);
        //        c.Post(user);
        //        return Ok();
        //    }
        //    catch (Exception e) { throw e; }
        //}
        [HttpPost]
        [Route("addUser/{pd}")]
        public IHttpActionResult Post([FromBody] JObject pd)
        {
            user user = new user();
            try
            {
                DBConnect c = new DBConnect();

                //user = Class1.Score(user);
                //c.Post(user);
                return Ok();
            }
            catch (Exception e) { throw e; }
        }
    //    user user = new user();
    //    string userid = (string)pd.SelectToken("userid");
    //    user.id = 0;
    //        user.@checked = false;
    //        user.date =DateTime.Now.ToString();
    //        user.url = "https://storage.cloud.google.com/myheartpdfbucket/"+ userid+".html";
    //        user.idUser = userid;
    //        user.name = (string) pd.SelectToken("name");
    //    user.score= (int) pd.SelectToken("score");
    //        try
    //        {
    //            DBConnect c = new DBConnect();
    //    c.Post(user);
    //            return Ok();
    //}
    //        catch (Exception e) { throw e; }
    }
}
