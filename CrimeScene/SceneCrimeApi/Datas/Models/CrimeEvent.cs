using MongoDB.Bson.Serialization.Attributes;
namespace SceneCrimeApi.Datas.Models
{
    public class CrimeEvent
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public DateTime dateOfEvent { get; set; } = DateTime.Now;
        public string? shortDescription { get; set; }

        public string? city { get; set; }
        public string? address { get; set; }

        public float? postalCode { get; set; }
        public bool? isAssigend { get; set; }
        public bool? isFinished { get; set; }
        public Guid? lawEnforcementId { get; set; }
    }
}
