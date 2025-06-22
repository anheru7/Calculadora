using CalculadoraSalarial.Repositories.Interfaces;
using CalculadoraSalarial.Repositories.DTO;

namespace CalculadoraSalarial.Repositories.Logic
{
    public class Calculadora : ICalculadora
    {
        private const decimal SALARIO_MINIMO = 1423500;
        private const decimal SUBSIDIO_TRANSPORTE = 200000;
        private const decimal TASA_SALUD = 0.08m;
        private const decimal TASA_PENSION = 0.04m;


        public SalarioResult_DTO CalcularSalarioLiquido(int salarioBruto)
        {
            try
            {
                int noSalarios = (int)(salarioBruto / SALARIO_MINIMO);
                decimal salarioLiquido = 0;
                bool AplicaSubsidio = false;

                if (salarioBruto < SALARIO_MINIMO)
                {
                    throw new ArgumentException("El salario bruto debe ser mayor o igual al salario mínimo.");
                }

                if (noSalarios < 2)
                {
                    salarioLiquido = salarioBruto - (salarioBruto * TASA_SALUD) - (salarioBruto * TASA_PENSION) + SUBSIDIO_TRANSPORTE;
                    AplicaSubsidio = true;
                }
                else
                {
                    salarioLiquido = salarioBruto - (salarioBruto * TASA_SALUD) - (salarioBruto * TASA_PENSION);
                }

                return new SalarioResult_DTO{
                    SalarioBruto = salarioBruto,
                    SalarioLiquido = salarioLiquido,
                    AplicaSubsidio = AplicaSubsidio,
                    NroSalarios = noSalarios,
                    FechaCalculo = DateTime.Now
                };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al calcular el salario.", ex);
            }
        }
    }
}
