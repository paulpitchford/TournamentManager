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
        [Route("GetGamesByGame/{seasonId}")]
        public ActionResult<IEnumerable<Game>> GetGamesByGame(Guid seasonId)
        {
            try
            {
                IEnumerable<Game> Games = _unitOfWork.Games.GetGamesBySeasonAscending(seasonId);
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
                Game? game = _unitOfWork.Games.GetGameWithResults(Id);
                if (game != null)
                {
                    return Ok(game);
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
                Game? oldGame = _unitOfWork.Games.GetGameWithResults(Id);
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

                    // Loop over the children from the page and see if any need adding or updating
                    foreach (Result result in game.Results)
                    {
                        // We're adding this result if the Guid is empty
                        if (result.Id == Guid.Empty)
                        {
                            result.GameId = game.Id;

                            // TODO: Fix this rubbish
                            // This line needs to be here - even though I hate it:
                            // 1. On the Game Edit page, so the list of results can use the player's name, when the player is selected
                            //    We populate Result.Player with the selected Player entity.
                            //
                            // 2. For some reason, this makes entity framework think that it's a new entity (it adds it to the change tracker as added).
                            //    If you remove it here, the change tracker no longer detects it as new and ignores it basically. Which is desired.
                            //
                            // However, it doesn't feel normal to be having to remove it here.
                            result.Player = null;
                            
                            _unitOfWork.Results.Add(result);
                        }
                        // We don't need to worry about updates as we're only adding and removing from this collection of entities
                    }

                    // Now loop over the old collection and see if any have been removed
                    foreach (Result oldResult in oldGame.Results)
                    {
                        Result? result = game.Results.Where(r => r.Id == oldResult.Id).FirstOrDefault();
                        if (result == null)
                        {
                            _unitOfWork.Results.Remove(oldResult);
                        }
                    }

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
