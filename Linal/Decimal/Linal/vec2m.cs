using System;
namespace PinkCasio.Decimal.Linal
{
	public struct vec2m
	{
		public decimal x, y;		
		public vec2m(decimal x, decimal y)
		{
			this.x = x;
			this.y = y;
		}
		public vec2m(decimal a)
		{
			this.x = a;
			this.y = a;
		}
		public static vec2m operator +(vec2m a, vec2m b)
		{
			return new vec2m(a.x + b.x, a.y + b.y);
		}
		public static vec2m operator -(vec2m a, vec2m b)
		{
			return new vec2m(a.x - b.x, a.y - b.y);
		}
		public static vec2m operator *(decimal d, vec2m v)
		{
			return new vec2m(d * v.x, d * v.y);
		}
		public static vec2m operator /(vec2m v, decimal d)
		{
			if (d == 0)
				throw new ArgumentException("Cannot divide by zero");
			return new vec2m(v.x / d, v.y / d);
		}
		public static vec2m operator *(matrix2x2m m, vec2m v)
		{
			return v.x * m.i + v.y * m.j;
		}
		public decimal Length()
		{
			return Mathm.Sqrt(x * x + y * y);
		}
		public decimal MaxComp()
		{
			return Math.Max(x, y);
		}
		public vec2m Normalize()
		{
			decimal length = this.Length();
			if (length == 0)
				throw new ArgumentException("Cannot normalize zero length vector");
			return this / length;
		}
		public vec2m Abs()
		{
			return new vec2m(Math.Abs(x), Math.Abs(y));
		}
		public static decimal Dot(vec2m a, vec2m b)
		{
			return a.x * b.x + a.y * b.y;
		}
		public static vec2m Max(vec2m a, decimal b)
		{
			return new vec2m(Math.Max(a.x, b), Math.Max(a.y, b));
		}
		public static vec2m Min(vec2m a, decimal b)
		{
			return new vec2m(Math.Min(a.x, b), Math.Min(a.y, b));
		}
		override public string ToString()
		{
			return "[" + "\t" + x + "\t" + y + "\t" + "]";
		}
	}
}