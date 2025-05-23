using ClarityAnalyzer.Helpers;
using ClarityAnalyzer.Models;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace ClarityAnalyzer.ViewModels
{
    public partial class ClarityAnalyzerViewModel
    {
        private Bitmap m_OriginalBitmap = null;
        private Bitmap m_CurrentBitmap = null;

        public ObservableCollection<string> AvailableFilters { get; private set; }

        private BitmapImage m_ImageViewer = null;
        public BitmapImage ImageViewer
        {
            get => m_ImageViewer;
            set => SetProperty(ref m_ImageViewer, value);
        }

        private string m_SelectedFilter = string.Empty;
        public string SelectedFilter
        {
            get => m_SelectedFilter;
            set => SetProperty(ref m_SelectedFilter, value);
        }

        private int m_BrightnessValue = 0;
        public int BrightnessValue
        {
            get => m_BrightnessValue;
            set => SetProperty(ref m_BrightnessValue, value);
        }

        private int m_ContrastValue = 0;
        public int ContrastValue
        {
            get => m_ContrastValue;
            set => SetProperty(ref m_ContrastValue, value);
        }

        private Bitmap ApplyAllAdjustments()
        {
            if (m_CurrentBitmap != null)
            {
                Bitmap temp = (Bitmap)m_CurrentBitmap.Clone();
                return ImageProcessor.Instance.ApplyAdjustments(temp, BrightnessValue, ContrastValue);
            }
            return null;
        }
    }
}
