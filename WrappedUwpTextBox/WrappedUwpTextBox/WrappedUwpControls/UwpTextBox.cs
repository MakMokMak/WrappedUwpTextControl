using System.Windows;
using UWP = Windows.UI;

namespace WrappedUwpTextBox.WrappedUwpControls
{
    public class UwpTextBox : Microsoft.Toolkit.Wpf.UI.XamlHost.WindowsXamlHost
    {
        private readonly UWP.Xaml.Controls.TextBox _myTextBox;

        public UwpTextBox()
        {
            var myTextBox = Microsoft.Toolkit.Win32.UI.XamlHost.UWPTypeFactory.CreateXamlContentByType(
                "Windows.UI.Xaml.Controls.TextBox") as UWP.Xaml.Controls.TextBox;
            this.Child = myTextBox;
            myTextBox.TextChanged += OnUwpTextBoxTextChanged;
            _myTextBox = myTextBox;
        }

        public static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.Register(nameof(FontSize), typeof(double),
                typeof(UwpTextBox), new PropertyMetadata(System.Windows.SystemFonts.MessageFontSize,
                    new PropertyChangedCallback(OnFontSizeChanged)));

        private static void OnFontSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UwpTextBox uwpTextBox)
            {
                if (e.Property.Name == nameof(FontSize))
                {
                    uwpTextBox._myTextBox.FontSize = (double)e.NewValue;
                }
            }
        }

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register(nameof(IsReadOnly), typeof(bool),
                typeof(UwpTextBox), new PropertyMetadata(false,
                    new PropertyChangedCallback(OnIsReadOnlyChanged)));

        private static void OnIsReadOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UwpTextBox uwpTextBox)
            {
                if (e.Property.Name == nameof(IsReadOnly))
                {
                    uwpTextBox._myTextBox.IsReadOnly = (bool)e.NewValue;
                }
            }
        }

        public bool IsReadOnly
        {
            get => (bool)GetValue(IsReadOnlyProperty);
            set => SetValue(IsReadOnlyProperty, value);
        }

        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.Register(nameof(PlaceholderText), typeof(string),
                typeof(UwpTextBox), new PropertyMetadata(string.Empty,
                    new PropertyChangedCallback(OnPlaceholderTextChanged)));

        private static void OnPlaceholderTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UwpTextBox uwpTextBox)
            {
                if (e.Property.Name == nameof(PlaceholderText))
                {
                    uwpTextBox._myTextBox.PlaceholderText = e.NewValue != null ? (string)e.NewValue : string.Empty;
                }
            }
        }

        public string PlaceholderText
        {
            get => (string)GetValue(PlaceholderTextProperty);
            set => SetValue(PlaceholderTextProperty, value);
        }

        public static readonly DependencyProperty TextProperty = 
            DependencyProperty.Register(nameof(Text), typeof(string),
                typeof(UwpTextBox),
                new FrameworkPropertyMetadata(
                    string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback(OnTextChanged)));

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UwpTextBox uwpTextBox)
            {
                if (e.Property.Name == nameof(Text) &&
                    uwpTextBox._myTextBox.Text != (string)e.NewValue)
                {
                    uwpTextBox._myTextBox.Text = e.NewValue != null ? (string)e.NewValue : string.Empty;
                }
            }
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private void OnUwpTextBoxTextChanged(object sender, UWP.Xaml.Controls.TextChangedEventArgs e)
        {
            // UWP の TextBox.Text の変更時に Text プロパティの書き換えをする必要がある。
            if ((string)GetValue(TextProperty) != _myTextBox.Text)
            {
                Text = _myTextBox.Text;
            }
        }
    }
}
