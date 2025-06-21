using System;
using CalculadoraSalarial.Repositories.DTO;

namespace CalculadoraSalarial.Repositories.Interfaces
{
    public interface ICalculadora
    {
        /// <summary>
        /// Calcula el salario devengado a partir del salario bruto
        /// </summary>
        /// <param name="salarioBruto"></param>
        /// <returns></returns>
        SalarioResult_DTO CalcularSalarioLiquido(int salarioBruto);
    }
}
