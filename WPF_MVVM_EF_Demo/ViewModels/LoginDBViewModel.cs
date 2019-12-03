using Caliburn.Micro;
using Demo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.UI.ViewModels
{
    public class LoginDBViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private string _pass;
        private bool _isErrorMessageVisible = false;

        public bool IsErrorMessageVisible
        {
            get { return _isErrorMessageVisible; }
            set
            {
                _isErrorMessageVisible = value;
                NotifyOfPropertyChange(() => IsErrorMessageVisible);
            }
        }
        public LoginDBViewModel(IEventAggregator eventAgg)
        {
            _eventAggregator = eventAgg;

        }
        public string Pass
        {
            get => _pass;
            set { _pass = value; NotifyOfPropertyChange(() => Pass);  }
        }

        public void SendLoginDetailsToShellVM()
        {
            if (Pass != null)
            {
                if ((new AbonentsFinder()).CanConnectDB(Pass))
                {
                    IsErrorMessageVisible = false;
                    _eventAggregator.PublishOnUIThread(Pass);
                    _eventAggregator.PublishOnUIThread(!IsErrorMessageVisible); //тут видимость сообщения об ошибке, в ShellViewModel возможность подключения
                    this.TryClose();
                }
                else IsErrorMessageVisible = true;

            }
            
            
        }


    }
}
