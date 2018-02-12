using LoginTest.Models.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LoginTest.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class SecurityController : Controller
    {
        private const string LOGIN = "/user/login/{user}/{pass}";
        private const string LOGOUT = "/user/logout/{user}";

        [HttpPost(LOGIN)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromRoute]string user, [FromRoute]string pass)
        {
            IActionResult result = BadRequest();
            try
            {
                if (!IsAuthentic(user, pass))
                    return Ok(false);
                List<Claim> claims = new List<Claim>();
                // create claims
                if (user == "james")
                {
                    claims.Add(new Claim(ClaimTypes.Name, "Maks Hafner"));
                    claims.Add(new Claim(ClaimTypes.Email, user));
                    claims.Add(new Claim("UserType", "Admin"));
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Name, "Maks Hafner"));
                    claims.Add(new Claim(ClaimTypes.Email, user));
                    claims.Add(new Claim("UserType", "user"));
                }


                // create identity
                ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");

                // create principal
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                // sign-in
                await HttpContext.SignInAsync(
                        scheme: "SmenSecurityScheme",
                        principal: principal,
                        properties: new AuthenticationProperties
                        {
                        IsPersistent = true, // for 'remember me' feature
                        //ExpiresUtc = DateTime.UtcNow.AddMinutes(1)
                    });
                result = Ok(true);
            }
            catch (Exception e)
            {

                result = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return result;
            //return RedirectToAction("Index", "Home");
        }
        [HttpPost(LOGOUT)]
        [AllowAnonymous]
        public async Task<IActionResult> Logout([FromRoute]string user)
        {
            await HttpContext.SignOutAsync(
                    scheme: "SmenSecurityScheme");

            return Ok(false);
        }

        #region " Private "

        private bool IsAuthentic(string username, string password)
        {
            return ((username == "james" && password == "bond") || (username == "maks" && password =="hafner"));
        }
        #endregion
    }
}
