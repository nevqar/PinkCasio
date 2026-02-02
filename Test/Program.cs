using System;
using PinkCasio.Double.Linal;
using PinkCasio.Decimal;
using PinkCasio.Decimal.Linal;

namespace Test
{
	internal class Program
	{
		static void Main(string[] args)
		{
			vec2m a = new vec2m(0, 1);
			vec3 b = new vec3(0, 1, 2);
			quaternion c = new quaternion(0, 1, 2, 3);
			matrix2x2 d = new matrix2x2(0, 1, 2, 3);
			matrix3x3 e = new matrix3x3(0, 1, 2, 3, 4, 5, 6, 7, 8);

			Console.WriteLine(".ToString() methods demonstration");
			Console.WriteLine();

			Console.WriteLine("vec2 >> ");
			Console.WriteLine(a);
			Console.WriteLine();

			Console.WriteLine("vec3 >> ");
			Console.WriteLine(b);
			Console.WriteLine();

			Console.WriteLine("quaternion >> ");
			Console.WriteLine(c);
			Console.WriteLine();

			Console.WriteLine("matrix2x2 >> ");
			Console.WriteLine(d);
			Console.WriteLine();

			Console.WriteLine("matrix3x3 >> ");
			Console.WriteLine(e);
			Console.WriteLine();

			Console.WriteLine(Mathm.Sqrt(25m));
		}
	}
}
