using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar5_HW
{
    internal class Calculator : ICalc
    {
        public event EventHandler<EventArgs> GotResult;

        public int Result = 0;

        private Stack<int> Results = new Stack<int>();

        public void Divide(int value)
        {
            Results.Push(Result);
            Result /= value;
            RaiseEvent();
        }

        public void Multiply(int value)
        {
            Results.Push(Result);
            Result *= value;
            RaiseEvent();
        }

        public void Substruct(int value)
        {
            Results.Push(Result);
            Result -= value;
            RaiseEvent();
        }

        public void Sum(int value)
        {
            Results.Push(Result);
            Result += value;
            RaiseEvent();
        }

        private void RaiseEvent()
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }

        public void CancelLast()
        {
            if (Results.Count > 0)
            {
                Result = Results.Pop();
                RaiseEvent();
            }

        }
    }
}
