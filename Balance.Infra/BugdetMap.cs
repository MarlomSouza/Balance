using Balance.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace Balance.Infra
{
    public class BugdetMap
    {
        public void Map()
        {
            BsonClassMap.RegisterClassMap<Budget>(map =>
                {
                    map.AutoMap();
                    map.SetIgnoreExtraElements(true);
                    map.MapIdMember(x => x.Id);
                    map.MapMember(x => x.Description).SetIsRequired(true);
                    map.MapMember(x => x.Month).SetIsRequired(true);
                    map.MapMember(x => x.Year).SetIsRequired(true);
                    map.MapMember(x => x.UserName).SetIsRequired(true);
                    map.MapMember(x => x.TypeBudget).SetIsRequired(true);

                });
        }
    }

}