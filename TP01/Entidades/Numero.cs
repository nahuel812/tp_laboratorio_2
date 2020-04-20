using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double _numero;

        //constructores
        public Numero():this(0){ }
        public Numero(double numero): this(numero.ToString()){ }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }
        
        public string SetNumero
        {
            set
            {
                this._numero = ValidarNumero(value);
            }
        }

        private double ValidarNumero(string strNumero)
        {
            double numeroValidado;

            if(!double.TryParse(strNumero,out numeroValidado))
            {
                numeroValidado = 0;
            }
            return numeroValidado;
        }

        
        public static string DecimalBinario(string strNumero)
        {
            string retorno = "Numero invalido";
            if (int.TryParse(strNumero, out int numEntero))
            {
                retorno = Convert.ToString(numEntero, 2);
            }
            return retorno;
            
        }
        public static string DecimalBinario(double numeroDouble)
        {
            long numEntero = Convert.ToInt64(numeroDouble);
            string numBinario = Convert.ToString(numEntero, 2);
            return numBinario;
        }

        
        public static string BinarioDecimal(string binario)
        {
            bool valido = false;
            foreach (char i in binario)
            {
                if(i == '0' || i == '1')
                {
                    valido = true;
                }
                else
                {
                    valido = false;
                    break;
                }
            }

            if(valido)
            {
                binario = Convert.ToInt32(binario, 2).ToString();
            }
            else
            {
                binario = "Numero invalido";
            }
            return binario;
        }
        
        //sobrecarga de operadores
        public static double operator +(Numero n1,Numero n2)
        {
            return n1._numero + n2._numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1._numero - n2._numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1._numero * n2._numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            return n1._numero / n2._numero;
        }
        
    }
}
