using Microsoft.Win32;
using System.Drawing;
using System.Drawing.Imaging;

namespace ClarityAnalyzer.Services
{
    /// <summary>
    /// Provides helper methods for loading and saving image files through file dialogs.
    /// </summary>
    internal static class FileService
    {
        /// <summary>
        /// Opens a file dialog and returns the selected image as a Bitmap.
        /// Supports JPG, PNG, and BMP formats.
        /// </summary>
        /// <returns>Bitmap of the loaded image or null if canceled.</returns>
        internal static Bitmap LoadImageFromDialog()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.png;*.bmp";
            if (dlg.ShowDialog() == true)
            {
                return new Bitmap(dlg.FileName);
            }
            return null;
        }

        /// <summary>
        /// Opens a save file dialog and saves the provided Bitmap as a PNG image.
        /// </summary>
        /// <param name="image">Bitmap image to save.</param>
        internal static void SaveImageToDialog(Bitmap image)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "PNG Image|*.png";
            if (dlg.ShowDialog() == true)
            {
                image.Save(dlg.FileName, ImageFormat.Png);
            }
        }
    }
}
