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
    public partial class FrmKategoriListesi : Form
    {
        public FrmKategoriListesi()
        {
            InitializeComponent();
        }

        TeknikServisEntities db = new TeknikServisEntities();

        void kategoricekme()
        {
            var kategoriler = from kategori in db.Kategori
                          select new
                          {
                              kategori.ID,
                              kategori.AD,
                          };
            gridControl1.DataSource = kategoriler.ToList();

        }
        private void gridControl1_Load(object sender, EventArgs e)
        {
            kategoricekme();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kategori kategori = new Kategori();
            kategori.AD = txtKategoriAd.Text;
            db.Kategori.Add(kategori);
            db.SaveChanges();
            MessageBox.Show("Kategori kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtKategoriID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtKategoriAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtKategoriID.Text);
            var kategori = db.Kategori.Find(ID);
            db.Kategori.Remove(kategori);
            db.SaveChanges();
            MessageBox.Show("Kategori silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            kategoricekme();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtKategoriID.Text);
            var kategori = db.Kategori.Find(id);
            kategori.AD = txtKategoriAd.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            kategoricekme();
        }
    }
}
