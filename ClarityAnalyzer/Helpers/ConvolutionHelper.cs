using System;
using System.Drawing;

namespace ClarityAnalyzer.Helpers
{
    /// <summary>
    /// Provides a method for applying a 3x3 convolution kernel to a Bitmap image.
    /// </summary>
    public static class ConvolutionHelper
    {
        /// <summary>
        /// Applies a 3x3 convolution kernel to the input Bitmap and returns the filtered image.
        /// This method assumes the input image is grayscale for simplicity.
        /// </summary>
        /// <param name="source">The source bitmap image.</param>
        /// <param name="kernel">A 3x3 convolution kernel matrix.</param>
        /// <returns>A new Bitmap with the convolution applied.</returns>
        public static Bitmap ApplyConvolution(Bitmap source, double[,] kernel)
        {
            if (kernel.GetLength(0) != 3 || kernel.GetLength(1) != 3)
                throw new ArgumentException("Only 3x3 kernels are supported.");

            int width = source.Width;
            int height = source.Height;
            Bitmap result = new Bitmap(width, height);

            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    double pixelValue = 0;

                    // Apply the 3x3 kernel
                    for (int ky = -1; ky <= 1; ky++)
                    {
                        for (int kx = -1; kx <= 1; kx++)
                        {
                            Color neighbor = source.GetPixel(x + kx, y + ky);
                            int gray = (int)(0.3 * neighbor.R + 0.59 * neighbor.G + 0.11 * neighbor.B);
                            pixelValue += gray * kernel[ky + 1, kx + 1];
                        }
                    }

                    // Clamp to [0, 255]
                    int finalGray = Math.Max(0, Math.Min(255, (int)pixelValue));
                    Color outputColor = Color.FromArgb(finalGray, finalGray, finalGray);
                    result.SetPixel(x, y, outputColor);
                }
            }

            return result;
        }
    }
}
