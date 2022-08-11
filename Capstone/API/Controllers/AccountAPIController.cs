using API.ResponseModel;
using ModelAuto.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Services.CommonModel;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountAPIController : AuthorizeByIDController
    {
        private IConfiguration _config;
        public AccountAPIController(IConfiguration config)
        {
            _config = config;
        }
        private IProfile p = new ProfileImpl();
        [AllowAnonymous]
        [HttpPost("GetAccount")]
        public IActionResult Get([FromBody] AccountResponse accountResponse)
        {
            Account a = new Account();
            a.UserName = accountResponse.username;
            a.Pass = accountResponse.password;
            Account account = p.GetAccount(a);
            if (account != null)
            {
                if (account.Status == -1)
                {
                    var token = Generate(account);
                    return Ok(new
                    {
                        Status = true,
                        Role = account.Rule,
                        Fullname = account.Employee?.FullName,
                        Data = token,
                        mess = "Login Success",
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Status = false,
                        mess = "Your account has been locked",
                    });
                }
            }
            else
            {
                return Ok(new
                {
                    Status = false,
                    mess= "Wrong account or password information"
                });
            }
        }

        [Authorize]
        [HttpGet("GetUserLog")]
        public IActionResult GetUserLog()
        {
            Account a = GetCurrentUser();
            Employee emp = p.GetEmployeeByID(a.EmployeeId);
            var empReturn = new
            {
                rule = a?.Rule,
                name = emp?.FullName,
                orgID= emp?.OrgnizationId,
                positionName= emp.Position?.Name,
                emID= emp.Id
            };

            return Ok(new
            {
                Data = empReturn
            });
        }

        private string Generate(Account a)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Sid, a.EmployeeId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, a.UserName),
                 new Claim(ClaimTypes.Role, a.Rule.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(25),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        [AllowAnonymous]
        [HttpPost("ResetpassWord")]
        public IActionResult ResetpassWord([FromBody] AccountResponse acc)
        {
            try
            {
                MailDTO obj = new MailDTO();
                obj.fromMail = "aisolutionssum22@gmail.com";
                obj.pass = "miztlfnbereqmeko";
                obj.listCC = new List<string>();
                obj.listBC = new List<string>();
                obj.subject = "Thông báo thay đổi mật khẩu";
                return Ok(new
                {
                    Status = p.ResetPass(acc.username,acc.email, obj)
                });
            }
            catch
            {
                return Ok(new
                {
                    Status = false
                }) ;
            }
           
        }

        [AllowAnonymous]
        [HttpPost("ChangePass")]
        public IActionResult ChangePass([FromBody] AccountResponse acc)
        {
            try
            {
                Account a = new Account();
                a.UserName = acc.username;
                a.Pass = acc.password;

                return Ok(new
                {
                    Status = p.ChangePass(a)
                });
            }
            catch
            {
                return Ok(new
                {
                    Status = false
                });
            }

        }

    }

}
