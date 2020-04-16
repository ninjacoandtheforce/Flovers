using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using FLovers.DAL.Repository.Entities;
using Newtonsoft.Json;

namespace FLovers.Shared.Dtos
{
    [DataContract]
    public class BranchDto
    {
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("telephoneNumber")]
        public string TelephoneNumber { get; set; }

        [DataMember]
        [JsonProperty("openDate")]
        public DateTime? OpenDate { get; set; }

        [DataMember]
        [JsonProperty("products")]
        public ICollection<Product> Products { get; set; }

        public static BranchDto FromModel(Branch model)
        {
            return new BranchDto()
            {
                Id = model.Id, 
                Name = model.Name, 
                TelephoneNumber = model.TelephoneNumber, 
                OpenDate = model.OpenDate, 
                Products = model.Products, 
            }; 
        }

        public Branch ToModel()
        {
            return new Branch()
            {
                Id = Id, 
                Name = Name, 
                TelephoneNumber = TelephoneNumber, 
                OpenDate = OpenDate, 
                Products = Products, 
            }; 
        }
    }
}