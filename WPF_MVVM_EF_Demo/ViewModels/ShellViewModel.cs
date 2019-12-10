using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.UI.ViewModels;
using Demo.UI.Models;
using Demo.Data;
using Caliburn.Micro;
using Demo.Data.DB;

namespace Demo.UI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<string>, IHandle<bool>
    {
        //private LoginDBViewModel _loginDBVM;
        
        private readonly IEventAggregator _eventAggregator;
        private string _pass = "";
        private IWindowManager _windowManager = new WindowManager();
        private bool _isConnected;
        private string _connectDBButtonText;
        private BindableCollection<ABONENTS> _abonentsList;
        private string _textToFind;

        public BANS SelectedBan { get; set; }
        public BindableCollection<ABONENTS> AbonentsList
        {
            get => _abonentsList;
            set
            {
                _abonentsList = value;
            }
        }
        public string TextToFind
        {
            get => _textToFind;


            set
            {
                _textToFind = value;
                NotifyOfPropertyChange(() => TextToFind);
            }
        }
        public string Pass
        {
            get => _pass;
            set
            {
                _pass = value;
                NotifyOfPropertyChange(() => Pass);
            }
        }
        public bool IsConnected // возможность подключения к БД + логика текста на кнопке
        {
            get => _isConnected;

            set
            {
                _isConnected = value;
                NotifyOfPropertyChange(() => IsConnected);
                ConnectDBButtonText = IsConnected ? "Отключиться от БД" : "Подключиться к БД";
            }
        }
        public string ConnectDBButtonText
        {
            get { return _connectDBButtonText; }
            set
            {
                _connectDBButtonText = value;
                NotifyOfPropertyChange(() => ConnectDBButtonText);
            }
        }

        public void ConnectDB()
        {
            Pass = "";
            if (IsConnected) IsConnected = false;
            else _windowManager.ShowDialog(new LoginDBViewModel(_eventAggregator)); // УТЕЧКА ПАМЯТИ???
        }
        public void FindAbonents() //поиск абонентов
        {
            AbonentsList.Clear();
            AbonentsList.AddRange(new AbonentsFinder(Pass).SelectAbonentsByBill(TextToFind));
        }
        public void ClearSearchingText()
        {
            TextToFind = "";
        }
        public ShellViewModel(IEventAggregator eventAgg) //, LoginDBViewModel loginDBViewModel
        {
            AbonentsList = new BindableCollection<ABONENTS>();  // переделать с DI?
            
            IsConnected = false;
            // _loginDBVM = loginDBViewModel;
            _eventAggregator = eventAgg;
            _eventAggregator.Subscribe(this);
            ConnectDBButtonText = "Подключиться к БД";
        }
        public void Handle(string message) //получение пароля из LoginDbViewModel
        {
            Pass = message;
        }
        public void Handle(bool message) //получение статуса подключения из LoginDbViewModel
        {
            IsConnected = message;
        }

        //public sealed override void ActivateItem(object item)
        //{
        //    base.ActivateItem(item);
        //}

        #region //временно для теста  подключения
        //private List<IFindAbonents> _found = new List<IFindAbonents>();

        //public List<IFindAbonents> Found
        //{
        //    get { return _found; }
        //    set { _found = value; }
        //}

        //public List<ISearchable> FindAbonents()
        //{
        //    List<ISearchable> result = new List<ISearchable>();

        //    return result;
        //}
        ////перегружаем конструктор DbMGSContext чтобы подставить пароль в ConnectionString
        //partial class DbMGSContext : DbContext
        //{

        //    public DbMGSContext(string pass)
        //            : base("name=DbMGSContext")
        //    {
        //        this.Database.Connection.ConnectionString = this.Database.Connection.ConnectionString.Replace("mypassword", pass);
        //    }

        //private List<SR_TYPE_PLACES> список = null;

        //public List<SR_TYPE_PLACES> Список
        //{
        //    get
        //    {
        //        список = TypePlaces.GetTypePlacesList();

        //        return список;

        //    }
        //}

        #endregion
    }
}
