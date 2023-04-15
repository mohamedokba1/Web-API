using API01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

namespace API01.Filters
{
    public class ValidateTypeOfCar : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // get parameter to validate it
            Car? car = context.ActionArguments["car"] as Car;

            //Define the types allowed
            Regex typeRegex = new Regex("^(Electric|Gas|Hybrid|Diesel)$",
                RegexOptions.IgnoreCase,
                TimeSpan.FromSeconds(2));
            //check if null or not matched
            if(car is null || !typeRegex.IsMatch(car.Type))
            {
                context.ModelState.AddModelError("Type", "Type is not allowed");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
