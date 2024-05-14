namespace ClanSystem.Server.Data
{
    public class DatabaseSettings
    {
        public string ConnectionName { get; set; }
        public string DatabaseName { get; set; }
        public string Connection { get; set; }

        public string ClanCollection { get; set; }
        public string UserCollection { get; set; }
        public string ClanUserRelationCollection { get; set; }
    }
}
