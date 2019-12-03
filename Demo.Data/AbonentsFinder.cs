using Demo.Data.DB;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Demo.Data
{
    public sealed class EntityFrameworkConfiguration : DbConfiguration
    {
        public static readonly DbConfiguration Instance = new EntityFrameworkConfiguration();

        public EntityFrameworkConfiguration()
        {
            SetDefaultConnectionFactory(new OracleConnectionFactory());
            SetProviderServices("Oracle.ManagedDataAccess.Client", EFOracleProviderServices.Instance);
            SetProviderFactory("Oracle.ManagedDataAccess.Client", new OracleClientFactory());
        }
    }




    public class AbonentsFinder
    {
        public List<ABONENTS> SelectAbonentsByName(string textToFind, string pass)
        {
            //DbConfiguration.SetConfiguration(EntityFrameworkConfiguration.Instance);
            using (DBDemoModel db = new DBDemoModel(pass))
            {
                //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
                var cont = db.ABONENTS.Where(a => a.OWNER.Contains(textToFind));
                var abon = cont.ToList();
                return new List<ABONENTS>(abon);
            }
            
        }

        public bool CanConnectDB(string pass)
        {
            try
            {
                using (DBDemoModel db = new DBDemoModel(pass))
                {
                    db.Database.Connection.Open();
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }



        #region //временно для теста  подключения
        //private List<ABONENTS> список = null;


        //public List<ABONENTS> GetABONENTs(string stringToFind)
        //{
        //    using (DBDemoModel cont = new DBDemoModel("kgtuutgk"))
        //    {
        //        var abon = cont.ABONENTS.ToList();
        //        foreach (var a in abon)
        //        {
        //            MessageBox.Show(a.OWNER);
        //            foreach (var b in a.BANS)
        //            {
        //                MessageBox.Show(b.BAN);
        //            }


        //        }


        //    }



        //    var context = new DBDemoModel("kgtuutgk");

        //    var t = context.ABONENTS;



        //    return список;


        //}



        #endregion
    }

}
