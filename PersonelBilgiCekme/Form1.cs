using NLog;
using PersonelBilgiCekme.Entities;
using PersonelBilgiCekme.Operasyon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelBilgiCekme
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        Image img;
        BusinessLogicLayer BLL;

        public Form1()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
            List<Entities.PersonelBilgileri> personels = BLL.KisileriListele();
            comboBox1.DataSource = personels;
            
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void btnResımEkle_Click(object sender, EventArgs e)
        {
            xtraOpenFileDialog1.ShowDialog();

            img = Image.FromFile(xtraOpenFileDialog1.FileName);
            pctFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pctFoto.Image = img;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            MemoryStream mem = new MemoryStream();
            img.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
            BusinessLogicLayer layer = new BusinessLogicLayer();
            int returnValue = layer.kayitEkle(txtIsım.Text,txtSoyısım.Text,txtEposta.Text,txtTel.Text,mem.ToArray());
            if (returnValue>0)
            {
                MessageBox.Show("Başarılı!");
                Base.Yardım.Loglamaİslemi();
                
            }
            else
            {
                MessageBox.Show("Başarısız!");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PersonelBilgileri k = (PersonelBilgileri)((ComboBox)sender).SelectedItem;
            k = BLL.KisiDetayGetir(k.ID);
            txtIsım2.Text = k.Isim;
            txtSoyısım2.Text = k.Soyisim;
            txtEpsota2.Text = k.EmailAdres;
            txtTelefon2.Text = k.Telefon;

            MemoryStream mem = new MemoryStream(k.Resim);
            Image img = Image.FromStream(mem);
            pctKayıtlıFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pctKayıtlıFoto.Image = img;
        }
    }
}
