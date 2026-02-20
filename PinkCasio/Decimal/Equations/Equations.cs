using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PinkCasio.Decimal.Linal;

namespace PinkCasio.Decimal.Equations
{
	public static class Equations
	{
		public static decimal QuadraticEquation(decimal a, decimal b, decimal c, bool sign)
		{
			decimal D = b * b - 4 * a * c;
			if (D < 0)
				throw new Exception("Discriminant is negative. Quadratic equation has no roots");
			if (sign)
				return (-b + Mathm.Sqrt(D)) / (2 * a);
			else
				return (-b - Mathm.Sqrt(D)) / (2 * a);
		}
		public static bool TryQuadraticEquation(decimal a, decimal b, decimal c, out decimal x1, out decimal x2)
		{
			decimal D = b * b - 4 * a * c;
			if (D < 0)
			{
				x1 = 0;
				x2 = 0;
				return false;
			}
			else
			{
				x1 = (-b + Mathm.Sqrt(D)) / (2 * a);
				x2 = (-b - Mathm.Sqrt(D)) / (2 * a);
				return true;
			}
		}

	}
}
