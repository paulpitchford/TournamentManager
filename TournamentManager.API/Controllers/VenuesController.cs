using Microsoft.AspNetCore.Mvc;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenuesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VenuesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Venue>> GetAllVenues()
        {
            try
            {
                IEnumerable<Venue> Venues = _unitOfWork.Venues.GetAllAscending();
                return Ok(Venues);
            }
            catch (Exception ex)
            {
                return BadRequest($"There was an error retrieving data from the server: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<int> AddVenue([FromBody] Venue venue)
        {
            try
            {
                _unitOfWork.Venues.Add(venue);
                return Ok(_unitOfWork.Save());
            }
            catch (Exception ex)
            {
                return BadRequest($"There was an error saving your data: {ex.Message}");
            }
        }

        [HttpGet("{Id}")]
        public ActionResult<Venue> GetVenue(Guid Id)
        {
            try
            {
                Venue venue = _unitOfWork.Venues.GetById(Id);
                if (venue != null)
                {
                    return venue;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"There was an error retrieving data from the server: {ex.Message}");
            }
        }

        [HttpPut("{Id}")]
        public ActionResult<bool> UpdateVenue(Guid Id, [FromBody] Venue venue)
        {
            try
            {
                Venue? oldVenue = _unitOfWork.Venues.GetById(Id);
                if (oldVenue != null)
                {
                    oldVenue.VenueName = venue.VenueName;
                    oldVenue.Address = venue.Address;
                    oldVenue.Town = venue.Town;
                    oldVenue.County = venue.County;
                    oldVenue.PostCode = venue.PostCode;
                    oldVenue.PhoneNumber = venue.PhoneNumber;
                    oldVenue.WebAddress = venue.WebAddress;
                    oldVenue.FacebookAddress = venue.FacebookAddress;
                    oldVenue.ExtraInformation = venue.ExtraInformation;
                    _unitOfWork.Save();
                    return true;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"There was an error saving your data: {ex.Message}");
            }
        }
    }
}
