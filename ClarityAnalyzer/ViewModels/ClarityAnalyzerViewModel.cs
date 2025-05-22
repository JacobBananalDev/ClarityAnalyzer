using ClarityAnalyzer.Base;

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
            // Initialize properties here if needed
        }
    }
}
