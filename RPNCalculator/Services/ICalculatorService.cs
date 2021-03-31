using System.Collections.Generic;
using RPNCalculator.Model;


namespace RPNCalculator.Services
{
    public interface ICalculatorService
    {
        public List<CalculatorStack> GetAllStacks();
        public CalculatorStack CreateNewStack(Stack<decimal> stack);
        public CalculatorStack ApplyOperandToStack(string oper, string stackid);

        public CalculatorStack AddNewValueToStack(string stackid, decimal value);
        public void DeleteStackById(string stackid);

        public Stack<string> GetAllOperands();
        public Stack<decimal> CalculateOperation(Stack<decimal> stack, string oper);

    }


}