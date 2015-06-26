using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Hosting;
using System.Web.Security;
using System.Web.SessionState;
using CocktailService.Entities;
using Microsoft.Win32.SafeHandles;

namespace CocktailService
{
    public class Global : HttpApplication
    {
        public static readonly List<Cocktail> CocktailsList = new List<Cocktail>();

         static Global()
        {
            /*
            Global.CocktailsList.Add
            (
                new Cocktail
                {
                    Id = "1",
                    Name = "Martini",
                    BaseLiquor = "Gin",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient
                        {
                            Name = "Gin", 
                            Measure = "2.5",
                            UnitOfMeasure = "oz"         
                        }, 
                        new Ingredient
                        {
                            Name = "Dry Vermouth", 
                            Measure = "0.5", 
                            UnitOfMeasure = "oz"
                        },
                     
                        new Ingredient
                        {
                            Name = "Orange Bitters", 
                            Measure = "2", 
                            UnitOfMeasure = "dash"
                        }
                    },
                    PreparationMethod = "Stirred"

                }
            );

            Global.CocktailsList.Add
            (
                new Cocktail
                {
                    Id = "2",
                    Name = "Manhattan",
                    BaseLiquor = "Rye Whiskey",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient
                        {
                            Name = "Rye Whiskey", 
                            Measure = "2",
                            UnitOfMeasure = "oz"         
                        }, 
                        new Ingredient
                        {
                            Name = "Sweet Vermouth", 
                            Measure = "1", 
                            UnitOfMeasure = "oz"
                        },
                     
                        new Ingredient
                        {
                            Name = "Angostura Bitters", 
                            Measure = "2", 
                            UnitOfMeasure = "dash"
                        }
                    },
                    PreparationMethod = "Stirred"

                }
            );
        */
        }


        protected void Application_Start(object sender, EventArgs e)
        {
            
            var dataDir = HostingEnvironment.MapPath("~/App_Data");
            try
            {
                var stream = File.OpenRead(dataDir + "\\cocktails.xml");
                var serializer = new DataContractSerializer(typeof(List<Cocktail>));
                var myCocktails = (List<Cocktail>)serializer.ReadObject(stream);
                CocktailsList.AddRange(myCocktails);
                stream.Close();

            }
            catch (Exception)
            {
                
                Debug.WriteLine("Could not find file");
            }
           

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            
            var dataDir = HostingEnvironment.MapPath("~/App_Data");
            var stream = File.Create(dataDir + "\\cocktails.xml");
            var serializer = new DataContractSerializer(typeof(List<Cocktail>));
            serializer.WriteObject(stream, CocktailsList);
            stream.Close();
             


        }
    }
}