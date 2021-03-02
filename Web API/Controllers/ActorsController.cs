using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }
        [HttpPost("add")]
        public IActionResult Add(Actor actor)
        {
            var result = _actorService.Add(actor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Actor actor)
        {
            var result = _actorService.Delete(actor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Actor actor)
        {
            var result = _actorService.Update(actor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _actorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbysexuality")]
        public IActionResult GetBySexuality(string Sexuality)
        {
            var result = _actorService.GetAllBySexuality(Sexuality);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyhaircolor")]
        public IActionResult GetByHairColor(string HairColor)
        {
            var result = _actorService.GetAllByHairCollor(HairColor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyeyecolor")]
        public IActionResult GetByEyeColor(string EyeColor)
        {
            var result = _actorService.GetAllByHairCollor(EyeColor);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbysexuality")]
        public IActionResult GetByJob(bool Job)
        {
            var result = _actorService.GetAllByJob(Job);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
