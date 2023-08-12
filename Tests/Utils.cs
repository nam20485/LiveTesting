using System;
namespace Tests
{
    public class Utils
    {
        public static string CallsToStringOnInt(int i) => i.ToString();
        public static string CallsToString<T>(T t) => t.ToString();

        public static string ReturnsNull<T>(T t) => null;
    }
}
