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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorFromNULLOneDimensionalArray()
        {
            // Arrange
            double[] coeff = null;
            Polynomial p = new Polynomial(coeff);
        }

        //5
        [TestMethod()]
        public void ConstructorFromTwoDimensionalArrayWithoutNulls()
        {
         
        }

        //6
        [TestMethod()]
        public void ConstructorFromTwoDimensionalArrayWithNulls()
        {
            // Arrange
       
        }

        //7
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorFromNULLTwoDimensionalArray()
        {
          
        }
       












        [TestMethod()]
        public void EqualsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }
    }
}