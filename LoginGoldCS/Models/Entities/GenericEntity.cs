using MongoDB.Bson;

namespace LoginGoldCS.Models.Entities;

public class GenericEntity
{
    public ObjectId Id { get; set; }
    public dynamic Data { get; set; }
}
