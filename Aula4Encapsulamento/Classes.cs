using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula4Encapsulamento
{
    public class ProcessadorDeBoletos
    {
        public void Processa(IList<Boleto> boletos, Fatura fatura)
        {
            foreach (Boleto boleto in boletos)
            {
                Pagamento pagamento = new Pagamento(boleto.Valor, MeioDePagamento.BOLETO);
                fatura.AdicionaPagamento(pagamento);
            }
        }
    }

    public class Boleto
    {
        public double Valor { get; private set; }

        public Boleto(double valor)
        {
            this.Valor = valor;
        }
    }

    public class Fatura
    {
        public string Cliente { get; private set; }
        public double Valor { get; set; }
        private IList<Pagamento> Pagamentos;
        private bool Pago;

        public Fatura(string cliente, double valor)
        {
            this.Cliente = cliente;
            this.Valor = valor;
            this.Pagamentos = new List<Pagamento>();
            this.Pago = false;
        }

        public void AdicionaPagamento(Pagamento pagamento)
        {
            double total = 0;
            this.Pagamentos.Add(pagamento);

            if (total >= Valor)
            {
                this.Pago = true;
            }
        }

    }
    public enum MeioDePagamento
    {
        BOLETO,
        CARTAO
    }
    public class Pagamento
    {
        public double Valor { get; private set; }
        public MeioDePagamento Forma { get; private set; }

        public Pagamento(double valor, MeioDePagamento forma)
        {
            // TODO: Complete member initialization
            this.Valor = valor;
            this.Forma = forma;
        }
    }
}
