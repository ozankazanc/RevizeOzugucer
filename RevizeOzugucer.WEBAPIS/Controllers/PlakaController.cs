using Microsoft.AspNetCore.Mvc;
using RevizeOzugucer.Business.Abstract;
using RevizeOzugucer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RevizeOzugucer.WEBAPIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlakaController : Controller
    {
        private IONPlakaService _plakaService;
        public PlakaController(IONPlakaService plakaService)
        {
            _plakaService = plakaService;
        }
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Thread.Sleep(1000);

            var result = _plakaService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getalldeleted")]
        public IActionResult GetAllDeleted()
        {
            //Thread.Sleep(1000);

            var result = _plakaService.GetAllDeleted();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getallnondeleted")]
        public IActionResult GetAllNonDeleted()
        {
            //Thread.Sleep(1000);

            var result = _plakaService.GetAllNonDeleted();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyplakaarac")]
        public IActionResult GetByPlakaArac(string plaka)
        {
            var result = _plakaService.GetByPlakaArac(plaka);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult GetById(int id)
        {
            var result = _plakaService.Get(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(ONPlaka onPlaka)
        {
            var result = _plakaService.Add(onPlaka);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _plakaService.Delete(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(ONPlaka onPlaka)
        {
            var result = _plakaService.Update(onPlaka);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
