var filmes = new Dictionary<int, string>(); //1º é uma chave key não pode ser repetido, e outro valor pode ser repetido
                                            
filmes.Add(2023, "Mario");
filmes.Add(2022, "Minions");
filmes.Add(2021, "Aquaman");

Console.WriteLine( filmes.ContainsKey(2023)); // retorna true se existe 2023 somenta para a chave
Console.WriteLine( filmes.ContainsValue("Mario")); // retorna true se existe o valor passado somente para o valor

Console.WriteLine( filmes.GetValueOrDefault(2022)); // retorna o nome se encontrar a chave fornecida
Console.WriteLine(filmes[2021]); // retorna o nome se encontrar mas se não encontrar vai dar erro, melhor opção e usar o GetValueOrDefault