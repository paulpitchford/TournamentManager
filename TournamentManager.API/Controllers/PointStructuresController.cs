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
            PointStructure? oldPointStructure = _unitOfWork.PointStructures.GetById(Id);
            if (oldPointStructure != null)
            {
                oldPointStructure.DefaultPoints = pointStructure.DefaultPoints;
                oldPointStructure.PointStructureDescription = pointStructure.PointStructureDescription;
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
