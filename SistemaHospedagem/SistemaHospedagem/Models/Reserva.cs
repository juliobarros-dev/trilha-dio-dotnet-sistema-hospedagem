namespace SistemaHospedagem.Models
{
  internal class Reserva
  {
    public List<Pessoa> Hospedes { get; set; } = new();
    public Suite? Suite { get; set; }
    public int DiasReservados { get; set; }

    public Reserva() { }

    public Reserva(int diasReservados)
    {
      DiasReservados = diasReservados;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
      if (hospedes.Count <= Suite.Capacidade)
      {
        Hospedes = hospedes;
      }
      else
      {
        throw new Exception("Quantidade de hospedes excede a capacidade da suíte.");
      }
    }

    public void CadastrarSuite(Suite suite)
    {
      Suite = suite;
    }

    public int ObterQuantidadeHospedes() => Hospedes.Count;

    public decimal CalcularValorDiaria()
    {
      decimal valor = DiasReservados * Suite.ValorDiaria;
      decimal desconto = valor * 0.10m;

      if (DiasReservados >= 10)
      {
        return valor - desconto;
      }

      return valor;
    }
  }
}

