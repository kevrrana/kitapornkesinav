using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kitapsınavornk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Kitap kitap;
        List<Kitap> kitapbilgisi = new List<Kitap>();

        private void Form1_Load(object sender, EventArgs e)
        {

         kitapbilgisi.Add(new Kitap(1, "Sokak Nöpetçileri", "Aslı Aslan", 700, "Roman", false, new DateTime(2019, 1, 24)));
         kitapbilgisi.Add(new Kitap(2, "Kimse Gerçek Değil", "Zeynep Sey", 210, "Aşk", true, new DateTime(2021, 1, 10)));
         kitapbilgisi.Add(new Kitap(3, "Ölüler Konuşamaz", "Dilara Keskin", 530, "Roman", true, new DateTime(2023, 3, 28)));
         kitapbilgisi.Add(new Kitap(4, "Sokak Nöpetçileri 3", "Aslı Aslan", 624, "Roman", false, new DateTime(2023, 12, 2)));
         kitapbilgisi.Add(new Kitap(5, "The Originals", "Julie Plec", 287, "Fantastik", false, new DateTime(2018, 1, 12)));
         kitapbilgisi.Add(new Kitap(6, "Şeytanlar ve Melekler", "Dan Brown", 574, "Polisiye", true, new DateTime(2009, 5, 21)));
         kitapbilgisi.Add(new Kitap(7, "Şeytanı Uyandırma", "John Verdon ", 538, "Gerilim", true, new DateTime(2012, 8, 11)));

            dgvKitapListesi.DataSource=kitapbilgisi;



        }

        private void dgvKitapListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
 
            


        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //int id=Convert.ToInt32(txtId.Text);
            //string kitapadi = txtKidapadi.Text;
            //string yazar = txtYazar.Text;
            //int sayfasayisi=Convert.ToInt32(txtSayfasayisi.Text);
            //string tur=cmbTur.Text;
            //bool cilt=chkCilt.Checked;
            //DateTime basimtarihi=dtpBasimtarihi.Value;

            //Kitap yenikitap = new Kitap(id, kitapadi, yazar, sayfasayisi, tur, cilt, basimtarihi);

            //kitapbilgisi.Add(yenikitap);
            //dgvKitapListesi.DataSource=kitapbilgisi; 

            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DataGridViewRow secilensatir=dgvKitapListesi.SelectedRows[0];
            Kitap secilenKitap=secilensatir.DataBoundItem as Kitap;

            int id = Convert.ToInt32(txtId.Text);
            string kitapadi = txtKidapadi.Text;
            string yazar = txtYazar.Text;
            int sayfasayisi = Convert.ToInt32(txtSayfasayisi.Text);
            string tur = cmbTur.Text;
            bool cilt = chkCilt.Checked;
            DateTime basimtarihi = dtpBasimtarihi.Value;


            secilenKitap.Id = id;
            secilenKitap.Kitapadi = kitapadi;
            secilenKitap.Yazar = yazar;
            secilenKitap.Sayfasayisi = sayfasayisi;
            secilenKitap.Tur=tur;
            secilenKitap.Cilt=cilt;
            secilenKitap.Basimtarihi=basimtarihi;

            dgvKitapListesi.DataSource = null;
            dgvKitapListesi.DataSource = kitapbilgisi.ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow secilensatir = dgvKitapListesi.SelectedRows[0];
            Kitap secilenKitap = secilensatir.DataBoundItem as Kitap;

            DialogResult result = MessageBox.Show("Seçilen Kitap Bilgisi Silinsin mi?", "Seçilen Kitap Bilgisini Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                kitapbilgisi.Remove(secilenKitap);
            }
            dgvKitapListesi.DataSource = kitapbilgisi.ToList();

                
                
             
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string kitapadi = txtKidapadi.Text;
            string yazar = txtYazar.Text;
            int sayfasayisi = Convert.ToInt32(txtSayfasayisi.Text);
            string tur = cmbTur.Text;
            bool cilt = chkCilt.Checked;
            DateTime basimtarihi = dtpBasimtarihi.Value;

            Kitap yenikitap = new Kitap(id, kitapadi, yazar, sayfasayisi, tur, cilt, basimtarihi);

            kitapbilgisi.Add(yenikitap);

            dgvKitapListesi.DataSource = kitapbilgisi.ToList();
        }

        private void dgvKitapListesi_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvKitapListesi.CurrentRow.Cells["id"].Value.ToString();
            txtKidapadi.Text = dgvKitapListesi.CurrentRow.Cells["kitapadi"].Value.ToString();
            txtYazar.Text = dgvKitapListesi.CurrentRow.Cells["yazar"].Value.ToString();
            txtSayfasayisi.Text = dgvKitapListesi.CurrentRow.Cells["sayfasayisi"].Value.ToString();
            cmbTur.Text = dgvKitapListesi.CurrentRow.Cells["tur"].Value.ToString();
            chkCilt.Checked = (bool)dgvKitapListesi.CurrentRow.Cells["cilt"].Value;
            dtpBasimtarihi.Value = (DateTime)dgvKitapListesi.CurrentRow.Cells["basimtarihi"].Value;
        }
    }
}
