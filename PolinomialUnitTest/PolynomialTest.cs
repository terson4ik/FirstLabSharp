using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Polinomial;

namespace PolinomialTests
{
    [TestClass()]
    public class PolynomialTests
    {
        //1
        [TestMethod()]
        public void ConstructorDefaultCreatesEmptyPolynomial()
        {
            // Arrange and act
            Polynomial p = new Polynomial();
            // Assert
            Assert.AreEqual(0, p.Elements.Length, "Polynomial expected will empty");
        }

        //2
        [TestMethod()]
        public void ConstructorFromOneDimensionalArrayWithoutNulls()
        {
            // Arrange 
            double[] coeffs = new double[] { 3, -1, 0, 5 }; // 3 - x + 5x^3

            // Act
            Polynomial p = new Polynomial(coeffs);
            
            //Assert
            Assert.AreEqual(3, p.Elements.Length);
            Assert.AreEqual(3, p.Elements[0].Coefficient);
            Assert.AreEqual(0, p.Elements[0].Degree);
            Assert.AreEqual(-1, p.Elements[1].Coefficient);
            Assert.AreEqual(1, p.Elements[1].Degree);
            Assert.AreEqual(5, p.Elements[2].Coefficient);
            Assert.AreEqual(3, p.Elements[2].Degree);
        }

        //3
        [TestMethod()]
        public void ConstructorFromOneDimensionalArrayWithNulls()
        {
            // Arrange
            double[] coeff = new double[0];
            Polynomial p = new Polynomial(coeff);
            Assert.AreEqual(0, p.Elements.Length);
        }

        //4
        [TestMethod()]
        public void ConstructorFromNULLOneDimensionalArray()
        {
            // Arrange
            double[] coeff = null;
            Assert.ThrowsException<ArgumentNullException>(() => new Polynomial(coeff));
        }

        //5
        [TestMethod()]
        public void ConstructorFromTwoDimensionalArrayWithoutNulls()
        {
            double[,] coeff = new double[,] { { 2, 5 }, { 0, -1 } };
            Polynomial p = new Polynomial(coeff); //expected [degree, coef.]
            Assert.AreEqual(5, p.Elements[0].Coefficient);
            Assert.AreEqual(-1, p.Elements[1].Coefficient);
            Assert.AreEqual(2, p.Elements[0].Degree);
            Assert.AreEqual(0, p.Elements[1].Degree);
        }
        //5
        [TestMethod()]
        public void ConstructorFromTwoDimensionalArrayWithSameDegrees()
        {
            double[,] coeff = new double[,] { { 2, 5 }, { 2, 5 }, { 2, 5 }, { 2, 5 } };
            Polynomial p = new Polynomial(coeff); //expected [degree, coef.]
            Assert.AreEqual(20, p.Elements[0].Coefficient);
            Assert.AreEqual(2, p.Elements[0].Degree);
            Assert.AreEqual(1, p.Elements.Length);
        }

        //6
        [TestMethod()]
        public void ConstructorFromTwoDimensionalArrayWithNulls()
        {
            double[,] coeff = new double[0, 0];
            Polynomial p = new Polynomial(coeff);
            Assert.AreEqual(0, p.Elements.Length);                
        }

        //7
        [TestMethod()]
        public void ConstructorFromNULLTwoDimensionalArray()
        {
            double[,] coeff = null;
            Assert.ThrowsException<ArgumentNullException>(() => new Polynomial(coeff));
        }

        //8
        [TestMethod()]
        public void ConstructorFromTwoDimensionalArrayWithNotWholeFraction()
        {
            double[,] coeff = new double[,] { { 2.7, 5 }, { 2.3, 10 } }; //expected [degree, coef.]
            Polynomial p = new Polynomial(coeff);
            Assert.AreEqual(3, p.Elements[0].Degree);
            Assert.AreEqual(5, p.Elements[0].Coefficient);
            Assert.AreEqual(2, p.Elements[1].Degree);
            Assert.AreEqual(10, p.Elements[1].Coefficient);
        }

        //9
        [TestMethod()]
        public void AddPositiveTest()
        {
        }
        [TestMethod()]
        public void AddNegativeTest()
        {
        }
        //9
        public void AddEmptyPolynomsTest()
        {
        }
        //10
        [TestMethod()]
        public void AddNullTest()
        {
        }

        //11
        [TestMethod()]
        public void SubtractionPositiveTest()
        {
        }
        public void SubtractionNegativeTest()
        {
        }
        //11
        [TestMethod()]
        public void SubtractionDifferntDegreeTest()
        {
        }
        //12
        [TestMethod()]
        public void SubstractionSameTest()
        {
        }

        //13
        [TestMethod()]
        public void MultiplyByNumberDefoltTest ()
        {
        }

        //14
        [TestMethod()]
        public void MultiplyByZeroNumberTest()
        {
        }
        //15
        [TestMethod()]
        public void AddNumberWithoutFreeMemberTest()
        {
        }
        //16
        [TestMethod()]
        public void AddNumberWithFreeMemberTest()
        {
        }

        //17
        [TestMethod()]
        public void CalculateValueDefoultTest()
        {
        }

        //18
        [TestMethod()]
        public void CalculateValueWithZeroTest()
        {
        }
        //19
        [TestMethod()]
        public void FindDerivativeDefoultTest()
        {
        }

        //19
        [TestMethod()]
        public void FindDerivativeConstTest()
        {
        }

        [TestMethod()]
        public void EqualsSamePolynomsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EqualsDifferentsPolynomsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EqualsNullTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void EqualsAnotherTypeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetHashCodeSameTest()
        {
            Assert.Fail();
        }
        public void GetHashCodeDifferentTest()
        {
            Assert.Fail();
        }
        public void GetHashCodeAnotherTypeTest()
        {
            Assert.Fail();
        }
    }
}