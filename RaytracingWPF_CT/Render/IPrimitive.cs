#nullable enable

namespace RaytracingWPF_CT.Render
{
    public interface IPrimitive
    {
        public Vec3 Origin { get; set; }
        public Vec3? CollisionPoint(Ray ray);
        public Color GetColor();
    }
}