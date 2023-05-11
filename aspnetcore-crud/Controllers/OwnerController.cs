using aspnetcore_crud.Data;
using aspnetcore_crud.Interfaces;
using aspnetcore_crud.Models;
using aspnetcore_crud.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_crud.Controllers
{
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IUnitofWork unitofWork;
        private readonly ILogger _logger;

        public OwnerController(IUnitofWork unitofWork, ILoggerFactory logFactory)
        {
            this.unitofWork = unitofWork;
            _logger = logFactory.CreateLogger<OwnerController>();
        }

        [HttpGet]
        public IActionResult GetOwners()
        {
            _logger.LogInformation("Log message in the GetOwners method");
            var owners = this.unitofWork.OwnerRepository.All().ToList();
            return Ok(owners);
        }

        [HttpGet("{id}")]
        public IActionResult GetOwnerById(int id)
        {
            _logger.LogInformation("Log message in the GetOwnerById method");
            var owner = this.unitofWork.OwnerRepository.Get(id);
            if(owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        [HttpPost]
        public IActionResult CreateOwner([FromBody] Owner owner)
        {
            _logger.LogInformation("Log message in the CreateOwner method");
            if (owner == null)
            {
                return BadRequest("Owner object is null");    
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            this.unitofWork.OwnerRepository.Add(owner);
            this.unitofWork.SaveChanges();
            return Ok(owner);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(int id, [FromBody] Owner owner)
        {
            _logger.LogInformation("Log message in the DeleteOwner method");
            var ownerDelete = this.unitofWork.OwnerRepository.Get(id);
            if (ownerDelete == null)
            {
                return NotFound();
            }
            this.unitofWork.OwnerRepository.Delete(owner);
            this.unitofWork.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(int id, [FromBody] Owner owner)
        {
            _logger.LogInformation("Log message in the UpdateOwner method");
            if (owner == null)
            {
                return BadRequest("Owner object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            var ownerEntity = this.unitofWork.OwnerRepository.Get(id);
            if (ownerEntity == null)
            {
                return NotFound();
            }
            this.unitofWork.OwnerRepository.Update(owner);
            this.unitofWork.SaveChanges();
            return NoContent();
        }
    }
}
