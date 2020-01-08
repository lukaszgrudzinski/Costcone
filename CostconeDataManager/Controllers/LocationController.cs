using CostconeDataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CostconeDataManager.Controllers
{
    public class LocationController : ApiController
    {
        
        public string Get(LocationBindingModel bindingModel)
        {
            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(LocationProvider.GetUsersWithinRange(0.003, (bindingModel.lattitude, bindingModel.longtitude)));
            var result = LocationProvider.GetUsersWithinRange(0.003, (bindingModel.lattitude, bindingModel.longtitude));
            return  serializedResult;
        }
        public void Post(LocationBindingModel bindingModel)
        {
            LocationProvider.AddLocation(RequestContext.Principal.Identity.Name, (bindingModel.lattitude, bindingModel.longtitude));
        }
    }
}
