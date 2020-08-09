using ModelClass.area.response;
using REPORT.service.user;
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
    public class UserController : ApiController
    {
        private IUser m_user;
        public UserController(IUser _user)
        {
            m_user = _user;
        }
        [Route("api/user/getById")]
        [HttpGet]
        public DataRespond getById(int usid)
        {
            DataRespond data = new DataRespond();
            try
            {
                data.message = "success";
                data.data = m_user.getById(usid);
                data.success = true;
            }
            catch(Exception e)
            {
                data.success = false;
                data.message = e.Message;
                data.error = e;
            }
            return data;
        }
    }
}
