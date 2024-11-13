namespace EsyaStore.Middleware
{
public class RoleBasedRedirectionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RoleBasedRedirectionMiddleware> _logger;

    public RoleBasedRedirectionMiddleware(RequestDelegate next, ILogger<RoleBasedRedirectionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var userRole = context.Session?.GetString("UserRole"); 
        var requestedPath = context.Request.Path;

        if (requestedPath.StartsWithSegments("/User/Login") ||
            requestedPath.StartsWithSegments("/User/Register") ||
            requestedPath.StartsWithSegments("/User/Logout") ||
            requestedPath.StartsWithSegments("/Admin/AdminLogout") ||
            requestedPath.StartsWithSegments("/Admin/AdminLogin") ||
            requestedPath.StartsWithSegments("/Seller/SellerRegister") ||
            requestedPath.StartsWithSegments("/Seller/SellerSignup") ||
            requestedPath.StartsWithSegments("/Seller/SellerSignout") ||
            requestedPath.StartsWithSegments("/Product/Index") ||
            requestedPath.StartsWithSegments("/Product") ||
            requestedPath.StartsWithSegments("/Product/ProductDetails") ||
            requestedPath.StartsWithSegments("/Index") ||
            requestedPath.StartsWithSegments("/") ||
            requestedPath.StartsWithSegments("/NotFound") ||
            requestedPath.StartsWithSegments("/Error")
            )
        {
            await _next(context); 
            return;
        }

        if (string.IsNullOrEmpty(userRole))
        {
            context.Response.Redirect("/User/Login");
            return;
        }

        if (requestedPath.StartsWithSegments("/Admin") && userRole != "Admin")
        {
            _logger.LogWarning("Unauthorized access attempt to Admin page");
            context.Response.Redirect("/Admin/AdminLogin");
            return;
        }

        if (requestedPath.StartsWithSegments("/Seller") && userRole != "Seller")
        {
            _logger.LogWarning("Unauthorized access attempt to Seller page");
            context.Response.Redirect("/Seller/SellerLogin");
            return;
        }


        if (requestedPath.StartsWithSegments("/Product") && userRole != "User")
        {
            _logger.LogWarning("Unauthorized access attempt to User page");
            context.Response.Redirect("/User/Login");
            return;
        }

        await _next(context);
    }
}


}