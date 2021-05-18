using System;
using System.Linq;
using WebCalculator.Middlewares;

namespace WebCalculator.Service
{
    public class CalculationService
    {
        public static float EvaluateSimpleEquation(SimpleEquation simpleEquation)
        {
            var result = simpleEquation.Operands.First();
            switch (simpleEquation.Operation)
            {
                case "sum":
                    result = simpleEquation.Operands.Sum();
                    break;
                case "sub":
                    simpleEquation.Operands.Skip(1).ToList().ForEach(op => result -= op);
                    break;
                case "div":
                    simpleEquation.Operands.Skip(1).ToList().ForEach(op =>
                    {
                        if (op == 0)
                        {
                            throw new ArithmeticException("Division by 0");
                        }

                        result /= op;
                    });
                    break;
                case "mul":
                    simpleEquation.Operands.Skip(1).ToList().ForEach(op => result *= op);
                    break;

            }

            return result;
        }
    }
}