using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrientacaoObjeto
{
    public class Celular
    {
        public string Nome;
        public double Preco;

        public Celular(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public Celular()
        {
           
        }

        public virtual string Vender(Celular celular)
        {
            return $"Celular {celular.Nome} vendido por {celular.Preco}";  
        }

        public override bool Equals(object? obj)
        {
            return obj is Celular celular &&
                   Nome == celular.Nome &&
                   Preco == celular.Preco;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nome, Preco);
        }
    }

    public class Motorola : Celular
    {
       public Motorola(string nome, double preco) : base(nome,preco) { }

    }

    public class Samsung : Celular
    {
      public Samsung(string Nome, Double Preco) : base(Nome,Preco) { }


        public override string Vender(Celular celular)
        {
            return $"SIM celular {Nome} foi vendido por {Preco}!";
        }

    }
}
