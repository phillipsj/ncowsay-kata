using System;
using System.Runtime.InteropServices.WindowsRuntime;
using cowsay.core;
using Microsoft.Extensions.CommandLineUtils;

namespace cowsay_ms
{
    class Program
    {
        static void Main(string[] args)
        {
            ICowsay cowsay = new Cowsay();
            
            CommandLineApplication commandLineApplication =
                new CommandLineApplication(throwOnUnexpectedArg: false);
            CommandArgument text = null;
            commandLineApplication.Command("say",
                (target) =>
                    text = target.Argument(
                        "say",
                        "Prints the given text to the console as if a cow had said it."));
            commandLineApplication.VersionOption("-v | --version", () => cowsay.Version());
            commandLineApplication.HelpOption("-? | -h | --help");
            commandLineApplication.OnExecute(() =>
            {
               
                return 0;
            });
            commandLineApplication.Execute(args);
        }
    }
}
