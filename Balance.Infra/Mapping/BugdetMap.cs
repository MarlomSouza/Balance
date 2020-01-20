using Balance.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Balance.Infra.Mapping
{
    public class BugdetMap
    {
        public static void Map()
        {
            BsonClassMap.RegisterClassMap<Budget>(cm =>
            {
                cm.AutoMap();
                cm.SetDiscriminator(typeof(Budget).Name);
                cm.SetIdMember(cm.GetMemberMap(a => a.Id));
                cm.MapMember(x => x.Description).SetIsRequired(true);
                cm.MapMember(x => x.DateTime).SetIsRequired(true);
                cm.MapMember(x => x.TypeBudget).SetIsRequired(true);
                cm.SetIgnoreExtraElements(true);
            });
        }
    }

}