using Dal1;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DialogFlowWebApi.Controllers
{
    public class postController : ApiController
    {
        public void Post([FromBody] JObject pd)
        {
            userWeb user = new userWeb();
            string userid = (string)pd.SelectToken("userId");
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
                c.getAllNames();
            }
            catch (Exception e) { throw e; }
        }
    }
}
