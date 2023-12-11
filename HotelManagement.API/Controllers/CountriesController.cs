using HotelManagement.Data.Data;
using HotelManagementAPI.Contracts;
using HotelManagementAPI.Data;
using HotelManagementAPI.Models.Country;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesRepository _countriesRepository;
        private readonly IMapper _mapper;
        public CountriesController(HotelManagementDbContext context, ICountriesRepository countriesRepository, IMapper mapper)
        {
            _countriesRepository = countriesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            List<Country> countries = await _countriesRepository.GetAllAsync();
            var result = _mapper.Map<List<GetCountryDto>>(countries);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await _countriesRepository.GetDetails(id);

            if (country == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<CountryDto>(country);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (id != updateCountryDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var country = await _countriesRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound($"No Country Has Id {id}");
            }

            _mapper.Map(updateCountryDto, country);

            try
            {
                await _countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            country = await _countriesRepository.GetAsync(id);
            var result = _mapper.Map<GetCountryDto>(country);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Administator")]
        public async Task<ActionResult<CountryDto>> PostCountry(CreateCountryDto createCountryDto)
        {
            Country country = _mapper.Map<Country>(createCountryDto);
            await _countriesRepository.AddAsync(country);
            var result = _mapper.Map<CountryDto>(country);

            return CreatedAtAction(nameof(GetCountry), new { id = country.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countriesRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            await _countriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}
