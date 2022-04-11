using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Intereface.Services.Cep;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private ICepService _service;
        public CepController(ICepService service)
        {
            _service = service;
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetCepWithId")]
        public async Task<ActionResult> Get(Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _service.Get(Id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("byCep/{cep}")]
        public async Task<ActionResult> GetByCep(string cep)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _service.GetByCep(cep);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CepDtoCreate cep)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _service.Post(cep);
                if (result == null)
                    return BadRequest();

                return Created(new Uri(Url.Link("GetCepWithId", new { id = result.Id })), result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CepDtoUpdate cep)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = await _service.Put(cep);
                if (result == null)
                    return BadRequest();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                return Ok(await _service.Delete(Id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
