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
    //public sealed class EntityFrameworkConfiguration : DbConfiguration
    //{
    //    public static readonly DbConfiguration Instance = new EntityFrameworkConfiguration();

    //    public EntityFrameworkConfiguration()
    //    {
    //        SetDefaultConnectionFactory(new OracleConnectionFactory());
    //        SetProviderServices("Oracle.ManagedDataAccess.Client", EFOracleProviderServices.Instance);
    //        SetProviderFactory("Oracle.ManagedDataAccess.Client", new OracleClientFactory());
    //    }
    //}
    public class AbonentsFinder
    {
        string _pass;
        public AbonentsFinder(string pass)
        {
            _pass = pass;
        }
        public List<ABONENTS> SelectAbonentsByName(string textToFind)
        {
            using (DBDemoModel db = new DBDemoModel(_pass))
            {
                //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us"); //если нужны ошибки на англ. яз.
                var cont = db.ABONENTS
                    .Where(a => a.OWNER.ToUpper().Contains(textToFind.ToUpper()))
                    .Include(a=> a.BANS); 
                var abon = cont.ToList();
                foreach (var a in abon) //установим selectedBan и selectedMSISDN в соответствии с критериями поиска
                {
                    var ban = a.BANS.FirstOrDefault();
                    a.SelectedBAN = ban?.BAN;
                    a.SelectedMSISDN = ban?.NUMBERS.FirstOrDefault()?.MSISDN;
                }
                #region тест
                //foreach (var a in abon)
                //{
                //    MessageBox.Show(a.OWNER);
                //    foreach (var b in a.BANS)
                //    {
                //        MessageBox.Show(b.BAN);
                //    }
                //}
                #endregion
                return new List<ABONENTS>(abon);
            }
        }
        public List<ABONENTS> SelectAbonentsByINN(string textToFind)
        {
            using (DBDemoModel db = new DBDemoModel(_pass))
            {
                int inn;
                Int32.TryParse(textToFind, out inn);
                var cont = db.ABONENTS
                    .Where(a => a.INN_PASSPORT == (int?)inn)
                    .Include(a => a.BANS);
                var abon = cont.ToList();
                foreach (var a in abon) //установим selectedBan и selectedMSISDN в соответствии с критериями поиска
                {
                    var ban = a.BANS.FirstOrDefault();
                    a.SelectedBAN = ban?.BAN;
                    a.SelectedMSISDN = ban?.NUMBERS.FirstOrDefault()?.MSISDN;
                }
                return new List<ABONENTS>(abon);
            }
        }
        public List<ABONENTS> SelectAbonentsByBAN(string textToFind)
        {
            using (DBDemoModel db = new DBDemoModel(_pass))
            {
                var cont = from a in db.ABONENTS
                           join b in db.BANS on a.KOD_SUBSCRIBE equals b.SR_SUBSCRIBE
                           where b.BAN.ToUpper().Contains(textToFind.ToUpper()) // может содержать буквы
                           select a;
                var abon = cont.Include(a => a.BANS.Select(m => m.NUMBERS)).ToList();
                foreach (var a in abon) //установим selectedBan и selectedMSISDN в соответствии с критериями поиска
                {
                    var ban = a.BANS.Where(b => b.BAN.Contains(textToFind)).FirstOrDefault();
                    a.SelectedBAN = ban?.BAN;
                    a.SelectedMSISDN = ban?.NUMBERS.FirstOrDefault()?.MSISDN;
                }
                return new List<ABONENTS>(abon);
            }
        }
        public List<ABONENTS> SelectAbonentsByMSISDN(string textToFind) 
        {
            using (DBDemoModel db = new DBDemoModel(_pass))
            {
                var cont = from a in db.ABONENTS
                           join n in db.NUMBERS on a.KOD_SUBSCRIBE equals n.KOD_SUBSCRIBE
                           where n.MSISDN.Contains(textToFind)
                           select a;
                var abon = cont.Include(a => a.BANS.Select(m => m.NUMBERS)).ToList();
                foreach (var a in abon) //установим selectedBan и selectedMSISDN в соответствии с критериями поиска
                {
                    foreach (var b in a.BANS)
                    {
                        var msisdn = b.NUMBERS.Where(m => m.MSISDN.Contains(textToFind)).FirstOrDefault();
                        a.SelectedMSISDN = msisdn?.MSISDN;
                        a.SelectedBAN = msisdn?.BAN;
                        if (msisdn != null) break;
                    }
                }
                return new List<ABONENTS>(abon);
            }
        }
        public List<ABONENTS> SelectAbonentsByBill(string textToFind)
        {
            using (DBDemoModel db = new DBDemoModel(_pass))
            {
                var cont = from n in db.NUMBERS
                           join b in db.BILLS on n.BAN equals b.BAN
                           join a in db.ABONENTS on n.KOD_SUBSCRIBE equals a.KOD_SUBSCRIBE
                           where b.BILL.Contains(textToFind)
                           select a;
                var abon = cont.Include(a => a.BANS.Select(b => b.NUMBERS)).ToList(); //одной строкой не работает с oracle ниже 12С из-за APPLY 
                abon = cont.Include(a => a.BANS.Select(b => b.BILLS)).ToList();

                foreach (var a in abon) //установим selectedBan и selectedMSISDN в соответствии с критериями поиска
                {
                    var ban = a.BANS.FirstOrDefault();
                    a.SelectedBAN = ban?.BAN;
                    a.SelectedMSISDN = ban?.NUMBERS.FirstOrDefault()?.MSISDN;
                }
                return new List<ABONENTS>(abon);
            }
        }
        public bool CanConnectDB()
        {
            try
            {
                using (DBDemoModel db = new DBDemoModel(_pass))
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
    }

}
