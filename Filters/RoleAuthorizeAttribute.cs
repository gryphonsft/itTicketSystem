using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace itTicketSystem.Filters

{
    public class RoleAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _requiredRole;

        public RoleAuthorizeAttribute(string requiredRole)
        {
            _requiredRole = requiredRole;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var role = context.HttpContext.Session.GetString("role");

            if (string.IsNullOrEmpty(role) || role != _requiredRole)
            {
                context.Result = new RedirectToActionResult("AccessDenied", "Auth", null);
            }
        }
    }
}