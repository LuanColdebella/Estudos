using Colecoes;

Produto p1 = new Produto ("Luan", 10);
Produto p2 = new Produto ("Luan", 10);

/*
EQUALS --> implementando o equals na classe produto, eu digo que agora eu quero verificar se 1 é igual ao outro utilizando a igualdede n por ref 

 // override object.Equals
        public override bool Equals(object obj)
        {
            Produto outro = (Produto)obj;
            bool mesmoNome = Nome == outro.Nome;
            bool mesmoPreco = Preco == outro.Preco; 

            return mesmoNome && mesmoPreco;
            
        }
*/


Console.WriteLine(p1 == p2); // N sao iguais pois p1 esta em 1 endereco de memoria e p2 em outro
Console.WriteLine(p1.Equals(p2)); // tambm é falsa compara endereço de memoria por padrão... <-- Agora vai dar TRUE