using EvxWebAppCore.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Controllers
{
    [Route("api/[controller]")]
    public class LineController: Controller
    {
        private readonly ILine _lineRepository;

        public LineController(ILine lineRepository)
        {
            _lineRepository = lineRepository;
        }
        [HttpGet("GetLines")]
        public async Task<IActionResult> GetLines(int adminID = 0)
        {
            try
            {
                return Ok(await _lineRepository.GetLines(adminID));
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("ViewLines/{adminID}")]
        public async Task<IActionResult> ViewLines(int adminID = 0)
        {
            return PartialView("LinesPartial", await _lineRepository.GetLines(adminID));
        }
    }
}
