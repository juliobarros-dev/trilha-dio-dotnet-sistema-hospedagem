using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHospedagem.Models
{
  public class Pessoa
  {
    public string Nome { get; set; } = string.Empty;
    public string Sobrenome { get; set; } = string.Empty;
    public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();

    public Pessoa() { }
    public Pessoa(string nome)
    {
      Nome = nome;
    }

    public Pessoa(string nome, string sobrenome)
    {
      Nome = nome;
      Sobrenome = sobrenome;
    }
  }
}
