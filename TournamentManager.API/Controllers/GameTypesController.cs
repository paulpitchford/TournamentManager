using Microsoft.AspNetCore.Mvc;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameTypesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameTypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<GameType> GetAllGameTypes()
        {
            return _unitOfWork.GameTypes.GetAllAscending();
        }

        [HttpPost]
        public int AddGameType([FromBody] GameType gameType)
        {
            _unitOfWork.GameTypes.Add(gameType);
            return _unitOfWork.Save();
        }

        [HttpGet("{Id}")]
        public GameType GetGameType(Guid Id)
        {
            return _unitOfWork.GameTypes.GetById(Id);
        }

        [HttpPut("{Id}")]
        public bool UpdateGameType(Guid Id, [FromBody] GameType gameType)
        {
            GameType? oldGameType = _unitOfWork.GameTypes.GetById(Id);
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
