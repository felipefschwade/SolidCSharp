using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class CalculadoraDeSalario
    {
        public double Calcula(Funcionario funcionario)
        {
            return funcionario.CalculaSalario();
        }
    }

    public abstract class Cargo
    {
        public IRegraDeCalculo Regra { get; set; }
        public Cargo(IRegraDeCalculo regra)
        {
            Regra = regra;
        }
    }

    public class Funcionario
    {

        public Cargo Cargo { get; private set; }

        public double SalarioBase { get; private set; }

        public Funcionario(Cargo cargo, double salarioBase)
        {
            this.Cargo = cargo;
            this.SalarioBase = salarioBase;
        }

        public double CalculaSalario()
        {
            return Cargo.Regra.Calcula(this);
        }

    }
}
