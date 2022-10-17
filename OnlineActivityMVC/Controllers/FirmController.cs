using Business.Abstract;
using Entities.Dtos.Concrete.ActivityDtos;
using Microsoft.AspNetCore.Mvc;
using OnlineActivityMVC.Models;

namespace OnlineActivityMVC.Controllers
{
    [Route("api/firm")]
    [ApiController]
    public class FirmController : ControllerBase
    {
        IActivityService _activityService;

        public FirmController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        

        [HttpGet("/activities")]
        public ActionResult GetActivitiesForFirm([FromQuery] ActivityFilterDto activityFilterDto)
        {
            activityFilterDto.ActivityStatus = Entities.Enums.ActivityStatus.Approved;
            var result = _activityService.GetList(activityFilterDto);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

 
    }
}
