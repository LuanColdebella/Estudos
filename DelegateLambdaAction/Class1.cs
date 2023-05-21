using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLambdaAction
{
    public class Class1
    {
        public delegate double Operacao(double x, double y);// delegate nada mais é que um tipo como uma classe exemplo....

        public Operacao sum = (x, y) => x + y; //Com este tipo pode ser criado várias coisas, com o mesmos parametros e return...
        public Operacao sub = (x, y) => x - y;
        public Operacao div = (x, y) => x / y;
        public Operacao mult = (x, y) => x * y;

        public Action algoNoConsole = () => 
        {
            Console.WriteLine("Lambda em c#");
        };

        public Func<int> JogarDado = () =>
        {
            Random rand = new Random();
            return rand.Next(1, 7);
        };
    }
}
