using ReactiveUI;
using System;
using System.Windows.Input;

namespace RPGWriter.ViewModels
{
    public class ItemViewModel : ViewModelBase
    {
        private string name = string.Empty;

        public string Name
        {
            get { return name; }
            private set { this.RaiseAndSetIfChanged(ref name, value); }
        }

        public ICommand Command { get; }

        public ItemViewModel(string name, Action commandAction)
        {
            Name = name;
            Command = ReactiveCommand.Create(commandAction);
        }
    }
}
