using System.Collections.ObjectModel;
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
    }
}
