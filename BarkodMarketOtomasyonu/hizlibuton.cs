using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodMarketOtomasyonu
{
    public partial class hizlibuton : Form
    {
        public hizlibuton()
        {
            InitializeComponent();
        }
        BarkodluSatisEntities db = new BarkodluSatisEntities();

        private void tUrunAra_TextChanged(object sender, EventArgs e)
        {
            if (tUrunAra.Text != "")
            {
                string urunad = tUrunAra.Text;
                var urunler = db.Urun.Where(a => a.UrunAd.Contains(urunad)).ToList();
                girdUrunler.DataSource = urunler;

            }

        }

        private void LbutonId_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chTumu_CheckedChanged(object sender, EventArgs e)
        {
            if (chTumu.Checked)
            {
                girdUrunler.DataSource = db.Urun.ToList();
            }
            else
            {
                girdUrunler.DataSource = null;


            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void girdUrunler_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (girdUrunler.Rows.Count > 0)
            {
                string barkod = girdUrunler.CurrentRow.Cells["Barkod"].Value.ToString();
                string urunad = girdUrunler.CurrentRow.Cells["UrunAd"].Value.ToString();
                double fiyat = Convert.ToDouble(girdUrunler.CurrentRow.Cells["SatisFİyat"].Value.ToString());
                int id = Convert.ToInt16(LbutonId.Text);
                var guncellenecek = db.HizliUrun.Find(id);
                guncellenecek.Barkod = barkod;
                guncellenecek.UrunAd = urunad;
                guncellenecek.Fiyat = fiyat;
                db.SaveChanges();
                MessageBox.Show("buton tanımlandı");

                Form1 f = (Form1)Application.OpenForms["Form1"];
                if (f != null)
                {
                    Button b = f.Controls.Find("bH" + id, true).FirstOrDefault() as Button;
                    b.Text = urunad + "\n" + fiyat.ToString("C2");

                }


            }
        }
    
        
    }

}
