using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Seminar6
{
    class CalculatorException : Exception
    {
        public CalculatorException(string v, Stack<CalcActionLog> actionLogs) : base(v)
        {
            ActionLogs = actionLogs;
        }

        public CalculatorException(string v, Exception e) : base(v, e)
        {
            
        }

        public override string ToString()
        {
            return Message + ":" + string.Join("\n", ActionLogs.Select(x => $"{x.CalcAction} {x.CalcArgument}"));
        }

        public Stack <CalcActionLog> ActionLogs { get; private set; }
    }

    internal class CalculatorDevideByZeroException : CalculatorException
    {
                
        public CalculatorDevideByZeroException(string v, Stack<CalcActionLog> actionLogs) : base(v, actionLogs)
        {
        }

        public CalculatorDevideByZeroException(string v, Exception e) : base(v, e)
        {
        }
    }

    internal class CalculatorOperationCauseOvwerflowExcertion : CalculatorException
    {
        public CalculatorOperationCauseOvwerflowExcertion(string v, Stack<CalcActionLog> actionLogs) : base(v, actionLogs)
        {
        }

        public CalculatorOperationCauseOvwerflowExcertion(string v, Exception e) : base(v, e)
        {
        }
    }


}
