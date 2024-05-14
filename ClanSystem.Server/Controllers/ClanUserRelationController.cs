using ClanSystem.Server.Entities;
using ClanSystem.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClanSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClanUserRelationController : ControllerBase
    {
        private readonly ClanUserRelationServices _clanUserRelationServices;

        public ClanUserRelationController(ClanUserRelationServices clanUserRelationServices)
        {
            _clanUserRelationServices = clanUserRelationServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClanUserRelation>>> GetClanUserRelations()
        {
            return await _clanUserRelationServices.GetClanUserRelations();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClanUserRelation>> GetClanUserRelationById(string id)
        {
            var clanUserRelation = await _clanUserRelationServices.GetClanUserRelationById(id);
            if (clanUserRelation == null)
            {
                return NotFound();
            }
            return clanUserRelation;
        }

        [HttpPost]
        public async Task<ActionResult<ClanUserRelation>> CreateClanUserRelation(ClanUserRelation clanUserRelation)
        {
            await _clanUserRelationServices.CreateClanUserRelation(clanUserRelation);
            return CreatedAtAction("GetClanUserRelationById", new { id = clanUserRelation.Id }, clanUserRelation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClanUserRelation(string id, ClanUserRelation clanUserRelation)
        {
            if (id != clanUserRelation.Id)
            {
                return BadRequest();
            }
            await _clanUserRelationServices.UpdateClanUserRelation(id, clanUserRelation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClanUserRelation(string id)
        {
            var clanUserRelation = await _clanUserRelationServices.GetClanUserRelationById(id);
            if (clanUserRelation == null)
            {
                return NotFound();
            }
            await _clanUserRelationServices.DeleteClanUserRelation(id);
            return NoContent();
        }

        [HttpPut("addContribution/{id}/{points}")]
        public async Task<IActionResult> AddContribution(string id, int points)
        {
            await _clanUserRelationServices.AddContribution(id, points);
            return NoContent();
        }

        [HttpPut("removeContribution/{id}/{points}")]
        public async Task<IActionResult> RemoveContribution(string id, int points)
        {
            await _clanUserRelationServices.RemoveContribution(id, points);
            return NoContent();
        }

        [HttpPut("resetContribution/{id}")]
        public async Task<IActionResult> ResetContribution(string id)
        {
            await _clanUserRelationServices.ResetContribution(id);
            return NoContent();
        }

        [HttpDelete("removeUser/{id}")]
        public async Task<IActionResult> RemoveUser(string id)
        {
            await _clanUserRelationServices.RemoveUser(id);
            return NoContent();
        }

        [HttpGet("getClanUsers/{clanName}")]
        public async Task<ActionResult<List<ClanUserRelation>>> GetClanUsers(string clanName)
        {
            return await _clanUserRelationServices.GetClanUsers(clanName);
        }


    }
}
