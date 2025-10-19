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
                (elements[min], elements[i]) = (elements[i], elements[min]);
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
        private IPolynomial ArithmeticWithPolynoms(Polynomial secondPolynomial, char operation)
        {
            int maxLen = this.elements.Length + secondPolynomial.elements.Length;
            Element[] tmp = new Element[maxLen];
            int count = 0;
            for (int i = 0; i < this.elements.Length; i++)
            {
                tmp[count] = this.elements[i];
                count++;
            }
            for (int i = 0; i < secondPolynomial.elements.Length; i++)
            {
                int degree = secondPolynomial.elements[i].Degree;
                double coeff = secondPolynomial.elements[i].Coefficient;
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
        public IPolynomial Add(IPolynomial secondPolynomial)
        {
            Polynomial poly = secondPolynomial as Polynomial;
            if (poly == null) throw new ArgumentNullException(nameof(secondPolynomial));
            return ArithmeticWithPolynoms(poly, '+');
        }
        public IPolynomial Subtract(IPolynomial secondPolynomial)
        {
            Polynomial poly = secondPolynomial as Polynomial;
            if (poly == null) throw new ArgumentNullException(nameof(secondPolynomial));
            return ArithmeticWithPolynoms(poly, '-');
        }
        
        public IPolynomial MultiplyByNumber(double num)
        {
            if (num == 0.0) return new Polynomial();

            Element[] newElements = new Element[elements.Length];
            int count = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                double newCoef = elements[i].Coefficient * num;
                if (newCoef != 0.0)
                {
                    newElements[count].Coefficient = newCoef;
                    newElements[count].Degree = elements[i].Degree;
                    count++;
                }
            }
            double[,] pairs = new double[count, 2];
            for (int i = 0; i < count; i++)
            {
                pairs[i, 0] = newElements[i].Degree;
                pairs[i, 1] = newElements[i].Coefficient;
            }
            return new Polynomial(pairs);
        }
    private double GetCoefByDegree(Element[] elements, int degree)
        {
            int left = 0;
            int right = elements.Length - 1;
            int med;
            while (left <= right)
            {
                med = (left + right) / 2;
                if (elements[med].Degree == degree)
                {
                    return elements[med].Coefficient;
                }
                else if (degree < elements[med].Degree)
                {
                    right = med - 1;
                }
                else
                {
                    left = med + 1;
                }
            }
            return 0.0;
        }
        public IPolynomial AddNumber(double num)
        {
           if (num == 0.0) return new Polynomial(this);

            double zeroDegreeCoef = GetCoefByDegree(elements, 0);
            bool foundZeroDegree = (zeroDegreeCoef != 0.0);

            Element[] newElements = new Element[elements.Length];
            for (int i = 0; i < elements.Length; i++)
            {
                newElements[i] = elements[i];
                if (elements[i].Degree == 0)
                {
                    newElements[i].Coefficient += num;
                }
            }

            if (!foundZeroDegree)
            {
                Element[] extended = new Element[newElements.Length + 1];
                for (int i = 0; i < newElements.Length; i++)
                {
                    extended[i] = newElements[i];
                }
                extended[newElements.Length].Degree = 0;
                extended[newElements.Length].Coefficient = num;
                newElements = extended;
            }
            double[,] pairs = new double[newElements.Length, 2];
            for (int i = 0; i < newElements.Length; i++)
            {
                pairs[i, 0] = newElements[i].Degree;
                pairs[i, 1] = newElements[i].Coefficient;
            }
            return new Polynomial(pairs);
        }

        public double CalculateValue(double value)
        {
            if (elements.Length == 0) return 0.0;
            if (value == 0.0) return GetCoefByDegree(elements,0);

            double res = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                res += elements[i].Coefficient * Math.Pow(value, elements[i].Degree);
            }
            return res;
        }

        public IPolynomial FindDerivative()
        {
            if (elements.Length == 0) return new Polynomial();

            Element[] deriv = new Element[elements.Length];
            int count = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i].Degree == 0) continue;
                deriv[count].Degree = elements[i].Degree - 1;
                deriv[count].Coefficient = elements[i].Coefficient * elements[i].Degree;
                count++;
            }
            if (count == 0) return new Polynomial();

            double[,] pairs = new double[count, 2];
            for (int i = 0; i < count; i++)
            {
                pairs[i, 0] = deriv[i].Degree;
                pairs[i, 1] = deriv[i].Coefficient;
            }
            return new Polynomial(pairs);
        }


        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Polynomial)) return false;
            Polynomial other = (Polynomial)obj;
            if (this.elements.Length != other.elements.Length) return false;
            for (int i = 0; i < elements.Length; i++)
            {
                int degree = this.elements[i].Degree;
                double thisCoef = GetCoefByDegree(this.elements, degree);
                double otherCoef = GetCoefByDegree(other.elements, degree);

                if (thisCoef != otherCoef)
                {
                    return false;
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            int hash = -1246362126;
            for (int i = 0; i < elements.Length; i++)
            {
                hash = hash * -1521134295 + elements[i].Coefficient.GetHashCode();
                hash = hash * -1521134295 + elements[i].Degree.GetHashCode();
            }
            return hash;
        }

        public override string ToString()
        {
            if (elements.Length == 0) return "0";
            string result = "";
            for (int i = 0; i < elements.Length; i++)
            {
                double coef = elements[i].Coefficient;
                int degr = elements[i].Degree;
                if (coef == 0.0) continue;

                if (result == "")
                {
                    if (coef < 0)
                        result += "-";
                }
                else
                {
                    result += coef > 0 ? " + " : " - ";
                }
                if (coef == 1.0 || coef == -1.0)
                {
                    if (degr == 0)
                        result += "1";
                }
                else
                    result += coef > 0 ? coef : -coef;
                if (degr > 0)
                {
                    result += "x";
                    if (degr > 1)
                        result += "^" + degr;
                }
            }
            return result;
        }
        }
    }