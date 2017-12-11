using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    public static class Helper
    {
        public static bool AlmostEquals(this double inst, double d, double eps)
        {
            return Math.Abs(inst - d) <= eps;
        }
    }

    public class Class1
    {
        public const string NegativeValuesMessage = "Parameters cannot have length of zero or less";
        public const string AbnormalLegLength = "Only one parameter can be of max length";
        public const string SquaredLegInfinity = "Leg Parameter is too big";
        public const string RightTriangleFormInvalidity = "Parameters cannot be used to form a Right Triangle";

        public static double RightTriangleArea(double a, double b, double c)
        {
            List<double> buff = new List<double>() { a, b, c };
            if (buff.Any(elm => elm <= 0))
                throw new ArgumentException(NegativeValuesMessage);
            double hyp_c = buff.Max();
            double smallest_value = hyp_c * 1E-15;
            buff.RemoveAll(val => hyp_c.AlmostEquals(val, smallest_value));
            if (buff.Count != 2)
                throw new ArgumentException(AbnormalLegLength);
            double leg_a = buff[0];
            double leg_b = buff[1];
            // use simple Pythagorean theory to check if these lengths can possibly form a Right Triangle
            double square_a = Math.Pow(leg_a, 2);
            double square_b = Math.Pow(leg_b, 2);
            if (double.IsInfinity(square_a))
                throw new ArgumentException(SquaredLegInfinity, nameof(a));
            if (double.IsInfinity(square_b))
                throw new ArgumentException(SquaredLegInfinity, nameof(b));
            if (hyp_c.AlmostEquals(Math.Sqrt(square_a + square_b), smallest_value))
                return 0.5 * leg_a * leg_b;
            else
                throw new ArgumentException(RightTriangleFormInvalidity);
        }
    }
}
