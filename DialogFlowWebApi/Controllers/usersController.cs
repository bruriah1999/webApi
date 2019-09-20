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
        [Route("getAllNames")]
        public IEnumerable<userWeb> getAllNames()
        {

            DBConnect c = new DBConnect();
            try
            {
               return c.getAllNames();
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
        public void Post([FromBody] JObject pd)
        {
            userWeb user = new userWeb();
            string userid = (string)pd.SelectToken("userid");
            user.id = 0;
            user.@checked = false;
            user.date = DateTime.Now.ToString();
            user.url = "https://storage.cloud.google.com/myheartpdfbucket/" + userid + ".html";
            user.idUser = userid;
            user.name = (string)pd.SelectToken("name");
            user.score = (int)pd.SelectToken("score");
            try
            {
                DBConnect c = new DBConnect();
                c.Post(user);
            }
            catch (Exception e) { throw e; }
        }
    }
}
