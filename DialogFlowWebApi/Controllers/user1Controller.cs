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
    public class user1Controller : ApiController
    {
        // GET: api/user1
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/user1/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/user1
        public IHttpActionResult Post([FromBody] JObject pd)
        {


           user user = new user();
            string userid = (string)pd.SelectToken("userid");
            user.id = 0;
            user.@checked = false;
            user.date =DateTime.Now.ToString();
            user.url = "https://storage.cloud.google.com/myheartpdfbucket/"+ userid+".html";
            user.idUser = userid;
            user.name = (string)pd.SelectToken("name");
            user.score= (int)pd.SelectToken("score");
            try
            {
                DBConnect c = new DBConnect();
                c.Post(user);
                return Ok();
            }
            catch (Exception e) { throw e; }
        }
    }
}
