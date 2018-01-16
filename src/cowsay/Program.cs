using System;
using cowsay.core;

namespace cowsay
{
    class Program
    {
        static void Main(string[] args)
        {
            ICowsay cowsay = new Cowsay();
            //Console.WriteLine(cowsay.SayMessage("Hi"));
            Console.ReadKey();
        }
    }
}
