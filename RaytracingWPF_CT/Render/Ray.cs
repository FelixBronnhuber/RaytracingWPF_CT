namespace RaytracingWPF_CT.Render
{
    public class Ray
    {
        public Ray(Vec3 origin, Vec3 direction)
        {
            Origin = origin;
            Direction = direction;
        }

        public Vec3 Origin { get; set; }
        public Vec3 Direction { get; set; }

        public Vec3 Lambda(double lambda)
        {
            return Origin + Direction * lambda;
        }
    }
}