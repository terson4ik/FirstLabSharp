using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinomial
{
     public interface IPolynomial
    {
       Element[] Elements { get; }
        IPolynomial Add(IPolynomial secondPolynomial);
        IPolynomial Subtraction(IPolynomial secondPolynomial);
        IPolynomial MultiplyByNumber(double num);
        IPolynomial AddNumber(double num);
        double CalculateValue(double value);
        IPolynomial FindDerivative();
        int GetHashCode();
    }
}
