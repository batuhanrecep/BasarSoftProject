using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasarsoftWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorsController : ControllerBase
    {
        private IDoorService _doorService;

        public DoorsController(IDoorService doorService)
        {
            _doorService = doorService;
        }


        [HttpGet("getall")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult GetList()
        {
            var result = _doorService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }



        [HttpGet("getbyid")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult GetById(int doorId)
        {
            var result = _doorService.GetById(doorId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult Add(Door door)
        {
            var result = _doorService.Add(door);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult Delete(Door door)
        {
            var result = _doorService.Delete(door);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult Update(Door door)
        {
            var result = _doorService.Update(door);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
