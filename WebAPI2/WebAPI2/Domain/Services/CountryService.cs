using Microsoft.EntityFrameworkCore;
using WebAPI2.DAL;
using WebAPI2.DAL.Entities;
using WebAPI2.Domain.Interfaces;

namespace WebAPI2.Domain.Services
{
    public class CountryService : ICountryService
    {

        private readonly DatabaseContext _context;//Estoy contextualizando la base de datos en mi plataforma

        public CountryService(DatabaseContext context)//constructor para inyectar la dependencia
        {
            _context = context; //Lo que tengo en mi contexto llevaselo a la variable privada que acabo de crear
        }

        //Con los dos metodos anteriores, ya puedo utilizar toda mi base de datos

        public async Task<IEnumerable<Country>> GetConutriesAsync()
        {
            try
            {
                var countries = await _context.Countries.ToListAsync();//Creo la lista

                return countries;//retorno la lista
            }

            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.Id = Guid.NewGuid();//creo un nuevo id
                country.CreatedDate = DateTime.Now;//crear fecha de ingreso
                _context.Countries.Add(country);//agrego el objeto country con todos los atributos de country

                await _context.SaveChangesAsync();//guarda en mi tabla country

                return country;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            try
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);//agarro el primer pais que me encuentre que coincida con el id

                return country;//retorno el pais
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;//ahora si tiene sentido utilizar este atributo
                _context.Countries.Update(country);
                await _context.SaveChangesAsync();

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await GetCountryByIdAsync(id);//utilizo el metodo para buscar el id

                if (country != null)//controlamos que en caso de que el id sea incorrecto o no exista
                {
                    return null;
                }
                _context.Countries.Remove(country);

                await _context.SaveChangesAsync();

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }

        }

    }
}
