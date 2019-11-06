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
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProcessLogin([FromBody] Dictionary<string, string> Credentials)
        {
            try
            {
                return Ok(await _loginRepository.LoginAttempt(Credentials));
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
     
    }
}
