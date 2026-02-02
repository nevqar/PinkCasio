using System;
namespace PinkCasio.Decimal.Linal
{
	public struct matrix3x3m
	{
		public decimal ix, jx, kx;
		public decimal iy, jy, ky;
		public decimal iz, jz, kz;

		public vec3m i
		{
			get{ return new vec3m(ix, iy, iz); }
			set
			{
				ix = value.x;
				iy = value.y;
				iz = value.z;
			}
		}
		public vec3m j
		{
			get{ return new vec3m(jx, jy, jz); }
			set
			{
				jx = value.x;
				jy = value.y;
				jz = value.z;
			}
		}
		public vec3m k
		{
			get{ return new vec3m(kx, ky, kz); }
			set
			{
				kx = value.x;
				ky = value.y;
				kz = value.z;
			}
		}

		static public readonly matrix3x3m identity = new matrix3x3m(
			1, 0, 0,
			0, 1, 0,
			0, 0, 1);

		public matrix3x3m(
			decimal a, decimal b, decimal c,
			decimal d, decimal e, decimal f,
			decimal g, decimal h, decimal i)
		{
			ix = a; jx = b; kx = c;
			iy = d; jy = e; ky = f;
			iz = g; jz = h; kz = i;
		}

		public static matrix3x3m operator *(decimal a, matrix3x3m b)
		{
			return new matrix3x3m(
				a * b.ix, a * b.jx, a * b.kx,
				a * b.iy, a * b.jy, a * b.ky,
				a * b.iz, a * b.jz, a * b.kz);
		}
		public static matrix3x3m operator *(matrix3x3m a, matrix3x3m b)
		{
			matrix3x3m c = new matrix3x3m();
			c.i = a * (b * identity.i);
			c.j = a * (b * identity.j);
			c.k = a * (b * identity.k);
			return c;
		}
		public decimal Det()
		{
			return
			+ ix * jy * kz
			+ iz * jx * ky
			+ iy * jz * kx
			- iz * jy * kx
			- iy * jx * kz
			- ix * jz * ky;
		}
		public matrix3x3m Inverse()
		{
			decimal det = Det();
			if (det == 0)
				throw new ArgumentException("Cannot inverse matrix with zero determinant");
			return (1/ det) * Cofactor().Transpose();
		}
		public matrix3x3m Cofactor()
		{
			return new matrix3x3m(
				jy * kz - jz * ky,		- iy * kz + iz * ky,	iy * jz - iz * jy,
				- jx * kz + jx * kx,	ix * kz - iz * kx,		- ix * jz + iz * jx,
				jx * ky - jy * kx,		- ix * ky + iy * kx,	ix * jy - iy * jx);
		}
		public matrix3x3m Transpose()
		{
			return new matrix3x3m(
				ix, iy, iz,
				jx, jy, jz,
				kx, ky, kz);
		}
		//public static matrix3x3m XRotationMatrix(decimal a)
		//{
		//	return new matrix3x3m(
		//		1, 0, 0,
		//		0, Math.Cos(a),	-Math.Sin(a),
		//		0, Math.Sin(a), Math.Cos(a));
		//}
		//public static matrix3x3m YRotationMatrix(decimal a)
		//{
		//	return new matrix3x3m(
		//		Math.Cos(a), 0, Math.Sin(a),
		//		0, 1, 0,
		//		-Math.Sin(a), 0, Math.Cos(a));
		//}
		//public static matrix3x3m ZRotationMatrix(decimal a)
		//{
		//	return new matrix3x3m(
		//	Math.Cos(a), -Math.Sin(a), 0,
		//	Math.Sin(a), Math.Cos(a), 0,
		//	0, 0, 1);
		//}
		override public string ToString()
		{
			return  "[" + "\t" + ix + "\t" + jx + "\t" + kx + "\t" + "]" + "\r\n" +
					"[" + "\t" + iy + "\t" + jy + "\t" + ky + "\t" + "]" + "\r\n" +
					"[" + "\t" + iz + "\t" + jz + "\t" + kz + "\t" + "]";
		}
	}
}