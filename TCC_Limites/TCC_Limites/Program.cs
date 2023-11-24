using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Limites
{
    class Program
    {
        static void Main(string[] args)
        {
            // Primeiro Iremos definiir as String para serem usadas no projeto
            // definindo assim as constantes e dados que o programa deve armazenar
            
            int valorX, Qtd, Qtd2 = 2; //int Armazena valores em numeros
            char Sub = 'A'; //Char amazena somente um dado que eum digito aprosimadamente

            double[] XDireita = new double[7]; // Isso sera o conjunto das Strings que armazenara o resultados dos calculos.
            double[] XEsquerda = new double[7];

            double[] RDireita = new double[7];
            double[] REsquerda = new double[7]; // <-- O numero entre os colchetes, ira determinar a quantidade de espaços de dados que a String Ira ter.
            double[] RDireita2 = new double[7];
            double[] REsquerda2 = new double[7];

            String[] Termos2, Opera2;
            double[] resultadosD2, resultadosE2;

            Console.Write("Quantos termos para inserir na Expressão? "); // 1° Requesitar com que o Usuario insira a quantidade de expressoes que usara                                                                         
            Qtd = int.Parse(Console.ReadLine());                         // alem de pergunta se a expressao e dividida pro algo.

            Console.Write($"\nVoce desejaria Insirir uma expressão para dividir a anterior?: (Y/N) ");
            Sub = Console.ReadLine().ToUpper()[0]; //Console.ReadLine() ira anotar na expressão o que foi digitado.

            String[] Termo = new string[Qtd]; //A quantidade insirada pelo usuario, ira converter-se para a quantidade de Strings que armazenaram cada expressão
            String[] Opera = new string[Qtd - 1];
            double[] resultadosD = new double[Qtd]; //Qtd equivale a quantidade de expressoes que o usuario ira usar.
            double[] resultadosE = new double[Qtd];

            // O codigo abaixo anotar a expressão inserida nessas Strings em um Loop, ate que o numero de expressoes que foram requesitados acabem

            for (int Num = 0; Num < Qtd; Num++) //
            {
                Console.Write($"\nInforme o {Num + 1}° termo da expressão: ");
                Termo[Num] = Console.ReadLine();

                //verifica se tem que solicitar a operação
                if (Num != Qtd - 1)
                {
                    Console.Write($"\nDigite o {Num + 1} operador (+ - * /): ");
                    Opera[Num] = Console.ReadLine();
                }
            }

            // Ira demostrar a expressao que o Usuario inseriu

            for (int Num = 0; Num < Qtd; Num++)
            {
                if (Num != Qtd - 1)
                    Console.Write($"{Termo[Num]} {Opera[Num]} ");
                else
                    Console.Write($"{Termo[Num]}\n");
            }

            if (Sub == 'Y')    // Caso o Ususario tenha selecionado a opçao de adicionar outra expressao para dividir a anterior,
            {                  // Essa linha de codigo IF (Se), ira repetir o codigo anterior para uma nova fraçao
                
                Console.Write("\nExpressão para dividir\n");
                Console.Write("\nQuantos termos? ");
                Qtd2 = int.Parse(Console.ReadLine());

                Termos2 = new string[Qtd2];  //Como pode se observar, usa similarmente as mesmas Strings que o codigo anterior, so que diferente, para destinguilas.
                Opera2 = new string[Qtd2 - 1];
                resultadosD2 = new double[Qtd2]; 
                resultadosE2 = new double[Qtd2];
            
                for (int parte = 0; parte < Qtd2; parte++)
                {
                    Console.Write($"\nInforme o {parte + 1}° termo da expressão: ");
                    Termos2[parte] = Console.ReadLine();

                    //verifica se tem que solicitar a operação
                    if (parte != Qtd2 - 1)
                    {
                        Console.Write($"\nDigite o {parte + 1} operador (+ - * /): ");
                        Opera2[parte] = Console.ReadLine();
                    }
                }

                //Agora ele ira mostrar a nova equação insirida

                for (int parte = 0; parte < Qtd; parte++)
                {
                    if (parte != Qtd - 1)
                        Console.Write($"{Termo[parte]} {Opera[parte]} ");
                    else
                        Console.Write($"{Termo[parte]}");
                }

                Console.Write($"\n======================\n");

                for (int parte = 0; parte < Qtd2; parte++)
                {
                    if (parte != Qtd2 - 1)
                        Console.Write($"{Termos2[parte]} {Opera2[parte]} ");
                    else
                        Console.Write($"{Termos2[parte]}\n\n");
                }
            }
            else //caso ele nao tenha requesitado, iremos zerar a String para que nao haja problemas.
            {
                Qtd2 = 0;
                Termos2 = new string[0];
                Opera2 = new string[0];
                resultadosD2 = new double[0];
                resultadosE2 = new double[0];
            }
            

            //O programa ira requesitar O valor de X
            
            Console.WriteLine("\nDigite o valor de X: ");
            valorX = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\n=================================");

            //Depois de receber o X, o programa ira inserir o X, em Strings que equivalem cada valor do limite
            // exemplo : X = 4 Direita de X = 5 e Esquerda de X sera 3

            XDireita[0] = (double)(valorX + 1); // "Nome da String" [Numero da Casa de dados] = (definir o tipo de String para converter) (O numero de X +/- o numero que sera inserido dependendo da posiçao do limite.)
            XDireita[1] = (double)(valorX + 0.5); 
            XDireita[2] = (double)(valorX + 0.1);
            XDireita[3] = (double)(valorX + 0.01);
            XDireita[4] = (double)(valorX + 0.001);
            XDireita[5] = (double)(valorX + 0.0001);
            XDireita[6] = (double)(valorX + 0.00001);

            XEsquerda[0] = (double)(valorX - 1);
            XEsquerda[1] = (double)(valorX - 0.5);
            XEsquerda[2] = (double)(valorX - 0.1);
            XEsquerda[3] = (double)(valorX - 0.01);
            XEsquerda[4] = (double)(valorX - 0.001);
            XEsquerda[5] = (double)(valorX - 0.0001);
            XEsquerda[6] = (double)(valorX - 0.00001);

            for (int D = 0; D <= 6; D++) // Agora o programa ira calcular a expressao, trocando a o X pelo valor de das Strings dos Limites Direitos e Esquerdos.
            {
                for (int parte = 0; parte < Qtd; parte++)
                {
                    resultadosD[parte] = Termonologia(XDireita[D], Termo[parte]);      //ResultadosD e E e onde sera armazenado o resultado da exspressao convertida
                    resultadosE[parte] = Termonologia(XEsquerda[D], Termo[parte]);     // Termonologia se refere ao Script que ira fazer os calculos separadamente.
                                                                                       // e as informaçoes entre parentese sera usadas no script
                }

                for (int l = 0; l < Qtd - 1; l++)
                {
                    RDireita[D] = Kickassia(Opera[l], resultadosD[l], resultadosD[l + 1], RDireita[D]);     //Similarmente a Termonologia, Kickassia ira somar 2 expressoes que foram calculadas. no prgograma
                    REsquerda[D] = Kickassia(Opera[l], resultadosE[l], resultadosE[l + 1], REsquerda[D]);
                }

            }

            if (Sub == 'Y') //Caso aja uma expressao dividindo a anterior, ele ira calcular tambem ela similarmente com o codigo anterir
            {
                for (int D = 0; D <= 6; D++) 
                {
                    for (int parte = 0; parte < Qtd; parte++)
                    {
                        resultadosD2[parte] = Termonologia(XDireita[D], Termos2[parte]);
                        resultadosE2[parte] = Termonologia(XEsquerda[D], Termos2[parte]);
                    }

                    for (int l = 0; l < Qtd - 1; l++)
                    {
                        RDireita2[D] = Kickassia(Opera2[l], resultadosD2[l], resultadosD2[l + 1], RDireita2[D]);
                        REsquerda2[D] = Kickassia(Opera2[l], resultadosE2[l], resultadosE2[l + 1], REsquerda2[D]);
                    }

                }

            }
            

            if (Sub == 'Y') // Ocorre a divisão de ambas expressões
            {
                for (int D = 0; D <= 6; D++)
                {
                    if (RDireita[D] < 0 && REsquerda[D] < 0) //Caso ambos resultados forem negativos, isso ira converter eles para positivos
                    {
                        RDireita[D] = RDireita[D] * -1;
                        REsquerda[D] = REsquerda[D] * -1;
                    }

                    RDireita[D] = RDireita[D] / RDireita2[D];
                    REsquerda[D] = REsquerda[D] / REsquerda2[D];
                }
            }


            //O prgrama agora ira mostrar esses resultados de ambos limites na tela.
            Console.WriteLine("\nCalculo da direita");

            for (int Dshow = 0; Dshow <= 6; Dshow++) 
            {
                Console.WriteLine($"\n{XDireita[Dshow]} = {RDireita[Dshow]}");
                Console.WriteLine("\n=================================");

            }

            Console.WriteLine("\nCalculo da esquerda");

            for (int Eshow = 0; Eshow <= 6; Eshow++) 
            {
                Console.WriteLine($"\n{XEsquerda[Eshow]} = {REsquerda[Eshow]}");                
                Console.WriteLine("\n=================================");

            }

            Console.ReadKey(); //O usuario ira ter que apertar a tecla para continuar

            // Agora o Programa ira pegar ambos os ultimos resultados dos limites, e ira arredondalos e comparar esse valor arredondado para ver se ambos Limites são Iguais ou Não


            if (Math.Round(REsquerda[6], MidpointRounding.AwayFromZero) == Math.Round(RDireita[6], MidpointRounding.AwayFromZero) ||      // Math.Round ira arredondar o resultado, do jeito que foi especificado.
                Math.Round(REsquerda[6], 4, MidpointRounding.AwayFromZero) == Math.Round(RDireita[6], 4, MidpointRounding.AwayFromZero)) // compara para ver se os resultados sao iguais
            {
                Console.WriteLine($"\n\nLimites são iguais, equivalentes a {Math.Round(REsquerda[6],MidpointRounding.AwayFromZero)} ");
            }
            else
            {
                Console.WriteLine($"\n\nLimites são diferentes, equivalentes a: D: {Math.Round(RDireita[6], 4, MidpointRounding.AwayFromZero)} E: {Math.Round(REsquerda[6], 4, MidpointRounding.AwayFromZero)} ");
            }

            Console.ReadKey(); //O usuario ira ter que apertar a tecla para encerrar o programa

        }

        static private double Termonologia(double valorX, String expressao) //Esse Script separado, Ira calcular o X da expressão e dar o seu valor.
        {
            double resultado = 0;

            //se a expressao não tem variavel, não precisa calcular
            if (expressao.ToUpper().IndexOf("X") == -1)
            {
                resultado = double.Parse(expressao);
            }
            else
            {
                //separa a expressão e joga dentro de um vetor
                String[] separado = expressao.ToUpper().Split('X'); // Ira dividir ambos o numero multiplicado e o potencial de X em Strings.

                if (separado[0] == "") // Caso X nao esteja sendo multiplicado por algo.
                {
                    separado[0] = "1";
                }
                else //não tem exponencial
                {
                    resultado = valorX * double.Parse(separado[0]);
                }

                //verifica se a expressao tem exponencial
                if (separado.Length == 2 && separado[1] != "")
                {
                    resultado = Math.Pow(valorX, double.Parse(separado[1]));
                    resultado = resultado * double.Parse(separado[0]);
                }
                else //não tem exponencial
                {
                    resultado = valorX * double.Parse(separado[0]);
                }
            }

            return resultado;

        }

        static private double Kickassia(String Op, double Res, double Res1, double Prevs) //Esse "Script" ira calcular uma expressao com a outra, dependendo do sinal
        {                                                                                 //Ex: 3 + 4 = 7 | 5 - 3 = 2
            double resultado = 0;

            if (Prevs == 0)
            {
                if (Op == "+")
                    resultado = Res + Res1;
                else if (Op == "-")
                    resultado = Res - Res1;
                else if (Op == "*")
                    resultado = Res * Res1;
                else if (Op == "/")
                    resultado = Res / Res1;
            }
            else
            {
                if (Op == "+")
                    resultado = Prevs + Res1;
                else if (Op == "-")
                    resultado = Prevs - Res1;
                else if (Op == "*")
                    resultado = Prevs * Res1;
                else if (Op == "/")
                    resultado = Prevs / Res1;
            }
            return resultado;

        }

    }
}
