

ClassVsStruct.Ref_e_Out refOut = new ClassVsStruct.Ref_e_Out();
// REF --> a variável que for criada terá a ref da variavel que está na funcção que soma + 1000

        /*
          public void AlterarRef(ref int a)
                {
                    a += 1000;
                }
        */

int a = 3;
refOut.AlterarRef(ref a);
Console.WriteLine(a);


// OUT --> neste caso não posso declarar uma variavel fora da função, com o operador out preciso passar um valor
// a variavel função neste caso a variavel b, somente criar a variavel sem valor   

/*
  public void AlterarOut(out int b)
        {
            int b = 2;
            b += 15;
        }
*/

int b;
refOut.AlterarOut(out b);
Console.WriteLine(b);

