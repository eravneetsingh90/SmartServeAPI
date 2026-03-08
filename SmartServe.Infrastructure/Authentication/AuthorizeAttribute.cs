namespace SmartServe.Infrastructure.Authorization
{
    public class AuthorizeAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    {
        public AuthorizeAttribute(params string[] roles)
        {
            if (roles != null && roles.Length > 0)
            {
                Roles = string.Join(",", roles);
            }
        }
    }
}
