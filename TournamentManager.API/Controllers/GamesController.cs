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
        public IEnumerable<Game> GetAllGames()
        {
            return _unitOfWork.Games.GetAllAscending();
        }

        [HttpGet]
        [Route("GetGamesBySeason/{seasonId}")]
        public IEnumerable<Game> GetGamesBySeason(Guid seasonId)
        {
            return _unitOfWork.Games.GetGamesBySeasonDescending(seasonId);
        }

        [HttpPost]
        public int AddGame([FromBody] Game game)
        {
            _unitOfWork.Games.Add(game);
            return _unitOfWork.Save();
        }

        [HttpGet("{Id}")]
        public Game GetGame(Guid Id)
        {
            return _unitOfWork.Games.GetById(Id);
        }

        [HttpPut("{Id}")]
        public bool UpdateGame(Guid Id, [FromBody] Game game)
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
                return false;
            }
        }
    }
}
