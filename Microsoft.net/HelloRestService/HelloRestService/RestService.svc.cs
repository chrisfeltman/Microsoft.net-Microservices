using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HelloRestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceContract]
    public class RestService
    {

      

        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Hello/")]
        string Hello()
        {
            return "Hello";
        }

        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Fart/")]
        Fart SendFartResponseEx()
        {
            return SendFartResponse();
        }

        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Fart")]
        Fart SendFartResponse()
        {

              var fartDescriptions  = new List<string>
              {
                  "Pungent", 
                  "Fishy", 
                  "Shameful", 
                  "Rotten", 
                  "Wet", 
                  "Horrible", 
                  "Beefy", 
                  "Garlicky", 
                  "Embarassing",
                  "Malodorous", 
                  "Room-Clearing", 
                  "Somewhat Pleasant", 
                  "Mercaptan"
              };
            var r = new Random();
            var rInt = r.Next(0, fartDescriptions.Count); 


            return new Fart{ Version = "1.0", Stench = fartDescriptions[rInt]} ;
        }
      
    }


    public class Fart
    {
        public String Version { get; set; }
        public String Stench { get; set; }
    }
}
