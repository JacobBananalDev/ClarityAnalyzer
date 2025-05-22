using System.Windows;
using System.Windows.Controls;

namespace ClarityAnalyzer.Controls
{
    public class ClarityAnalyzerComboBox : ComboBox
    {
        static ClarityAnalyzerComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ClarityAnalyzerComboBox), new FrameworkPropertyMetadata(typeof(ClarityAnalyzerComboBox)));
        }
    }
}
