using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PollManager.Middlewares
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

                string authHeader = context.Request.Headers["Authorization"];

                if (authHeader != null && authHeader.StartsWith("Simple"))
                {
                    var usernamePassword = authHeader.Substring("Simple ".Length).Trim();

                    var seperatorIndex = usernamePassword.IndexOf(':');

                    username = usernamePassword.Substring(0, seperatorIndex);
                    password = usernamePassword.Substring(seperatorIndex + 1);

                    int checkPassword;
                    var strPass = password.Substring("pwd".Length).Trim();
                    if (strPass.Last() == '!')
                    {
                        strPass = strPass.TrimEnd('!');
                    }

                    if (!int.TryParse(strPass, out checkPassword) || checkPassword !=
                        username.Length * 2)
                    {
                        context.Response.StatusCode = 403;
                        await context.Response.WriteAsync("Authentication failed");
                    }
                }
                else
                {
                    throw new Exception("The authorization header is either empty or isn't Basic.");
                }

                if (username != string.Empty && password != string.Empty)
                {
                    context.Response.Cookies.Append("auth", username);
                    context.Response.Cookies.Append("isCreator", password.Last() == '!' ? "true" : "false");
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