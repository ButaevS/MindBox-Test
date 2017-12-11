using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLib;

namespace UnitTestTriangle
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NegativeValuesTest()
        { // arrange 
            double a = -1;
            double b = -4;
            double c = -9;
            // act 
            try
            {
                Class1.RightTriangleArea(a, b, c);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, Class1.NegativeValuesMessage);
            }
        }


        // Test is redundant since Pythagorean theory already covers this case and throws its exception.
        // Nevertheless, it can still be useful if precise control over the user-input is required.
        [TestMethod]
        public void IncorrectLegLengthTest()    
        {
            double a = 9;
            double b = 9;
            double c = 8;
            try
            {
                Class1.RightTriangleArea(a, b, c);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, Class1.AbnormalLegLength);
            }
        }

        // The following test is used to check whenever one of the values exceeds its squared value
        // since floating point values cannot be checked for overflows, Infinity check is applied
        [TestMethod]
        public void SquaredLegTest()
        {
            double leg_a = double.MaxValue / 2;
            double leg_b = 10;
            double hypothenuse_c = double.MaxValue - 100;
            try
            {
                Class1.RightTriangleArea(leg_a, leg_b, hypothenuse_c);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, Class1.SquaredLegInfinity);
            }
        }
        
        [TestMethod]
        public void PythagoreanTest()
        {
            double leg_a = 2;
            double leg_b = 4;
            double hypothenuse_c = 10;
            try
            {
                Class1.RightTriangleArea(leg_a, leg_b, hypothenuse_c);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, Class1.RightTriangleFormInvalidity);
            }
        }
        
        [TestMethod]
        public void CorrectInput()
        {
            double a = 1000000.111111;
            double b = 2000000.222222;
            double expected = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            Class1.RightTriangleArea(a, b, expected);
        }
    }
}
