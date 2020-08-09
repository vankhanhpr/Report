
using ModelClass.area.response;
using ModelClass.auth;
using ModelClassLibrary.connection;
using ModelClassLibrary.imlp;
using ModelClassLibrary.interfaces;
using REPORT.reponsitory.impl;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace REPORT.service.auth.impl
{
    public class AuthImpl : Reponsitory<Users>, IAuth
    {
        private IHashPass m_hashPass = new HashPass();

        public AuthImpl(DataContext context) : base(context)
        {
        }

        public DataRespond login(Users users)
        {
            DataRespond data = new DataRespond();
            Users us = getAll().Where(m=>m.username== users.username).FirstOrDefault();
            if (us is null)
            {
                data.success = false;
                data.message = "User is not exists";
                return data;
            }
            if (checkUser(users))
            {
                data.success = true;
                data.data = new { token = genToken(us), user = us };
                data.message = "Login success";
            }
            else
            {
                data.success = false;
                data.message = "Password is not correct";
            }
            return data;
        }

        //check username or password
        private Boolean checkUser(Users us)
        {
            Users user = getAll().Where(m => m.username == us.username).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            if (m_hashPass.checkPass(user.password, us.password) == true)
            {
                return true;
            }
            return false;
        }
        public dynamic genToken(Users user)
        {
            var now = DateTime.UtcNow;
            string key = "my_secret_key_12345";  
            var issuer = "http://mysite.com";   

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); 
            var permClaims = new List<Claim>();

            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.username));
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64));
            permClaims.Add(new Claim(ClaimTypes.Role, user.role.ToString())); 
            var token = new JwtSecurityToken(issuer, //Issure    
                            issuer,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

            var responseJson = new
            {
                access_token = jwt_token,
                expires_in = (int)TimeSpan.FromDays(1).TotalSeconds
            };
            return responseJson;
        }
    }
}