using System.Windows;
using System.Windows.Controls;

namespace ClarityAnalyzer.Controls
{
    public class ClarityAnalyzerTabControl : TabControl
    {
        static ClarityAnalyzerTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ClarityAnalyzerTabControl), new FrameworkPropertyMetadata(typeof(ClarityAnalyzerTabControl)));
        }
    }
}
