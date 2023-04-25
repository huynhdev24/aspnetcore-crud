using aspnetcore_crud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        [HttpGet(Name = "GetOwners")]
        public async Task<IActionResult> GetOwners()
        {
            var owners = await _ownerRepository.GetOwners();
            return Ok(owners);
        }

        [HttpGet("{id}", Name = "GetOwner")]
        public async Task<IActionResult> GetOwner(int id)
        {
            var owner = await _ownerRepository.GetOwner(id);
            if(owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }
    }
}
