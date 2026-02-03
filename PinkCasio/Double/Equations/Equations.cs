using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinkCasio.Double.Linal;

namespace PinkCasio.Double.Equations
{
	public static class Equations
	{
		public static double QuadraticEquation(double a, double b, double c, bool sign)
		{
			double D = b * b - 4 * a * c;
			if (D < 0)
				throw new Exception("Discriminant is negative. Quadratic equation has no roots");
			if (sign)
				return (-b + Math.Sqrt(D)) / (2 * a);
			else
				return (-b - Math.Sqrt(D)) / (2 * a);
		}
		public static bool TryQuadraticEquation(double a, double b, double c, out double x1, out double x2)
		{
			double D = b * b - 4 * a * c;
			if (D < 0)
			{
				x1 = 0;
				x2 = 0;
				return false;
			}
			else
			{
				x1 = (-b + Math.Sqrt(D)) / (2 * a);
				x2 = (-b - Math.Sqrt(D)) / (2 * a);
				return true;
			}
		}

	}
}
