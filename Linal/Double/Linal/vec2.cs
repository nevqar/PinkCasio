using System;
namespace PinkCasio.Double.Linal
{
	public struct vec2
	{
		public double x, y;		
		public vec2(double x, double y)
		{
			this.x = x;
			this.y = y;
		}
		public vec2(double a)
		{
			this.x = a;
			this.y = a;
		}
		public static vec2 operator +(vec2 a, vec2 b)
		{
			return new vec2(a.x + b.x, a.y + b.y);
		}
		public static vec2 operator -(vec2 a, vec2 b)
		{
			return new vec2(a.x - b.x, a.y - b.y);
		}
		public static vec2 operator *(double d, vec2 v)
		{
			return new vec2(d * v.x, d * v.y);
		}
		public static vec2 operator /(vec2 v, double d)
		{
			if (d == 0)
				throw new ArgumentException("Cannot divide by zero");
			return new vec2(v.x / d, v.y / d);
		}
		public static vec2 operator *(matrix2x2 m, vec2 v)
		{
			return v.x * m.i + v.y * m.j;
		}
		public double Length()
		{
			return Math.Sqrt(x * x + y * y);
		}
		public double MaxComp()
		{
			return Math.Max(x, y);
		}
		public vec2 Normalize()
		{
			double length = this.Length();
			if (length == 0)
				throw new ArgumentException("Cannot normalize zero length vector");
			return this / length;
		}
		public vec2 Abs()
		{
			return new vec2(Math.Abs(x), Math.Abs(y));
		}
		public static double Dot(vec2 a, vec2 b)
		{
			return a.x * b.x + a.y * b.y;
		}
		public static vec2 Max(vec2 a, double b)
		{
			return new vec2(Math.Max(a.x, b), Math.Max(a.y, b));
		}
		public static vec2 Min(vec2 a, double b)
		{
			return new vec2(Math.Min(a.x, b), Math.Min(a.y, b));
		}
		override public string ToString()
		{
			return "[" + "\t" + x + "\t" + y + "\t" + "]";
		}
	}
}