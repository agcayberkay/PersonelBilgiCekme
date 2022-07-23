using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBilgiCekme.Base
{
    public static class Yardım
    {
        public static void TryCatchKullanımı(Action _action)
        {
            try
            {
                _action();
            }
            catch (Exception ex)
            {
              
            }
        }

        public static void Loglamaİslemi()
        {
            Logger logger = LogManager.GetLogger("databaseLogger");
            logger.Info("KAYDETME İSLEMİ GERCEKLESTİRİLDİ.");
        }
    }
}
