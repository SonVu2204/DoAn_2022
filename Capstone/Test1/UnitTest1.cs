using System;
using Xunit;

namespace Test1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            if (Sum(2,2) !=4)
            {
                throw new Exception();
            }
        }
        int Sum(int left, int right)
        {
            return left + right;
        }
    }
}
