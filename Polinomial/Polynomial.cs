using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinomial
{
    public struct Element
    {
        double Coefficient;
        int Deegree;
    }
    internal class Polynomial : IPolynomial
    {
        private Element[] elements;
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            throw new NotImplementedException();
        }
        Polynomial IPolynomial.Add(Polynomial secondPolynomial)
        {
            throw new NotImplementedException();
        }

        Polynomial IPolynomial.AddNumber(double num)
        {
            throw new NotImplementedException();
        }

        double IPolynomial.CalculateValue(double value)
        {
            throw new NotImplementedException();
        }

        double IPolynomial.FindDerivative()
        {
            throw new NotImplementedException();
        }

        Polynomial IPolynomial.MultiplyByNumber(double num)
        {
            throw new NotImplementedException();
        }

        Polynomial IPolynomial.Subtraction(Polynomial secondPolynomial)
        {
            throw new NotImplementedException();
        }
    }
}
