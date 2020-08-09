using ModelClass.area.response;
using ModelClass.auth;
using REPORT.reponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REPORT.service.auth
{
    public interface IAuth:IReponsitory<Users>
    {
        DataRespond login(Users users);
    }
}