using ClanSystem.Server.Data;
using ClanSystem.Server.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ClanSystem.Server.Services
{
    public class ClanServices
    {
        private readonly IMongoCollection<Clan> _clanCollection;

        public ClanServices(IOptions<DatabaseSettings> settings) 
        {
            var client = new MongoClient(settings.Value.Connection);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _clanCollection = database.GetCollection<Clan>(settings.Value.ClanCollection);
        }

        // get all clans
        public async Task<List<Clan>> GetClans()
        {
            return await _clanCollection.Find(clan => true).ToListAsync();
        }

        // get clan by id
        public async Task<Clan> GetClanById(string id)
        {
            return await _clanCollection.Find<Clan>(clan => clan.Id == id).FirstOrDefaultAsync();
        }

        // get clan by name
        public async Task<Clan> GetClanByName(string clanName)
        {
            return await _clanCollection.Find<Clan>(clan => clan.ClanName == clanName).FirstOrDefaultAsync();
        }

        // create clan
        public async Task<Clan> CreateClan(Clan clan)
        {
            await _clanCollection.InsertOneAsync(clan);
            return clan;
        }

        // update clan
        public async Task UpdateClan(string id, Clan clan)
        {
            await _clanCollection.ReplaceOneAsync(c => c.Id == id, clan);
        }

        // delete clan
        public async Task DeleteClan(string id)
        {
            await _clanCollection.DeleteOneAsync(clan => clan.Id == id);
        }

        // add points to clan
        public async Task AddPoints(string id, int points)
        {
            var clan = await GetClanById(id);
            clan.Points += points;
            await UpdateClan(id, clan);
        }

        // remove points from clan
        public async Task RemovePoints(string id, int points)
        {
            var clan = await GetClanById(id);
            clan.Points -= points;
            await UpdateClan(id, clan);
        }

        // set points to clan
        public async Task SetPoints(string id, int points)
        {
            var clan = await GetClanById(id);
            clan.Points = points;
            await UpdateClan(id, clan);
        }

        // increase clan users if less than 10
        public async Task IncreaseClanUsers(string id)
        {
            var clan = await GetClanById(id);
            if (clan.UserCount < 10)
            {
                clan.UserCount++;
                await UpdateClan(id, clan);
            }
        }

        // decrease clan users if greater than 0
        public async Task DecreaseClanUsers(string id)
        {
            var clan = await GetClanById(id);
            if (clan.UserCount > 0)
            {
                clan.UserCount--;
                await UpdateClan(id, clan);
            }
        }

    }
}
