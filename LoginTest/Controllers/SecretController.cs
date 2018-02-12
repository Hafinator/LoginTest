using LoginTest.Models.UserData;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace LoginTest.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class SecretController: Controller
    {
        private const string SECRET = "/user/secret";

        
        [HttpGet(SECRET)]
        [Authorize(AuthenticationSchemes = "SmenSecurityScheme", Policy = "JustForAdmins")]//(AuthenticationSchemes = "Cookies")(Policy = "Maks Hafner")
        public IActionResult Secret()
        {
            IActionResult result = BadRequest();
            try
            {
                var data = new UserData();
                data.Name = "SomeName";
                data.Surname = "SomeSurname";
                data.Age = 21;
                data.Address = "The street I live at";
                //string json = JsonConvert.SerializeObject(data);
                result = Ok(data);
            }
            catch (Exception e)
            {

                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;

        }
    }
}
