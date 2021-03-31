using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace RPNCalculator.Model
{

    public class CalculatorStack
    {
   
        public string stackid{get; set;}
        public Stack<decimal> stack {get; set;}


    } 


}