using WebAPI.DAL.Entities;

namespace WebAPI.Domain.Interfaces
{
    public interface IBarberService
    {
        Task<IEnumerable<Barber>> GetBarbersAsync();
        Task<Barber> GetBarberByIdAsync(Guid id);
        Task<Barber> CreateBarberAsync(Barber barber);
        Task<Barber> UpdateBarberAsync(Barber barber);
        Task<Barber> DeleteBarberAsync(Guid id);
    }
}
