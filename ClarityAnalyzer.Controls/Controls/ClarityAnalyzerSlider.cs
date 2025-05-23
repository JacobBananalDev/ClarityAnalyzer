using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ClarityAnalyzer.Controls
{
    public class ClarityAnalyzerSlider : Slider
    {
        private DispatcherTimer debounceTimer;
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

        public static readonly RoutedEvent DebouncedValueChangedEvent = EventManager.RegisterRoutedEvent(
          "DebouncedValueChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<double>), typeof(ClarityAnalyzerSlider));

        public event RoutedPropertyChangedEventHandler<double> DebouncedValueChanged
        {
            add { AddHandler(DebouncedValueChangedEvent, value); }
            remove { RemoveHandler(DebouncedValueChangedEvent, value); }
        }

        public ClarityAnalyzerSlider()
        {
            debounceTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(200)
            };
            debounceTimer.Tick += DebounceTimer_Tick;
            ValueChanged += ClarityAnalyzerSlider_ValueChanged;
        }

        private void ClarityAnalyzerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            debounceTimer.Stop();
            debounceTimer.Tag = e; // Store latest args
            debounceTimer.Start();
        }

        private void DebounceTimer_Tick(object sender, EventArgs e)
        {
            debounceTimer.Stop();
            if (debounceTimer.Tag is RoutedPropertyChangedEventArgs<double> args)
            {
                RaiseEvent(new RoutedPropertyChangedEventArgs<double>(args.OldValue, args.NewValue, DebouncedValueChangedEvent));
            }
        }
    }
}
