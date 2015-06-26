using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CocktailService
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