using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvxWebAppCore.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvxWebAppCore.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly IUser _userRepository;

        public UserController(IUser userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(string usertype)
        {
            try
            {
                return Ok(await _userRepository.GetUsers(usertype));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}