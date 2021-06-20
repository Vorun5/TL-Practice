using System;
using System.Collections.Generic;
using CalculatorLib;

using System.Net;
using System.Text.RegularExpressions;

namespace lw2
{
    class Program
    {
        static void Main( string[] args )
        {
            if ( args.Length < 1 )
            {
                Console.WriteLine( "Please specify calculation string" );
                return;
            }
            List<IOperation> operations = new List<IOperation>
             {
                 new AdditionOperation(),
                 new SubstractionOperation(),
                 new MultiplicationOperation(),
                 new DivisionOperation(),
                 new ExponentiationOperation(),
                 new RemainderDivisionOperation()
             };
            ICalculator calculator = new SimpleCalculator( operations );
            int result = calculator.Calculate( args[ 0 ] );

            Console.WriteLine( $"Result: {result}" );
        }
    }
}
