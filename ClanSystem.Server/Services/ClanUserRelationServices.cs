using ClanSystem.Server.Data;
using ClanSystem.Server.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ClanSystem.Server.Services
{
    public class ClanUserRelationServices
    {
        private readonly IMongoCollection<ClanUserRelation> _clanUserRelationCollection;

        public ClanUserRelationServices(IOptions<DatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.Connection);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _clanUserRelationCollection = database.GetCollection<ClanUserRelation>(settings.Value.ClanUserRelationCollection);
        }

        public async Task<List<ClanUserRelation>> GetClanUserRelations()
        {
            return await _clanUserRelationCollection.Find(clanUserRelation => true).ToListAsync();
        }

        public async Task<ClanUserRelation> GetClanUserRelationById(string id)
        {
            return await _clanUserRelationCollection.Find<ClanUserRelation>(clanUserRelation => clanUserRelation.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ClanUserRelation> CreateClanUserRelation(ClanUserRelation clanUserRelation)
        {
            await _clanUserRelationCollection.InsertOneAsync(clanUserRelation);
            return clanUserRelation;
        }

        public async Task UpdateClanUserRelation(string id, ClanUserRelation clanUserRelation)
        {
            await _clanUserRelationCollection.ReplaceOneAsync(clanUserRelation => clanUserRelation.Id == id, clanUserRelation);
        }

        public async Task DeleteClanUserRelation(string id)
        {
            await _clanUserRelationCollection.DeleteOneAsync(clanUserRelation => clanUserRelation.Id == id);
        }

        // add points to user contribution 
        public async Task AddContribution(string id, int points)
        {
            var clanUserRelation = await GetClanUserRelationById(id);
            clanUserRelation.UserContribution += points;
            await UpdateClanUserRelation(id, clanUserRelation);
        }

        // remove points from user contribution
        public async Task RemoveContribution(string id, int points)
        {
            var clanUserRelation = await GetClanUserRelationById(id);
            clanUserRelation.UserContribution -= points;
            await UpdateClanUserRelation(id, clanUserRelation);
        }

        // reset user contribution
        public async Task ResetContribution(string id)
        {
            var clanUserRelation = await GetClanUserRelationById(id);
            clanUserRelation.UserContribution = 0;
            await UpdateClanUserRelation(id, clanUserRelation);
        }

        // remove user from clan
        public async Task RemoveUser(string id)
        {
            await DeleteClanUserRelation(id);
        }

        // get all users in a clan
        public async Task<List<ClanUserRelation>> GetClanUsers(string clanName)
        {
            return await _clanUserRelationCollection.Find<ClanUserRelation>(clanUserRelation => clanUserRelation.ClanName == clanName).ToListAsync();
        }


        // get all clans a user is in
        public async Task<List<ClanUserRelation>> GetUserClans(string user)
        {
            return await _clanUserRelationCollection.Find<ClanUserRelation>(clanUserRelation => clanUserRelation.User == user).ToListAsync();
        }




    }
}
