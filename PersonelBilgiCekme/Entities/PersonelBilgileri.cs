using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBilgiCekme.Entities
{
    public class PersonelBilgileri
    {
        public int ID { get; set; }

        public string Isim { get; set; }

        public string Soyisim { get; set; }

        public string EmailAdres { get; set; }

        public string Telefon { get; set; }

        public byte[] Resim { get; set; }

        public override string ToString()
        {
            return Isim + " " + Soyisim;
        }
    }
}
