using System;
using System.Data.Odbc;
using System.Text;

namespace Polinomial
{
    public struct Element
    {
        public double Coefficient;
        public int Degree;
    }
    public class Polynomial : IPolynomial
    {
        public Element[] Elements { get; }
        
        public Polynomial()
        {
            throw new NotImplementedException();
        }
        public Polynomial(double[] coefficients)
        {
            throw new NotImplementedException();
        }
        public Polynomial(double[,] pairs) //expected [degree, coef.]
        {
            throw new NotImplementedException();
        }

        public Polynomial(Polynomial other)
        {
            throw new NotImplementedException();
        }
        public IPolynomial Add(IPolynomial secondPolynomial)
        {
            throw new NotImplementedException();
        }
        public IPolynomial Subtract(IPolynomial secondPolynomial)
        {
            throw new NotImplementedException();
        }
        
        public IPolynomial MultiplyByNumber(double num)
        {
            throw new NotImplementedException();
        }
        public IPolynomial AddNumber(double num)
        {
            throw new NotImplementedException();
        }

        public double CalculateValue(double value)
        {
            throw new NotImplementedException();
        }

        public IPolynomial FindDerivative()
        {
            throw new NotImplementedException();
        }


        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}