using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar6
{
    internal class Calculator : ICalc
    {
        public event EventHandler<EventArgs> GotResult;

        private double _result = 0;
        public double Result
        {
            get => _result;
            private set
            {
                _result = value;
                RaiseEvent();
            }
        }

        int ICalc.Result => (int)Math.Round(_result);

        private Stack<double> Results = new Stack<double>();

        private Stack<CalcActionLog> actions = new Stack<CalcActionLog>();

        public void Divide(int value) => Divide((double)value);
        public void Divide (double value)
        {
            if (value == 0)
            {
                actions.Push(new CalcActionLog(CalcAction.Divide, value));
                throw new CalculatorDevideByZeroException("На ноль делить нельзя!", actions);
            }

            Results.Push(Result);
            Result /= value;
        }

        public void Multiply(int value) => Multiply((double)value);
        public void Multiply(double value)
        {
            double temp = value * Result;
            if(double.IsInfinity(temp))
            {
                actions.Push(new CalcActionLog(CalcAction.Multiply, value));
                throw new CalculatorOperationCauseOvwerflowExcertion("Переполнение", actions);
            }
            Results.Push(Result);
            Result *= value;
        }

        public void Substruct(int value) => Substruct((double)value);
        public void Substruct(double value)
        {
            double temp = Result - value;
            if (double.IsInfinity(temp))
            {
                actions.Push(new CalcActionLog(CalcAction.Substruct, value));
                throw new CalculatorOperationCauseOvwerflowExcertion("Переполнение", actions);
            }
            Results.Push(Result);
            Result -= value;
        }

        public void Sum(int value) => Sum((double)value);
        public void Sum(double value)
        {
            double temp = value + Result; ;
            if (double.IsInfinity(temp))
            {
                actions.Push(new CalcActionLog(CalcAction.Sum, value));
                throw new CalculatorOperationCauseOvwerflowExcertion("Переполнение", actions);
            }
            Results.Push(Result);
            Result += value;
        }

        private void RaiseEvent()
        {
            Console.WriteLine($"Вызов события. Текущий результат: {Result}");
            GotResult?.Invoke(this, EventArgs.Empty);
        }

        public void CancelLast()
        {
            if (Results.Count > 0)
            {
                Result = Results.Pop();
            }

        }
    }
}
