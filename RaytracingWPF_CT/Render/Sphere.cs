#nullable enable
using System;

namespace RaytracingWPF_CT.Render
{
    public class Sphere : IPrimitive
    {
        public Sphere(Vec3 origin, double radius, Color color)
        {
            Origin = origin;
            Radius = radius;
            Color = color;
        }

        public double Radius { get; set; }
        public Color Color { get; set; }

        public Vec3 Origin { get; set; }

        public Vec3? CollisionPoint(Ray ray)
        {
            Vec3 v = ray.Origin - Origin;
            double a = ray.Direction * ray.Direction;
            double b = 2 * (ray.Direction * v);
            double disc = b * b - 4 * a * (v * v - Radius * Radius);

            if (disc <= 0) return null;

            double lambda0 = (-b + Math.Sqrt(disc)) / (2 * a);
            double lambda1 = (-b - Math.Sqrt(disc)) / (2 * a);

            if (lambda0 < 0) return lambda1 < 0 ? null : ray.Lambda(lambda1);

            Vec3 p0 = ray.Lambda(lambda0);
            Vec3 p1 = ray.Lambda(lambda1);

            if (p0.X1 < 0) return p1.X1 < 0 ? null : p1;

            double distance0 = p0.GetLength();
            double distance1 = p1.GetLength();

            return distance0 < distance1 ? p0 : p1;
        }

        public Color GetColor()
        {
            return Color;
        }
    }
}