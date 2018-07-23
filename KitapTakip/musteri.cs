using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace KitapTakip
{
    public partial class musteri : Form
    {
        public musteri()
        {
            InitializeComponent();         
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KitapTakip.accdb"); //Veri tabanının bulubduğu konum belirlenmesi
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        private void pictureBox1_Click(object sender, EventArgs e)//Kontrollü Müşteri kayıt işlemi
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && richTextBox1.Text != "")
            {
                komut.Connection = baglanti;
                komut.CommandText = "Insert Into MUSTERI(ad,soyad,telno,sehir,adres) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + richTextBox1.Text + "')";
                baglanti.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                MessageBox.Show("Müşteri Ekleme İşlemi Başarılı!","BİLGİLENDİRME",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ds.Clear();
                listele();
                dataGridView1.FirstDisplayedCell=dataGridView1.Rows[dataGridView1.RowCount-1].Cells[1];//Son Satıra Git
                dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;//Son Satırı Seçili Hale Getir.
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = richTextBox1.Text = "";
            }
            else {
                MessageBox.Show("Boş Alan Bırakmayınız!!!!"); textBox1.Focus();
            }
        }
        void listele()//Veri tabanından kayırları getir ve dataGridView1 de görüntüle
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select *From MUSTERI", baglanti);
            adtr.Fill(ds, "MUSTERI");
            dataGridView1.DataSource = ds.Tables["MUSTERI"];
            adtr.Dispose();
            baglanti.Close();
        }
        private void musteri_Load(object sender, EventArgs e)//Form açıldığında kayırları göster
        {
            listele();
        }
        private void musteri_FormClosed(object sender, FormClosedEventArgs e)//Form kapatıldığında anasayfaya geri dön
        {
            Form1 form1 =new Form1();
            form1.Show();
        }
        bool kntrl = false;
        private void tabControl1_Click(object sender, EventArgs e)//Tablara tekrar basıltığında açma/kapama işlemini yapma
        {
            if (tabControl1.SelectedIndex == 0 && kntrl == false) ac(); 
            if (tabControl1.SelectedIndex == 1 && kntrl == false) ac(); 
            if (tabControl1.SelectedIndex == 2 && kntrl == false) ac(); 
            if (tabControl1.SelectedIndex == 3 && kntrl == false) ac(); 
        }
        private void pictureBox2_Click(object sender, EventArgs e)//Pencere Küçültme Efekti
        {
            kapat();
        }
        private void kapat(){//TabControl Tasarımı Kapatma
            tabControl1.Location = new Point(106, 444); tabControl1.Size = new Size(389,20); kntrl = false;
        }
        private void ac() {//TabControl Tasarımı Açma
            tabControl1.Location = new Point(106, 256); tabControl1.Size = new Size(389, 208); kntrl = true;
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)//Çift Tıklayarak Silme
        {      
             DialogResult c;
            c = MessageBox.Show("Seçili Kaydı Silmek İstediğinizden Emin Misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "Delete From MUSTERI where mno=" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() + "";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                ds.Tables["MUSTERI"].Clear();
                listele();
                dataGridView1.FirstDisplayedCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1];//Son Satıra Git
                dataGridView1.Rows[dataGridView1.RowCount-1].Selected = true;//Son Satırı Seçili Hal
            }     
        }
        private void pictureBox6_Click(object sender, EventArgs e)//Silme 
        {
            DialogResult c;
            c = MessageBox.Show("Seçili Kaydı Silmek İstediğinizden Emin Misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "Delete From MUSTERI where ad='" + label12.Text + "' AND soyad='" + label13.Text + "' AND telno='" + label14.Text + "' AND sehir='" + label15.Text + "' AND adres='" + richTextBox2.Text + "'";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                ds.Tables["MUSTERI"].Clear();
                listele();
                label12.Text = label13.Text = label14.Text = label15.Text = richTextBox2.Text = "";
                kapat();
                dataGridView1.FirstDisplayedCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1];//Son Satıra Git
                dataGridView1.Rows[dataGridView1.RowCount - 1].Selected = true;//Son Satırı Seçili Hal
            }        
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)//TabControl Tab değiştirme koşulu
        {
            if (tabControl1.SelectedIndex == 1 && label12.Text == "") { MessageBox.Show("Silme penceresini açmadan önce silincek müşteriye sağ tıklayıp Sil'e seçiniz.");tabControl1.SelectedIndex = 0; kapat(); }
            if (tabControl1.SelectedIndex == 2 && textBox5.Text == "") { MessageBox.Show("Güncelleme penceresini açmadan önce düzenlenecek müşteriye sağ tıklayıp Düzenle'yi seçiniz."); tabControl1.SelectedIndex = 0; kapat(); }
        }
        int guncelSonKonum;
        private void pictureBox7_Click(object sender, EventArgs e)//Kayıt Güncelleme
        {
            OleDbCommand komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "UPDATE MUSTERI set  ad='" + textBox5.Text + "', soyad='" + textBox6.Text + "', telno='" + textBox7.Text + "' ,sehir='" + textBox8.Text + "', adres='" + richTextBox3.Text + "' where mno=" + textBox9.Text + "";
            komut.ExecuteNonQuery();
            baglanti.Close();          
            MessageBox.Show("Kayıt Güncellemesi Başarılı!");
            ds.Tables["MUSTERI"].Clear();
            listele();
            dataGridView1.FirstDisplayedCell = dataGridView1.Rows[guncelSonKonum].Cells[1];
            dataGridView1.Rows[guncelSonKonum].Selected = true;//Tıklanan Satırı Seç
            textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = richTextBox3.Text = "";
            kapat();
            tabControl1.SelectedIndex = 0;
        }    
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)//DataGridView1 Üzerinde Sağ click 
        {
            int fareKonum = dataGridView1.HitTest(e.X, e.Y).RowIndex;
            guncelSonKonum = dataGridView1.HitTest(e.X, e.Y).RowIndex; 
            try
            {
                dataGridView1.Rows[dataGridView1.HitTest(e.X, e.Y).RowIndex].Selected = true;//Tıklanan Satırı Seç
               
                if (e.Button == MouseButtons.Right)
                {
                    ContextMenu m = new ContextMenu();
                    if (fareKonum >= 0)
                    {
                        m.MenuItems.Add(new MenuItem("Sil", Sil));
                        m.MenuItems.Add(new MenuItem("Düzenle", Düzenle));
                    }
                    m.Show(dataGridView1, new Point(e.X, e.Y));
                }
            }
            catch { }
        }
        private void Sil(object sender, EventArgs e)// Seçili kaydı labellere atayıp silme
        {
            label12.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            label13.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label14.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            label15.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            richTextBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();        
            tabControl1.SelectedIndex = 1; ac();
        }
        private void Düzenle(object sender,EventArgs e) {//Seçili kaydı textlere atayıp güncelleme
            textBox5.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            richTextBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();//mno 
            tabControl1.SelectedIndex = 2; ac();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        { 
            baglanti.Open(); 
            DataTable dt = new DataTable();
            OleDbDataAdapter ad=new OleDbDataAdapter();
            if (radioButton1.Checked == true) ad = new OleDbDataAdapter("Select * From MUSTERI where ad LIKE '%" + textBox10.Text + "%'", baglanti);
            if (radioButton2.Checked == true) ad = new OleDbDataAdapter("Select * From MUSTERI where soyad LIKE '%" + textBox10.Text + "%'", baglanti);
            if (radioButton3.Checked == true) ad = new OleDbDataAdapter("Select * From MUSTERI where telno LIKE '%" + textBox10.Text + "%'", baglanti);
            if (radioButton4.Checked == true) ad = new OleDbDataAdapter("Select * From MUSTERI where sehir LIKE '%" + textBox10.Text + "%'", baglanti);
            if (radioButton5.Checked == true) ad = new OleDbDataAdapter("Select * From MUSTERI where adres LIKE '%" + textBox10.Text + "%'", baglanti);
            if (radioButton6.Checked == true) ad = new OleDbDataAdapter("Select * From MUSTERI", baglanti);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            textBox10.Clear();
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
        bool dragging;
        Point offset;
        private void musteri_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            offset = e.Location;
        }
        private void musteri_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void musteri_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new
                Point(currentScreenPos.X - offset.X,
                currentScreenPos.Y - offset.Y);
            }
        }   
    }
}
