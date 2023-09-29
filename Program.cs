using System.Text;
using ReservaHotel.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Tales Ribeiro");
Pessoa p2 = new Pessoa(nome: "Camila Ramires");

hospedes.Add(p1);
hospedes.Add(p2);

Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 50);

Reserva reserva = new Reserva(diasReservados: 5);
reserva.CadastraSuite(suite);
reserva.CadastraHospedes(hospedes);

Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor da Diária: {reserva.CalcularValorDiaria()}");