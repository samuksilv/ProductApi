using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Product.api.Domain.Models {
    public class BaseModel {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}