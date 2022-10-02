using SistemaHospedagem.Models;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Suite basicSuite = new("Basic", 1, 20.00m);
Suite standardSuite = new("Standard", 3, 20.00m);
Suite premiumSuite = new("Basic", 5, 20.00m);

List<Suite> hotelRooms = new List<Suite>() { basicSuite, standardSuite, premiumSuite };

bool showMenu = true;

while (showMenu)
{
  Console.WriteLine("Sistema de hospedagem\n");
  Console.WriteLine("Escolha um opção pra prosseguir\n");
  Console.WriteLine("1. Cadastrar hóspedes;");
  Console.WriteLine("2. Encerrar programa.");

  switch (Console.ReadLine())
  {
    case "1":
      Console.Clear();
      Console.WriteLine("Sistema de hospedagem\n");
      Console.WriteLine("Escolha sua suíte");
      foreach (var suite in hotelRooms)
      {
        Console.WriteLine(suite.TipoSuite);
      }
      Console.WriteLine();

      string inputSelectedSuite = Console.ReadLine().ToLower();

      Suite selectedSuite = hotelRooms.Find(x => x.TipoSuite.ToLower() == inputSelectedSuite);

      Console.Clear();
      Console.WriteLine("Sistema de hospedagem\n");
      Console.WriteLine($"A capacidade da suíte é de {selectedSuite.Capacidade} hóspedes.\n");

      List<Pessoa> hospedes = new();

      for (int index = 1; index <= selectedSuite.Capacidade; index++)
      {
        Console.Write("Digite o nome completo do hóspede: ");
        string[] inputFullName = Console.ReadLine().Split(' ');
        string firstName = inputFullName[0];
        string lastName = inputFullName[1];

        Pessoa hospede = new(firstName, lastName);
        hospedes.Add(hospede);
      }

      Console.Write("Digite quantos dias deseja se hospedar: ");
      int period = int.Parse(Console.ReadLine());

      Reserva reservation = new(period);
      reservation.CadastrarSuite(selectedSuite);
      reservation.CadastrarHospedes(hospedes);

      Console.WriteLine("\nHóspedes cadastrados");

      foreach(Pessoa hospede in hospedes)
      {
        Console.WriteLine($"- {hospede.NomeCompleto};");
      }

      break;

    case "2":
      showMenu = false;
      Console.WriteLine("Programa encerrado");
      break;
  }

  Console.WriteLine("\nPressione qualquer tecla para continuar.");
  Console.ReadLine();
  Console.Clear();
}