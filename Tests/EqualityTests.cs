using LiveTestingLib;
using FluentAssertions;

namespace Tests
{
    public class EqualityTests
    {
        [Fact]
        public void Test_ValuEqualityIsUsed()
        {
            // i.e. "0" == 0.ToString() => true
            // if reference equality was used it would not match
            new TestHarness<int, string>(Utils.CallsToString, new[]
            {
                (0, "0")
            }).RunTests().Should().Be(0);
        }        

        [Fact]
        public void Test_ExpectedOutputIsNullValue()
        {
            new TestHarness<int, string>(Utils.ReturnsNull, new (int, string)[]
            {
                (0, null)
            }).RunTests().Should().Be(0);
        }
    }
}