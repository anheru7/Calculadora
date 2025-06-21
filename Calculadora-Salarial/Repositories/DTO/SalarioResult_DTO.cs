namespace CalculadoraSalarial.Repositories.DTO;
public class SalarioResult_DTO
{
    /// <summary>
    /// Salario bruto ingresado
    /// </summary>
    public int SalarioBruto { get; set; }

    /// <summary>
    /// Salario calculado
    /// </summary>
    public decimal SalarioLiquido { get; set; }

    /// <summary>
    /// Aplica subsidio de transporte 
    /// </summary>
    public bool AplicaSubsidio { get; set; }

    /// <summary>
    /// Numero de salarios devengados
    /// </summary>
    public int NroSalarios { get; set; }

    /// <summary>
    /// Fecha de calculo del salario
    /// </summary>
    public DateTime FechaCalculo { get; set; } = DateTime.Now;
}
