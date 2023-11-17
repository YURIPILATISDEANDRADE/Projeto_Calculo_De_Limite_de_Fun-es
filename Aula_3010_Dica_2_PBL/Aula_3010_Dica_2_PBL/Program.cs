using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_3010_Dica_2_PBL
{
    class Program
    {
        /*
         * separar uma função em dois vetores
         * vetor de termos 
         * vetor de operaçõe
         */ 
        static void Main(string[] args)
        {
            int qtdtermos, qtdtermos2;
            char Sub = 'A';

            Console.Write("Quantos termos? ");
            qtdtermos = int.Parse(Console.ReadLine());

            //criar os vetores de acordo com os termos
            String[] termos = new string[qtdtermos];
            String[] operacoes = new string[qtdtermos - 1];
            double[] resultados = new double[qtdtermos];

            

            //solicitar a função
            for (int parte=0; parte < qtdtermos; parte++)
            {
                Console.Write($"Informe o {parte + 1} termo:");
                termos[parte] = Console.ReadLine();

                //verifica se tem que solicitar a operação
                if(parte != qtdtermos - 1)
                {
                    Console.Write($"Digite o {parte + 1} operador: ");
                    operacoes[parte] = Console.ReadLine();
                }
            }

            Console.WriteLine();

            //exibindo a função
            for (int parte = 0; parte < qtdtermos; parte++)
            {
                if (parte != qtdtermos - 1)
                    Console.Write($"{termos[parte]} {operacoes[parte]} ");
                else
                    Console.Write($"{termos[parte]}");
            }

            

            //vamos ver quanto vale o 'X'
            int valor = 0;
            Console.Write("\n\nDigite o valor de X: ");
            valor = Convert.ToInt32(Console.ReadLine());

            //vamos varrer cada Termo
            for (int parte = 0; parte < qtdtermos; parte++)
            {
                resultados[parte] = calculaTermo(valor, termos[parte]);
            }

            //exibindo a função calculada
            for (int parte = 0; parte < qtdtermos; parte++)
            {
                if (parte != qtdtermos - 1)
                    Console.Write($"{resultados[parte]} {operacoes[parte]} ");
                else
                    Console.Write($"{resultados[parte]}");
            }


            double resultado = 0;

            for (int l = 0; l < qtdtermos - 1; l++)
            {
                resultado = Kickassia(operacoes[l], resultados[l], resultados[l + 1], resultado);
            }

            Console.Write($"\n\n{resultado} ");


            Console.Write($"\n Voce desejaria Insirir uma expressão para dividir a anterior? Y/N");
            Sub = Console.ReadLine().ToUpper()[0];


            if (Sub == 'Y') // expressão para dividir 
            {
                Console.Write("Quantos termos? ");
                qtdtermos2 = int.Parse(Console.ReadLine());

                //criar os vetores de acordo com os termos
                String[] Termos2 = new string[qtdtermos2];
                String[] Operacoes2 = new string[qtdtermos2 - 1];
                double[] Resultados2 = new double[qtdtermos2];



                //solicitar a função
                for (int parte = 0; parte < qtdtermos2; parte++)
                {
                    Console.Write($"Informe o {parte + 1} termo:");
                    Termos2[parte] = Console.ReadLine();

                    //verifica se tem que solicitar a operação
                    if (parte != qtdtermos2 - 1)
                    {
                        Console.Write($"Digite o {parte + 1} operador: ");
                        Operacoes2[parte] = Console.ReadLine();
                    }
                }

                Console.WriteLine();

                //exibindo a função
                for (int parte = 0; parte < qtdtermos; parte++)
                {
                    if (parte != qtdtermos - 1)
                        Console.Write($"{termos[parte]} {operacoes[parte]} ");
                    else
                        Console.Write($"{termos[parte]}");
                }

                for (int parte = 0; parte < qtdtermos2; parte++)
                {
                    if (parte != qtdtermos2 - 1)
                        Console.Write($"{Termos2[parte]} {Operacoes2[parte]} ");
                    else
                        Console.Write($"{Termos2[parte]}");
                }

                Console.Write($"\n================ ");

                for (int parte = 0; parte < qtdtermos2; parte++)
                {
                    Resultados2[parte] = calculaTermo(valor, Termos2[parte]);
                }

                //exibindo a função calculada
                for (int parte = 0; parte < qtdtermos2; parte++)
                {
                    if (parte != qtdtermos2 - 1)
                        Console.Write($"{Resultados2[parte]} {Operacoes2[parte]} ");
                    else
                        Console.Write($"{Resultados2[parte]}");
                }


                double resultado2 = 0;

                for (int l = 0; l < qtdtermos2 - 1; l++)
                {
                    resultado2 = Kickassia(Operacoes2[l], Resultados2[l], Resultados2[l + 1], resultado2);
                }

                resultado = resultado / resultado2;

            }
            
            
            Console.Write($"\n\n{resultado} ");

            Console.ReadKey();
        }
        
        static private double calculaTermo(int valorX, String expressao)
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

        static private double Kickassia(String Op, double Res, double Res1, double Prevs) //calculadora
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
