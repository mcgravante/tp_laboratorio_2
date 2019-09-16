using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        private string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        public static string BinarioDecimal(string binario)
        {
            bool esValido = true;
            foreach (char ch in binario)
            {
                string aux = ch.ToString();
                if (!aux.Equals("0") && !aux.Equals("1"))
                {
                    esValido = false;
                    break;
                }
            }
            if (esValido)
            {
                double ret = 0;
                int pos = 0;
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    ret += Math.Pow(2, pos) * int.Parse(binario[i].ToString());
                    pos++;
                }
                return ret.ToString();
            }
            return "Valor Inválido";
        }

        public static string DecimalBinario(double numero)
        {
            string auxiliar = "";
            string strRet = "";
            int intNumero = (int)numero;
            while (intNumero != 0)
            {
                strRet += (intNumero % 2).ToString();
                intNumero = intNumero / 2;

            }
            for (int i = strRet.Length - 1; i >= 0; i--)
            {
                auxiliar += strRet[i];
            }
            return auxiliar;
        }

        public static string DecimalBinario(string numero)
        {
            double auxiliar = 0;
            if (double.TryParse(numero, out auxiliar))
            {
                return DecimalBinario(auxiliar);
            }
            return "Valor Inválido";
        }

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double ret = double.MinValue;
            if (n2.numero != 0)
            {
                ret = n1.numero / n2.numero;
            }
            return ret;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        private double ValidarNumero(string strNumero)
        {
            double ret = 0;
            double.TryParse(strNumero, out ret);
            return ret;
        }
    }
}
