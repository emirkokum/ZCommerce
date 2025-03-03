﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ZCommerce.Catalog.Entities
{
    public class Product 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int ProductStock { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImageUrl { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }
    }
}
