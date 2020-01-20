namespace Balance.Infra.Mapping
{
    public class MongoDbPersistence
    {

        public static void Configure()
        {
            BugdetMap.Map();
        }
    }
}