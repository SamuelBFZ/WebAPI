using Microsoft.AspNetCore.Mvc;
using WebAPI.DAL.Entities;
using WebAPI.Domain.Interfaces;

namespace WebAPI.Controllers
{
    public class BarberController : ControllerBase
    {
        private readonly IBarberService _barberService;

        public BarberController(IBarberService barberService)
        {
            _barberService = barberService;
        }

        [HttpGet, ActionName ("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Barber>>> GetBarbersAsync()
        {
            var barber = await _barberService.GetBarbersAsync();

            if (barber == null || !barber.Any()) return NotFound();

            return Ok(barber);
        }

        [HttpGet, ActionName ("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Barber>> GetBarberByIdAsync(Guid id)
        {
            if (id == null) return BadRequest("Id necessary");

            var barber = await _barberService.GetBarberByIdAsync(id);

            if (barber == null) return NotFound();

            return Ok(barber);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateBarberAsync(Barber barber)
        {
                var createdBarber = await _barberService.CreateBarberAsync(barber);
                return Ok(createdBarber);            
        }
    }
}
