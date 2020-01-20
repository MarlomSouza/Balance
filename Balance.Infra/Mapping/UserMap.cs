using Balance.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Balance.Infra.Mapping
{
    public class UserMap
    {
        public static void Map()
        {
            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.SetDiscriminator(typeof(User).Name);
                cm.SetIdMember(cm.GetMemberMap(a => a.Id));
                cm.MapMember(x => x.Budgets).SetIsRequired(true);
                cm.MapMember(x => x.Email).SetIsRequired(true);
                cm.MapMember(x => x.Password).SetIsRequired(true);
                cm.SetIgnoreExtraElements(true);
            });
        }
    }
}