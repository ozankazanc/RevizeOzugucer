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
    public class SurucuController : Controller
    {

        IONSurucuService _surucuService;

        public SurucuController(IONSurucuService surucuService)
        {
            _surucuService = surucuService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //Dependency chain --

            //Thread.Sleep(1000);

            var result = _surucuService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getalldeleted")]
        public IActionResult GetAllDeleted()
        {
            //Swagger
            //Dependency chain --

            //Thread.Sleep(1000);

            var result = _surucuService.GetAllDeleted();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getallnondeleted")]
        public IActionResult GetAllNonDeleted()
        {
            //Swagger
            //Dependency chain --

            //Thread.Sleep(1000);

            var result = _surucuService.GetAllNonDeleted();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getonlysurucunames")]
        public IActionResult GetOnlySurucuNames()
        {
            //Swagger
            //Dependency chain --

            //Thread.Sleep(1000);

            var result = _surucuService.GetOnlySurucuNames();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("get")]
        public IActionResult GetById(int id)
        {
            var result = _surucuService.Get(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(ONSurucu surucu)
        {
            var result = _surucuService.Add(surucu);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ONSurucu onSurucu)
        {
            var result = _surucuService.Delete(onSurucu.SurucuId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(ONSurucu surucu)
        {
            var result = _surucuService.Update(surucu);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
