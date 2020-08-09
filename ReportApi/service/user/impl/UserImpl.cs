using ModelClass.auth;
using ModelClassLibrary.connection;
using REPORT.reponsitory.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REPORT.service.user.impl
{
    public class UserImpl : Reponsitory<Users>, IUser
    {
        public UserImpl(DataContext context) : base(context)
        {
        }
    }
}