using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using FLovers.DAL.Repository.Entities;
using Newtonsoft.Json;

namespace FLovers.Shared.Dtos
{
    [DataContract]
    public class ProductDto
    {
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("weightedItem")]
        public Nullable<bool> WeightedItem { get; set; }

        [DataMember]
        [JsonProperty("suggestedSellingPrice")]
        public decimal SuggestedSellingPrice { get; set; }

        [DataMember]
        [JsonProperty("branches")]
        public ICollection<Branch> Branches { get; set; }

        public static ProductDto FromModel(Product model)
        {
            return new ProductDto()
            {
                Id = model.Id, 
                Name = model.Name, 
                WeightedItem = model.WeightedItem, 
                SuggestedSellingPrice = model.SuggestedSellingPrice, 
                Branches = model.Branches, 
            }; 
        }

        public Product ToModel()
        {
            return new Product()
            {
                Id = Id, 
                Name = Name, 
                WeightedItem = WeightedItem, 
                SuggestedSellingPrice = SuggestedSellingPrice, 
                Branches = Branches, 
            }; 
        }
    }
}