using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS_Smart_logistics.Model;
using TMS_Smart_logistics.IRepository;
using TMS_Smart_logistics.Repository;
using Microsoft.Extensions.Logging;

namespace TMS_Smart_logistics.Api.Controllers
{
    /// <summary>
    /// 登录
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
       /// <summary>
       /// 登录I
       /// </summary>
        public ILogin login;
        /// <summary>
        /// 日志
        /// </summary>
        public ILogger<LoginController> logger;
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="_login"></param>
        /// <param name="_logger"></param>
        public LoginController(ILogin _login,ILogger<LoginController> _logger)
        {
            login = _login;
            logger = _logger;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPasd"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login(string UserName,string UserPasd)
        {
            logger.LogInformation("登陆成功");
            return Ok(login.Logins(UserName,UserPasd));
        }
    }
}
