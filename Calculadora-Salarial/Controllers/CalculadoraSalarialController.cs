using Microsoft.AspNetCore.Mvc;
using CalculadoraSalarial.Repositories.Interfaces;
using CalculadoraSalarial.Repositories.DTO;
using System;

namespace CalculadoraSalarial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculadoraSalarialController : ControllerBase
    {
        private readonly ICalculadora _calculadora;

        public CalculadoraSalarialController(ICalculadora calculadora)
        {
            _calculadora = calculadora;
        }

        [HttpPost("calcular-salario/{salarioBruto}")]
        public ActionResult<SalarioResult_DTO> CalcularSalario(int salarioBruto)
        {
            try
            {
                if (salarioBruto <= 0)
                {
                    return BadRequest("El valor del salario no es válido");
                }

                var salarioLiquido = _calculadora.CalcularSalarioLiquido(salarioBruto);
                return Ok(salarioLiquido);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
