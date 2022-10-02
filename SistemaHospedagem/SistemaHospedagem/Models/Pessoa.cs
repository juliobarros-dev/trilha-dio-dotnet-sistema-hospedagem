namespace SistemaHospedagem.Models
{
  public class Pessoa
  {
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
    public string CPF { get; set; } = string.Empty;

    public Pessoa() { }
    public Pessoa(string nome)
    {
      Nome = nome;
    }

    public Pessoa(string nome, string sobrenome, string cpf)
    {
      Nome = nome;
      Sobrenome = sobrenome;
      CPF = cpf;
    }
  }
}
