using System;
using System.Runtime.Serialization;
namespace CocktailService.Entities
{
    [DataContract]
    public class Ingredient
    {
        [DataMember(Order = 1)]
        public String Name { get; set; }

        [DataMember(Order = 2)]
        public String Measure { get; set; }

        [DataMember(Order = 3)]
        public String UnitOfMeasure { get; set; }

    }
    
}