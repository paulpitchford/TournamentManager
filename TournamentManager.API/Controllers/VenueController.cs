using Microsoft.AspNetCore.Mvc;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VenueController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Venue> GetAllVenues()
        {
            return _unitOfWork.Venue.GetAllAscending();
        }

        [HttpPost]
        public int AddVenue([FromBody] Venue venue)
        {
            _unitOfWork.Venue.Add(venue);
            return _unitOfWork.Save();
        }

        [HttpGet("{Id}")]
        public Venue GetVenue(Guid Id)
        {
            return _unitOfWork.Venue.GetById(Id);
        }

        [HttpPut("{Id}")]
        public bool UpdateVenue(Guid Id, [FromBody] Venue venue)
        {
            Venue? oldVenue = _unitOfWork.Venue.GetById(Id);
            if (oldVenue != null)
            {
                oldVenue.VenueName = venue.VenueName;
                oldVenue.Address = venue.Address;
                oldVenue.Town = venue.Town;
                oldVenue.County = venue.County;
                oldVenue.PostCode = venue.PostCode;
                oldVenue.PhoneNumber= venue.PhoneNumber;
                oldVenue.WebAddress = venue.WebAddress;
                oldVenue.FacebookAddress = venue.FacebookAddress;
                oldVenue.ExtraInformation = venue.ExtraInformation;
                _unitOfWork.Save();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
