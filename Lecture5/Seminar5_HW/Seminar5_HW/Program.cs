namespace Seminar5_HW
{
    internal class Program
    {
        static void Calculator_GotResult(object sendler, EventArgs eventArgs)
        {
            Console.WriteLine($"Результат: {((Calculator)sendler).Result}");
        }

        static void Main(string[] args)
        {
            ICalc calc = new Calculator();
            calc.GotResult += Calculator_GotResult;

            while (true)
            {
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1 - Сложить");
                Console.WriteLine("2 - Вычесть");
                Console.WriteLine("3 - Умножить");
                Console.WriteLine("4 - Разделить");
                Console.WriteLine("5 - Отменить последнее действие");
                Console.WriteLine("Для выхода нажмите Enter или введите 'отмена'");

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || input.ToLower() == "отмена")
                {
                    break;
                }

                if (input == "5")
                {
                    calc.CancelLast();
                    continue;
                }

                if (!int.TryParse(input, out int operation) || operation < 1 || operation > 4)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, выберите операцию от 1 до 5.");
                    continue;
                }

                Console.WriteLine("Введите число:");
                string numberInput = Console.ReadLine();

                if (string.IsNullOrEmpty(numberInput))
                {
                    break;
                }

                if (!int.TryParse(numberInput, out int number))
                {
                    Console.WriteLine("Некорректное число. Пожалуйста, введите целое число.");
                    continue;
                }

                try
                {
                    switch (operation)
                    {
                        case 1:
                            calc.Sum(number);
                            break;
                        case 2:
                            calc.Substruct(number);
                            break;
                        case 3:
                            calc.Multiply(number);
                            break;
                        case 4:
                            if (number == 0)
                            {
                                Console.WriteLine("Ошибка: деление на ноль!");
                                continue;
                            }
                            calc.Divide(number);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
            }

            Console.WriteLine("Работа калькулятора завершена.");
        }
    }
}
