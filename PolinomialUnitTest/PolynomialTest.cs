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
            // Arrange
            const int TARGET_LENGTH = 0;

            // Act
            Polynomial p = new Polynomial();

            // Assert
            Assert.AreEqual(TARGET_LENGTH, p.Elements.Length, "Polynomial expected will empty");
        }

        //2
        [TestMethod()]
        public void ConstructorFromOneDimensionalArrayWithoutNulls()
        {
            // Arrange 
            const int FIRST_COEF = 3;
            const int SECOND_COEF = -1;
            const int THIRD_COEF = 0;
            const int FOURTH_COEF = 5;
            const int FIRST_DEGR = 0;
            const int SECOND_DEGR = 1;
            // THIRD_DEGR is not need: in correct polyn. his don`t be
            const int FOURTH_DEGR = 3;
            const int TARGET_LENGTH = 3;

            // Act
            double[] coeffs = new double[] {FIRST_COEF, SECOND_COEF, THIRD_COEF, FOURTH_COEF}; // 3 - x + 5x^3
            Polynomial p = new Polynomial(coeffs);
            
            //Assert
            Assert.AreEqual(TARGET_LENGTH, p.Elements.Length);
            Assert.AreEqual(FIRST_COEF, p.Elements.Length);
            Assert.AreEqual(FIRST_DEGR, p.Elements[0].Degree);
            Assert.AreEqual(SECOND_COEF, p.Elements[1].Coefficient);
            Assert.AreEqual(SECOND_DEGR, p.Elements[1].Degree);
            Assert.AreEqual(FOURTH_COEF, p.Elements[2].Coefficient);
            Assert.AreEqual(FOURTH_DEGR, p.Elements[2].Degree);
        }

        //3
        [TestMethod()]
        public void ConstructorFromOneDimensionalArrayWithNulls()
        {
            // Arrange
            const int NILL = 0;
            const int TARGET_LENGTH = 0;

            // Act
            double[] coeff = new double[NILL];
            Polynomial p = new Polynomial(coeff);

            //Assert
            Assert.AreEqual(TARGET_LENGTH, p.Elements.Length);
        }

        //4
        [TestMethod()]
        public void ConstructorFromNULLOneDimensionalArray()
        {
            // Arrange
            double[] coeff = null;

            // Act & Assert 
            Assert.ThrowsException<ArgumentNullException>(() => new Polynomial(coeff));
        } 
        
        [TestMethod()]
        public void ConstructorFromTwoDimensionalArrayWithoutNulls()
        {
            // Arrange 
            const int FIRST_COEF = 5;
            const int SECOND_COEF = -1;
            const int THIRD_COEF = -4;
            const int FIRST_DEGR = 2;
            const int SECOND_DEGR = 0;
            const int THIRD_DEGR = 0;
            const int TARGET_LENGTH = 2; // THIRD will be not used

            // Act
            double[,] coeff = new double[,] { { FIRST_DEGR, FIRST_COEF }, { SECOND_DEGR, SECOND_COEF }, {THIRD_DEGR, THIRD_COEF} };
            Polynomial p = new Polynomial(coeff); //expected [degree, coef.]

            // Assert
            Assert.AreEqual(TARGET_LENGTH, p.Elements.Length);
            Assert.AreEqual(FIRST_COEF, p.Elements[0].Coefficient);
            Assert.AreEqual(SECOND_COEF, p.Elements[1].Coefficient);
            Assert.AreEqual(FIRST_DEGR, p.Elements[0].Degree);
            Assert.AreEqual(SECOND_DEGR, p.Elements[1].Degree);
        }

        //6
        [TestMethod()]
        public void ConstructorFromTwoDimensionalArrayWithSameDegrees()
        {
            // Arrange 
            const int FIRST_COEF = 5;
            const int FIRST_DEGR = 2;
            const int COUNT = 4;
            const int TARGET_COEF = FIRST_COEF * COUNT;
            const int TARGET_DEGREE = 1;
            const int TARGET_LENGTH = 1;
            
            // Act
            double[,] coeff = new double[COUNT,2] { { FIRST_DEGR, FIRST_COEF }, { FIRST_DEGR, FIRST_COEF }, { FIRST_DEGR, FIRST_COEF }, { FIRST_DEGR, FIRST_COEF } };
            Polynomial p = new Polynomial(coeff); //expected [degree, coef.]
            
            // Assert
            Assert.AreEqual(TARGET_COEF, p.Elements[0].Coefficient);
            Assert.AreEqual(TARGET_DEGREE, p.Elements[0].Degree);
            Assert.AreEqual(TARGET_LENGTH, p.Elements.Length);
        }

        //7
        [TestMethod()]
        public void ConstructorFromTwoDimensionalArrayWithNulls()
        {
            // Arrange 
            const int NIL = 0;
            const int TARGET_LENGTH = 0;
            
            // Act
            double[,] coeff = new double[NIL, NIL];
            Polynomial p = new Polynomial(coeff);

            // Assert
            Assert.AreEqual(TARGET_LENGTH, p.Elements.Length);                
        }

        //8
        [TestMethod()]
        public void ConstructorFromNULLTwoDimensionalArray()
        {
            // Arrange 
            double[,] coeff = null;
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Polynomial(coeff));
        }

        //9
        [TestMethod()]
        public void ConstructorFromTwoDimensionalArrayWithNotWholeFraction()
        {
            // Arrange 
            const int FIRST_COEF = 5;
            const int SECOND_COEF = 10;
            const double FIRST_DEGR = 2.7;
            const double SECOND_DEGR = 2.3;
            const int TARGET_FIRST_DEGR = 3;
            const int TARGET_SECOND_DEGR = 2;
            const int TARGET_LENGTH = 2; // THIRD will be not used
            
            // Act
            //expected [degree, coef.]
            double[,] coeff = new double[,] { { FIRST_DEGR, FIRST_COEF }, { SECOND_DEGR, SECOND_COEF } }; 
            Polynomial p = new Polynomial(coeff);

            // Assert
            Assert.AreEqual(TARGET_FIRST_DEGR, p.Elements[0].Degree);
            Assert.AreEqual(FIRST_COEF, p.Elements[0].Coefficient);
            Assert.AreEqual(TARGET_SECOND_DEGR, p.Elements[1].Degree);
            Assert.AreEqual(SECOND_COEF, p.Elements[1].Coefficient);
            Assert.AreEqual(TARGET_LENGTH, p.Elements.Length);                
        }

        //10
        [TestMethod()]
        public void AddPositiveTest()
        {
        }
        [TestMethod()]
        public void AddNegativeTest()
        {
        }

        //11
        public void AddEmptyPolynomsTest()
        {
        }
        
        //12
        [TestMethod()]
        public void AddNullTest()
        {
        }

        //13
        [TestMethod()]
        public void SubtractionPositiveTest()
        {
        }

        //14
        [TestMethod()]
        public void SubtractionNegativeTest()
        {
        }

        //15
        [TestMethod()]
        public void SubtractionDifferntDegreeTest()
        {
        }

        //16
        [TestMethod()]
        public void SubstractionSameTest()
        {
        }

        //17
        [TestMethod()]
        public void MultiplyByNumberDefoltTest ()
        {
        }

        //19
        [TestMethod()]
        public void MultiplyByZeroNumberTest()
        {
        }

        //20
        [TestMethod()]
        public void AddNumberWithoutFreeMemberTest()
        {
        }

        //21
        [TestMethod()]
        public void AddNumberWithFreeMemberTest()
        {
        }

        //22
        [TestMethod()]
        public void CalculateValueDefoultTest()
        {
        }

        //23
        [TestMethod()]
        public void CalculateValueWithZeroTest()
        {
        }

        //24
        [TestMethod()]
        public void FindDerivativeDefoultTest()
        {
        }

        //25
        [TestMethod()]
        public void FindDerivativeConstTest()
        {
        }

        //26
        [TestMethod()]
        public void EqualsSamePolynomsTest()
        {
            Assert.Fail();
        }

        //27
        [TestMethod()]
        public void EqualsDifferentsPolynomsTest()
        {
            Assert.Fail();
        }

        //28
        [TestMethod()]
        public void EqualsNullTest()
        {
            Assert.Fail();
        }

        //29
        [TestMethod()]
        public void EqualsAnotherTypeTest()
        {
            Assert.Fail();
        }

        //30
        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }

        //31
        [TestMethod()]
        public void GetHashCodeSameTest()
        {
            Assert.Fail();
        }

        //32
        public void GetHashCodeDifferentTest()
        {
            Assert.Fail();
        }

        //33
        public void GetHashCodeAnotherTypeTest()
        {
            Assert.Fail();
        }
    }
}