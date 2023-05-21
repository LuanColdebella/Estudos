using DelegateLambdaAction;
using static DelegateLambdaAction.Class1;

Class1 class1 = new Class1();

Console.WriteLine(class1.JogarDado());

Console.WriteLine("sum" + " "+  class1.sum(10,10));
Console.WriteLine("sub"  + " "+class1.sub(10,10));
Console.WriteLine("mult" + " " +class1.mult(10,10));
Console.WriteLine("div" + " "+ class1.div(10,10));


class1.algoNoConsole();






