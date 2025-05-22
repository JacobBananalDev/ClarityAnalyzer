using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace ClarityAnalyzer.Helpers
{
    internal static class ImageHelper
    {
        public static BitmapImage ToBitMapImage(Bitmap source)
        {
            if (source == null)
            {
                return null;
            }

            using (var ms = new MemoryStream())
            {
                // Save the bitmap to the memory stream.
                ((System.Drawing.Bitmap)source).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                // Create and initialize the BitmapImage.
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // Ensure the stream is fully loaded into memory.
                ms.Seek(0, SeekOrigin.Begin); // Reset the stream position.
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
    }
}
