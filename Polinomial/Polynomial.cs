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

        private void SortDegrees(Element[] elements) // sort for CORRECT degrees
        {
            for (int i = 0; i < elements.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (elements[min].Degree > elements[j].Degree)
                        min = j;
                }
                if (i == min) continue; //nothing to do
                Element temp = elements[i];
                elements[i] = elements[min];
                elements[min] = temp;
            }
        }

        private void CopyDoubleArr(double[,] source, double[,] target)
        {
            for (int i = 0; i < source.GetLength(0); i++)
            { // This was done so as not to spoil the original
                for (int j = 0; j < source.GetLength(1); j++)
                {
                    target[i, j] = source[i, j];
                }
            }
        }

        private void FilterDublicatesDegreesDoubleArr(double[,] source)
        {
            for (int i = 0; i < source.GetLength(0); i++) 
            {// Filter dublicate degrees
                int tmpDegree = Convert.ToInt32(source[i, 0]);
                for (int j = i + 1; j < source.GetLength(0); j++)
                {
                    int find = Convert.ToInt32(source[j, 0]);
                    if (tmpDegree == find)
                    {
                        source[i, 1] += source[j, 1];
                        source[j, 1] = 0; // Reset the repetion
                    }
                }
            }

        }

        public Polynomial(double[,] pairs) //expected [degree, coef.]
        {
            if (pairs == null) throw new ArgumentNullException(nameof(pairs));
            double[,] TemporaryArr = new double[pairs.GetLength(0), pairs.GetLength(1)];
            CopyDoubleArr(pairs, TemporaryArr);// Copy pairs into temp
            FilterDublicatesDegreesDoubleArr(TemporaryArr);
            int rows = TemporaryArr.GetLength(0); // Used for cycles
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
            for (int i = 0; i < rows; i++) // Fill in the final struct
            {
                int degree = Convert.ToInt32(TemporaryArr[i, 0]);
                double coeff = TemporaryArr[i, 1];
                if (coeff == 0.0) continue;
                elements[index].Degree = degree;
                elements[index].Coefficient = coeff;
                index++;
            }
            SortDegrees(elements); // sort for CORRECT degrees
        }

        public Polynomial(Polynomial other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            elements = new Element[other.elements.Length];
            for (int i = 0; i < other.elements.Length; i++)
            {
                elements[i] = other.elements[i];
            }
        }
        private double GetCoefByDegree(Element[] elements, int degree)
        {
            int left = 0;
            int rigth = elements.Length - 1;
            int med;
            while (left <= rigth)
            {
                med = (left + rigth) / 2;
                if (elements[med].Degree == degree)
                {
                    return elements[med].Coefficient;
                }
                else if (degree < elements[med].Degree)
                {
                    left = med + 1;
                }
                else
                {
                    rigth = med - 1;
                }
            }
            return 0.0;
        }
        private Polynomial ArithmeticWithPolynoms(Polynomial SecondPolynomial, char operation)
        {
            int maxLen = this.elements.Length + SecondPolynomial.elements.Length;
            Element[] tmp = new Element[maxLen];
            int count = 0;
            for (int i = 0; i < this.elements.Length; i++)
            {
                tmp[count] = this.elements[i];
                count++;
            }
            for (int i = 0; i < SecondPolynomial.elements.Length; i++)
            {
                int degree = SecondPolynomial.elements[i].Degree;
                double coeff = SecondPolynomial.elements[i].Coefficient;
                bool found = false;
                for (int j = 0; j < count; j++)
                {
                    if (tmp[j].Degree == degree)
                    {
                        if (operation == '+')
                        {
                            tmp[j].Coefficient += coeff;
                        }
                        else if (operation == '-')
                        {
                            tmp[j].Coefficient -= coeff;

                        }
                            found = true;
                        break;
                    }
                }
                if (!found)
                {
                    tmp[count].Degree = degree;
                    tmp[count].Coefficient = coeff;
                    count++;
                }
            }
            int nonZeroCount = 0;
            for (int i = 0; i < count; i++)
            {
                if(tmp[i].Coefficient != 0.0)
                {
                    nonZeroCount++;
                }
            }
            double[,] pairs = new double[nonZeroCount,2];
            int index = 0;
            for (int i = 0; i < count; i++)
            {
                if (tmp[i].Coefficient != 0.0)
                {
                    pairs[index, 0] = tmp[i].Degree;
                    pairs[index, 1] = tmp[i].Coefficient;
                    index++;
                }
            }
            return new Polynomial(pairs);

        }
        public Polynomial Add(Polynomial SecondPolynomial)
        {
            if (SecondPolynomial == null) throw new ArgumentNullException(nameof(SecondPolynomial));
            return ArithmeticWithPolynoms(SecondPolynomial, '+');
        }
        public Polynomial Subtraction(Polynomial SecondPolynomial)
        {
            if (SecondPolynomial == null) throw new ArgumentNullException(nameof(SecondPolynomial));
            return ArithmeticWithPolynoms(SecondPolynomial, '-');
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