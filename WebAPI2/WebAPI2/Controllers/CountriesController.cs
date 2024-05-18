﻿using Microsoft.AspNetCore.Mvc;
using WebAPI2.DAL.Entities;
using WebAPI2.Domain.Interfaces;

namespace WebAPI2.Controllers
{
    [Route("apy/[controller]")]
    [ApiController]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        #region Constructor
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        #endregion

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Country>>> GetConutriesAsync()
        {
            var countries = await _countryService.GetConutriesAsync();

            if (countries == null || !countries.Any())
            {
                return NotFound();
            }

            return Ok(countries);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Country>> GetCountryByIdAsync(Guid id)
        {
            var country = await _countryService.GetCountryByIdAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Country>> CreateCountryAsync(Country country)
        {
            try
            {
                var newCountry = await _countryService.CreateCountryAsync(country);

                if (newCountry == null) return NotFound();

                return Ok(newCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("{0} ya existe", country.Name));
                }

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Country>> EditCountryAsync(Country country)
        {
            try
            {
                var editedCountry = await _countryService.EditCountryAsync(country);

                if (editedCountry == null) return NotFound();

                return Ok(editedCountry);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("{0} ya existe", country.Name));
                }

                return Conflict(ex.Message);
            }

        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Country>> DeleteCountryAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var deletedCountry = await _countryService.DeleteCountryAsync(id);

            if (deletedCountry == null) return NotFound();

            return Ok(deletedCountry);
        }
    }
}
