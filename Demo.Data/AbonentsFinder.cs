using Demo.Data.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Demo.Data
{
    public class AbonentsFinder
    {
        public List<ABONENTS> SelectAbonentsByName(string textToFind)
        {
            using (DBDemoModel db = new DBDemoModel())
            {

                //db.Database.Connection.ConnectionString = db.Database.Connection.ConnectionString.Replace("mypassword", "\"KGTUUTGK\"");
                var abon = db.ABONENTS.Where(a => a.OWNER.Contains(textToFind)).ToList();
                return new List<ABONENTS>(abon);

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
