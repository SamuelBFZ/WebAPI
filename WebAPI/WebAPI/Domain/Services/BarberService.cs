using Microsoft.EntityFrameworkCore;
using WebAPI.DAL;
using WebAPI.DAL.Entities;
using WebAPI.Domain.Interfaces;

namespace WebAPI.Domain.Services
{
    public class BarberService : IBarberService
    {
        private readonly DatabaseContext _context;

        public BarberService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Barber> GetBarberByIdAsync(Guid id)
        {
            return await _context.Barbers.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Barber>> GetBarbersAsync()
        {
            return await _context.Barbers.ToListAsync();
        }

        public async Task<Barber> CreateBarberAsync(Barber barber)
        {
            try
            {
                barber.Id = Guid.NewGuid();
                barber.CreatedDate = DateTime.Now;

                _context.Barbers.Add(barber);
                await _context.SaveChangesAsync();

                return barber;
            }
            catch(DbUpdateException exception)
            {
                throw new Exception(exception.InnerException?.Message ?? exception.Message);
            }
        }

        public async Task<Barber> UpdateBarberAsync(Barber barber)
        {
            try
            {
                barber.ModifiedDate = DateTime.Now;

                _context.Barbers.Update(barber);
                await _context.SaveChangesAsync();

                return barber;

            }catch(DbUpdateException exception)
            {
                throw new Exception(exception.InnerException?.Message ?? exception.Message);
            }
        }

        public async Task<Barber> DeleteBarberAsync(Guid id)
        {
            var barber = await _context.Barbers.FirstOrDefaultAsync(b => b.Id == id);
            if (barber == null) return null;

            _context.Barbers.Remove(barber);
            await _context.SaveChangesAsync();

            return barber;
        }
    }
}
