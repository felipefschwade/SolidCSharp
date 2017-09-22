using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutive_Principle
{
    public class ProcessadorDeInvestimentos
    { 
        static void Main(string[] args)
        {
            IList<ContaComum> contas = ContasDoBanco();

            foreach (ContaComum conta in contas)
            {
                conta.somaInvestimento();

                Console.WriteLine("Novo saldo: " + conta.Saldo);
            }

            Console.ReadLine();
        }

        private static IList<ContaComum> ContasDoBanco()
        {
            List<ContaComum> contas = new List<ContaComum>();
            contas.Add(umaContaComum(100));
            contas.Add(umaContaComum(150));
            contas.Add(umaContaEstudante(100));
            return contas;
        }

        private static ContaEstudante umaContaEstudante(double saldo)
        {
            ContaEstudante conta = new ContaEstudante();
            conta.Deposita(saldo);
            return conta;
        }

        private static ContaComum umaContaComum(double saldo)
        {
            ContaComum conta = new ContaComum();
            conta.Deposita(saldo);
            return conta;
        }
    }

    class ContaEstudante : ContaComum
    {
        public int Milhas { get; private set; }

        public override void Deposita(double valor)
        {
            base.Deposita(valor);
            this.Milhas += (int)valor;
        }

        public override void somaInvestimento()
        {
            Saldo = Saldo;
        }

    }

    class ContaComum
    {
        public double Saldo { get; protected set; }

        public ContaComum()
        {
            this.Saldo = 0;
        }

        public virtual void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        public void Saca(double valor)
        {
            if (valor <= this.Saldo)
            {
                this.Saldo -= valor;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public virtual void somaInvestimento()
        {
            this.Saldo += this.Saldo * 0.01;
        }
    }
}
