using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula2AcoplamentoEEstabilidade
{
    class GeradorDeNotaFiscal
    {

        private IList<IAcaoAposGerarNota> Acoes;
        public GeradorDeNotaFiscal(IList<IAcaoAposGerarNota> acoes)
        {
            Acoes = acoes;
        }

        public NotaFiscal Gera(Fatura fatura)
        {

            double valor = fatura.ValorMensal;

            NotaFiscal nf = new NotaFiscal(valor, ImpostoSimplesSobreO(valor));

            foreach (var acao in Acoes)
            {
                acao.Executa(nf);
            }

            return nf;
        }

        private double ImpostoSimplesSobreO(double valor)
        {
            return valor * 0.06;
        }
    }


    public class EnviadorDeEmail : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Enviando email");
        }
    }

    class NotaFiscalDao : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Persistindo nota");
        }
    }
    class Fatura
    {
        public double ValorMensal { get; set; }
        public string Cliente { get; private set; }

        public Fatura(double valorMensal, string cliente)
        {
            this.ValorMensal = valorMensal;
            this.Cliente = cliente;
        }
    }

    public class NotaFiscal
    {
        public double ValorBruto { get; private set; }
        public double Impostos { get; private set; }
        public double ValorLiquido
        {
            get
            {
                return this.ValorBruto - this.Impostos;
            }

        }

        public NotaFiscal(double valorBruto, double impostos)
        {
            // TODO: Complete member initialization
            this.ValorBruto = valorBruto;
            this.Impostos = impostos;
        }
    }
}
