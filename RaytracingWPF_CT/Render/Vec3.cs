using System;

namespace RaytracingWPF_CT.Render
{
    public class Vec3
    {
        private const double Tolerance = 0.000001;

        public Vec3(double x1, double x2, double x3)
        {
            X1 = x1;
            X2 = x2;
            X3 = x3;
        }

        public double X1 { get; }
        public double X2 { get; }
        public double X3 { get; }

        public static Vec3 operator +(Vec3 a)
        {
            return a;
        }

        public static Vec3 operator -(Vec3 a)
        {
            return new Vec3(-a.X1, -a.X2, -a.X3);
        }

        public static Vec3 operator +(Vec3 a, Vec3 b)
        {
            return new Vec3(a.X1 + b.X1, a.X2 + b.X2, a.X3 + b.X3);
        }

        public static Vec3 operator -(Vec3 a, Vec3 b)
        {
            return new Vec3(a.X1 - b.X1, a.X2 - b.X2, a.X3 - b.X3);
        }

        public static Vec3 operator *(Vec3 a, double c)
        {
            return new Vec3(a.X1 * c, a.X2 * c, a.X3 * c);
        }

        public static Vec3 operator *(double c, Vec3 a)
        {
            return new Vec3(a.X1 * c, a.X2 * c, a.X3 * c);
        }

        public static double operator *(Vec3 a, Vec3 b)
        {
            return a.X1 * b.X1 + a.X2 * b.X2 + a.X3 * b.X3;
        }

        public static Vec3 operator /(Vec3 a, double c)
        {
            if (c <= 0) throw new ArgumentOutOfRangeException(nameof(c));
            return new Vec3(a.X1 / c, a.X2 / c, a.X3 / c);
        }

        public static Vec3 operator /(double c, Vec3 a)
        {
            if (c <= 0) throw new ArgumentOutOfRangeException(nameof(c));
            return new Vec3(a.X1 / c, a.X2 / c, a.X3 / c);
        }

        public static bool operator ==(Vec3 a, Vec3 b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;
            return Math.Abs(a.X1 - b.X1) < Tolerance && Math.Abs(a.X2 - b.X2) < Tolerance &&
                   Math.Abs(a.X3 - b.X3) < Tolerance;
        }

        public static bool operator !=(Vec3 a, Vec3 b)
        {
            if (a is null && b is null) return false;
            if (a is null || b is null) return true;
            return Math.Abs(a.X1 - b.X1) > Tolerance || Math.Abs(a.X2 - b.X2) > Tolerance ||
                   Math.Abs(a.X3 - b.X3) > Tolerance;
        }

        public static Vec3 CrossProduct(Vec3 a, Vec3 b)
        {
            return new Vec3(a.X2 * b.X3 - a.X3 * b.X2, a.X3 * b.X1 - a.X1 * b.X3, a.X1 * b.X2 - a.X2 * b.X1);
        }

        public double GetLength()
        {
            return Math.Sqrt(X1 * X1 + X2 * X2 + X3 * X3);
        }

        public Vec3 GetUnitVector()
        {
            //Causes the program to crash if the vectors length is zero.
            return this / GetLength();
        }

        public override string ToString()
        {
            return $"({X1}, {X2}, {X3})";
        }

        private bool Equals(Vec3 other)
        {
            return X1.Equals(other.X1) && X2.Equals(other.X2) && X3.Equals(other.X3);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Vec3) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X1.GetHashCode();
                hashCode = (hashCode * 397) ^ X2.GetHashCode();
                hashCode = (hashCode * 397) ^ X3.GetHashCode();
                return hashCode;
            }
        }
    }
}