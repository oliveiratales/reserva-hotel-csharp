using System;
using System.Collections.Generic;

namespace ReservaHotel.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; private set; }
        public Suite? Suite { get; private set; }
        public int DiasReservados { get; set; }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
            Hospedes = new List<Pessoa>();
        }

        public void CadastraHospedes(List<Pessoa> hospedes)
        {
            if (Suite != null && Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new InvalidOperationException("A capacidade da suíte é insuficiente para a quantidade de hóspedes recebidos");
            }
        }

        public void CadastraSuite(Suite suite)
        {
            Suite = suite;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite != null)
            {
                decimal valor = DiasReservados * Suite.ValorDiaria;

                if (DiasReservados >= 10)
                {
                    valor -= valor * 0.1M;
                }

                return valor;
            }
            else
            {
                throw new InvalidOperationException("A suíte não foi cadastrada para calcular o valor da diária.");
            }
        }
    }
}
