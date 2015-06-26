using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CocktailService.Entities
{
    [DataContract]
    public class Cocktail
    {
        [DataMember(Order = 1)]
        public string Id { get; set; }

        [DataMember(Order = 2)]
        public String Name { get; set; }

        [DataMember(Order = 3)]
        public String BaseLiquor { get; set; }

        [DataMember(Order = 4)]
        public String PreparationMethod { get; set; }

        [DataMember(Order = 5)]
        public List<Ingredient> Ingredients { get; set; }


    }

    

}