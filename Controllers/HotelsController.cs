using HotelManagementAPI.Contracts;
using HotelManagementAPI.Data;
using HotelManagementAPI.Models.Hotel;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsRepository _hotelsRepository;
        private readonly IMapper _mapper;

        public HotelsController(HotelManagementDbContext context, IHotelsRepository hotelsRepository, IMapper mapper)
        {
            _hotelsRepository = hotelsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
        {
            List<Hotel> hotels = await _hotelsRepository.GetAllAsync();
            var result = _mapper.Map<List<HotelDto>>(hotels);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotel(int id)
        {
            var hotel = await _hotelsRepository.GetAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<HotelDto>(hotel);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelDto createHotelDto)
        {
            if (id != createHotelDto.Id)
            {
                return BadRequest();
            }

            Hotel hotel = await _hotelsRepository.GetAsync(id);

            _mapper.Map(createHotelDto, hotel);
            try
            {
                await _hotelsRepository.UpdateAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            hotel = await _hotelsRepository.GetAsync(id);
            var result = _mapper.Map<HotelDto>(hotel);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<HotelDto>> PostHotel(CreateHotelDto createHotelDto)
        {
            Hotel hotel = _mapper.Map<Hotel>(createHotelDto);
            hotel = await _hotelsRepository.AddAsync(hotel);

            var result = _mapper.Map<HotelDto>(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _hotelsRepository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            await _hotelsRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> HotelExists(int id)
        {
            return await _hotelsRepository.Exists(id);
        }
    }
}
