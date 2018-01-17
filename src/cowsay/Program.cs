using System;
using System.Linq;
using cowsay.core;

namespace cowsay {
    class Program {
        static void Main(string[] args) {
            ICowsay cowsay = new Cowsay();
            if (args.Length == 0) {
                //Console.WriteLine("Print the error message.");
                Console.WriteLine(cowsay.GetVersion());
            }

            if (args.Length == 1) {
                var option = args.First();
                if (option == "--version" || option == "-v") {
                    Console.WriteLine(cowsay.GetVersion());
                }

                if (option == "--help" || option == "-h") {
                    Console.WriteLine("Print the help.");
                }
            }

            //Console.WriteLine(cowsay.SayMessage("Hi"));
            Console.ReadKey();
        }
    }
}
