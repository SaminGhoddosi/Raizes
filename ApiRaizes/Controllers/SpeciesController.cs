using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Repository;
using Microsoft.AspNetCore.Mvc;
using ApiRaizes.Contracts.Services;
using ApiRaizes.Response;
using ApiRaizes.Services;
using ApiRaizes.Contracts.Repository;
using Microsoft.AspNetCore.Authorization;

namespace ApiRaizes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class SpeciesController : ControllerBase
    {
        private ISpeciesService _service;
        public SpeciesController(ISpeciesService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<SpeciesGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SpeciesEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(SpeciesInsertDTO species)
        {
            return Ok(await _service.Post(species));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(SpeciesEntity species)
        {
            return Ok(await _service.Update(species));
        }
    }
}

