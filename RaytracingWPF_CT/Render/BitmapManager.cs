using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RaytracingWPF_CT.Render
{
    public static class BitmapManager
    {
        public static BitmapSource SaveToBmp(int width, int height, byte[] pixelData)
        {
            return BitmapSource.Create(
                width,
                height,
                300,
                300,
                PixelFormats.Bgr32,
                null,
                pixelData,
                width * 4
            );
        }
    }
}