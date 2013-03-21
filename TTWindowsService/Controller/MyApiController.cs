using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Http;
using TTWindowsServiceModel.Models;

using AttributeRouting;
using AttributeRouting.Web.Http;

namespace TTWindowsService.Controller
{
    [RouteArea("test")]    
    public class MyApiController : ApiController
    {
        [GET("Hello")]
        public string Get() {
            return "Hello World!!!";
        }
        
        [POST("{id}")]
        public TTResult Post(int id)
        {
            return new TTResult();
        }
    }
}
