using Microsoft.AspNetCore.Mvc;
using System.Threading;
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

        [HttpGet, ActionName ("GetAll")]
        [Route("GetAll")]
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
        
        [HttpPut, ActionName("Update")]
        [Route("Update")]
        public async Task<ActionResult> UpdateBarberAsync(Barber barber)
        {

            Guid emptyGuid = Guid.Empty;

            if (barber.Id.Equals(emptyGuid)) return BadRequest("Must provide an ID to update");

            var updatedBarber = await _barberService.UpdateBarberAsync(barber);
            return Ok(updatedBarber);
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult> DeleteBarberAsync(Guid id)
        {
            Guid emptyGuid = Guid.Empty;

            if (id.Equals(emptyGuid)) return BadRequest("Must provide an ID to delete");

            var deletedBarber = await _barberService.DeleteBarberAsync(id);

            if (deletedBarber == null) return NotFound("Barber ID not found");

            return Ok($"{deletedBarber.Firstname} deleted");

        }
    }
}
