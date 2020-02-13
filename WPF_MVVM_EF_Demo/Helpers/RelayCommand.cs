using System;
using System.Windows.Input;

namespace Demo.UI.Helpers
{
    public class RelayCommand : ICommand
    {
        private Action mAction;
        private object v;

        public event EventHandler CanExecuteChanged = (sender,e) => { };

        public RelayCommand(Action action)
        {
            mAction = action;
        }

        public RelayCommand(object v)
        {
            this.v = v;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
