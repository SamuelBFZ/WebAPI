using WebAPI2.DAL.Entities;

namespace WebAPI2.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetConutriesAsync();//Firma de un metodo

        Task<Country> GetCountryByIdAsync(Guid id);

        Task<Country> CreateCountryAsync(Country country);

        Task<Country> EditCountryAsync(Country country);

        Task<Country> DeleteCountryAsync(Guid id);

    }
}
