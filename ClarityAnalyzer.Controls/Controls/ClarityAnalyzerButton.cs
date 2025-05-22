using System.Windows;
using System.Windows.Controls;

namespace ClarityAnalyzer.Controls
{
    public class ClarityAnalyzerButton : Button
    {
        static ClarityAnalyzerButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ClarityAnalyzerButton), new FrameworkPropertyMetadata(typeof(ClarityAnalyzerButton)));
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register
            (nameof(CornerRadius), typeof(CornerRadius), typeof(ClarityAnalyzerButton), new PropertyMetadata(default(CornerRadius)));
    }
}
