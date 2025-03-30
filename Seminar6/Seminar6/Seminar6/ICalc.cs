using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar6
{
    internal interface ICalc
    {
        event EventHandler<EventArgs> GotResult;
        void Sum(int Value);
        void Substruct(int Value);
        void Divide(int Value);
        void Multiply(int Value);

        void Sum(double Value);      
        void Substruct(double Value);
        void Divide(double Value);
        void Multiply(double Value);
        void CancelLast();
        int Result { get; }     
    }
}
