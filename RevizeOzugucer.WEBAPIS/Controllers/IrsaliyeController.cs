using Microsoft.AspNetCore.Mvc;
using RevizeOzugucer.Business.Abstract;
using RevizeOzugucer.Entities.Concrete;
using RevizeOzugucer.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RevizeOzugucer.WEBAPIS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class IrsaliyeController : Controller
    {
        IONIrsaliyeService _irsaliyeService;

        public IrsaliyeController(IONIrsaliyeService irsaliyeService)
        {
            _irsaliyeService = irsaliyeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //Dependency chain --

            Thread.Sleep(1000);

            var result = _irsaliyeService.GetAll();
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

            Thread.Sleep(1000);

            var result = _irsaliyeService.GetAllDeleted();
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

            Thread.Sleep(1000);

            var result = _irsaliyeService.GetAllNonDeleted();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getallplakas")]
        public IActionResult GetAllPlakas()
        {
            Thread.Sleep(1000);

            var result = _irsaliyeService.GetAllPlakas();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _irsaliyeService.GetByIrsaliyeId(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getlastid")]
        public IActionResult GetLastId(int id)
        {
            var result = _irsaliyeService.GetLastId();
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(ONIrsaliye irsaliye)
        {
            var result = _irsaliyeService.Add(irsaliye);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addirsaliyeandirsaliyedetay")]
        public IActionResult AddIrsaliyeAndIrsaliyeDetay(IrsaliyeAndDetayDto irsaliyeAndDetayDto)
        {
            var result = _irsaliyeService.AddIrsaliyeAndIrsaliyeDetay(irsaliyeAndDetayDto);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = _irsaliyeService.Delete(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(ONIrsaliye irsaliye)
        {
            var result = _irsaliyeService.Update(irsaliye);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
