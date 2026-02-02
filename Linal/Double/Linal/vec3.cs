using System;
namespace PinkCasio.Double.Linal
{
	public struct vec3
	{
		public double x, y, z;	
		public vec3(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public vec3(double a)
		{
			this.x = a;
			this.y = a;
			this.z = a;
		}
		public static vec3 operator +(vec3 a, vec3 b)
		{
			return new vec3(a.x + b.x, a.y + b.y, a.z + b.z);
		}
		public static vec3 operator -(vec3 a, vec3 b)
		{
			return new vec3(a.x - b.x, a.y - b.y, a.z - b.z);
		}
		public static vec3 operator *(double d, vec3 v)
		{
			return new vec3(d * v.x, d * v.y, d * v.z);
		}
		public static vec3 operator /(vec3 a, double b)
		{
			if (b == 0)
				throw new ArgumentException("Cannot divide by zero");
			return new vec3(a.x / b, a.y / b, a.z / b);
		}
		public static vec3 operator *(matrix3x3 m, vec3 v)
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
		public vec3 Normalize()
		{
			double length = this.Length();
			if (length == 0)
				throw new ArgumentException("Cannot normalize zero length vector");
			return this / length;
		}
		public vec3 Abs()
		{
			return new vec3(Math.Abs(x), Math.Abs(y), Math.Abs(z));
		}
		public static double Dot(vec3 a, vec3 b)
		{
			return a.x * b.x + a.y * b.y + a.z * b.z;
		}
		public static vec3 Cross(vec3 a, vec3 b)
		{
			return new vec3(
				a.y * b.z - a.z * b.y,
				a.z * b.x - a.x * b.z,
				a.x * b.y - a.y * b.x);
		}
		public static vec3 Max(vec3 a, double b)
		{
			return new vec3(Math.Max(a.x, b), Math.Max(a.y, b), Math.Max(a.z, b));
		}
		public static vec3 Min(vec3 a, double b)
		{
			return new vec3(Math.Min(a.x, b), Math.Min(a.y, b), Math.Min(a.z, b));
		}
		override public string ToString()
		{
			return "[" + "\t" + x + "\t" + y + "\t" + z + "\t" + "]";
		}
	}
}