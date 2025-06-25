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
    public class UserController : ControllerBase
    {
        private IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<UserGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(UserInsertDTO user)
        {
            return Ok(await _service.Post(user));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(UserEntity user)
        {
            return Ok(await _service.Update(user));
        }
    }
}