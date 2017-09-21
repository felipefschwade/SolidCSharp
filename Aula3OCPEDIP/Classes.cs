using Aula3OCPEDIP.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula3OCPEDIP
{
    public class Compra
    {
        public string Cidade { get; set; }
        public double Valor { get; set; }
    }

    public class CalculadoraDePrecos
    {
        private readonly IMetodoEntrega _entrega;
        private readonly ITabelaDeDesconto _desconto;

        public CalculadoraDePrecos(ITabelaDeDesconto desconto, IMetodoEntrega entrega)
        {
            _entrega = entrega;
            _desconto = desconto;
        }
        public double Calcula(Compra produto)
        {
            double desconto = _desconto.DescontoPara(produto.Valor);
            double frete = _entrega.Para(produto.Cidade);

            return produto.Valor * (1 - desconto) + frete;
        }
    }
    class TabelaDePrecoPadrao : ITabelaDeDesconto
    {
        public double DescontoPara(double valor)
        {
            if (valor > 5000) return 0.03;
            if (valor > 1000) return 0.05;
            return 0;
        }
    }

    class Frete : IMetodoEntrega
    {
        public double Para(string cidade) 
        {

            if ("SAO PAULO".Equals(cidade.ToUpper()))
            {
                return 15;
            }
            return 30;
        }
    }
}
