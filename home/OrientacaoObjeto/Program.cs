using OrientacaoObjeto;
Celular celular = new Celular();

Motorola motorola = new("MotoG4", 5000.200);
Samsung samsung = new("GlaxyNote", 10500.500);
Samsung samsung1 = new("GlaxyNote", 10500.500);


Console.WriteLine(samsung.Equals(samsung1));
Console.WriteLine(samsung.Vender(samsung));

Console.WriteLine(celular.Vender(motorola)); 
Console.WriteLine(celular.Vender(samsung)); 
