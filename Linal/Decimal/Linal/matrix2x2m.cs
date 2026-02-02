using System;
namespace PinkCasio.Decimal.Linal
{
	public struct matrix2x2m
	{
		public decimal ix, jx;
		public decimal iy, jy;

		public vec2m i
		{
			get { return new vec2m(ix, iy); }
			set
			{
				ix = value.x;
				iy = value.y;
			}
		}
		public vec2m j
		{
			get { return new vec2m(jx, jy); }
			set
			{
				jx = value.x;
				jy = value.y;
			}
		}

		static public readonly matrix2x2m identity = new matrix2x2m(
			1, 0,
			0, 1);

		public matrix2x2m(
			decimal a, decimal b,
			decimal c, decimal d)
		{
			ix = a; jx = b;
			iy = c; jy = d;
		}

		public static matrix2x2m operator *(decimal a, matrix2x2m b)
		{
			return new matrix2x2m(
				a * b.ix, a * b.jx,
				a * b.iy, a * b.jy);
		}
		//public static vec2 operator *(matrix2x2 m, vec2 v)
		//{
		//	return v.x * m.i + v.y * m.j;
		//}
		public static matrix2x2m operator *(matrix2x2m a, matrix2x2m b)
		{
			matrix2x2m c = new matrix2x2m();
			c.i = a * (b * identity.i);
			c.j = a * (b * identity.j);
			return c;
		}
		public decimal Det()
		{
			return ix * jy - iy * jx;
		}
		public matrix2x2m Inverse()
		{
			decimal det = Det();
			if (det == 0)
				throw new ArgumentException("Cannot inverse matrix with zero determinant");
			return (1 / det) * Cofactor().Transpose();
		}
		public matrix2x2m Cofactor()
		{
			return new matrix2x2m(
				jy, -iy,
				-jx, ix);
		}
		public matrix2x2m Transpose()
		{
			return new matrix2x2m(
				ix, iy,
				jx, jy);
		}
		//public static matrix2x2m RotationMatrix(decimal a)
		//{
		//	return new matrix2x2m(
		//		Math.Cos(a), -Math.Sin(a),
		//		Math.Sin(a), -Math.Cos(a));
		//}
		override public string ToString()
		{
			return "[" + "\t" + ix + "\t" + jx + "\t" + "]" + "\r\n" +
					"[" + "\t" + iy + "\t" + jy + "\t" + "]";
		}
	}
}