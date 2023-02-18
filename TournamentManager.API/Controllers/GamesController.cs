using Microsoft.AspNetCore.Mvc;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GamesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetAllGames()
        {
            try
            {
                IEnumerable<Game> Games = _unitOfWork.Games.GetAllAscending();
                return Ok(Games);
            }
            catch (Exception ex)
            {
                return BadRequest($"There was an error retrieving data from the server: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetGamesByGame/{gameId}")]
        public ActionResult<IEnumerable<Game>> GetGamesByGame(Guid gameId)
        {
            try
            {
                IEnumerable<Game> Games = _unitOfWork.Games.GetGamesBySeasonAscending(gameId);
                return Ok(Games);
            }
            catch (Exception ex)
            {
                return BadRequest($"There was an error retrieving data from the server: {ex.Message}");
            }
        }
        
        [HttpPost]
        public ActionResult<int> AddGame([FromBody] Game game)
        {
            try
            {
                _unitOfWork.Games.Add(game);
                return Ok(_unitOfWork.Save());
            }
            catch (Exception ex)
            {
                return BadRequest($"There was an error saving your data: {ex.Message}");
            }
        }

        [HttpGet("{Id}")]
        public ActionResult<Game> GetGame(Guid Id)
        {
            try
            {
                Game game = _unitOfWork.Games.GetById(Id);
                if (game != null)
                {
                    return game;
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
        public ActionResult<bool> UpdateGame(Guid Id, [FromBody] Game game)
        {
            try
            {
                Game? oldGame = _unitOfWork.Games.GetById(Id);
                if (oldGame != null)
                {
                    oldGame.SeasonId = game.SeasonId;
                    oldGame.VenueId = game.VenueId;
                    oldGame.GameTypeId = game.GameTypeId;
                    oldGame.GameTitle = game.GameTitle;
                    oldGame.GameDateTime = game.GameDateTime;
                    oldGame.PublishResults = game.PublishResults;
                    oldGame.GameDetails = game.GameDetails;
                    oldGame.Buyin = game.Buyin;
                    oldGame.Fee = game.Fee;
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
