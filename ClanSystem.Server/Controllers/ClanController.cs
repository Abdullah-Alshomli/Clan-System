using ClanSystem.Server.Entities;
using ClanSystem.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClanSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClanController : ControllerBase
    {
        private readonly ClanServices _clanServices;

        public ClanController(ClanServices clanServices)
        {
            _clanServices = clanServices;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<List<Clan>>> GetClans()
        {
            return await _clanServices.GetClans();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Clan>> GetClanById(string id)
        {
            var clan = await _clanServices.GetClanById(id);
            if (clan == null)
            {
                return NotFound();
            }
            return clan;
        }

        [HttpPost]
        public async Task<ActionResult<Clan>> CreateClan(Clan clan)
        {
            await _clanServices.CreateClan(clan);
            return CreatedAtAction("GetClanById", new { id = clan.Id }, clan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClan(string id, Clan clan)
        {
            if (id != clan.Id)
            {
                return BadRequest();
            }
            await _clanServices.UpdateClan(id, clan);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClan(string id)
        {
            var clan = await _clanServices.GetClanById(id);
            if (clan == null)
            {
                return NotFound();
            }
            await _clanServices.DeleteClan(id);
            return NoContent();
        }

        [HttpPatch("{id}/points/add")]
        public async Task<IActionResult> AddPoints(string id, int points)
        {
            await _clanServices.AddPoints(id, points);
            return NoContent();
        }

        [HttpPatch("{id}/points/remove")]
        public async Task<IActionResult> RemovePoints(string id, int points)
        {
            await _clanServices.RemovePoints(id, points);
            return NoContent();
        }

        [HttpPatch("{id}/points/set")]
        public async Task<IActionResult> SetPoints(string id, int points)
        {
            await _clanServices.SetPoints(id, points);
            return NoContent();
        }
    }
}
