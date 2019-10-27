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
    public class ShellViewModel:PropertyChangedBase
    {
        AbonentsFinder af = null;
        

        public BANS FirstBan { get; set; }
        public BindableCollection<ABONENTS> AbonentsList { get; set; }
        private string _textToFind;
        public string AuthenticationString { get; set; }
        public string TextToFind
        {
            get
            {
                return _textToFind;
            }
            set
            {
                _textToFind = value;
                NotifyOfPropertyChange(() => TextToFind);
            }
        }
        public string Pass { get; set; }
        IWindowManager windowManager = new WindowManager();

        public void CreateLoginDB()
        {
            LoginDBViewModel LoginDB = new LoginDBViewModel();
            windowManager.ShowWindow(LoginDB);
            
        }

        public void FindAbonentsByName()
        {

            AbonentsList.Clear();
            AbonentsList.AddRange(af.SelectAbonentsByName(TextToFind));

        }
        public void ClearSearchingText()
        {

            TextToFind = "";


        }
        public ShellViewModel()
        {
            af = new AbonentsFinder();
            AbonentsList = new BindableCollection<ABONENTS>();
        }


        #region //временно для теста  подключения
        //private List<IFindAbonents> _found = new List<IFindAbonents>();
        //

        //public List<IFindAbonents> Found
        //{
        //    get { return _found; }
        //    set { _found = value; }
        //}

        //





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
