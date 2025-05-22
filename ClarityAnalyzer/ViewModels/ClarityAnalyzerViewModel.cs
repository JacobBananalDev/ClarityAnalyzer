using ClarityAnalyzer.Base;
using System.Collections.ObjectModel;

namespace ClarityAnalyzer.ViewModels
{
    public partial class ClarityAnalyzerViewModel : ViewModelBase
    {
        private static ClarityAnalyzerViewModel m_Instance = null;
        internal static ClarityAnalyzerViewModel Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new ClarityAnalyzerViewModel();
                }
                return m_Instance;
            }
        }

        private ClarityAnalyzerViewModel()
        {
            AvailableFilters = new ObservableCollection<string>
            {
                "Sharpen",
                "Box Blur",
                "Gaussian Blur",
                "Edge Detect - Horizontal",
                "Edge Detect - Vertical"
            };

            SelectedFilter = AvailableFilters[0];
        }
    }
}
