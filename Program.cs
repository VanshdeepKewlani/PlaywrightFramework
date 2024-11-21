// See https://aka.ms/new-console-template for more information
using NUnitLite;

namespace PlaywrightFramework
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            // Run the tests programmatically with NUnitLite
            return new AutoRun().Execute(args);
        }
    }
}

