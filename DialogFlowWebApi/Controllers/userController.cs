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
    public class userController : ApiController
    {
        public IHttpActionResult Get([FromBody] JObject pd)
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
    }
}
