using System;
namespace Linal
{
	public struct matrix3x3
	{
		public double ix, jx, kx;
		public double iy, jy, ky;
		public double iz, jz, kz;

		public vec3 i
		{
			get{ return new vec3(ix, iy, iz); }
			set
			{
				ix = value.x;
				iy = value.y;
				iz = value.z;
			}
		}
		public vec3 j
		{
			get{ return new vec3(jx, jy, jz); }
			set
			{
				jx = value.x;
				jy = value.y;
				jz = value.z;
			}
		}
		public vec3 k
		{
			get{ return new vec3(kx, ky, kz); }
			set
			{
				kx = value.x;
				ky = value.y;
				kz = value.z;
			}
		}

		static public readonly matrix3x3 identity = new matrix3x3(
			1, 0, 0,
			0, 1, 0,
			0, 0, 1);

		public matrix3x3(
			double a, double b, double c,
			double d, double e, double f,
			double g, double h, double i)
		{
			ix = a; jx = b; kx = c;
			iy = d; jy = e; ky = f;
			iz = g; jz = h; kz = i;
		}

		public static matrix3x3 operator *(double a, matrix3x3 b)
		{
			return new matrix3x3(
				a * b.ix, a * b.jx, a * b.kx,
				a * b.iy, a * b.jy, a * b.ky,
				a * b.iz, a * b.jz, a * b.kz);
		}
		public static vec3 operator *(matrix3x3 m, vec3 v)
		{
			return v.x * m.i + v.y * m.j + v.z * m.k;
		}
		public static matrix3x3 operator *(matrix3x3 a, matrix3x3 b)
		{
			matrix3x3 c = new matrix3x3();
			c.i = a * (b * identity.i);
			c.j = a * (b * identity.j);
			c.k = a * (b * identity.k);
			return c;
		}
		public double Det()
		{
			return
			+ ix * jy * kz
			+ iz * jx * ky
			+ iy * jz * kx
			- iz * jy * kx
			- iy * jx * kz
			- ix * jz * ky;
		}
		public matrix3x3 Inverse()
		{
			double det = Det();
			if (det == 0)
				throw new ArgumentException("Cannot inverse matrix with zero determinant");
			return (1/ det) * Cofactor().Transpose();
		}
		public matrix3x3 Cofactor()
		{
			return new matrix3x3(
				jy * kz - jz * ky,		- iy * kz + iz * ky,	iy * jz - iz * jy,
				- jx * kz + jx * kx,	ix * kz - iz * kx,		- ix * jz + iz * jx,
				jx * ky - jy * kx,		- ix * ky + iy * kx,	ix * jy - iy * jx);
		}
		public matrix3x3 Transpose()
		{
			return new matrix3x3(
				ix, iy, iz,
				jx, jy, jz,
				kx, ky, kz);
		}
		public static matrix3x3 XRotationMatrix(double a)
		{
			return new matrix3x3(
				1, 0, 0,
				0, Math.Cos(a),	-Math.Sin(a),
				0, Math.Sin(a), Math.Cos(a));
		}
		public static matrix3x3 YRotationMatrix(double a)
		{
			return new matrix3x3(
				Math.Cos(a), 0, Math.Sin(a),
				0, 1, 0,
				-Math.Sin(a), 0, Math.Cos(a));
		}
		public static matrix3x3 ZRotationMatrix(double a)
		{
			return new matrix3x3(
			Math.Cos(a), -Math.Sin(a), 0,
			Math.Sin(a), Math.Cos(a), 0,
			0, 0, 1);
		}
		public static vec3 Cramer(matrix3x3 a, vec3 b)
		{
			double det = a.Det();
			if (det == 0)
				throw new Exception("Determinant equals zero. No solution");
			matrix3x3 ax = a;
			ax.i = b;
			double detx = ax.Det();
			matrix3x3 ay = a;
			ay.j = b;
			double dety = ay.Det();
			matrix3x3 az = a;
			ay.k = b;
			double detz = az.Det();
			return new vec3(detx / det, dety / det, detz / det);
		}
		override public string ToString()
		{
			return  "[" + "\t" + ix + "\t" + jx + "\t" + kx + "\t" + "]" + "\r\n" +
					"[" + "\t" + iy + "\t" + jy + "\t" + ky + "\t" + "]" + "\r\n" +
					"[" + "\t" + iz + "\t" + jz + "\t" + kz + "\t" + "]";
		}
	}
}