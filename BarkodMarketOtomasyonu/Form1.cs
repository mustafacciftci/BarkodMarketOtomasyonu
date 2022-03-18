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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            HizliButonDoldur();
            b5.Text = 5.ToString("c2");
            b10.Text = 10.ToString("c2");
            b20.Text = 20.ToString("c2");
            b50.Text = 50.ToString("c2");
            b100.Text = 100.ToString("c2");
            b200.Text = 200.ToString("c2");


        }
        private void HizliButonDoldur()
        {
            var hizliurun = db.HizliUrun.ToList();
            foreach (var item in hizliurun)
            {
                Button bH = this.Controls.Find("bH" + item.Id, true).FirstOrDefault() as Button;

                if (bH != null)
                {
                    double fiyat = Islemler.doubleYap(item.Fiyat.ToString());

                    bH.Text = item.UrunAd + "\n" + fiyat.ToString("c2");



                }

            }

        }
        private void HizliButonClick(object sender, EventArgs e)
        {
            tBarkod.Focus();

            Button b = (Button)sender;
            int butonid = Convert.ToInt16(b.Name.ToString().Substring(2, b.Name.Length - 2));
            if (b.Text.ToString().StartsWith("-"))
            {

                hizlibuton f = new hizlibuton();
                f.LbutonId.Text = butonid.ToString("");
                f.ShowDialog();



            }
            else
            {
                var urunbarkod = db.HizliUrun.Where(a => a.Id == butonid).Select(a => a.Barkod).FirstOrDefault();
                // var urun = db.Urun.Where(a => a.Barkod == urunbarkod)
                var urun = db.Urun.Where(a => a.Barkod == urunbarkod).FirstOrDefault();
                UrunListeyeGetir(urun, urunbarkod, Convert.ToDouble(tMiktar.Text));
                GenelToplam();
                db.SaveChanges();
                HizliUrun hizliUrun = new HizliUrun();
                db.HizliUrun.Add(hizliUrun);


            }
        }
        BarkodluSatisEntities db = new BarkodluSatisEntities();



        private void tBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barkod = tBarkod.Text.Trim();
                if (barkod.Length <= 2)
                {
                    tMiktar.Text = barkod;
                    tBarkod.Clear();
                    tBarkod.Focus();

                }
                else
                {
                    if (db.Urun.Any(a => a.Barkod == barkod))
                    {
                        var urun = db.Urun.Where(a => a.Barkod == barkod).FirstOrDefault();
                        UrunListeyeGetir(urun, barkod, Convert.ToDouble(tMiktar.Text));

                    }
                    else
                    {
                        int onek = Convert.ToInt32(barkod.Substring(0, 2));


                        if (db.Terazi.Any(a => a.TeraziOnEk == onek))
                        {
                            string teraziurunno = barkod.Substring(2, 5);
                            if (db.Urun.Any(a => a.Barkod == teraziurunno))
                            {
                                var urunterazi = db.Urun.Where(a => a.Barkod == teraziurunno).FirstOrDefault();
                                double miktarkg = Convert.ToDouble(barkod.Substring(7, 5)) / 1000;
                                UrunListeyeGetir(urunterazi, teraziurunno, miktarkg);



                            }

                        }
                    }
                }
                gridSatisListesi.ClearSelection();
                GenelToplam();
                tBarkod.Focus();

            }
        }


        private void GenelToplam()
        {
            Double toplam = 0;
            for (int i = 0; i < gridSatisListesi.Rows.Count; i++)
            {

                toplam += Convert.ToDouble(gridSatisListesi.Rows[i].Cells["Toplam"].Value);

            }
            tMiktar.Text = "1";
            tBarkod.Clear();

            tGenelToplam.Text = toplam.ToString("c2");
        }
        public void UrunListeyeGetir(Urun urun, string barkod, double miktar)
        {
            int satirsayisi = gridSatisListesi.Rows.Count;
            //double miktar = Convert.ToDouble(tMiktar.Text);
            bool eklenmismi = false;
            if (satirsayisi > 0)
            {
                for (int i = 0; i < satirsayisi; i++)
                {
                    if (gridSatisListesi.Rows[i].Cells["Barkod"].Value.ToString() == barkod)
                    {
                        gridSatisListesi.Rows[i].Cells["Miktar"].Value = miktar + Convert.ToDouble(gridSatisListesi.Rows[i].Cells["Miktar"].Value);
                        gridSatisListesi.Rows[i].Cells["Toplam"].Value = Math.Round(Convert.ToDouble(gridSatisListesi.Rows[i].Cells["Miktar"].Value) * Convert.ToDouble(gridSatisListesi.Rows[i].Cells["Fiyat"].Value), 2);
                        eklenmismi = true;


                    }

                }

            }
            if (eklenmismi == false)
            {
                gridSatisListesi.Rows.Add();
                gridSatisListesi.Rows[satirsayisi].Cells["Barkod"].Value = barkod;
                gridSatisListesi.Rows[satirsayisi].Cells["UrunAdi"].Value = urun.UrunAd;
                gridSatisListesi.Rows[satirsayisi].Cells["Birim"].Value = urun.Birim;
                gridSatisListesi.Rows[satirsayisi].Cells["Fiyat"].Value = urun.SatisFİyat;
                gridSatisListesi.Rows[satirsayisi].Cells["Miktar"].Value = miktar;
                gridSatisListesi.Rows[satirsayisi].Cells["UrunGrup"].Value = urun.UrunGrup;
                gridSatisListesi.Rows[satirsayisi].Cells["Toplam"].Value = Math.Round(miktar * (double)urun.SatisFİyat, 2);
                gridSatisListesi.Rows[satirsayisi].Cells["KdvTutari"].Value = urun.KdvTutari;
                gridSatisListesi.Rows[satirsayisi].Cells["AlisFiyat"].Value = urun.AlisFiyat;


            }

        }

        private void gridSatisListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                DialogResult cevap;
                cevap = MessageBox.Show("Silmek istediğinizden Emin misiniz?", "Uyarı", MessageBoxButtons.YesNoCancel);
                if (cevap == DialogResult.Yes)
                {
                    gridSatisListesi.Rows.Remove(gridSatisListesi.CurrentRow);
                    gridSatisListesi.ClearSelection();
                    GenelToplam();
                    tBarkod.Focus();

                }


            }
        }
        private void bh_MouseDown(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            if (!b.Text.StartsWith("-"))
            {
                int butonid = Convert.ToInt32(b.Name.ToString().Substring(2, b.Name.Length - 2));
                ContextMenuStrip s = new ContextMenuStrip();
                ToolStripMenuItem sil = new ToolStripMenuItem();
                sil.Text = "Temizle - Buton No:" + butonid.ToString();
                sil.Click += Sil_Click;
                s.Items.Add(sil);
                this.ContextMenuStrip = s;

            }
        }

        private void Sil_Click(object sender, EventArgs e)
        {
            int butonid = Convert.ToInt32(sender.ToString().Substring(19, sender.ToString().Length - 19));
            var guncelle = db.HizliUrun.Find(butonid);
            guncelle.Barkod = "-";
            guncelle.UrunAd = "-";
            guncelle.Fiyat = 0;
            db.SaveChanges();
            double fiyat = 0;

            Button b = this.Controls.Find("bH" + butonid, true).FirstOrDefault() as Button;
            b.Text = "-" + "\n" + fiyat.ToString("C2");

        }

        private void bNx_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == ",")
            {

                int virgul = tNumarator.Text.Count(x => x == ',');
                if (virgul < 1)
                {
                    tNumarator.Text += b.Text;
                }
            }

            else if (b.Text == "<")
            {
                if (tNumarator.Text.Length > 0)
                {
                    tNumarator.Text = tNumarator.Text.Substring(0, tNumarator.Text.Length - 1);


                }
            }
            else
            {
                tNumarator.Text += b.Text;

            }
        }

        private void bAdet_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text != "")
            {
                tMiktar.Text = tNumarator.Text;
                tNumarator.Clear();
                tBarkod.Clear();
                tBarkod.Focus();


            }
        }

        private void bOdenen_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text != "")
            {

                double sonuc = Islemler.doubleYap(tNumarator.Text) - Islemler.doubleYap(tGenelToplam.Text);

                tParaUstu.Text = sonuc.ToString("c2");
                tOdenen.Text = tNumarator.Text;

                tNumarator.Clear();
                tBarkod.Focus();
            }
        }

        private void bBarkod_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text != "")
            {
                if (db.Urun.Any(a => a.Barkod == tNumarator.Text))
                {
                    var urun = db.Urun.Where(a => a.Barkod == tNumarator.Text).FirstOrDefault();
                    UrunListeyeGetir(urun, tNumarator.Text, Convert.ToDouble(tMiktar.Text));
                    tMiktar.Text = "1";
                    tNumarator.Clear();


                }
                else
                {
                    MessageBox.Show("asd");

                }
            }
        }
        private void ParaUstuHesapla_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            double sonuc = Islemler.doubleYap(b.Text) - Islemler.doubleYap(tGenelToplam.Text);
            tParaUstu.Text = sonuc.ToString("c2");
            tOdenen.Text = b.Text;


        }
        private void bDigerUrun_Click(object sender, EventArgs e)
        {
            if (tNumarator.Text != "")
            {
                int satirsayisi = gridSatisListesi.Rows.Count;
                gridSatisListesi.Rows.Add();
                gridSatisListesi.Rows[satirsayisi].Cells["Barkod"].Value = "1111111111116";
                gridSatisListesi.Rows[satirsayisi].Cells["UrunAdi"].Value = "Barkodsuz Ürün";
                gridSatisListesi.Rows[satirsayisi].Cells["Birim"].Value = "Adet";
                gridSatisListesi.Rows[satirsayisi].Cells["Miktar"].Value = 1;
                gridSatisListesi.Rows[satirsayisi].Cells["Fiyat"].Value = Convert.ToDouble(tNumarator.Text);
                gridSatisListesi.Rows[satirsayisi].Cells["KdvTutari"].Value = 0;
                gridSatisListesi.Rows[satirsayisi].Cells["Toplam"].Value = Convert.ToDouble(tNumarator.Text);
                tNumarator.Text = "";
                tBarkod.Focus();
                GenelToplam();


            }
        }

        private void bIade_Click(object sender, EventArgs e)
        {
            if (chSatisIadeIslemi.Checked)
            {
                chSatisIadeIslemi.Checked = false;
                chSatisIadeIslemi.Text = "Satış Yaplıyor";
            }
            else
            {
                chSatisIadeIslemi.Checked = true;
                chSatisIadeIslemi.Text = "İade İşlemi";

            }
        }

        private void button53_Click(object sender, EventArgs e)
        {
            temizler();


        }
        public void temizler()
        {
            tMiktar.Text = "1";
            tBarkod.Clear();
            tOdenen.Clear();
            tParaUstu.Clear();
            tGenelToplam.Clear();
            tGenelToplam.Text = 0.ToString("c2");
            chSatisIadeIslemi.Checked = false;
            tNumarator.Clear();

            gridSatisListesi.Rows.Clear();


        }
        private void SatisYap(string odemesekli)
        {
            int satirsayisi = gridSatisListesi.Rows.Count;
            bool satisiade = chSatisIadeIslemi.Checked;
            double alisfiyattoplam = 0;
            if (satirsayisi > 0)

            {
                int? islemno = db.Islem.First().IslemNo;
                Satis satis = new Satis();
                for (int i = 0; i < satirsayisi; i++)
                {
                    satis.IslemNo = islemno;
                    satis.UrunAd = gridSatisListesi.Rows[i].Cells["UrunAdi"].Value.ToString();
                    satis.UrunGrup = gridSatisListesi.Rows[i].Cells["UrunGrup"].Value.ToString();
                    satis.Barkod = gridSatisListesi.Rows[i].Cells["Barkod"].Value.ToString();
                    satis.Birim = gridSatisListesi.Rows[i].Cells["Birim"].Value.ToString();
                    satis.AlisFiyat = Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["AlisFiyat"].Value.ToString());
                    satis.SatisFiyat = Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["Fiyat"].Value.ToString());
                    satis.Miktar = Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["Miktar"].Value.ToString());
                    satis.Toplam = Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["Toplam"].Value.ToString());
                    satis.KdvTutari = Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["KdvTutari"].Value.ToString());
                    satis.OdemeSekli = odemesekli;
                    satis.Iade = satisiade;
                    satis.Tarih = DateTime.Now;
                    satis.Kullanici = lKullanici.Text;

                    db.Satis.Add(satis);
                    db.SaveChanges();

                    alisfiyattoplam += Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["AlisFiyat"].Value.ToString());
                    if (!satisiade)
                    {
                        Islemler.StokAzalt(gridSatisListesi.Rows[i].Cells["Barkod"].Value.ToString(), Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["Miktar"].Value.ToString()));
                    }
                    else
                    {
                        Islemler.StokArtir(gridSatisListesi.Rows[i].Cells["Barkod"].Value.ToString(), Islemler.doubleYap(gridSatisListesi.Rows[i].Cells["Miktar"].Value.ToString()));

                    }



                }

                IslemOzet io = new IslemOzet();
                io.IslemNo = islemno;
                io.İadeMi = satisiade;
                io.AlisFiyatToplam = alisfiyattoplam;
                io.Gelir = false;
                io.Gider = false;
                if (!satisiade)
                {

                    io.Aciklama = odemesekli = "Satış";
                }
                else
                {
                    io.Aciklama = "İade İslemi(" + odemesekli + ")";
                }
                io.OdemeSekli = odemesekli;
                io.Kullanici = lKullanici.Text;
                io.Tarih = DateTime.Now;
                switch (odemesekli)
                {
                    case "Nakit":
                        io.Nakit = Islemler.doubleYap(tGenelToplam.Text);
                        





                        break;

                }

            }

        }

        private void bNakit_Click(object sender, EventArgs e)
        {
            SatisYap("Nakit");
        }
    }
}



