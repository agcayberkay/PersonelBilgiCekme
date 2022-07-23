using NLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBilgiCekme.Operasyon
{
    public class DataAcessLayer
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;


        public DataAcessLayer()
        {
            con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonelBilgiAlma;Integrated Security=True");

        }


        public void baglantiAyarla()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
                
            }
            else
            {
                con.Open();
                
            }
        }

        public int KayitEkle(Entities.PersonelBilgileri personelBilgi)
        {
            int returnValue = 0;
            Base.Yardım.TryCatchKullanımı(()=> {
                cmd = new SqlCommand("KisiEkle",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Isim", System.Data.SqlDbType.NVarChar).Value = personelBilgi.Isim;
                cmd.Parameters.Add("@Soyisim", System.Data.SqlDbType.NVarChar).Value = personelBilgi.Soyisim;
                cmd.Parameters.Add("@EmailAdres", System.Data.SqlDbType.NVarChar).Value = personelBilgi.EmailAdres;
                cmd.Parameters.Add("@TelefonNumarası", System.Data.SqlDbType.NVarChar).Value = personelBilgi.Telefon;
                cmd.Parameters.Add("@Resim", System.Data.SqlDbType.VarBinary).Value = personelBilgi.Resim;
                baglantiAyarla();
                returnValue = cmd.ExecuteNonQuery();
                baglantiAyarla();

            });
            return returnValue;

        }

        public SqlDataReader KisiDetayGetir(int id) 
        {
            Base.Yardım.TryCatchKullanımı(()=> {

                cmd = new SqlCommand("select * from PersonelBilgileri where ID =@id",con);
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value= id;
                baglantiAyarla();
                reader = cmd.ExecuteReader();

            });
            return reader;
        }


        public SqlDataReader KisileriGoruntule()
        {
            Base.Yardım.TryCatchKullanımı(() => {

                cmd = new SqlCommand("select * from PersonelBilgileri", con);
                baglantiAyarla();
                reader = cmd.ExecuteReader();

            });
            return reader;
        }
    }

}
