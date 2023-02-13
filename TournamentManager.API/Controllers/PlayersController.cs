using Microsoft.AspNetCore.Mvc;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Player> GetAllPlayers()
        {
            return _unitOfWork.Players.GetAllAscending();
        }

        [HttpPost]
        public int AddPlayer([FromBody] Player player)
        {
            _unitOfWork.Players.Add(player);
            return _unitOfWork.Save();
        }

        [HttpGet("{Id}")]
        public Player GetPlayer(Guid Id)
        {
            return _unitOfWork.Players.GetById(Id);
        }

        [HttpPut("{Id}")]
        public bool UpdatePlayer(Guid Id, [FromBody] Player player)
        {
            Player? oldPlayer = _unitOfWork.Players.GetById(Id);
            if (oldPlayer != null)
            {
                oldPlayer.FirstName = player.FirstName;
                oldPlayer.LastName = player.LastName;
                oldPlayer.TournamentDirectorId = player.TournamentDirectorId;
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
