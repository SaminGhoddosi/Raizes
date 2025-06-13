using ApiRaizes.DTO;
using ApiRaizes.Entity;
using ApiRaizes.Repository;
using Microsoft.AspNetCore.Mvc;
using ApiRaizes.Contracts.Services;
using ApiRaizes.Response;
using ApiRaizes.Services;

namespace ApiRaizes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HarvestController : ControllerBase
    {
        private IHarvestService _service;
        public HarvestController()
        {
            _service = new HarvestService();
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
    }
}
