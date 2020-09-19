using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using WrappedUwpTextBlock4.WrappedUwpControls.Containers;
using UWP = Windows.UI;

namespace WrappedUwpTextBlock4.WrappedUwpControls
{
    public class UwpTextBlock : Microsoft.Toolkit.Wpf.UI.XamlHost.WindowsXamlHost
    {
        private readonly UWP.Xaml.Controls.TextBlock _myTextBlock;

        public UwpTextBlock()
        {
            var myTextBlock = Microsoft.Toolkit.Win32.UI.XamlHost.UWPTypeFactory.CreateXamlContentByType(
                "Windows.UI.Xaml.Controls.TextBlock") as UWP.Xaml.Controls.TextBlock;
            this.Child = myTextBlock;
            _myTextBlock = myTextBlock;
        }

        public static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.Register(nameof(FontSize), typeof(double),
                typeof(UwpTextBlock), new PropertyMetadata(System.Windows.SystemFonts.MessageFontSize,
                    new PropertyChangedCallback(OnFontSizeChanged)));

        private static void OnFontSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UwpTextBlock uwpTextBlock)
            {
                if (e.Property.Name == nameof(FontSize))
                {
                    uwpTextBlock._myTextBlock.FontSize = (double)e.NewValue;
                }
            }
        }

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static readonly DependencyProperty FontWeightProperty =
            DependencyProperty.Register(nameof(FontWeight), typeof(FontWeight),
                typeof(UwpTextBlock), new PropertyMetadata(SystemFonts.MenuFontWeight,
                    new PropertyChangedCallback(OnFontWeightChanged)));

        private static void OnFontWeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UwpTextBlock uwpTextBlock)
            {
                if (e.Property.Name == nameof(FontWeight))
                {
                    uwpTextBlock._myTextBlock.FontWeight = WpfUwpConverter.Convert((FontWeight)e.NewValue);
                }
            }
        }

        public FontWeight FontWeight
        {
            get => (FontWeight)GetValue(FontWeightProperty);
            set => SetValue(FontWeightProperty, value);
        }

        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register(nameof(Foreground), typeof(Brush),
                typeof(UwpTextBlock), new PropertyMetadata(Brushes.Black,
                    new PropertyChangedCallback(OnForegroundChanged)));

        private static void OnForegroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UwpTextBlock uwpTextBlock)
            {
                if (e.Property.Name == nameof(Foreground))
                {
                    var brush = (Brush)e.NewValue;
                    uwpTextBlock._myTextBlock.Foreground = brush != null ?
                        WpfUwpConverter.Convert(brush) : new UWP.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Black);
                }
            }
        }

        public Brush Foreground
        {
            get => (Brush)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string),
                typeof(UwpTextBlock), new PropertyMetadata(string.Empty,
                    new PropertyChangedCallback(OnTextChanged)));

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UwpTextBlock uwpTextBlock)
            {
                if (e.Property.Name == nameof(Text))
                {
                    uwpTextBlock._myTextBlock.Text = e.NewValue != null ? (string)e.NewValue : string.Empty;
                }
            }
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private static readonly DependencyProperty InlinesProperty =
            DependencyProperty.Register(nameof(Inlines), typeof(InlineDataContainer),
                typeof(UwpTextBlock), new PropertyMetadata(null,
                    new PropertyChangedCallback(OnInlinesChanged)));

        private static void OnInlinesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UwpTextBlock uwpTextBlock)
            {
                var container = (InlineDataContainer)e.NewValue;
                if (container == null)
                {
                    uwpTextBlock._myTextBlock.Inlines.Clear();
                    return;
                }
                var inlines = GetInlines(container);
                if (container.Operation == InlineDataOperation.Replace)
                {
                    uwpTextBlock._myTextBlock.Inlines.Clear();
                }
                foreach (var n in inlines)
                {
                    uwpTextBlock._myTextBlock.Inlines.Add(n);
                }
            }
        }

        private static IEnumerable<UWP.Xaml.Documents.Inline> GetInlines(InlineDataContainer container)
        {
            var builder = new UwpInlineBuilder();

            foreach (var (containtKind, text, urlString) in container.Container)
            {
                switch (containtKind)
                {
                    case ContaintKind.Text:
                        builder.AddText(text);
                        break;
                    case ContaintKind.NewLine:
                        builder.AddLineBreak();
                        break;
                    case ContaintKind.Uri:
                        builder.AddLink(text, urlString);
                        break;
                    default:
                        throw new NotImplementedException(containtKind.ToString());
                }
            }

            return builder.ToInLines();
        }

        public InlineDataContainer Inlines
        {
            get => (InlineDataContainer)GetValue(InlinesProperty);
            set => SetValue(InlinesProperty, value);
        }

        public static readonly DependencyProperty IsTextSelectionEnabledProperty =
            DependencyProperty.Register(nameof(IsTextSelectionEnabled), typeof(bool),
                typeof(UwpTextBlock), new PropertyMetadata(false,
                    new PropertyChangedCallback(OnIsTextSelectionEnabledChanged)));

        private static void OnIsTextSelectionEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UwpTextBlock uwpTextBlock)
            {
                if (e.Property.Name == nameof(IsTextSelectionEnabled))
                {
                    uwpTextBlock._myTextBlock.IsTextSelectionEnabled = (bool)e.NewValue;
                }
            }
        }

        public bool IsTextSelectionEnabled
        {
            get => (bool)GetValue(IsTextSelectionEnabledProperty);
            set => SetValue(IsTextSelectionEnabledProperty, value);
        }

        public static readonly DependencyProperty TextWrappingProperty =
            DependencyProperty.Register(nameof(TextWrapping), typeof(System.Windows.TextWrapping),
                typeof(UwpTextBlock), new PropertyMetadata(System.Windows.TextWrapping.NoWrap,
                    new PropertyChangedCallback(OnTextWrappingChanged)));

        private static void OnTextWrappingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UwpTextBlock uwpTextBlock)
            {
                if (e.Property.Name == nameof(TextWrapping))
                {
                    uwpTextBlock._myTextBlock.TextWrapping = WpfUwpConverter.Convert((System.Windows.TextWrapping)e.NewValue);
                }
            }
        }

        public System.Windows.TextWrapping TextWrapping
        {
            get => (System.Windows.TextWrapping)GetValue(TextWrappingProperty);
            set => SetValue(TextWrappingProperty, value);
        }
    }
}
