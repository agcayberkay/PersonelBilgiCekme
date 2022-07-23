using PersonelBilgiCekme.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBilgiCekme.Operasyon
{
    public class BusinessLogicLayer
    {
        DataAcessLayer DAL;

        public BusinessLogicLayer()
        {
            DAL = new DataAcessLayer();
        }

        public int kayitEkle(string isim, string soyisim, string emailadres, string tel, byte[] resim)
        {

            PersonelBilgileri personel = new PersonelBilgileri()
            {

                Isim = isim,
                Soyisim = soyisim,
                EmailAdres = emailadres,
                Telefon = tel,
                Resim = resim
            };
            return DAL.KayitEkle(personel);

        }

        public PersonelBilgileri KisiDetayGetir(int id)
        {
            PersonelBilgileri P1 = new PersonelBilgileri();

            SqlDataReader reader= DAL.KisiDetayGetir(id);
            while (reader.Read())
            {
                P1.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                P1.Isim = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                P1.Soyisim = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                P1.EmailAdres = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                P1.Telefon = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                P1.Resim = reader.IsDBNull(5) ? null : (byte[])reader[5];
            }
            reader.Close();
            DAL.baglantiAyarla();
            return P1;
        }

        public List<PersonelBilgileri> KisileriListele()
        {
            List<PersonelBilgileri> P2 = new List<PersonelBilgileri>();

            SqlDataReader reader = DAL.KisileriGoruntule();
            while (reader.Read())
            {
                P2.Add(new PersonelBilgileri()
                {
                    ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                Isim = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                Soyisim = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                EmailAdres = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                    Telefon = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                Resim = reader.IsDBNull(5) ? null : (byte[])reader[5]

            });
            }
            reader.Close();
            DAL.baglantiAyarla();
            return P2; 
        }
    }
}
