using System.Text;
using ReservaHotel.Models;

Console.OutputEncoding = Encoding.UTF8;

// Registrar os hóspedes

List<Pessoa> hospedes = new List<Pessoa>();

Console.Write("Informe a quantidade de hóspedes: ");
var InputHospedes = Console.ReadLine();

int QtdHospedes;

if (int.TryParse(InputHospedes, out QtdHospedes))
{
    for (int i = 0; i < QtdHospedes; i++)
    {
        Console.Write("Digite o nome do hóspede: ");
        var Nome = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(Nome))
        {
            Pessoa p = new Pessoa(nome: Nome);
            hospedes.Add(p);
        }
        else
        {
            Console.WriteLine("Digite o nome para prosseguir!");
            i--;
        }
    }
}
else
{
    Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
}
Console.WriteLine("-----------------------------");

// Escolher a suíte desejada

Console.WriteLine("Digite a suíte desejada: ");
Console.WriteLine("1 - Simples");
Console.WriteLine("2 - Média");
Console.WriteLine("3 - Premium");
Console.WriteLine("-----------------------------");
var InputSuite = Console.ReadLine();

int NumSuite;
Suite? suite = null;

if (int.TryParse(InputSuite, out NumSuite))
{
    switch (NumSuite)
    {
        case 1:
            suite = new Suite("Suíte Simples", 2, 300.0m);
            break;

        case 2:
            suite = new Suite("Suíte Média", 4, 450.0m);
            break;

        case 3:
            suite = new Suite("Suíte Premium", 2, 1000.0m);
            break;

        default:
            Console.WriteLine("O número da suíte não é válido");
            break;
    }
}
else
{
    Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
}

// Criar a reserva

Console.WriteLine("-----------------------------");
Console.WriteLine("Digite o número de diárias: ");
var InputDiarias = Console.ReadLine();

int NumDiarias;
Reserva? reserva = null;

if (int.TryParse(InputDiarias, out NumDiarias))
{
    reserva = new Reserva(diasReservados: NumDiarias);

    if (suite != null)
    {
        reserva.CadastraSuite(suite);
    }
    else
    {
        Console.WriteLine("Não foi selecionada nenhuma suíte.");
    }

    reserva.CadastraHospedes(hospedes);
}
else
{
    Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
}

if (reserva != null)
{
    Console.WriteLine("-----------------------------");
    Console.WriteLine("RESUMO DA RESERVA:");
    Console.WriteLine($"Hóspedes: {QtdHospedes}");
    Console.WriteLine($"Valor da Diária: {reserva.CalcularValorDiaria():C}");
}
