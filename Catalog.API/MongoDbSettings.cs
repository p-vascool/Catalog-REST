namespace Catalog.API
{
    public class MongoDbSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        //public string User { get; set; }
        //public string Password { get; set; }
        public string ConnectionString
        {
            get
            {
                //{ User}:{ Password}@
                return $"mongodb://{Host}:{Port}";
            }
        }
    }
}