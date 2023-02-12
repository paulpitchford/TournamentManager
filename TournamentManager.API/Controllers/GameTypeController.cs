using Microsoft.AspNetCore.Mvc;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<GameType> GetAllGameTypes()
        {
            return _unitOfWork.GameType.GetAllAscending();
        }

        [HttpPost]
        public int AddGameType([FromBody] GameType gameType)
        {
            _unitOfWork.GameType.Add(gameType);
            return _unitOfWork.Save();
        }

        [HttpGet("{Id}")]
        public GameType GetGameType(Guid Id)
        {
            return _unitOfWork.GameType.GetById(Id);
        }

        [HttpPut("{Id}")]
        public bool UpdateGameType(Guid Id, [FromBody] GameType gameType)
        {
            GameType? oldGameType = _unitOfWork.GameType.GetById(Id);
            if (oldGameType != null)
            {
                oldGameType.GameTypeName = gameType.GameTypeName;
                oldGameType.AwardPoints = gameType.AwardPoints;
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
