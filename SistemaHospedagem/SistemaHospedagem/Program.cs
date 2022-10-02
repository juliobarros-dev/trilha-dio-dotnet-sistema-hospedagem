using SistemaHospedagem.Enums;
using SistemaHospedagem.Models;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Suite basicSuite = new(SuiteTypeEnum.Basic, 1, 20.00m);
Suite standardSuite = new(SuiteTypeEnum.Standard, 3, 20.00m);
Suite premiumSuite = new(SuiteTypeEnum.Premium, 5, 20.00m);

List<Suite> hotelRooms = new List<Suite>() { basicSuite, standardSuite, premiumSuite };

bool showMenu = true;

while (showMenu)
{
  Console.WriteLine("Sistema de hospedagem\n");
  Console.WriteLine("Escolha um opção pra prosseguir\n");
  Console.WriteLine("1. Cadastrar hóspedes;");
  Console.WriteLine("2. Encerrar programa.\n");

  switch (Console.ReadLine())
  {
    case "1":
      Console.Clear();
      Console.WriteLine("Sistema de hospedagem\n");
      Console.WriteLine("Escolha sua suíte\n");

      int suiteIndex = 1;

      foreach (var suite in hotelRooms)
      {
        if (!suite.Occupied)
        {
          Console.WriteLine($"{suiteIndex}. {suite.TipoSuite} - Capacidade de {suite.Capacidade} hóspedes.");
          suiteIndex++;
        }
      }
      Console.WriteLine();

      Console.WriteLine("Pessione 0 para retornar.");

      int inputOption = int.Parse(Console.ReadLine());

      if (inputOption == 0)
      {
        break;
      }

      SuiteTypeEnum inputSelectedSuite = (SuiteTypeEnum) inputOption - 1;

      Suite selectedSuite = hotelRooms.Find(x => x.TipoSuite == inputSelectedSuite);

      selectedSuite.ChangeOccupiedStatus();

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
        Console.Write("Digite o CPF do hóspede: ");
        string inputCPF = Console.ReadLine();

        Pessoa hospede = new(firstName, lastName, inputCPF);
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

      Console.WriteLine($"\nSuíte reservada: {selectedSuite.TipoSuite}");

      break;

    case "2":
      showMenu = false;
      Console.WriteLine("\nPrograma encerrado");
      break;
  }

  Console.WriteLine("\nPressione qualquer tecla para continuar.");
  Console.ReadLine();
  Console.Clear();
}