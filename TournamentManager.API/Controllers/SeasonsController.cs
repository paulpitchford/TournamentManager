using Microsoft.AspNetCore.Mvc;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeasonsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Season> GetAllSeasons()
        {
            return _unitOfWork.Seasons.GetAllByDateDesc();
        }

        [HttpPost]
        public int AddSeason([FromBody] Season season)
        {
            _unitOfWork.Seasons.Add(season);
            return _unitOfWork.Save();
        }

        [HttpGet("{Id}")]
        public Season GetSeason(Guid Id)
        {
            return _unitOfWork.Seasons.GetById(Id);
        }

        [HttpPut("{Id}")]
        public bool UpdateSeason(Guid Id, [FromBody] Season season)
        {
            Season? oldSeason = _unitOfWork.Seasons.GetById(Id);
            if (oldSeason != null)
            {
                oldSeason.SeasonName = season.SeasonName;
                oldSeason.StartDate = season.StartDate;
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
