using ModelClass.area.response;
using ModelClass.auth;
using REPORT.service.auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace REPORT.controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthController : ApiController
    {
        private IAuth m_auth;
        public AuthController(IAuth auth)
        {
            m_auth = auth;
        }
        [Route("api/auth/login")]
        [HttpPost]
        public DataRespond Login([FromBody] Users us)
        {
            return m_auth.login(us);
        }
    }
}
