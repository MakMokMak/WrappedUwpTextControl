using MakCraft.ViewModels;
using System.Windows.Input;
using WrappedUwpTextBlock4.WrappedUwpControls.Containers;

namespace WrappedUwpTextBlock4.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private InlineDataContainer _inlineDataContainer;
        public InlineDataContainer InlineDataContainer
        {
            get => _inlineDataContainer;
            set => SetProperty(ref _inlineDataContainer, value);
        }

        private void DisplayTextExecute()
        {
            var container = new InlineDataContainer();
            container.AddText("abcdefg ☺⛄☂♨⛅ ");
            container.AddLineBreak();
            container.AddLink("アカデミー賞", "https://ja.wikipedia.org/wiki/アカデミー賞");

            InlineDataContainer = container;
        }
        private ICommand _displayTextCommand;
        public ICommand DisplayTextCommand
        {
            get
            {
                if (_displayTextCommand == null)
                {
                    _displayTextCommand = new RelayCommand(DisplayTextExecute);
                }
                return _displayTextCommand;
            }
        }

        private void ChangeTextExecute()
        {
            var container = new InlineDataContainer();
            container.AddText("0123abcd ☺⛄☂♨⛅ abcdefghijklmnopqrstuvwxyz 0123456789 abcdefghijklmnopqrstuvwxyz");
            container.AddLineBreak();
            container.AddLink("アカデミー賞", "https://ja.wikipedia.org/wiki/アカデミー賞");

            InlineDataContainer = container;
        }
        private ICommand _changeTextCommand;
        public ICommand ChangeTextCommand
        {
            get
            {
                if (_changeTextCommand == null)
                {
                    _changeTextCommand = new RelayCommand(ChangeTextExecute);
                }
                return _changeTextCommand;
            }
        }
    }
}
