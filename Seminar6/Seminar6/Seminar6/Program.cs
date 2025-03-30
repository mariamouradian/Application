namespace Seminar6
{
    internal class Program
    {
        static void Calculator_GotResult(object sendler, EventArgs eventArgs)
        {
            Console.WriteLine($"Результат: {((Calculator)sendler).Result}");
        }

        static void Execute(Action<double> action, double value = 10)
        {
            try
            {
                action.Invoke(value);
            }
            catch (CalculatorDevideByZeroException ex)
            {
                Console.WriteLine(ex);
            }

            catch (CalculatorOperationCauseOvwerflowExcertion ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            var calc = new Calculator();
            calc.GotResult += Calculator_GotResult;

            Execute(calc.Sum, 10.5);
            Execute(calc.Multiply, 2.0);
            Execute(calc.Divide, 4);
            Execute(calc.Substruct, 0.25);

        }
    }
}

