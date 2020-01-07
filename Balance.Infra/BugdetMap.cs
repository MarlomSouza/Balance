using Balance.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Balance.Infra
{
    public class BugdetMap
    {
        public void Map()
        {
            BsonClassMap.RegisterClassMap<Budget>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(x => x.Id);
                cm.MapMember(x => x.Description).SetIsRequired(true);
                cm.MapMember(x => x.Month).SetIsRequired(true);
                cm.MapMember(x => x.Year).SetIsRequired(true);
                cm.MapMember(x => x.UserName).SetIsRequired(true);
                cm.MapMember(x => x.TypeBudget).SetIsRequired(true);
                cm.SetIgnoreExtraElements(true);
            });
        }       
    }

}