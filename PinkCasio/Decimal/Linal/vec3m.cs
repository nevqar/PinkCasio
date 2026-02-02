using System;
namespace PinkCasio.Decimal.Linal
{
	public struct vec3m
	{
		public double x, y, z;	
		public vec3m(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public vec3m(double a)
		{
			this.x = a;
			this.y = a;
			this.z = a;
		}
		public static vec3m operator +(vec3m a, vec3m b)
		{
			return new vec3m(a.x + b.x, a.y + b.y, a.z + b.z);
		}
		public static vec3m operator -(vec3m a, vec3m b)
		{
			return new vec3m(a.x - b.x, a.y - b.y, a.z - b.z);
		}
		public static vec3m operator *(double d, vec3m v)
		{
			return new vec3m(d * v.x, d * v.y, d * v.z);
		}
		public static vec3m operator /(vec3m a, double b)
		{
			if (b == 0)
				throw new ArgumentException("Cannot divide by zero");
			return new vec3m(a.x / b, a.y / b, a.z / b);
		}
		public static vec3m operator *(matrix3x3m m, vec3m v)
		{
			return v.x * m.i + v.y * m.j + v.z * m.k;
		}
		public double Length()
		{
			return Math.Sqrt(x * x + y * y + z * z);
		}
		public double MaxComp()
		{
			return Math.Max(x, Math.Max(y, z));
		}
		public vec3m Normalize()
		{
			double length = this.Length();
			if (length == 0)
				throw new ArgumentException("Cannot normalize zero length vector");
			return this / length;
		}
		public vec3m Abs()
		{
			return new vec3m(Math.Abs(x), Math.Abs(y), Math.Abs(z));
		}
		public static double Dot(vec3m a, vec3m b)
		{
			return a.x * b.x + a.y * b.y + a.z * b.z;
		}
		public static vec3m Cross(vec3m a, vec3m b)
		{
			return new vec3m(
				a.y * b.z - a.z * b.y,
				a.z * b.x - a.x * b.z,
				a.x * b.y - a.y * b.x);
		}
		public static vec3m Max(vec3m a, double b)
		{
			return new vec3m(Math.Max(a.x, b), Math.Max(a.y, b), Math.Max(a.z, b));
		}
		public static vec3m Min(vec3m a, double b)
		{
			return new vec3m(Math.Min(a.x, b), Math.Min(a.y, b), Math.Min(a.z, b));
		}
		override public string ToString()
		{
			return "[" + "\t" + x + "\t" + y + "\t" + z + "\t" + "]";
		}
	}
}