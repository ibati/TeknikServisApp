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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        TeknikServisEntities db = new TeknikServisEntities();
        void uruncekme()
        {
            var urunler = from urun in db.Urun
                          select new
                          {
                              urun.ID,
                              urun.AD,
                              urun.MARKA,
                              urun.ALISFIYAT,
                              urun.SATISFIYAT,
                              urun.STOK,
                          };
            gridControl1.DataSource = urunler.ToList();

        }


        private void gridControl1_Load(object sender, EventArgs e)
        {


            uruncekme();
            lookUpEdit1.Properties.DataSource = db.Kategori.ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Urun urun = new Urun();
            urun.AD = txtUrunAdi.Text;
            urun.MARKA = txtMarka.Text;
            urun.ALISFIYAT = decimal.Parse(txtAlisFiyat.Text);
            urun.SATISFIYAT = decimal.Parse(txtSatisFiyat.Text);
            urun.STOK = short.Parse(txtStok.Text);
            urun.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            urun.DURUM = false;
            db.Urun.Add(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Kaydettikten sonra listeyi yenile//
            uruncekme();
            lookUpEdit1.Properties.DataSource = db.Kategori.ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtUrunID.Text);
            var urun = db.Urun.Find(ID);
            db.Urun.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            //Sildikten sonra listeyi yenile//
            uruncekme();
            lookUpEdit1.Properties.DataSource = db.Kategori.ToList();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtUrunID.Text);
            var urun = db.Urun.Find(id);
            urun.AD = txtUrunAdi.Text;
            urun.MARKA = txtMarka.Text;
            urun.ALISFIYAT = decimal.Parse(txtAlisFiyat.Text);
            urun.SATISFIYAT = decimal.Parse(txtSatisFiyat.Text);
            urun.STOK = short.Parse(txtStok.Text);
            urun.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //Güncelledikten sonra listeyi yenile//
            uruncekme();
            lookUpEdit1.Properties.DataSource = db.Kategori.ToList();

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            //Listeyi yenile//
            uruncekme();
            lookUpEdit1.Properties.DataSource = db.Kategori.ToList();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            /*
            txtUrunID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtUrunAdi.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
            txtAlisFiyat.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
            txtSatisFiyat.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
            txtStok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString(); */
        }

    }
}
