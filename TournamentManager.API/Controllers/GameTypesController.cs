using EntityFramework.Exceptions.Common;
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
        public ActionResult<IEnumerable<GameType>> GetAllGameTypes()
        {
            try
            {
                IEnumerable<GameType> GameTypes = _unitOfWork.GameTypes.GetAllAscending();
                return Ok(GameTypes);
            }
            catch (Exception ex)
            {
                return BadRequest($"There was an error retrieving data from the server: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<int> AddGameType([FromBody] GameType gameType)
        {
            try
            {
                _unitOfWork.GameTypes.Add(gameType);
                return Ok(_unitOfWork.Save());
            }
            catch (UniqueConstraintException)
            {
                // There is only one unique constraint on the gametype entity so we can statically return an error message
                return BadRequest("This game type name has been used already and must be unique.");
            }
            catch (Exception ex)
            {
                return BadRequest($"There was an error saving your data: {ex.Message}");
            }
        }

        [HttpGet("{Id}")]
        public ActionResult<GameType> GetGameType(Guid Id)
        {
            try
            {
                GameType gameType = _unitOfWork.GameTypes.GetById(Id);
                if (gameType != null)
                {
                    return Ok(gameType);
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
        public ActionResult<bool> UpdateGameType(Guid Id, [FromBody] GameType gameType)
        {
            try
            {
                GameType? oldGameType = _unitOfWork.GameTypes.GetById(Id);
                if (oldGameType != null)
                {
                    oldGameType.GameTypeName = gameType.GameTypeName;
                    oldGameType.AwardPoints = gameType.AwardPoints;
                    oldGameType.IsDefault = gameType.IsDefault;
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
