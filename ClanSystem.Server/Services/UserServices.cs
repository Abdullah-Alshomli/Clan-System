using ClanSystem.Server.Data;
using ClanSystem.Server.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ClanSystem.Server.Services
{
    public class UserServices
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserServices(IOptions<DatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.Connection);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _userCollection = database.GetCollection<User>(settings.Value.UserCollection);
        }

        // get all users
        public async Task<List<User>> GetUsers()
        {
            return await _userCollection.Find(user => true).ToListAsync();
        }

        // get user by id
        public async Task<User> GetUserById(string id)
        {
            return await _userCollection.Find<User>(user => user.Id == id).FirstOrDefaultAsync();
        }

        // get user by username
        public async Task<User> GetUserByUsername(string username)
        {
            return await _userCollection.Find<User>(user => user.Username == username).FirstOrDefaultAsync();
        }

        // create user
        public async Task<User> CreateUser(User user)
        {
            await _userCollection.InsertOneAsync(user);
            return user;
        }

        // update user
        public async Task UpdateUser(string id, User user)
        {
            await _userCollection.ReplaceOneAsync(u => u.Id == id, user);
        }

        // delete user
        public async Task DeleteUser(string id)
        {
            await _userCollection.DeleteOneAsync(user => user.Id == id);
        }


    }
}
