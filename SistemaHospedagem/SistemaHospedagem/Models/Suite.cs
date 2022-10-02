using SistemaHospedagem.Enums;
using System.Diagnostics;

namespace SistemaHospedagem.Models
{
  public class Suite
  {
    public SuiteTypeEnum TipoSuite { get; set; }
    public int Capacidade { get; set; }
    public decimal ValorDiaria { get; set; }
    public bool Occupied = false;

    public Suite() { }

    public Suite(SuiteTypeEnum tipoSuite, int capacidade, decimal valorDiaria)
    {
      TipoSuite = tipoSuite;
      Capacidade = capacidade;
      ValorDiaria = valorDiaria;
    }

    public void ChangeOccupiedStatus() => Occupied = !Occupied;
  }
}
