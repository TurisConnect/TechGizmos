using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Item
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } // Cambia a string o usa directamente ObjectId

    public string Name { get; set; }
    public string Description { get; set; }
}
