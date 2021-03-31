using System.Collections.Generic;
using System;
using System.Linq;
using RPNCalculator.Model;

namespace RPNCalculator.Services
{
    public class CalculatorService : ICalculatorService
    {

        private List<CalculatorStack> _calculatorStacks;
        private Stack<string> _operandStack;

        public CalculatorService()
        {
            _calculatorStacks = new List<CalculatorStack>();
            _operandStack = new Stack<string>();
        }
        public List<CalculatorStack> GetAllStacks()
        {
            return _calculatorStacks;
        }
        public CalculatorStack CreateNewStack(Stack<decimal> stack)
        {

            CalculatorStack calculatorstack = new CalculatorStack();

            string id = Guid.NewGuid().ToString();
            calculatorstack.stackid = id;
            calculatorstack.stack = stack;
            _calculatorStacks.Add(calculatorstack);
            return calculatorstack;
        }

        public CalculatorStack ApplyOperandToStack(string oper, string stackid)
        {

            var stack = GetStackById(stackid);
            if (stack.stack.Count < 2) throw new Exception("Stack must contain more than one string! ");

            Stack<decimal> new_stack = CalculateOperation(stack.stack, oper);

            updateStack(stackid, new_stack);

            _operandStack.Push(oper);
            return stack;

        }

         public Stack<decimal> CalculateOperation(Stack<decimal> stack, string oper)
        {

            decimal op1 = stack.Pop();
            decimal op2 = stack.Pop();

            switch (oper)
            {
                case "+":
                    stack.Push(op1 + op2);
                    break;

                case "-":
                    stack.Push(op1 - op2);
                    break;

                case "*":
                    stack.Push(op1 * op2);
                    break;

                case "%2F":
                    if (op2 == decimal.Zero)
                    {
                        throw new Exception("Can't devide by zero!");
                    }
                    stack.Push(op1 / op2);
                    break;

                default:
                    throw new Exception("Invalid operator!");

            }
            return stack;

        }



        public CalculatorStack AddNewValueToStack(string stackid, decimal value)
        {
            var stack = GetStackById(stackid);
            stack.stack.Push(value);

            return stack;

        }

        private CalculatorStack GetStackById(string stackid)
        {

            CalculatorStack s = _calculatorStacks.Where(s => s.stackid == stackid).FirstOrDefault();

            if (s != null)
            {
                return s;
            }

            throw new Exception("No stack with this id: " + stackid);
        }

        private void updateStack(string stackid, Stack<decimal> new_stack)
        {
            var stack = GetStackById(stackid);

            stack.stack = new_stack;

        }

        public void DeleteStackById(string stackid)
        {
            var stack = GetStackById(stackid);

            _calculatorStacks.Remove(stack);

        }

        public Stack<string> GetAllOperands()
        {
            return _operandStack;
        }
    }
}