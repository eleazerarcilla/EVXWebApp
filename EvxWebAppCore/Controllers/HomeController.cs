using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EvxWebAppCore.Common;
using EvxWebAppCore.Common.Interfaces;
using EvxWebAppCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EvxWebAppCore.Controllers
{
    public class HomeController : Controller
    {
        public const string SessionName = "user";
        private readonly ILogin _loginRepository;
        public HomeController(ILogin loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public IActionResult Index(bool IsLogout)
        {
            return View(HttpContext.Session.SessionGet<UserDetailModel>("user"));
        }
        [HttpGet]
        public IActionResult _NavBarPartial()
        {
            return PartialView(HttpContext.Session.SessionGet<UserDetailModel>("user"));
        }
        [HttpPost]
        public async Task<IActionResult> ProcessLogin([FromBody] Dictionary<string, string> Credentials)
        {
            try
            {
                UserDetailModel user = await _loginRepository.GetUserDetails(Credentials);
                bool IsSuccess = await _loginRepository.LoginValidation(user, Credentials);
                if (IsSuccess)
                    HttpContext.Session.SessionSet("user", user);
                return Ok(IsSuccess);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return Ok(true);
        }
    }
}
