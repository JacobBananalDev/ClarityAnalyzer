namespace ClarityAnalyzer.Helpers
{
    /// <summary>
    /// Provides static 3x3 convolution kernels commonly used in image processing.
    /// </summary>
    internal static class ConvolutionKernel
    {
        /// <summary>
        /// Returns a sharpen kernel that enhances edges and contrast.
        /// </summary>
        internal static double[,] Sharpen3x3
        {
            get
            {
                return new double[,]
                {
                    {  0, -1,  0 },
                    { -1,  5, -1 },
                    {  0, -1,  0 }
                };
            }
        }

        /// <summary>
        /// Returns a box blur kernel that averages surrounding pixels for basic blurring.
        /// </summary>
        internal static double[,] BoxBlur3x3
        {
            get
            {
                return new double[,]
                {
                    { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                    { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
                    { 1.0 / 9, 1.0 / 9, 1.0 / 9 }
                };
            }
        }

        /// <summary>
        /// Returns a Gaussian blur kernel for smoother, weighted blurring.
        /// </summary>
        internal static double[,] GaussianBlur3x3
        {
            get
            {
                return new double[,]
                {
                    { 1 / 16.0, 2 / 16.0, 1 / 16.0 },
                    { 2 / 16.0, 4 / 16.0, 2 / 16.0 },
                    { 1 / 16.0, 2 / 16.0, 1 / 16.0 }
                };
            }
        }

        /// <summary>
        /// Returns a horizontal edge detection kernel using the Sobel operator.
        /// </summary>
        internal static double[,] EdgeDetectHorizontal3x3
        {
            get
            {
                return new double[,]
                {
                    { -1, -2, -1 },
                    {  0,  0,  0 },
                    {  1,  2,  1 }
                };
            }
        }

        /// <summary>
        /// Returns a vertical edge detection kernel using the Sobel operator.
        /// </summary>
        internal static double[,] EdgeDetectVertical3x3
        {
            get
            {
                return new double[,]
                {
                    { -1,  0,  1 },
                    { -2,  0,  2 },
                    { -1,  0,  1 }
                };
            }
        }
    }
}
