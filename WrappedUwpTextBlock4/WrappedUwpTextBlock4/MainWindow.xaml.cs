using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WrappedUwpTextBlock4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            var container = new WrappedUwpControls.Containers.InlineDataContainer();
            container.AddText("abcdefg ☺⛄☂♨⛅ ");
            container.AddLineBreak();
            container.AddLink("アカデミー賞", "https://ja.wikipedia.org/wiki/アカデミー賞");

            UwpTextBlock01.Inlines = container;
        }

        private void Button02_Click(object sender, RoutedEventArgs e)
        {
            var container = new WrappedUwpControls.Containers.InlineDataContainer();
            container.AddText("0123abcd ☺⛄☂♨⛅ abcdefghijklmnopqrstuvwxyz 0123456789 abcdefghijklmnopqrstuvwxyz");
            container.AddLineBreak();
            container.AddLink("アカデミー賞", "https://ja.wikipedia.org/wiki/アカデミー賞");

            UwpTextBlock01.Inlines = container;
        }
    }
}
