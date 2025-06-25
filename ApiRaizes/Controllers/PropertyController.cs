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
    public class PropertyController : ControllerBase
    {
        private IPropertyService _service;
        public PropertyController(IPropertyService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<PropertyGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(PropertyInsertDTO property)
        {
            return Ok(await _service.Post(property));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(PropertyEntity property)
        {
            return Ok(await _service.Update(property));
        }
    }
}