using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EvxWebAppCore.Common;
using EvxWebAppCore.Common.Interfaces;
using EvxWebAppCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EvxWebAppCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogin _loginRepository;
        private readonly RequestData _requestData;
        public HomeController(ILogin loginRepository, IOptions<RequestData> requestData)
        {
            _loginRepository = loginRepository;
            _requestData = requestData.Value;
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
                return Ok(await _loginRepository.LoginAttempt(_requestData, Credentials));
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
     
    }
}
