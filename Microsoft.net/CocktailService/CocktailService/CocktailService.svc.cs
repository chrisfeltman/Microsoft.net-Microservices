using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace CocktailService
{

    [ServiceContract]
    public class Service
    {
       
        [OperationContract]
        [WebGet(UriTemplate = "cocktails/")]
        public List<Cocktail> Cocktails()
        {
            return Global.CocktailsList;
        }

        [OperationContract]
        [WebGet(UriTemplate = "cocktail/{id}")]
        public Cocktail Cocktail(string id)
        {
            try
            {
                return Global.CocktailsList.First(x => id == x.Id);
            }
            catch
            {
                throw new WebFaultException<string>(string.Format("No cocktail with id {0}", id), HttpStatusCode.NotFound);  // test case
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "cocktail?name={name}")]
        public Cocktail GetCocktailByName(string name)
        {
            if (name == null)
            {
               throw new WebFaultException<string>("Name parameter must be supplied", HttpStatusCode.BadRequest);   // test case
            }
            
        
            var result = Global.CocktailsList.FirstOrDefault(x => name.Equals(x.Name, StringComparison.OrdinalIgnoreCase));
            if(result == null)
            {
                throw new WebFaultException<string>(string.Format("No cocktail found with name \"{0}\"", name), HttpStatusCode.NotFound);  // test case
            }

            return result;

        }


        [OperationContract]
        [WebInvoke(UriTemplate = "cocktail/", Method = "POST")]
        public Cocktail AddCocktail(Cocktail newCocktail)
        {
            var maxId = Global.CocktailsList.Max(x => int.Parse(x.Id)) + 1;   // test case 
            newCocktail.Id = maxId.ToString();
            Global.CocktailsList.Add(newCocktail);

            SetResponseCode(HttpStatusCode.Created);
            return newCocktail;
        }

        [OperationContract]
        [WebInvoke(UriTemplate = "cocktail/{id}", Method = "DELETE")]
        public void DeleteCocktail(string id)
        {


            var cocktailToRemove = Global.CocktailsList.FirstOrDefault(x => id == x.Id);

            if (cocktailToRemove == null)
            {
                SetResponseCode(HttpStatusCode.NotFound); // test case
                return;

            }

            // maybe check for user authorization here? 

            Global.CocktailsList.Remove(cocktailToRemove);   // test case
            SetResponseCode(HttpStatusCode.NoContent);


        }

        private static void SetResponseCode(HttpStatusCode statusCode)
        {
            var ctx = WebOperationContext.Current;
            Debug.Assert(ctx != null);
            ctx.OutgoingResponse.StatusCode = statusCode;
        }


    }

}