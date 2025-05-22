using System.Windows;
using System.Windows.Controls;

namespace ClarityAnalyzer.Controls
{
    public class ClarityAnalyzerComboBoxItem : ComboBoxItem
    {
        static ClarityAnalyzerComboBoxItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ClarityAnalyzerComboBoxItem), new FrameworkPropertyMetadata(typeof(ClarityAnalyzerComboBoxItem)));
        }
    }
}
