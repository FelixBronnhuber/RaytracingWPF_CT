using System;
using RaytracingWPF_CT.ViewModel;
using static System.Byte;

namespace RaytracingWPF_CT.Render
{
    public class RenderMain
    {
        private readonly int _height;
        private readonly IPrimitive[] _primitives;
        private readonly int _width;

        public RenderMain(MainViewModel mainViewModel, string input)
        {
            Scene scene = Parser.Parse(input);
            if (!scene.ParseCompleted) return;
            _width = scene.Width;
            _height = scene.Height;
            _primitives = scene.ConvertToArray();
            byte[] pixelData = RenderPixels();
            mainViewModel.BitmapSource = BitmapManager.SaveToBmp(_width, _height, pixelData);
        }

        private byte[] RenderPixels()
        {
            Console.WriteLine(_primitives.Length);
            byte[] pixelData = new byte[_width * _height * 4];
            double width = Convert.ToDouble(_width);
            double height = Convert.ToDouble(_height);
            double d = -(Convert.ToDouble(_width) / 2 / Math.Tan(Math.PI / 4));
            Vec3 start = new Vec3(d, 0, 0);

            for (int x = 0; x < _width; x++)
            for (int y = 0; y < _height; y++)
            {
                Vec3 direction = new Vec3(
                    -d,
                    Convert.ToDouble(x) - Convert.ToDouble(width / 2),
                    Convert.ToDouble(y) - Convert.ToDouble(height / 2)
                );

                Color color = GetColor(new Ray(start, direction));

                pixelData[(y * _width + x) * 4] = color.B;
                pixelData[(y * _width + x) * 4 + 1] = color.G;
                pixelData[(y * _width + x) * 4 + 2] = color.R;
                pixelData[(y * _width + x) * 4 + 3] = MaxValue;
            }

            return pixelData;
        }

        private Color GetColor(Ray ray)
        {
            double minDistance = double.MaxValue;
            double t = 0.5 * (-ray.Direction.GetUnitVector().X3 + 1.0);
            Color color = new Color(
                Convert.ToByte(255 * (1.0 - t + t * 0.3)),
                Convert.ToByte(255 * (1.0 - t + t * 0.7)),
                Convert.ToByte(255 * (1.0 - t + t * 1.0))
            );

            Vec3 actualHitpoint = null;
            Vec3 normal = null;
            foreach (IPrimitive primitive in _primitives)
            {
                Vec3 collisionPoint = primitive.CollisionPoint(ray);

                if (collisionPoint == null) continue;

                Vec3 vec = ray.Origin - collisionPoint;
                double distance = vec.GetLength();

                if (!(distance < minDistance)) continue;

                minDistance = distance;
                actualHitpoint = collisionPoint;

                //color = primitive.GetColor();
                normal = (primitive.Origin - collisionPoint).GetUnitVector();
                color = new Color(
                    Convert.ToByte(0.5 * (normal.X3 + 1.0) * 255),
                    Convert.ToByte(0.5 * (normal.X2 + 1.0) * 255),
                    Convert.ToByte(0.5 * (normal.X1 + 1.0) * 255)
                );
            }
            
            //Shadow- or Light-Raycast:

            if (actualHitpoint == null) return color;
            
            Vec3 lightSource = new Vec3(1000, 1000, 0);
            Ray lightRay = new Ray(actualHitpoint, normal);

            foreach (IPrimitive primitive in _primitives)
            {
                Vec3 point = primitive.CollisionPoint(lightRay);
                if (point != null && (point != actualHitpoint))
                {
                    Vec3 c = new Vec3(color.R, color.G, color.B) * 0.5;
                    return new Color((byte) c.X1, (byte) c.X2, (byte) c.X3);
                }
            }

            return color;
        }
    }
}