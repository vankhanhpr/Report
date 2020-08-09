
using REPORT.service;
using System.Web.Http;
using System.Web.Mvc;
using System.Collections.Generic;
using REPORT.service.auth;
using ModelClass.auth;

namespace REPORT.Controllers
{
    public class ValuesController : ApiController
    {
        private IReport m_report;
        private IAuth m_auth;
        public  ValuesController(IReport report, IAuth auth)
        {
            m_report = report;
            m_auth = auth;
        }
        // GET api/values
        public dynamic Get()
        {
            Users us = new Users();
            return  m_auth.login(us);
        }

        // GET api/values?test=5
        public dynamic Get(int test)
        {
            return m_report.execureStoreProcedure(test);
        }

        
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
