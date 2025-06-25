using ApiRaizes.Contracts.Repository;
using ApiRaizes.Contracts.Services;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Repository;
using ApiRaizes.Response;
using ApiRaizes.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace ApiRaizes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasureUnitController : ControllerBase
    {

        private IMeasureUnitService _service;
        public MeasureUnitController(IMeasureUnitService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<MeasureUnitGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MeasureUnitEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(MeasureUnitInsertDTO measureUnit)
        {
            return Ok(await _service.Post(measureUnit));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(MeasureUnitEntity measureUnit)
        {
            return Ok(await _service.Update(measureUnit));
        }
    }
}