namespace Seminar5
{
    internal class Program
    {
        static void Calculator_GotResult(object sendler, EventArgs eventArgs)
        {
            Console.WriteLine($"{((Calculator)sendler).Result}");
        }

        static void Main(string[] args)
        {
            ICalc calc = new Calculator();

            calc.GotResult += Calculator_GotResult;
            
            calc.Sum(2);
            calc.Substruct(4);
            calc.Multiply(3);
            calc.CancelLast();
            calc.Multiply(5);

        }
    }
}
