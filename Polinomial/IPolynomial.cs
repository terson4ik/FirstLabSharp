using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinomial
{
    internal interface IPolynomial
    {
       Element[] Elements { get; }
        Polynomial Add(Polynomial secondPolynomial);
        Polynomial Subtraction(Polynomial secondPolynomial);
        Polynomial MultiplyByNumber(double num);
        Polynomial AddNumber(double num);
        double CalculateValue(double value);
        double FindDerivative();

    }
}
