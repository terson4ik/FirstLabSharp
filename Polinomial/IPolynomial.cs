using System;

namespace Polinomial
{
     public interface IPolynomial
    {
       Element[] Elements { get; }
        IPolynomial Add(IPolynomial secondPolynomial);
        IPolynomial Subtract(IPolynomial secondPolynomial);
        IPolynomial MultiplyByNumber(double num);
        IPolynomial AddNumber(double num);
        double CalculateValue(double value);
        IPolynomial FindDerivative();
    }
}
