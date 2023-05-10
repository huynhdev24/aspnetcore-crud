using aspnetcore_crud.Data;
using aspnetcore_crud.Interfaces;
using aspnetcore_crud.Models;
using aspnetcore_crud.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_crud.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IUnitofWork unitofWork;    

        public OwnerController(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        [HttpGet("owner")]
        public async Task<IActionResult> GetOwners()
        {
            var owners = await this.unitofWork.Ownerrepo.GetEntities();
            return Ok(owners);
        }

        [HttpGet("owner/{id}")]
        public async Task<IActionResult> GetOwner(int id)
        {
            var owner = await this.unitofWork.Ownerrepo.GetEntity(id);
            if(owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        [HttpGet("{id}/account")]
        public async Task<ActionResult<Owner>> GetOwnerWithDetails(int id)
        {
            var owner = await this.unitofWork.Ownerrepo.GetEntityWithDetails(id);
            if(owner == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(owner);
            }
        }

        [HttpPost("owner")]
        public Task<IActionResult> CreateOwner([FromBody] Owner owner)
        {
            if(owner == null)
            {
                return Task.FromResult<IActionResult>(BadRequest("Owner object is null"));    
            }
            if (!ModelState.IsValid)
            {
                return Task.FromResult<IActionResult>(BadRequest("Invalid model object"));
            }

            this.unitofWork.Ownerrepo.CreateEntity(owner);
            return Task.FromResult<IActionResult>(CreatedAtRoute("GetOwner", new { id = owner.Id }, owner));
        }

        [HttpDelete("owner/{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            var owner = await this.unitofWork.Ownerrepo.GetEntity(id);
            if (owner == null)
            {
                return NotFound();
            }
            this.unitofWork.Ownerrepo.DeleteEntity(owner);
            return NoContent();
        }

        [HttpPut("owner/{id}")]
        public async Task<IActionResult> UpdateOwner(int id, [FromBody] Owner owner)
        {
            if (owner == null)
            {
                return BadRequest("Owner object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            var ownerEntity = await this.unitofWork.Ownerrepo.GetEntity(id);
            if (ownerEntity == null)
            {
                return NotFound();
            }
            this.unitofWork.Ownerrepo.UpdateEntity(ownerEntity, owner);
            return NoContent();
        }
    }
}
