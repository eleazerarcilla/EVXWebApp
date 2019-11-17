using EvxWebAppCore.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvxWebAppCore.Models;
using EvxWebAppCore.ViewModel;
using EvxWebAppCore.Common;

namespace EvxWebAppCore.Controllers
{
    [Route("api/[controller]")]
    public class LineController: Controller
    {
        private readonly ILine _lineRepository;
        private readonly IUser _userRepository;

        public LineController(ILine lineRepository, IUser userRepository)
        {
            _lineRepository = lineRepository;
            _userRepository = userRepository;
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

        [Route("LineFormPartial")]
        [HttpPost]
        public async Task<IActionResult> LineFormPartial([FromBody]LineModel line)
        {
            
            List<UserDetailModel> userList = await _userRepository.GetUsers(GlobalEnums.UserTypes.Administrator.ToString());

            LineFormViewModel lineFormViewModel = new LineFormViewModel(line, userList);
            return PartialView(lineFormViewModel);
        }


        [HttpPost("UpdateLine")]
        public async Task<IActionResult> UpdateLine(int lineID,
            string newLineName,
             int newAdminUserID)
        {
            try
            {
                return Ok(await _lineRepository.UpdateLine(lineID, newLineName, newAdminUserID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
         
        }
        [HttpPost("AddLine")]
        public async Task<IActionResult> AddLine(string newLineName, int newAdminUserID)
        {
            try
            {
                return Ok(await _lineRepository.AddLine(newLineName, newAdminUserID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpGet("DeleteLine")]
        public async Task<IActionResult> DeleteLine(int lineID)
        {
            try
            {
                return Ok(await _lineRepository.DeleteLine(lineID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
