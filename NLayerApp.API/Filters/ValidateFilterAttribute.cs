using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerApp.Core.DTOs;

namespace NLayerApp.API.Filters
{
    public class ValidateFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                //selectMany de bir liste geliyor 
                var errors=context.ModelState.Values.SelectMany(x => x.Errors).Select(x=>x.ErrorMessage).ToList();
                context.Result = new BadRequestObjectResult(CustomResponceDto<NoContentDto>.Fail(400,errors));
            }
        }
    }
}
