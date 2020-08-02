using System;
using WPF = System.Windows;
using UWP = Windows.UI;

namespace WrappedUwpTextBlock4.WrappedUwpControls
{
    internal class WpfUwpConverter
    {
        public static UWP.Text.FontWeight Convert(WPF.FontWeight fontWeight)
        {
            return (fontWeight.ToOpenTypeWeight()) switch
            {
                100 => UWP.Text.FontWeights.Thin,
                200 => UWP.Text.FontWeights.ExtraLight,
                300 => UWP.Text.FontWeights.Light,
                400 => UWP.Text.FontWeights.Normal,
                500 => UWP.Text.FontWeights.Medium,
                600 => UWP.Text.FontWeights.SemiBold,
                700 => UWP.Text.FontWeights.Bold,
                800 => UWP.Text.FontWeights.ExtraBold,
                900 => UWP.Text.FontWeights.Black,
                950 => UWP.Text.FontWeights.ExtraBlack,
                _ => throw new ArgumentException(nameof(fontWeight)),
            };
        }

        public static WPF.FontWeight Convert(UWP.Text.FontWeight fontWeight)
        {
            return (fontWeight.Weight) switch
            {
                100 => WPF.FontWeights.Thin,
                200 => WPF.FontWeights.ExtraLight,
                300 => WPF.FontWeights.Light,
                350 => WPF.FontWeights.Normal,
                400 => WPF.FontWeights.Normal,
                500 => WPF.FontWeights.Medium,
                600 => WPF.FontWeights.SemiBold,
                700 => WPF.FontWeights.Bold,
                800 => WPF.FontWeights.ExtraBold,
                900 => WPF.FontWeights.Black,
                950 => WPF.FontWeights.ExtraBlack,
                _ => throw new ArgumentException(nameof(fontWeight)),
            };
        }

        public static UWP.Xaml.Media.Brush Convert(WPF.Media.Brush brush)
        {
            if (brush == null) return null;

            return brush switch
            {
                WPF.Media.SolidColorBrush solidBrush => ConvertBrush(solidBrush),
                _ => throw new ArgumentException(nameof(brush)),
            };
        }

        public static WPF.Media.Brush Convert(UWP.Xaml.Media.Brush brush)
        {
            if (brush == null) return null;

            return brush switch
            {
                UWP.Xaml.Media.SolidColorBrush solidBrush => ConvertBrush(solidBrush),
                _ => throw new ArgumentException(nameof(brush)),
            };
        }

        private static UWP.Xaml.Media.Brush ConvertBrush(WPF.Media.SolidColorBrush solidBrush)
        {
            return new UWP.Xaml.Media.SolidColorBrush(Windows.UI.Color.FromArgb(
                solidBrush.Color.A, solidBrush.Color.R, solidBrush.Color.G, solidBrush.Color.B));
        }

        private static WPF.Media.Brush ConvertBrush(UWP.Xaml.Media.SolidColorBrush solidBrush)
        {
            return new WPF.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(
                solidBrush.Color.A, solidBrush.Color.R, solidBrush.Color.G, solidBrush.Color.B));
        }

        public static UWP.Xaml.TextWrapping Convert(WPF.TextWrapping textWrapping)
        {
            return textWrapping switch
            {
                WPF.TextWrapping.NoWrap => UWP.Xaml.TextWrapping.NoWrap,
                WPF.TextWrapping.Wrap => UWP.Xaml.TextWrapping.Wrap,
                WPF.TextWrapping.WrapWithOverflow => UWP.Xaml.TextWrapping.WrapWholeWords,
                _ => throw new ArgumentException(nameof(textWrapping)),
            };
        }

        public static WPF.TextWrapping Convert(UWP.Xaml.TextWrapping textWrapping)
        {
            return textWrapping switch
            {
                UWP.Xaml.TextWrapping.NoWrap => WPF.TextWrapping.NoWrap,
                UWP.Xaml.TextWrapping.Wrap => WPF.TextWrapping.Wrap,
                UWP.Xaml.TextWrapping.WrapWholeWords => WPF.TextWrapping.WrapWithOverflow,
                _ => throw new ArgumentException(nameof(textWrapping)),
            };
        }
    }
}
