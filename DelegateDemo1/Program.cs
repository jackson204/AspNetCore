using System;

namespace DelegateDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate myDelegate = Method1;
            myDelegate();
            MyDelegate2 myDelegate2 = Add;
            var result = myDelegate2(1,3);
            Console.WriteLine(result);
            
            Action action = () => Console.WriteLine("Action");
            action.Invoke();

            Func<int, int, int> func = (a, b) => a + b;

            var i = func(1,2);
            Console.WriteLine(i);
        }
        static void Method1()
        {
            Console.WriteLine("Method1");
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
    }
    
    delegate void MyDelegate();
    
    delegate int MyDelegate2(int a, int b);
}
