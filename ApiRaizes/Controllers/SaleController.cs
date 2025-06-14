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
    public class SaleController : ControllerBase
    {
        private ISaleService _service;
        public SaleController()
        {
            _service = new SaleService();
        }
        [HttpGet]
        public async Task<ActionResult<SaleGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(SaleInsertDTO sale)
        {
            return Ok(await _service.Post(sale));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(SaleEntity sale)
        {
            return Ok(await _service.Update(sale));
        }
    }
}
