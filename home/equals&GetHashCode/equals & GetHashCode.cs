using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colecoes
{
    public class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Produto(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            Produto outro = (Produto) obj; // foi feito um cast agora a var obj é do tipo classe (Produto) obj, com isto posso
                                                                                         // acessar as propriedades de Produto.
            bool mesmoNome = Nome == outro.Nome;
            bool mesmoPreco = Preco == outro.Preco; 

            return mesmoNome && mesmoPreco;
            
        }

        public override int GetHashCode()
        {
            return Nome.Length; // dentro de uma colecao de inf. eu to buscando o que tem 4 caracteres somente então só
                                                                  // sera mostrado os que realmente so tem 4 caracteres
                                                                  //usado com o HashSet, para evitar criar dois produtos iguais neste caso.
        }


    }
}
