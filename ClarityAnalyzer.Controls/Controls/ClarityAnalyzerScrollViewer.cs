using System.Windows;
using System.Windows.Controls;

namespace ClarityAnalyzer.Controls
{
    public class ClarityAnalyzerScrollViewer : ScrollViewer
    {
        static ClarityAnalyzerScrollViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ClarityAnalyzerScrollViewer), new FrameworkPropertyMetadata(typeof(ClarityAnalyzerScrollViewer)));
        }
    }
}
