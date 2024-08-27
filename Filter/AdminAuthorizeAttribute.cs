using Microsoft.AspNetCore.Mvc.Filters;

namespace Dotnet8.Filter
{
    public class AdminAuthorizeAttribute : Attribute,  IAuthorizationFilter
    { 
        public string 
        public AdminAuthorizeAttribute() 
        { 

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
