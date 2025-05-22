using ClarityAnalyzer.ViewModels;
using System.Windows;

namespace ClarityAnalyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClarityAnalyzerViewModel m_ClarityAnalyzerVM => ClarityAnalyzerViewModel.Instance;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = m_ClarityAnalyzerVM;
        }
    }
}
