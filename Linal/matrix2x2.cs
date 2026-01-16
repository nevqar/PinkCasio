using System;
namespace Linal
{
	public struct matrix2x2
	{
		public double ix, jx;
		public double iy, jy;

		public vec2 i
		{
			get { return new vec2(ix, iy); }
			set
			{
				ix = value.x;
				iy = value.y;
			}
		}
		public vec2 j
		{
			get { return new vec2(jx, jy); }
			set
			{
				jx = value.x;
				jy = value.y;
			}
		}

		static public readonly matrix2x2 identity = new matrix2x2(
			1, 0,
			0, 1);

		public matrix2x2(
			double a, double b,
			double c, double d)
		{
			ix = a; jx = b;
			iy = c; jy = d;
		}

		public static matrix2x2 operator *(double a, matrix2x2 b)
		{
			return new matrix2x2(
				a * b.ix, a * b.jx,
				a * b.iy, a * b.jy);
		}
		public static vec2 operator *(matrix2x2 m, vec2 v)
		{
			return v.x * m.i + v.y * m.j;
		}
		public static matrix2x2 operator *(matrix2x2 a, matrix2x2 b)
		{
			matrix2x2 c = new matrix2x2();
			c.i = a * (b * identity.i);
			c.j = a * (b * identity.j);
			return c;
		}
		public double Det()
		{
			return ix * jy - iy * jx;
		}
		public matrix2x2 Inverse()
		{
			double det = Det();
			if (det == 0)
				throw new ArgumentException("Cannot inverse matrix with zero determinant");
			return (1 / det) * Cofactor().Transpose();
		}
		public matrix2x2 Cofactor()
		{
			return new matrix2x2(
				jy, -iy,
				-jx, ix);
		}
		public matrix2x2 Transpose()
		{
			return new matrix2x2(
				ix, iy,
				jx, jy);
		}
		public static matrix2x2 RotationMatrix(double a)
		{
			return new matrix2x2(
				Math.Cos(a), -Math.Sin(a),
				Math.Sin(a), -Math.Cos(a));
		}
		public static vec2 Cramer(matrix2x2 a, vec2 b)
		{
			double det = a.Det();
			if (det == 0)
				throw new Exception("Determinant equals zero. No solution");
			matrix2x2 ax = a;
			ax.i = b;
			double detx = ax.Det();
			matrix2x2 ay = a;
			ay.j = b;
			double dety = ay.Det();
			return new vec2(detx / det, dety / det);
		}
		override public string ToString()
		{
			return "[" + "\t" + ix + "\t" + jx + "\t" + "]" + "\r\n" +
					"[" + "\t" + iy + "\t" + jy + "\t" + "]";
		}
	}
}