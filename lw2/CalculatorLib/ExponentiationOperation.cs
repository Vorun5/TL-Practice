using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    public class ExponentiationOperation : IOperation
    {
        public string OperatorCode
        {
            get { return "^"; }
        }
        public int Apply(int operand1, int operand2)
        {
            int result = 1;
            while (operand2 != 0)
            {
                result *= operand1;
                operand2 -= 1;
            }
            return result;

        }
    }
}
