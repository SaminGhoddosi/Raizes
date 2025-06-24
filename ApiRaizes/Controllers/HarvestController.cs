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
    public class HarvestController : ControllerBase
    {
        private IHarvestService _service;

        public HarvestController(IHarvestService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<HarvestGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HarvestEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(HarvestInsertDTO harvest)
        {
            return Ok(await _service.Post(harvest));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(HarvestEntity harvest)
        {
            return Ok(await _service.Update(harvest));
        }

        private string GenerateJwtToken(string username)
        {
            var secretKey = "minha-chave-super-secreta-123456";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claim = new[] {
                new Claim(ClaimTypes.Name, username)
            };

            var token = new JwtSecurityToken(
                issuer: "Api-Raizes",
                audience: "Api-Raizes",
                claims: claim,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            if (userLogin.Username == "oi" && userLogin.Password == "123456")
            {
                var token = GenerateJwtToken(userLogin.Username);
                return Ok(new { token });
            }
            return Unauthorized("Login inválido");
        }


        [HttpGet("plantio/{plantioId}")]

        public async Task<IActionResult> GetByPlantioId(int plantioId)
        {
            var todasColheitas = await _service.GetAll();
            var resultado = todasColheitas.Data
                .Where(c => c.PlantioId == plantioId)
                .OrderByDescending(c => c.DataColheita)
                .Select(c => new
                {
                    c.Id,
                    c.Quantidade,
                    c.DataColheita
                })
                .ToList();
            return Ok(resultado);
        }
    }
}