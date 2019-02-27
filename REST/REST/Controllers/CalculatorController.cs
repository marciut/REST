using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace REST.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        // GET api/values/5/5
        [HttpGet("{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal resultado;
                resultado = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(resultado.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string valor)
        {
            decimal valorDecimal;
            bool isNumber = decimal.TryParse(valor, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out valorDecimal);
            return isNumber;
        }

        private decimal ConvertToDecimal(string valor)
        {
            decimal valorDecimal;
            if (Decimal.TryParse(valor, out valorDecimal))
                return valorDecimal;

            return 0;

        }
    }
}
