using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerApp.Core.DTOs;

namespace NLayerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]//end point olmadigini belirtiyoruz
        public IActionResult CreateActionResult<T>(CustomResponceDto<T> responce) 
        {
            if(responce.statusCode == 204) 
            {
                return new ObjectResult(null)
                {
                    StatusCode = responce.statusCode,
                };

            }
            return new ObjectResult(responce) 
            {
                StatusCode = responce.statusCode 
            };
            
        }
    }
}
