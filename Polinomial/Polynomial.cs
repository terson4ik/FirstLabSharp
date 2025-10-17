using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Polinomial
{
    public struct Element
    {
        public double Coefficient;
        public int Degree;
    }
    internal class Polynomial : IPolynomial
    {
        private readonly Element[] elements;
        public Element[] Elements => elements;
        
        public Polynomial()
        {
            elements = new Element[0];
        }
        public Polynomial(double[] coefficients)
        {
            if (coefficients == null) throw new ArgumentNullException(nameof(coefficients));
            int count = 0;
            for (int i = 0; i < coefficients.Length; i++)
            {
                if (coefficients[i] != 0.0)
                    count++;
            }
            elements = new Element[count];
            int index = 0;
            for (int i = 0; i < coefficients.Length; i++)
            {
                double c = coefficients[i];
                if (c != 0.0)
                {
                    elements[index].Coefficient = c;
                    elements[index].Degree = i;
                    index++;
                }
            }
        }
        public Polynomial(double[,] pairs) //expected [degree, coef.]
        {
            if (pairs == null) throw new ArgumentNullException(nameof(pairs));
            int rows = pairs.GetLength(0);
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                double coeff = pairs[i, 1];
                if (coeff != 0.0)
                    count++;
            }
            if (count == 0)
            {
                elements = new Element[0];
                return;
            }
            elements = new Element[count];
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                int degree = Convert.ToInt32(pairs[i, 0]);
                double coeff = pairs[i, 1];
                if (coeff == 0.0) continue;

                elements[index].Degree = degree;
                elements[index].Coefficient = coeff;
                index++;
            }

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
    }
}
