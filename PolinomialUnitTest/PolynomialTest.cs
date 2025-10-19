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
            IPolynomial p = new Polynomial();

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
            IPolynomial p = new Polynomial(coeffs);
            
            //Assert
            Assert.AreEqual(TARGET_LENGTH, p.Elements.Length, "Polynomial length is not correct");
            Assert.AreEqual(FIRST_COEF, p.Elements[0].Coefficient, "First coefficient is not correct");
            Assert.AreEqual(FIRST_DEGR, p.Elements[0].Degree, "First degree is not correct");
            Assert.AreEqual(SECOND_COEF, p.Elements[1].Coefficient, "Second coefficient is not correct");
            Assert.AreEqual(SECOND_DEGR, p.Elements[1].Degree, "Second degree is not correct");
            Assert.AreEqual(FOURTH_COEF, p.Elements[2].Coefficient, "Fourth coefficient is not correct");
            Assert.AreEqual(FOURTH_DEGR, p.Elements[2].Degree, "Fourth degree is not correct");
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
            IPolynomial p = new Polynomial(coeff);

            //Assert
            Assert.AreEqual(TARGET_LENGTH, p.Elements.Length, "Polynomial length is not correct");
        }

        //4
        [TestMethod()]
        public void ConstructorFromNULLOneDimensionalArray()
        {
            // Arrange
            double[] coeff = null;

            // Act & Assert 
            Assert.ThrowsException<ArgumentNullException>(() => new Polynomial(coeff), "Constructor should throw ArgumentNullException for NULL array");
        } 

        //5
        [TestMethod()]
        public void ConstructorFromTwoDimensionalArrayWithoutNulls()
        {
            // Arrange 
            const int FIRST_COEF = 5;
            const int SECOND_COEF = -1;
            const int THIRD_COEF = -4;
            const int FIRST_DEGR = 0;
            const int SECOND_DEGR = 2;
            const int THIRD_DEGR = 3;
            const int TARGET_LENGTH = 3; // THIRD will be not used

            // Act
            double[,] coeff = new double[,] { { FIRST_DEGR, FIRST_COEF }, { SECOND_DEGR, SECOND_COEF }, {THIRD_DEGR, THIRD_COEF} };
            IPolynomial p = new Polynomial(coeff); //expected [degree, coef.]

            // Assert
            Assert.AreEqual(TARGET_LENGTH, p.Elements.Length, "Polynomial length is not correct");
            Assert.AreEqual(FIRST_COEF, p.Elements[0].Coefficient, "First coefficient is not correct");
            Assert.AreEqual(SECOND_COEF, p.Elements[1].Coefficient, "Second coefficient is not correct");
            Assert.AreEqual(FIRST_DEGR, p.Elements[0].Degree, "First degree is not correct");
            Assert.AreEqual(SECOND_DEGR, p.Elements[1].Degree, "Second degree is not correct");
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
            const int TARGET_DEGREE = FIRST_DEGR;
            const int TARGET_LENGTH = 1;
            
            // Act
            double[,] coeff = new double[COUNT,2] { { FIRST_DEGR, FIRST_COEF }, { FIRST_DEGR, FIRST_COEF }, { FIRST_DEGR, FIRST_COEF }, { FIRST_DEGR, FIRST_COEF } };
            IPolynomial p = new Polynomial(coeff); //expected [degree, coef.]
            
            // Assert
            Assert.AreEqual(TARGET_COEF, p.Elements[0].Coefficient, "Coefficient is not correct");
            Assert.AreEqual(TARGET_DEGREE, p.Elements[0].Degree, "Degree is not correct");
            Assert.AreEqual(TARGET_LENGTH, p.Elements.Length, "Length is not correct");
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
            IPolynomial p = new Polynomial(coeff);

            // Assert
            Assert.AreEqual(TARGET_LENGTH, p.Elements.Length, "Polynomial length is not correct");
        }

        //8
        [TestMethod()]
        public void ConstructorFromNULLTwoDimensionalArray()
        {
            // Arrange 
            double[,] coeff = null;
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Polynomial(coeff), "Constructor should throw ArgumentNullException for NULL array");
        }

        //9
        [TestMethod()]
        public void ConstructorFromTwoDimensionalArrayWithNotWholeFraction()
        {
            // Arrange 
            const int FIRST_COEF = 5;
            const int SECOND_COEF = 10;
            const double FIRST_DEGR = 1.4;
            const double SECOND_DEGR = 2.3;
            const int TARGET_FIRST_DEGR = 1;
            const int TARGET_SECOND_DEGR = 2;
            const int TARGET_LENGTH = 2; // THIRD will be not used

            // Act
            //expected [degree, coef.]
            double[,] coeff = new double[,] { { FIRST_DEGR, FIRST_COEF }, { SECOND_DEGR, SECOND_COEF } };
            IPolynomial p = new Polynomial(coeff);

            // Assert
            Assert.AreEqual(TARGET_FIRST_DEGR, p.Elements[0].Degree, "First degree is not correct");
            Assert.AreEqual(FIRST_COEF, p.Elements[0].Coefficient, "First coefficient is not correct");
            Assert.AreEqual(TARGET_SECOND_DEGR, p.Elements[1].Degree, "Second degree is not correct");
            Assert.AreEqual(SECOND_COEF, p.Elements[1].Coefficient, "Second coefficient is not correct");
            Assert.AreEqual(TARGET_LENGTH, p.Elements.Length, "Length is not correct");
        }
        
        //10
        [TestMethod()]
        public void ConstructorOfCopyDefaultTest()
        {
            // Arrange 
            const int FIRST_COEF = 5;
            const int SECOND_COEF = 10;
            const int TARGET_LENGTH = 2; // THIRD will be not used

            // Act
            double[] coeff = new double[] { FIRST_COEF, SECOND_COEF };
            Polynomial p1 = new Polynomial(coeff);
            Polynomial p2 = new Polynomial(p1);
            // Assert
            Assert.AreEqual(FIRST_COEF, p2.Elements[0].Coefficient, "First coefficient is not correct");
            Assert.AreEqual(SECOND_COEF, p2.Elements[1].Coefficient, "Second coefficient is not correct");
            Assert.AreEqual(TARGET_LENGTH, p2.Elements.Length, "Length is not correct");
        }

        //11
        [TestMethod()]
        public void ConstructorOfCopyNULLTest()
        {
            // Arrange 
            Polynomial p1 = null;
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Polynomial(p1), "Constructor should throw ArgumentNullException for NULL polynomial");
        }

        //12
        [TestMethod()]
        public void AddPositiveTest()
        {
            // Arrange
            const double FIRST_COEF_ONE = 5;
            const double FIRST_COEF_TWO = 5;
            const double SECOND_COEF_ONE = 10;
            const double SECOND_COEF_TWO = 10;
            const double THIRD_COEF_ONE = 15;
            const double TARGET_COEF_ONE = FIRST_COEF_ONE + FIRST_COEF_TWO;
            const double TARGET_COEF_TWO = SECOND_COEF_ONE + SECOND_COEF_TWO;
            const double TARGET_COEF_THREE = THIRD_COEF_ONE;
            const double TARGET_DEGR_ONE = 0;
            const double TARGET_DEGR_TWO = 1;
            const double TARGET_DEGR_THREE = 2;
            const int TARGET_LENGTH = 3;

            // Act
            double[] coeffs1 = new double[] { FIRST_COEF_ONE, SECOND_COEF_ONE, THIRD_COEF_ONE };
            double[] coeffs2 = new double[] { FIRST_COEF_TWO, SECOND_COEF_TWO };
            IPolynomial p1 = new Polynomial(coeffs1);
            IPolynomial p2 = new Polynomial(coeffs2);
            IPolynomial result = p1.Add(p2);

            // Assert
            Assert.AreEqual(TARGET_LENGTH, result.Elements.Length, "Length is not correct");
            Assert.AreEqual(TARGET_COEF_ONE, result.Elements[0].Coefficient, "First coefficient is not correct");
            Assert.AreEqual(TARGET_COEF_TWO, result.Elements[1].Coefficient, "Second coefficient is not correct");
            Assert.AreEqual(TARGET_COEF_THREE, result.Elements[2].Coefficient, "Third coefficient is not correct");
            Assert.AreEqual(TARGET_DEGR_ONE, result.Elements[0].Degree, "First degree is not correct");
            Assert.AreEqual(TARGET_DEGR_TWO, result.Elements[1].Degree, "Second degree is not correct");
            Assert.AreEqual(TARGET_DEGR_THREE, result.Elements[2].Degree, "Third degree is not correct");
        }

        //13
        [TestMethod()]
        public void AddNegativeTest()
        {
            // Arrange
            const double FIRST_COEF_ONE = 5;
            const double FIRST_COEF_TWO = -5;
            const double SECOND_COEF_ONE = 10;
            const double SECOND_COEF_TWO = -10;
            const double THIRD_COEF_ONE = 15;
            const double TARGET_COEF_THREE = THIRD_COEF_ONE;
            const double TARGET_DEGR_ONE = 2;
            const int TARGET_LENGTH = 1;

            // Act
            double[] coeffs1 = new double[] { FIRST_COEF_ONE, SECOND_COEF_ONE, THIRD_COEF_ONE };
            double[] coeffs2 = new double[] { FIRST_COEF_TWO, SECOND_COEF_TWO };
            IPolynomial p1 = new Polynomial(coeffs1);
            IPolynomial p2 = new Polynomial(coeffs2);
            IPolynomial result = p1.Add(p2);

            // Assert
            Assert.AreEqual(TARGET_LENGTH, result.Elements.Length, "Length is not correct");
            Assert.AreEqual(TARGET_COEF_THREE, result.Elements[0].Coefficient, "First coefficient is not correct");
            Assert.AreEqual(TARGET_DEGR_ONE, result.Elements[0].Degree, "First degree is not correct");
        }

        //14
        [TestMethod()]
        public void AddEmptyPolynomsTest()
        {
            // Arrange
            const double FIRST_COEF = 5;
            const double SECOND_COEF = 10;
            const double TARGET_COEF_ONE = FIRST_COEF;
            const double TARGET_COEF_TWO = SECOND_COEF;
            const double TARGET_DEGR_ONE = 0;
            const double TARGET_DEGR_TWO = 1;
            const int TARGET_LENGTH = 2;

            // Act
            double[] coeff = new double[] { FIRST_COEF, SECOND_COEF };
            IPolynomial p1 = new Polynomial(coeff);
            IPolynomial p2 = new Polynomial();
            IPolynomial result = p1.Add(p2);

            // Assert
            Assert.AreEqual(TARGET_LENGTH, result.Elements.Length, "Length is not correct");
            Assert.AreEqual(TARGET_COEF_ONE, result.Elements[0].Coefficient, "First coefficient is not correct");
            Assert.AreEqual(TARGET_COEF_TWO, result.Elements[1].Coefficient, "Second coefficient is not correct");
            Assert.AreEqual(TARGET_DEGR_ONE, result.Elements[0].Degree, "First degree is not correct");
            Assert.AreEqual(TARGET_DEGR_TWO, result.Elements[1].Degree, "Second degree is not correct");
        }
        
        //15
        [TestMethod()]
        public void AddNullTest()
        {
            // Arange
            const double FIRST_COEF = 5;
            double[] coeff = new double[] { FIRST_COEF };
            //act
            IPolynomial p1 = new Polynomial(coeff);
            Polynomial p2 = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => p1.Add(p2), "Add method should throw ArgumentNullException for NULL polynomial");
        }

        //16
        [TestMethod()]
        public void SubtractDefaultTest()
        {
            // Arrange
            const double FIRST_COEF_ONE = 5;
            const double FIRST_COEF_TWO = 5;
            const double SECOND_COEF_ONE = -10;
            const double SECOND_COEF_TWO = 10;
            const double THIRD_COEF_ONE = 15;
            const double TARGET_DEGR_THREE = 2;
            const int TARGET_LENGTH = 2;

            // Act
            double[] coeffs1 = new double[] { FIRST_COEF_ONE, SECOND_COEF_ONE, THIRD_COEF_ONE };
            double[] coeffs2 = new double[] { FIRST_COEF_TWO, SECOND_COEF_TWO };
            IPolynomial p1 = new Polynomial(coeffs1);
            IPolynomial p2 = new Polynomial(coeffs2);
            IPolynomial result = p1.Subtract(p2);

            // Assert
            Assert.AreEqual(TARGET_LENGTH, result.Elements.Length, "Length is not correct");
            Assert.AreEqual(TARGET_DEGR_THREE, result.Elements[1].Degree, "Degree is not correct");
        }

        //17
        [TestMethod()]
        public void SubtractSameTest()
        {
            // Arrange
            const double FIRST_COEF = 5;
            const double FIRST_DEGR = 5;
            const int TARGET_LENGTH = 0;

            // Act
            double[] coeff = new double[] { FIRST_COEF, FIRST_DEGR };
            IPolynomial p1 = new Polynomial(coeff);
            IPolynomial p2 = new Polynomial(coeff);
            IPolynomial result = p1.Subtract(p2);

            // Assert
            Assert.AreEqual(TARGET_LENGTH, result.Elements.Length, "Length is not correct");
        }

        //18
        [TestMethod()]
        public void SubtractEmptyPolynomsTest()
        {
            // Arrange
            const double FIRST_COEF = 5;
            const double SECOND_COEF = 10;
            const double TARGET_COEF_ONE = FIRST_COEF;
            const double TARGET_COEF_TWO = SECOND_COEF;
            const double TARGET_DEGR_ONE = 0;
            const double TARGET_DEGR_TWO = 1;
            const int TARGET_LENGTH = 2;

            // Act
            double[] coeff = new double[] { FIRST_COEF, SECOND_COEF };
            IPolynomial p1 = new Polynomial(coeff);
            IPolynomial p2 = new Polynomial();
            IPolynomial result = p1.Subtract(p2);

            // Assert
            Assert.AreEqual(TARGET_LENGTH, result.Elements.Length, "Length is not correct");
            Assert.AreEqual(TARGET_COEF_ONE, result.Elements[0].Coefficient, "First coefficient is not correct");
            Assert.AreEqual(TARGET_COEF_TWO, result.Elements[1].Coefficient, "Second coefficient is not correct");
            Assert.AreEqual(TARGET_DEGR_ONE, result.Elements[0].Degree, "First degree is not correct");
            Assert.AreEqual(TARGET_DEGR_TWO, result.Elements[1].Degree, "Second degree is not correct");
        }
        
        //19
        [TestMethod()]
        public void SubtractNullTest()
        {
            // Arange
            const double FIRST_COEF = 5;
            double[] coeff = new double[] { FIRST_COEF };
            //act
            IPolynomial p1 = new Polynomial(coeff);
            Polynomial p2 = null;

            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => p1.Subtract(p2), "Subtraction method should throw ArgumentNullException for NULL polynomial");
        }

        //20
        [TestMethod()]
        public void AddNumberWithoutFreeMemberTest()
        {
            // Arange
            const int THIRD_COEF = 5;
            const int THIRD_DEGR = 3;
            const double TARGET_NUM = 10;
            const int TARGET_DEGR_ONE = 0;
            const int TARGET_LENGTH = 2;

            // Act
            double[,] pair = new double[,] { { THIRD_DEGR, THIRD_COEF } };
            IPolynomial p = new Polynomial(pair);
            IPolynomial res = p.AddNumber(TARGET_NUM);
            Assert.AreEqual(TARGET_LENGTH, res.Elements.Length, "Length is not correct");
            Assert.AreEqual(TARGET_DEGR_ONE, res.Elements[0].Degree, "First degree is not correct");
            Assert.AreEqual(THIRD_DEGR, res.Elements[1].Degree, "Second degree is not correct");
            Assert.AreEqual(TARGET_NUM, res.Elements[0].Coefficient, "First coefficient is not correct");
            Assert.AreEqual(THIRD_COEF, res.Elements[1].Coefficient, "Second coefficient is not correct");
        }
        //21
        [TestMethod()]
        public void AddNumberWithFreeMemberTest()
        {
            // Arrange
            const int FIRST_COEF = 5;
            const int FIRST_DEGR = 0;
            const int THIRD_COEF = 5;
            const int THIRD_DEGR = 3;
            const int NUM = 10;
            const double TARGET_NUM = 15;
            const int TARGET_DEGR_ONE = 0;
            const int TARGET_DEGR_TWO = 3;
            const int TARGET_LENGTH = 2;

            // Act
            double[,] pair = new double[,] { { FIRST_DEGR, FIRST_COEF }, { THIRD_DEGR, THIRD_COEF } };
            IPolynomial p = new Polynomial(pair);
            IPolynomial res = p.AddNumber(NUM);

            // Assert
            Assert.AreEqual(TARGET_LENGTH, res.Elements.Length, "Length is not correct");
            Assert.AreEqual(TARGET_DEGR_ONE, res.Elements[0].Degree, "First degree is not correct");
            Assert.AreEqual(TARGET_NUM, res.Elements[0].Coefficient, "First coefficient is not correct");
            Assert.AreEqual(TARGET_DEGR_TWO, res.Elements[1].Degree, "Second degree is not correct");
            Assert.AreEqual(THIRD_COEF, res.Elements[1].Coefficient, "Second coefficient is not correct");
        }

        //22
        [TestMethod()]
        public void MultiplyByNumberDefoltTest ()
        {
            // Arange
            const int FIRST_COEF = 5;
            const int FIRST_DEGR= 0;
            const int THIRD_COEF = 5;
            const int THIRD_DEGR = 3;
            const int NUM = 10;
            const double TARGET_NUM = 50;
            const int TARGET_DEGR_ONE = 0;
            const int TARGET_LENGTH = 2;

            // Act
            double[,] pair = new double[,] { { FIRST_DEGR, FIRST_COEF }, { THIRD_DEGR, THIRD_COEF } };
            IPolynomial p = new Polynomial(pair);
            IPolynomial res = p.MultiplyByNumber(NUM);
            Assert.AreEqual(TARGET_LENGTH, res.Elements.Length, "Length is not correct");
            Assert.AreEqual(TARGET_DEGR_ONE, res.Elements[0].Degree, "First degree is not correct");
            Assert.AreEqual(TARGET_NUM, res.Elements[0].Coefficient, "First coefficient is not correct");
            Assert.AreEqual(THIRD_DEGR, res.Elements[1].Degree, "Second degree is not correct");
            Assert.AreEqual(THIRD_COEF * NUM, res.Elements[1].Coefficient, "Second coefficient is not correct");
        }

        //23
        [TestMethod()]
        public void MultiplyByZeroNumberTest()
        {
            const int FIRST_COEF = 5;
            const int FIRST_DEGR = 0;
            const int THIRD_COEF = 5;
            const int THIRD_DEGR = 3;
            const int NUM = 0;
            const int TARGET_LENGTH = 0;

            // Act
            double[,] pair = new double[,] { { FIRST_DEGR, FIRST_COEF }, { THIRD_DEGR, THIRD_COEF } };
            IPolynomial p = new Polynomial(pair);
            IPolynomial res = p.MultiplyByNumber(NUM);
            Assert.AreEqual(TARGET_LENGTH, res.Elements.Length, "Length is not correct");
        }

        //24
        [TestMethod()]
        public void CalculateValueDefaultTest()
        {
            // Arrange
            const int FIRST_COEF = 5;
            const int FIRST_DEGR = 0;
            const int THIRD_COEF = 5;
            const int THIRD_DEGR = 3;
            const double X = 2;
            const double TARGET_NUM = 45;

            // Act
            double[,] pair = new double[,] { { FIRST_DEGR, FIRST_COEF }, { THIRD_DEGR, THIRD_COEF } };
            IPolynomial p = new Polynomial(pair);
            double res = p.CalculateValue(X);
            Assert.AreEqual(TARGET_NUM, res, "Calculated value is not correct");
        }

        //25
        [TestMethod()]
        public void CalculateValueWithZeroTest()
        {
            // Arrange
            const int FIRST_COEF = 5;
            const int FIRST_DEGR = 0;
            const int THIRD_COEF = 5;
            const int THIRD_DEGR = 3;
            const double X = 0;
            const double TARGET_NUM = 5;

            // Act
            double[,] pair = new double[,] { { FIRST_DEGR, FIRST_COEF }, { THIRD_DEGR, THIRD_COEF } };
            IPolynomial p = new Polynomial(pair);
            double res = p.CalculateValue(X);
            Assert.AreEqual(TARGET_NUM, res, "Calculated value is not correct");
        }

        //26
        [TestMethod()]
        public void CalculateValueWithEmptyPolynomialTest()
        {
            const double X = 5; 
            const double TARGET_NUM = 0;
            // Act
            IPolynomial p = new Polynomial();
            double res = p.CalculateValue(X);
            Assert.AreEqual(TARGET_NUM, res, "Calculated value is not correct");
        }


        //27
        [TestMethod()]
        public void FindDerivativeDefaultTest()
        {
            // Arrange
            const int FIRST_COEF = 5;
            const int FIRST_DEGR= 0;
            const int THIRD_COEF = 5;
            const int THIRD_DEGR = 3;
            const int TARGET_LENGTH = 1;
            const int TARGET_DEGR = 2; 
            // Act
            double[,] pair = new double[,] { { FIRST_DEGR, FIRST_COEF }, { THIRD_DEGR, THIRD_COEF } };
            IPolynomial p = new Polynomial(pair);
            IPolynomial res = p.FindDerivative();
            Assert.AreEqual(TARGET_LENGTH, res.Elements.Length, "Length is not correct");
            Assert.AreEqual(TARGET_DEGR, res.Elements[0].Degree, "First degree is not correct");
        }

        //28
        [TestMethod()]
        public void FindDerivativeConstTest()
        {
            const int FIRST_COEF = 5;
            const int FIRST_DEGR = 0;
            const int THIRD_COEF = 5;
            const int THIRD_DEGR = 3;
            const double TARGET_NUM = THIRD_COEF * THIRD_DEGR;
            const int TARGET_LENGTH = 1;

            // Act
            double[,] pair = new double[,] { { FIRST_DEGR, FIRST_COEF }, { THIRD_DEGR, THIRD_COEF } };
            IPolynomial p = new Polynomial(pair);
            IPolynomial res = p.FindDerivative();
            Assert.AreEqual(TARGET_NUM, res.Elements[0].Coefficient, "First coefficient is not correct");
            Assert.AreEqual(TARGET_LENGTH, res.Elements.Length, "Length is not correct");
        }

        //29
        [TestMethod()]
        public void EqualsSamePolynomsTest()
        {
            // Arrange
            const double FIRST_COEF = 5;
            const double SECOND_COEF = 10;

            // Act
            double[] coeffs = new double[] { FIRST_COEF, SECOND_COEF };
            IPolynomial p1 = new Polynomial(coeffs);
            IPolynomial p2 = new Polynomial(coeffs);

            // Assert
            Assert.IsTrue(p1.Equals(p2), "Polynomials should be equal");
        }

        //30
        [TestMethod()]
        public void EqualsDifferentsPolynomsTest()
        {
            // Arrange
            const double FIRST_COEF = 10;
            const double SECOND_COEF = 5;
            const double FIRST_DEGR = 3;
            const double SECOND_DEGR = 8;

            // Act
            double[] coeffs1 = new double[] { FIRST_DEGR, FIRST_COEF };
            double[] coeffs2 = new double[] { SECOND_DEGR, SECOND_COEF };
            IPolynomial p1 = new Polynomial(coeffs1);
            IPolynomial p2 = new Polynomial(coeffs2);

            // Assert
            Assert.IsFalse(p1.Equals(p2), "Polynomials should not be equal");
        }

        //31
        [TestMethod()]
        public void EqualsNullTest()
        {
            // Arrange
            const double FIRST_COEF = 5;

            // Act
            double[] coeffs = new double[] { FIRST_COEF };
            IPolynomial p1 = new Polynomial(coeffs);
            IPolynomial p2 = null;

            // Assert
            Assert.IsFalse(p1.Equals(p2), "Polynomial should not be equal to null");
        }

        //32
        [TestMethod()]
        public void EqualsAnotherTypeTest()
        {
            // Arrange
            const double FIRST_COEF = 5;

            // Act
            double[] coeffs = new double[] { FIRST_COEF };
            IPolynomial p1 = new Polynomial(coeffs);
            object p2 = new object();

            // Assert
            Assert.IsFalse(p1.Equals(p2), "Polynomial should not be equal to object of another type");
        }
        
        //33
        [TestMethod()]
        public void ToStringDefaultTest()
        {
            // Arrange
            const double FIRST_COEF = 5;
            const double SECOND_COEF = -3;
            const double THIRD_COEF = 1;
            const double FOURTH_COEF = 2;
            const string TARGET_STRING = "5 - 3x + x^2 + 2x^3";

            // Act
            double[] coeffs = new double[] { FIRST_COEF, SECOND_COEF, THIRD_COEF, FOURTH_COEF }; // 5 - 3x + 2x^3
            IPolynomial p = new Polynomial(coeffs);
            string res = p.ToString();

            // Assert
            Assert.AreEqual(TARGET_STRING, res, "String representation is not correct");
        }

        //34
        [TestMethod()]
        public void ToStringNullPolynomialTest()
        {
            // Arrange & Act
            IPolynomial p = null;
            // Assert
            Assert.ThrowsException<NullReferenceException>(() => p.ToString(), "ToString method should throw NullReferenceException for NULL polynomial");
        }

        //35
        [TestMethod()]
        public void ToStringEmptyCoeffTest()
        {
            // Arrange
            const string TARGET_STRING = "0";

            // Act
            IPolynomial p = new Polynomial();
            string res = p.ToString();

            // Assert
            Assert.AreEqual(TARGET_STRING, res, "String representation is not correct");
        }

        //36
        [TestMethod()]
        public void ToStringOneCoeffTest()
        {
            // Arrange
            const double FIRST_COEF = 1;
            const string TARGET_STRING = "1";

            // Act
            double[] coef = new double[] { FIRST_COEF };
            IPolynomial p = new Polynomial(coef);
            string res = p.ToString();

            // Assert
            Assert.AreEqual(TARGET_STRING, res, "String representation is not correct");
        }
        //37
        [TestMethod()]
        public void GetHashCodeSameTest()
        {
            // Arrange
            const double FIRST_COEF = 10;
            const double SECOND_COEF = 11;

            // Act
            double[] coeffs = new double[] { FIRST_COEF, SECOND_COEF };
            IPolynomial p1 = new Polynomial(coeffs);
            IPolynomial p2 = new Polynomial(coeffs);

            // Assert
            Assert.AreEqual(p1.GetHashCode(), p2.GetHashCode(), "Hash codes should be equal");
        }

        //38
        [TestMethod()]
        public void GetHashCodeDifferentTest()
        {
            // Arrange
            const double FIRST_COEF = 1;
            const double SECOND_COEF = 10;
            const double FIRST_DEGR = 4;
            const double SECOND_DEGR = 23;

            // Act
            double[] coeffs1 = new double[] { FIRST_DEGR, FIRST_COEF };
            double[] coeffs2 = new double[] { SECOND_DEGR, SECOND_COEF };
            IPolynomial p1 = new Polynomial(coeffs1);
            IPolynomial p2 = new Polynomial(coeffs2);
            int hash1 = p1.GetHashCode();
            int hash2 = p2.GetHashCode();

            // Assert
            Assert.AreNotEqual(hash1, hash2, "Hash codes should be different for different polynomials");
        }

        //39
        [TestMethod()]
        public void GetHashCodeAnotherTypeTest()
        {
            // Arrange
            const double FIRST_COEF = 10;
            const double SECOND_COEF = 10;
            const double FIRST_DEGR = 4;
            const double SECOND_DEGR = 4;

            // Act
            double[] coeffs1 = new double[] { FIRST_DEGR, FIRST_COEF };
            double[] coeffs2 = new double[] { SECOND_DEGR, SECOND_COEF };
            IPolynomial p1 = new Polynomial(coeffs1);
            object p2 = new object();

            int hash1 = p1.GetHashCode();
            int hash2 = p2.GetHashCode();

            // Assert
            Assert.AreNotEqual(hash1, hash2, "Hash codes should be different for different types");
        }
    }
}