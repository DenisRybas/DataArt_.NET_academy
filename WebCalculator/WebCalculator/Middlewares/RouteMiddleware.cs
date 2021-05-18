using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebCalculator.Service;

namespace WebCalculator.Middlewares
{
    public class RouteMiddleware
    {
        readonly RequestDelegate _next;

        public RouteMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            switch (context.Request.Path.Value)
            {
                case "/calculate" when context.Request.Method == "GET":
                {
                    SimpleEquation equation = null;
                    var operands = context.Request.Query["operands"].ToList();
                    var operation = context.Request.Query["operation"].ToString();
                    var stateOperand = context.Request.Query["state_operand"].ToString();

                    if (stateOperand != "")
                    {
                        if (operands.Count != 0)
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.CompleteAsync();
                        }

                        var state = context.Request.Cookies["state"];
                        if (state != "")
                        {
                            operands.Add(context.Request.Cookies["state"]);
                            operands.Add(stateOperand);
                        }
                        else if (!context.Response.HasStarted)
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.CompleteAsync();
                        }
                    }

                    try
                    {
                        if (!SimpleEquation.TryParse(operation, operands, out equation)
                            && !context.Response.HasStarted)
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.CompleteAsync();
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.StackTrace);
                        if (!context.Response.HasStarted)
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.CompleteAsync();
                        }
                    }

                    var result = 0.0f;
                    try
                    {
                        result = CalculationService.EvaluateSimpleEquation(equation);
                    }
                    catch (Exception e)
                    {
                        if (e is not ArithmeticException && e is not NullReferenceException) throw;
                        if (!context.Response.HasStarted)
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.CompleteAsync();
                            Console.WriteLine(e.StackTrace);
                        }
                    }

                    if (!context.Response.HasStarted)
                    {
                        context.Response.StatusCode = 200;
                        var resultStr = result.ToString();
                        context.Response.Cookies.Append("state", resultStr);
                        await context.Response.WriteAsync(resultStr);
                    }

                    break;
                }
                case "/":
                {
                    if (context.Request.Cookies.ContainsKey("auth"))
                    {
                        var user = context.Request.Cookies["auth"];
                        await context.Response.WriteAsync($"Hello {user}");
                    }

                    break;
                }
                default:
                    context.Response.StatusCode = 404;
                    break;
            }
        }
    }

    public class SimpleEquation
    {
        public static readonly List<string> SupportedOperations = new() {"sum", "sub", "div", "mul"};
        public string Operation { get; set; }
        public List<float> Operands { get; set; }

        public SimpleEquation(string operation, List<float> operands)
        {
            Operation = operation;
            Operands = operands;
        }

        public static bool TryParse(string operation, IEnumerable<string> operands, out SimpleEquation simpleEquation)
        {
            if (!SupportedOperations.Contains(operation) || operands.Count() < 2)
            {
                simpleEquation = null;
                return false;
            }

            var newOperands = operands.Select(float.Parse).ToList();
            simpleEquation = new SimpleEquation(operation, newOperands);

            return true;
        }
    }
}