namespace NestorRoca.TechnicalTest.PolicyManagement.Entities.Model
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.ComponentModel.DataAnnotations;

    public class BaseEntity
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id
        {
            get; set;
        }
    }
}
