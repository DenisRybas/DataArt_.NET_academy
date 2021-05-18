using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebCalculator.Middlewares
{
    public class AuthenticationMiddleware
    {
        readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey("auth"))
            {
                var auth = context.Request.Cookies["auth"];

                if (string.IsNullOrEmpty(auth))
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("Authentication failed");
                }

                else
                    await _next(context);
            }
            else if (context.Request.Path.Value == "/authentication" && context.Request.Method == "POST")
            {
                var username = string.Empty;
                var password = string.Empty;
                const string usernameConst = "TestUser";
                const string passwordConst = "!Q2w3e4r";

                if (context.Request.HasFormContentType)
                {
                    username = context.Request.Form["username"];
                    password = context.Request.Form["password"];
                }

                if (username == usernameConst && password == passwordConst)
                {
                    context.Response.Cookies.Append("auth", username);
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync($"Hello {username}");
                }
                else
                {
                    context.Response.StatusCode = 403;
                }
            }
            else
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Authentication failed");
            }
        }
    }
}