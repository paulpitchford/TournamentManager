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
        public ActionResult<IEnumerable<Player>> GetAllPlayers()
        {
            try
            {
                IEnumerable<Player> Players = _unitOfWork.Players.GetAllAscending();
                return Ok(Players);
            }
            catch (Exception ex)
            {
                return BadRequest($"There was an error retrieving data from the server: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<int> AddPlayer([FromBody] Player player)
        {
            try
            {
                _unitOfWork.Players.Add(player);
                return Ok(_unitOfWork.Save());
            }
            catch (Exception ex)
            {
                return BadRequest($"There was an error saving your data: {ex.Message}");
            }
        }

        [HttpGet("{Id}")]
        public ActionResult<Player> GetPlayer(Guid Id)
        {
            try
            {
                Player player = _unitOfWork.Players.GetById(Id);
                if (player != null)
                {
                    return Ok(player);
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
        public ActionResult<bool> UpdatePlayer(Guid Id, [FromBody] Player player)
        {
            try
            {
                Player? oldPlayer = _unitOfWork.Players.GetById(Id);
                if (oldPlayer != null)
                {
                    oldPlayer.FirstName = player.FirstName;
                    oldPlayer.LastName = player.LastName;
                    oldPlayer.TournamentDirectorId = player.TournamentDirectorId;
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
