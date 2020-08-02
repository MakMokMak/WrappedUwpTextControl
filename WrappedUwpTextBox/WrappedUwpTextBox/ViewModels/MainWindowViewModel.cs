using MakCraft.ViewModels;
using System.Windows.Input;

namespace WrappedUwpTextBox.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private string _inputText;
        public string InputText
        {
            get => _inputText;
            set => SetProperty(ref _inputText, value);
        }

        private string _displayText;
        public string DisplayText
        {
            get => _displayText;
            set => SetProperty(ref _displayText, value);
        }

        private void InputCommandExecute()
        {
            DisplayText = InputText;
        }
        private ICommand _inputCommand;
        public ICommand InputCommand
        {
            get
            {
                if (_inputCommand == null)
                {
                    _inputCommand = new RelayCommand(InputCommandExecute);
                }
                return _inputCommand;
            }
        }
    }
}
