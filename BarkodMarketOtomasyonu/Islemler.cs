using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodMarketOtomasyonu
{
    static class Islemler
    {
        public static double doubleYap(string deger)
        {
            double sonuc;
            double.TryParse(deger, NumberStyles.Currency, CultureInfo.CurrentUICulture.NumberFormat, out sonuc);

            return Math.Round(sonuc, 2);

        }
        public static void StokAzalt(string barkod , double miktar )
        {
            using (var db = new BarkodluSatisEntities())
            {
                var urunbilgi = db.Urun.SingleOrDefault(x => x.Barkod == barkod);
                urunbilgi.Miktar -= miktar;
                db.SaveChanges();

            }

        }
        public static void StokArtir(string barkod, double miktar)
        {
            using (var db = new BarkodluSatisEntities())
            {
                var urunbilgi = db.Urun.SingleOrDefault(x => x.Barkod == barkod);
                urunbilgi.Miktar += miktar;
                db.SaveChanges();

            }

        }
    }
}
