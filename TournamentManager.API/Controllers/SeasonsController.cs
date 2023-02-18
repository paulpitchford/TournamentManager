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
        public ActionResult<Season> GetAllSeasons()
        {
            try
            {
                IEnumerable<Season> Seasons = _unitOfWork.Seasons.GetAllByDateDesc();
                return Ok(Seasons);
            }
            catch (Exception ex)
            {
                return BadRequest($"There was an error retrieving data from the server: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<int> AddSeason([FromBody] Season season)
        {
            try
            {
                _unitOfWork.Seasons.Add(season);
                return Ok(_unitOfWork.Save());
            }
            catch (Exception ex)
            {
                return BadRequest($"There was an error saving your data: {ex.Message}");
            }
        }

        [HttpGet("{Id}")]
        public ActionResult<Season> GetSeason(Guid Id)
        {
            try
            {
                Season season = _unitOfWork.Seasons.GetById(Id);
                if (season != null)
                {
                    return season;
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
        public ActionResult<bool> UpdateSeason(Guid Id, [FromBody] Season season)
        {
            try
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
