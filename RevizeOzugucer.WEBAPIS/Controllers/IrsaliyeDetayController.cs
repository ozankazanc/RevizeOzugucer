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
    public class IrsaliyeDetayController : Controller
    {
        IONIrsaliyeDetayService _irsaliyeDetayService;

        public IrsaliyeDetayController(IONIrsaliyeDetayService irsaliyeDetayService)
        {
            _irsaliyeDetayService = irsaliyeDetayService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //Dependency chain --

            ////Thread.Sleep(1000);

            var result = _irsaliyeDetayService.GetAll();
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

            ////Thread.Sleep(1000);

            var result = _irsaliyeDetayService.GetAllDeleted();
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

            ////Thread.Sleep(1000);

            var result = _irsaliyeDetayService.GetAllNonDeleted();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("get")]
        public IActionResult GetById(int id)
        {
            var result = _irsaliyeDetayService.Get(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(ONIrsaliyeDetay irsaliyeDetay)
        {
            var result = _irsaliyeDetayService.Add(irsaliyeDetay);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _irsaliyeDetayService.Delete(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(ONIrsaliyeDetay irsaliyeDetay)
        {
            var result = _irsaliyeDetayService.Update(irsaliyeDetay);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyirsaliyeid")]
        public IActionResult GetByIrsaliyeId(int id)
        {
            var result = _irsaliyeDetayService.GetByIrsaliyeId(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
