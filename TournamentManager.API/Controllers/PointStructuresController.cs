using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TournamentManager.Infrastructure.Entities;
using TournamentManager.Infrastructure.Interfaces;

namespace TournamentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointStructuresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PointStructuresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<PointStructure> GetAllPointStructures()
        {
            return _unitOfWork.PointStructures.GetAllAscending();
        }

        [HttpPost]
        public int AddPointStructure([FromBody] PointStructure pointStructure)
        {
            _unitOfWork.PointStructures.Add(pointStructure);
            return _unitOfWork.Save();
        }

        [HttpGet("{Id}")]
        public PointStructure? GetPointStructure(Guid Id)
        {
            return _unitOfWork.PointStructures.GetPointStructureWithPoints(Id);
        }

        [HttpPut("{Id}")]
        public bool UpdatePointStructure(Guid Id, [FromBody] PointStructure pointStructure)
        {
            PointStructure? oldPointStructure = _unitOfWork.PointStructures.GetPointStructureWithPoints(Id);
            // Update the structure
            if (oldPointStructure != null)
            {
                oldPointStructure.DefaultPoints = pointStructure.DefaultPoints;
                oldPointStructure.PointStructureDescription = pointStructure.PointStructureDescription;

                // Loop over the children from the page and see if any need adding or updating
                foreach (PointPosition position in pointStructure.PointPositions)
                {
                    if (position.Id == Guid.Empty)
                    {
                        position.PointStructureId = pointStructure.Id;
                        _unitOfWork.PointPositions.Add(position);
                    }
                    // We don't need to worry about updates as we're only adding and removing from this collection of entities
                }

                // Now loop over the old collection and see if any have been removed
                foreach (PointPosition oldPosition in oldPointStructure.PointPositions)
                {
                    PointPosition? position = pointStructure.PointPositions.Where(pp => pp.Id == oldPosition.Id).FirstOrDefault();
                    if (position == null)
                    {
                        _unitOfWork.PointPositions.Remove(oldPosition);
                    }
                }

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
