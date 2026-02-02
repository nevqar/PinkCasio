using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkCasio.Decimal
{
	public static class Mathm
	{
		public const decimal epsilon = 0.0m;
		public static decimal Abs(decimal a)
		{
			if (a >= 0)
				return a;
			else
				return -a;
		}
		public static decimal Sqrt(decimal a)
		{
			decimal x = a;
			while (Abs(a - x * x) > epsilon)
			{
				x = (x + a / x) / 2;
			}
			return x;
		}
	}
}
