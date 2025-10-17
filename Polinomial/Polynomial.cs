using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Polinomial
{
    public struct Element
    {
        public double Coefficient;
        public int Degree;
    }
    public class Polynomial : IPolynomial
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
                
                if (coefficients[i] != 0.0)
                {
                    elements[index].Coefficient = coefficients[i];
                    elements[index].Degree = i;
                    index++;
                }
            }
        }
        public Polynomial(double[,] pairs) //expected [degree, coef.]
        {
            if (pairs == null) throw new ArgumentNullException(nameof(pairs));
            double[,] TemporaryArr = new double[pairs.GetLength(0), pairs.GetLength(1)];
            for (int i = 0; i < pairs.GetLength(0); i++) // Copy all elements pairs into temp
            { // This was done so as not to spoil the original
                for (int j = 0; j < pairs.GetLength(1); j++)
                {
                    TemporaryArr[i, j] = pairs[i, j];
                }
            }
            int rows = TemporaryArr.GetLength(0); // Used for cycles
            for (int i = 0; i < rows; i++) // Filter dublicate degrees
            {
                int tmpDegree = Convert.ToInt32(TemporaryArr[i, 0]);
                for (int j = i + 1; j < rows; j++)
                {
                    int find = Convert.ToInt32(TemporaryArr[j, 0]);
                    if (tmpDegree == find)
                    {
                        TemporaryArr[i, 1] += TemporaryArr[j, 1];
                        TemporaryArr[j, 1] = 0; // Reset the repetion
                    }
                }
            }
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                if (TemporaryArr[i, 1] != 0.0) // Check coef. of array
                    count++;
            }
            if (count == 0) // Case of empty array = exit
            {
                elements = new Element[0];
                return;
            }
            elements = new Element[count];
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                int degree = Convert.ToInt32(TemporaryArr[i, 0]);
                double coeff = TemporaryArr[i, 1];
                if (coeff == 0.0) continue;
                elements[index].Degree = degree;
                elements[index].Coefficient = coeff;
                index++;
            }

            for (int i = 0; i < elements.Length; i++)
            { // sort for CORRECT degrees
                int min = i;
                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (elements[min].Degree < elements[j].Degree)
                        min = j;
                }
                if (i == min) continue; //nothing to do
                Element temp = elements[i];
                elements[i] = elements[min];
                elements[min] = temp;
                
            }
        }
        
        private double GetCoefByDegree(int degree)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i].Degree == degree)
                {
                    return elements[i].Coefficient;
                }
            }
            return 0.0;
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
