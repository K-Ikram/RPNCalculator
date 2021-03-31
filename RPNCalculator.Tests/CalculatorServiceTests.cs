using Xunit;
using RPNCalculator.Services;
using System.Collections.Generic;
using System.Collections;


namespace RPNCalculator.Tests
{
    public class CalculatorService_OperationsTests
    {
        [Theory]
        [ClassData(typeof(CalculatorTestOperations))]

        public void Test_ApplyOperands(Stack<decimal> old_stack, string op, Stack<decimal> expected_stack)
        {
            var calculatorService = new CalculatorService();
            var result = calculatorService.CalculateOperation(old_stack, op);
            Assert.Equal(expected_stack, result);

        }
    }

    public class CalculatorTestOperations : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Stack<decimal>(new decimal[] { 1, 2, 3 }),
                 "+",
                 new Stack<decimal>(new decimal[] { 1, 5 })
            };
            yield return new object[]
            {
                new Stack<decimal>(new decimal[] { 1, -2, 0 }),
                 "*",
                 new Stack<decimal>(new decimal[] { 1, 0 })
            };
             yield return new object[]
            {
                new Stack<decimal>(new decimal[] { 1, 2, 4 }),
                 "%2F",
                 new Stack<decimal>(new decimal[] { 1, 2 })
            };
             yield return new object[]
            {
                new Stack<decimal>(new decimal[] { 1, 2, 10 }),
                 "-",
                 new Stack<decimal>(new decimal[] { 1, 8 })
            };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
