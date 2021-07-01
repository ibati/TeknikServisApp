using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServisApp.Formlar
{
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            FrmYeniUrun yeniurunform = new FrmYeniUrun();
            yeniurunform.Hide();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TeknikServisEntities db = new TeknikServisEntities();
            Urun urun = new Urun();
            urun.AD = txtUrunAd.Text;
            urun.MARKA = txtMarka.Text;
            urun.ALISFIYAT = decimal.Parse(txtAlisFiyat.Text);
            urun.SATISFIYAT = decimal.Parse(txtSatisFiyat.Text);
            urun.STOK = short.Parse(txtStok.Text);
            urun.KATEGORI = byte.Parse(txtKategori.Text);
            db.Urun.Add(urun);
            db.SaveChanges();
            MessageBox.Show("Ürünler kaydedildi.");
        }
    }
}
