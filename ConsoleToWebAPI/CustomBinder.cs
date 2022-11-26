using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAPI
{
    //Custom Binder
    //Split the endpoint by '|'
    // Https://localhost:4409/api/country/search? countries=India|china|usa
    public class CustomBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.Query;

            var result = data.TryGetValue("countries", out var country);

            if (result)
            {
                var array = country.ToString().Split('|');

                bindingContext.Result = ModelBindingResult.Success(array);
            }

            return Task.CompletedTask;

        }
    }
}
