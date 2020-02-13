using Caliburn.Micro;
using Demo.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Demo.UI.ViewModels
{
    public class AbonentViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        public ABONENTS Abonent;

        public AbonentViewModel(IEventAggregator eventAgg, ABONENTS abonent)
        {
            _eventAggregator = eventAgg;
            Abonent = abonent;

        }

        public void FindAbonents() //поиск абонентов
        {
            MessageBox.Show(Abonent.OWNER);
        }

    }
}
