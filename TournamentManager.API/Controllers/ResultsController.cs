using Microsoft.AspNetCore.Mvc;
using TournamentManager.DataAccess.Migrations;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResultsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetResultsByGame/{gameId}")]
        public ActionResult<IEnumerable<Result>> GetResultsByGame(Guid gameId)
        {
            try
            {
                IEnumerable<Result> Results = _unitOfWork.Results.GetResultsByGame(gameId);
                return Ok(Results);
            }
            catch ( Exception ex)
            {
                return BadRequest($"There was an error retrieving data from the server: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetResultsByPlayer/{playerId}")]
        public ActionResult<IEnumerable<Result>> GetResultsByPlayer(Guid playerId)
        {
            try
            {
                IEnumerable<Result> Results = _unitOfWork.Results.GetResultsByPlayer(playerId);
                return Ok(Results);
            }
            catch (Exception ex)
            {
                return BadRequest($"There was an error retrieving data from the server: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<int> AddResult([FromBody] Result result)
        {
            try
            {
                _unitOfWork.Results.Add(result);
                return Ok(_unitOfWork.Save());
            }
            catch (Exception ex)
            {
                return BadRequest($"There was an error saving your data: {ex.Message}");
            }
        }

        [HttpGet("{Id}")]
        public ActionResult<Result> GetResult(Guid Id)
        {
            try
            {
                Result result = _unitOfWork.Results.GetById(Id);
                if (result != null)
                {
                    return Ok(result);
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
        public ActionResult<bool> UpdateResult(Guid Id, [FromBody] Result result)
        {
            try
            {
                Result? oldResult = _unitOfWork.Results.GetById(Id);
                if (oldResult != null)
                {
                    oldResult.GameId = result.GameId;
                    oldResult.PlayerId = result.PlayerId;
                    oldResult.Position = result.Position;
                    oldResult.Cash = result.Cash;
                    oldResult.Points = result.Points;
                    _unitOfWork.Save();
                    return Ok(true);
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
