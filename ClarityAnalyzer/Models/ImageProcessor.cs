using ClarityAnalyzer.Base;
using ClarityAnalyzer.Helpers;
using System.Drawing;

namespace ClarityAnalyzer.Models
{
    internal class ImageProcessor : SingletonBase<ImageProcessor>
    {
        private ImageProcessor()
        {
            // Initialize properties here if needed
        }

        /// <summary>
        /// Converts an image to grayscale using luminance-based formula.
        /// </summary>
        internal Bitmap ApplyGrayscale(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color original = source.GetPixel(x, y);
                    int gray = (int)(0.3 * original.R + 0.59 * original.G + 0.11 * original.B);
                    result.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            return result;
        }

        /// <summary>
        /// Inverts the colors of an image.
        /// </summary>
        internal Bitmap ApplyInvert(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color original = source.GetPixel(x, y);
                    result.SetPixel(x, y, Color.FromArgb(255 - original.R, 255 - original.G, 255 - original.B));
                }
            }
            return result;
        }

        internal Bitmap ApplySharpen(Bitmap source)
        {
            return ConvolutionHelper.ApplyConvolution(source, ConvolutionKernel.Sharpen3x3);
        }

        internal Bitmap ApplyBoxBlur(Bitmap source)
        {
            return ConvolutionHelper.ApplyConvolution(source, ConvolutionKernel.BoxBlur3x3);
        }

        internal Bitmap ApplyGaussianBlur(Bitmap source)
        {
            return ConvolutionHelper.ApplyConvolution(source, ConvolutionKernel.GaussianBlur3x3);
        }

        internal Bitmap ApplyEdgeDetectHorizontal(Bitmap source)
        {
            return ConvolutionHelper.ApplyConvolution(source, ConvolutionKernel.EdgeDetectHorizontal3x3);
        }

        internal Bitmap ApplyEdgeDetectVertical(Bitmap source)
        {
            return ConvolutionHelper.ApplyConvolution(source, ConvolutionKernel.EdgeDetectVertical3x3);
        }

    }
}
