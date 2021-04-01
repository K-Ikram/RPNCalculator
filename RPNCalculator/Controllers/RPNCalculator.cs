using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RPNCalculator.Services;
using RPNCalculator.Model;

namespace RPNCalculator.Controllers
{
    [ApiController]
    [Route("rpn/")]
    public class RPNcalculator : ControllerBase
    {
        private readonly ILogger<RPNcalculator> _logger;
        private readonly ICalculatorService _calculatorService;
    
        public RPNcalculator(ILogger<RPNcalculator> logger, ICalculatorService calculatorService)
        {
            _logger = logger;
            _calculatorService = calculatorService;
        }
       
        /// <summary>
        /// List all the operations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("op")]
        public ActionResult<Stack<string>> GetAllOperands()
        {
            if(ModelState.IsValid){
                return Ok(_calculatorService.GetAllOperands());
            }
            return BadRequest(ModelState);
        }


        /// <summary>
        /// List the available stacks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("stack")]
        public ActionResult<List<CalculatorStack>> GetAllStacks()
        {
          if(ModelState.IsValid)
          {
              return Ok(_calculatorService.GetAllStacks());
          }        
            
            return BadRequest(ModelState);

        }

        /// <summary>
        /// Apply an operand to a stack
        /// </summary>
        /// <returns></returns>

         [HttpPost]
         [Route("op/{op}/stack/{stackid}")]
         public ActionResult<CalculatorStack> ApplystringToStack([FromRoute] string op, [FromRoute] string stackid)
         {
            if(ModelState.IsValid)
            {
                return Ok(_calculatorService.ApplyOperandToStack(op, stackid));

            }
            return BadRequest(ModelState);

        }


        /// <summary>
        /// Create a new stack
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("op/stack")]
        public ActionResult<CalculatorStack> CreateNewStack(Stack<decimal> stack)
        {            
           if(ModelState.IsValid) 
           {
               return  Ok(_calculatorService.CreateNewStack(stack));

           }

            return BadRequest(ModelState);

        }

        /// <summary>
        /// Delete a stack
        /// </summary>
        /// <param name="stackid"></param>
        /// <returns></returns>

        [HttpDelete]
        [Route("rpn/stack/{stackid}")]
        public IActionResult DeleteStackById([FromRoute] string stackid)
        {
            if(ModelState.IsValid)
            {
                _calculatorService.DeleteStackById(stackid);
                return Ok();
            }
            return BadRequest(ModelState);

        }
        /// <summary>
        /// Push a new value to a stack
        /// </summary>
        /// <param name="stackid"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("stack/{stackid}")]
        public ActionResult<CalculatorStack> AddNewValueToStack([FromRoute] string stackid, [FromBody] AddValueForm value)
        {
            if(ModelState.IsValid)
            {
                return Ok(_calculatorService.AddNewValueToStack(stackid,value.value));
            }
            
            return BadRequest(ModelState);

        }



    }
}
