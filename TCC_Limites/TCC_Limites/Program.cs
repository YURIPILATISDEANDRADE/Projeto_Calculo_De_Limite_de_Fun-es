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
            int valorX, Qtd, Qtd2 = 2;
            char Sub = 'A';
            double RDireita2 = 1, REsquerda2 = 1;


            double[] XDireita = new double[7];
            double[] XEsquerda = new double[7];

            double[] RDireita = new double[7];
            double[] REsquerda = new double[7];

            String[] Termos2 = new string[Qtd2];
            String[] Operacoes2 = new string[Qtd2 - 1];
            double[] resultadosD2 = new double[Qtd2];
            double[] resultadosE2 = new double[Qtd2];

            Console.Write("Quantos termos para inserir na Expressão? ");
            Qtd = int.Parse(Console.ReadLine());

            String[] Termo = new string[Qtd];
            String[] Opera = new string[Qtd - 1];
            double[] resultadosD = new double[Qtd];
            double[] resultadosE = new double[Qtd];

            // anotar a expressão inserida

            for (int Num = 0; Num < Qtd; Num++)
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

            Console.Write($"\nVoce desejaria Insirir uma expressão para dividir a anterior?: (Y/N) ");
            Sub = Console.ReadLine().ToUpper()[0];

            for (int Num = 0; Num < Qtd; Num++)
            {
                if (Num != Qtd - 1)
                    Console.Write($"{Termo[Num]} {Opera[Num]} ");
                else
                    Console.Write($"{Termo[Num]}\n");
            }

            if (Sub == 'Y') // expressão para dividir 
            {
                Console.Write("\nQuantos termos? ");
                Qtd2 = int.Parse(Console.ReadLine());

                //criar os vetores de acordo com os termos

                //solicitar a função
                for (int parte = 0; parte < Qtd2; parte++)
                {
                    Console.Write($"\nInforme o {parte + 1}° termo da expressão: ");
                    Termos2[parte] = Console.ReadLine();

                    //verifica se tem que solicitar a operação
                    if (parte != Qtd2 - 1)
                    {
                        Console.Write($"\nDigite o {parte + 1} operador (+ - * /): ");
                        Operacoes2[parte] = Console.ReadLine();
                    }
                }

                Console.WriteLine();

                //exibindo a função
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
                        Console.Write($"{Termos2[parte]} {Operacoes2[parte]} ");
                    else
                        Console.Write($"{Termos2[parte]}\n\n");
                }
            }
   
            Console.WriteLine("\nDigite o valor de X: ");
            valorX = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\n=================================");

            //calcular a expressão

            XDireita[0] = valorX;
            XDireita[1] = (double)(valorX + 0.5);
            XDireita[2] = (double)(valorX + 0.1);
            XDireita[3] = (double)(valorX + 0.01);
            XDireita[4] = (double)(valorX + 0.001);
            XDireita[5] = (double)(valorX + 0.0001);
            XDireita[6] = (double)(valorX + 0.00001);

            XEsquerda[0] = valorX;
            XEsquerda[1] = (double)(valorX - 0.5);
            XEsquerda[2] = (double)(valorX - 0.1);
            XEsquerda[3] = (double)(valorX - 0.01);
            XEsquerda[4] = (double)(valorX - 0.001);
            XEsquerda[5] = (double)(valorX - 0.0001);
            XEsquerda[6] = (double)(valorX - 0.00001);

            for (int D = 0; D <= 6; D++) // calculo da direita
            {
                for (int parte = 0; parte < Qtd; parte++)
                {
                    resultadosD[parte] = Termonologia(XDireita[D], Termo[parte]);
                    
                    if (Sub == 'Y') // expressão para dividir 
                    {
                        resultadosD2[parte] = Termonologia(XDireita[D], Termos2[parte]);

                    }

                }

                for (int l = 0; l < Qtd - 1; l++)
                {
                    RDireita[D] = Kickassia(Opera[l], resultadosD[l], resultadosD[l + 1], RDireita[D]);

                    if (Sub == 'Y') // expressão para dividir 
                    {
                        RDireita2 = Kickassia(Operacoes2[l], resultadosD2[l], resultadosD2[l + 1], RDireita[D]);

                    }

                    RDireita[D] = RDireita[D] / RDireita2;
                }

            }

            for (int E = 0; E <= 6; E++) // calculo da esquerda
            {
                for (int parte = 0; parte < Qtd; parte++)
                {
                    resultadosE[parte] = Termonologia(XEsquerda[E], Termo[parte]);

                    if (Sub == 'Y') // expressão para dividir 
                    {
                        resultadosE2[parte] = Termonologia(XEsquerda[E], Termos2[parte]);

                    }

                }

                for (int l = 0; l < Qtd - 1; l++)
                {
                    REsquerda[E] = Kickassia(Opera[l], resultadosE[l], resultadosE[l + 1], REsquerda[E]);

                    if (Sub == 'Y') // expressão para dividir 
                    {
                        REsquerda[E] = REsquerda[E] / Kickassia(Operacoes2[l], resultadosE2[l], resultadosE2[l + 1], REsquerda[E]);
                    }

                    REsquerda[E] = REsquerda[E] / REsquerda2;

                }

            }

            
            Console.WriteLine("\nCalculo da direita");

            for (int Dshow = 0; Dshow <= 6; Dshow++) // calculo da direita
            {
                Console.WriteLine($"\n{XDireita[Dshow]} = {RDireita[Dshow]}");
                Console.WriteLine("\n=================================");

            }

            Console.WriteLine("\nCalculo da esquerda");

            for (int Eshow = 0; Eshow <= 6; Eshow++) // calculo da direita
            {
                Console.WriteLine($"\n{XEsquerda[Eshow]} = {REsquerda[Eshow]}");                
                Console.WriteLine("\n=================================");

            }

            Console.ReadKey();


            if (Math.Round(REsquerda[6], MidpointRounding.AwayFromZero) == Math.Round(RDireita[6], MidpointRounding.AwayFromZero) || 
                Math.Round(REsquerda[6], 4, MidpointRounding.AwayFromZero) == Math.Round(RDireita[6], 4, MidpointRounding.AwayFromZero)) // compara para ver se os resultados sao iguais
            {
                Console.WriteLine($"\n\nLimites são iguais, equivalentes a {Math.Round(REsquerda[6],MidpointRounding.AwayFromZero)} ");
            }
            else
            {
                Console.WriteLine($"\n\nLimites são diferentes, equivalentes a: D: {Math.Round(RDireita[6], 4, MidpointRounding.AwayFromZero)} E: {Math.Round(REsquerda[6], 4, MidpointRounding.AwayFromZero)} ");
            }

            Console.ReadKey();

        }

        static private double Termonologia(double valorX, String expressao)
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
                String[] separado = expressao.ToUpper().Split('X');

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

        static private double Kickassia(String Op, double Res, double Res1, double Prevs) //somadora dos resultados
        {
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
