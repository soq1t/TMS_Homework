namespace Homework9_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Debt mortgage = new Debt(120000.0, 1.01);
            mortgage.PrintBalance();

            Console.WriteLine();
            mortgage.Wait();
            mortgage.PrintBalance();

            // Wait 20 years
            Console.WriteLine();
            mortgage.Wait(20);
            mortgage.PrintBalance();
        }
    }
}
