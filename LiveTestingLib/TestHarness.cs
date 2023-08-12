using System.Text;

namespace LiveTestingLib
{
    public class TestHarness<TInput, TOutput>
    {
        public delegate TOutput TestFunc(TInput input);

        public TestFunc FuncUnderTest { get; }

        public (TInput Input, TOutput ExpectedOutput)[] TestCases { get; }

        public TestHarness(TestFunc funcUnderTest,
                           IEnumerable<(TInput Input, TOutput ExpectedOutput)> testCases)
        {
            FuncUnderTest = funcUnderTest;
            TestCases = testCases.ToArray();
        }

        public int RunTests()
        {
            var failureCount = 0;
            var sb = new StringBuilder();
            sb.AppendLine("Running test cases...");

            for (int i = 0; i < TestCases.Length; i++)
            {
                try
                {
                    sb.Append($"Testing input [{TestCases[i].Input}]: ");

                    var actualOutput = FuncUnderTest(TestCases[i].Input);
                    
                    var correct = Equals(actualOutput, TestCases[i].ExpectedOutput);
                    if (correct)
                    {
                        sb.Append("PASSED");
                    }
                    else
                    {
                        failureCount++;
                        sb.Append("FAILED");
                    }
                    sb.AppendLine($", expected [{(TestCases[i].ExpectedOutput == null? "null" : TestCases[i].ExpectedOutput)}], {(correct? "and" : "but")} actually received [{(actualOutput == null? "null" : actualOutput)}].");
                }
                catch (Exception e)
                {
                    sb.AppendLine($"{e.GetType().ToString}!");
                    failureCount++;
                }
            }

            sb.AppendLine($"Finished: {(failureCount > 0? "Failed" : "Success")} ({failureCount} errors).");

            Console.WriteLine(sb.ToString());
            return failureCount;
        }
    }
}
