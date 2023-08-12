using LiveTestingLib;

using Tests;

namespace LiveTestingDriver
{
    internal class Program
    {
        static int Main(string[] args)
        {
            var failures = 0;

            failures += new TestHarness<int, string>(Utils.CallsToString, new[]
            {
                (0, "0")
            }).RunTests();

            failures += new TestHarness<int, string>(Utils.ReturnsNull, new (int, string)[]
            {
                (0, null)
            }).RunTests();

            return failures;
        }
    }
}