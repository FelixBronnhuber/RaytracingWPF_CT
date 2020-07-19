using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

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

        public static void SaveToPng(BitmapSource bitmapSource)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Image files (*.png)|*.png;*.jpeg|All files (*.*)|*.*"
            };
            if (saveFileDialog.ShowDialog() != true) return;
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
            FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create);
            encoder.Save(stream);
            stream.Close();
        }
    }
}