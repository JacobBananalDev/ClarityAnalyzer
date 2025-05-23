using System.Windows;
using System.Windows.Controls;

namespace ClarityAnalyzer.Controls
{
    public class ClarityAnalyzerSlider : Slider
    {
        static ClarityAnalyzerSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ClarityAnalyzerSlider), new FrameworkPropertyMetadata(typeof(ClarityAnalyzerSlider)));
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register
            (nameof(CornerRadius), typeof(CornerRadius), typeof(ClarityAnalyzerSlider), new PropertyMetadata(default(CornerRadius)));

        public bool CanIncrement
        {
            get { return (bool)GetValue(CanIncrementProperty); }
            set { SetValue(CanIncrementProperty, value); }
        }
        public static readonly DependencyProperty CanIncrementProperty = DependencyProperty.Register
            (nameof(CanIncrement), typeof(bool), typeof(ClarityAnalyzerSlider), new PropertyMetadata(true));

        public bool CanDecrement
        {
            get { return (bool)GetValue(CanDecrementProperty); }
            set { SetValue(CanDecrementProperty, value); }
        }
        public static readonly DependencyProperty CanDecrementProperty = DependencyProperty.Register
            (nameof(CanDecrement), typeof(bool), typeof(ClarityAnalyzerSlider), new PropertyMetadata(true));
    }
}
