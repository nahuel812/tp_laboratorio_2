using System;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";
            if(operador == "+" || operador == "-" || operador == "/" || operador == "*" )
            {
                retorno = operador;
            }
            return retorno;
        }

        public static double Operar(Numero num1,Numero num2,string operador)
        {
            double resultado=0;
            string operadorValidado;

            operadorValidado = ValidarOperador(operador);
            switch (operadorValidado)
            {
                case "+":
                    resultado = num1 + num2;
                    break;

                case "-":
                    resultado = num1 - num2;
                    break;

                case "/":
                    resultado = num1 / num2;
                    if (double.IsInfinity(resultado))
                    {
                        resultado = double.MinValue;
                    }
                    break;

                case "*":
                    resultado = num1 * num2;
                    break;
            }
            return resultado; 
        }

    }
}
