using System;
using System.Linq;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputeFibonacci();
            ComputeMoneyChangeProblem();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void ComputeFibonacci()
        {
            Console.Write("Enter a number to be Fibonaccified: ");
            var number = int.Parse(Console.ReadLine());

            var fibonacciCalculator = new FibonacciCalculator();
            var fibonacciResult = fibonacciCalculator.Compute(number);

            Console.WriteLine(
                $"Result is {fibonacciResult}, Recursive Iteration: {fibonacciCalculator.RecursiveIterationIndex}, Dynamic Iteration: {fibonacciCalculator.DynamicIterationIndex}");
        }

        private static void ComputeMoneyChangeProblem()
        {
            Console.Write("Enter a change amount to be given the least amount of coins: ");
            var number = int.Parse(Console.ReadLine());

            var moneyChangeCalculator = new MoneyChangeCalculator();
            var changeResult = moneyChangeCalculator.Compute(number);

            Console.WriteLine($"Recursive Iteration: {moneyChangeCalculator.RecursiveIterationIndex}, Dynamic Iteration: {moneyChangeCalculator.DynamicIterationIndex}");
            Console.WriteLine($"Coin count: {changeResult.Count}, Result: {string.Join(", ", changeResult.OrderByDescending(n => n))}");
        }
    }
}
