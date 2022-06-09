using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyect1_Calc
{
    internal class CCalculate
    {
        public static double Sum(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Rest(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Mult(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Div(double n1, double n2)
        {
            if(n2 == 0)
            {
                MessageBox.Show(
                    "No se puede dividir entre cero", 
                    "Operacion incorrecta", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning);
                return 0;
            }
            return n1 / n2;
        }
        public static double Cuadratic(double n1)
        {
            return n1 * n1;
        }
        public static double Sqr(double n1)
        {
            return Math.Sqrt(n1);
        }

    }
}
