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
    public class ShellViewModel 
    {
        AbonentsFinder af = null;

        public BANS FirstBan { get; set; }
        public BindableCollection<ABONENTS> AbonentsByName { get; set; }

        public string SearchingText { get; set; }
        public void FindAbonentByName()
        {

            AbonentsByName.Clear();
            
            AbonentsByName.AddRange(af.SelectAbonentsByName(SearchingText));

        }
        public ShellViewModel()
        {
            af = new AbonentsFinder();
            AbonentsByName = new BindableCollection<ABONENTS>();
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
