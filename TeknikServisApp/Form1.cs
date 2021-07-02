using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServisApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnUrunListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmUrunListesi urunlistesi = new Formlar.FrmUrunListesi();
            urunlistesi.MdiParent = this;
            urunlistesi.Show();

        }

        private void btnYeniUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmUrunListesi urunlistesi = new Formlar.FrmUrunListesi();
            urunlistesi.MdiParent = this;
            urunlistesi.Show();

            Formlar.FrmYeniUrun yeniurunpenceresi = new Formlar.FrmYeniUrun();
            yeniurunpenceresi.Show();
        }

        private void btnKategoriListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmKategoriListesi kategorilistesi = new Formlar.FrmKategoriListesi();
            kategorilistesi.MdiParent = this;
            kategorilistesi.Show();
        }
    }
}
