using Microsoft.AspNetCore.Mvc;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeasonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Season> GetAllSeasons()
        {
            return _unitOfWork.Season.GetAllByDateDesc();
        }

        [HttpPost]
        public int AddSeason([FromBody] Season season)
        {
            _unitOfWork.Season.Add(season);
            return _unitOfWork.Save();
        }

        [HttpGet("{Id}")]
        public Season GetSeason(Guid Id)
        {
            return _unitOfWork.Season.GetById(Id);
        }

        [HttpPut("{Id}")]
        public bool UpdateSeason(Guid Id, [FromBody] Season season)
        {
            Season? oldSeason = _unitOfWork.Season.GetById(Id);
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
