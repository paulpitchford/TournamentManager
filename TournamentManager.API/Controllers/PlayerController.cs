using Microsoft.AspNetCore.Mvc;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlayerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Player> GetAllPlayers()
        {
            return _unitOfWork.Player.GetAllAscending();
        }

        [HttpPost]
        public int AddPlayer([FromBody] Player player)
        {
            _unitOfWork.Player.Add(player);
            return _unitOfWork.Save();
        }

        [HttpGet("{Id}")]
        public Player GetPlayer(Guid Id)
        {
            return _unitOfWork.Player.GetById(Id);
        }

        [HttpPut("{Id}")]
        public bool UpdatePlayer(Guid Id, [FromBody] Player player)
        {
            Player? oldPlayer = _unitOfWork.Player.GetById(Id);
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
