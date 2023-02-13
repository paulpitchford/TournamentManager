using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Result> GetResultsByGame(Guid gameId)
        {
            return _unitOfWork.Results.GetResultsByGame(gameId);
        }

        [HttpGet]
        [Route("GetResultsByPlayer/{playerId}")]
        public IEnumerable<Result> GetResultsByPlayer(Guid playerId)
        {
            return _unitOfWork.Results.GetResultsByPlayer(playerId);
        }

        [HttpPost]
        public int AddResult([FromBody] Result result)
        {
            _unitOfWork.Results.Add(result);
            return _unitOfWork.Save();
        }

        [HttpGet("{Id}")]
        public Result GetResult(Guid Id)
        {
            return _unitOfWork.Results.GetById(Id);
        }

        [HttpPut("{Id}")]
        public bool UpdateResult(Guid Id, [FromBody] Result result)
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
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
