using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitapTakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)//Hareketli Resim Yükleme
        {
            pictureBox1.Image = Properties.Resources.musteri;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)//Sabit Resim Yükleme
        {
            pictureBox1.Image = Properties.Resources.musteri1;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)//Hareketli Resim Yükleme
        {
            pictureBox2.Image = Properties.Resources.kitap;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)//Sabit Resim Yükleme
        {
            pictureBox2.Image = Properties.Resources.kitap1;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)//Hareketli Resim Yükleme
        {
            pictureBox3.Image = Properties.Resources.yazar;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)//Sabit Resim Yükleme
        {
            pictureBox3.Image = Properties.Resources.yazar1;
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)//Hareketli Resim Yükleme
        {
            pictureBox4.Image = Properties.Resources.yayın;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)//Sabit Resim Yükleme
        {
            pictureBox4.Image = Properties.Resources.yayın1;
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)//Hareketli Resim Yükleme
        {
            pictureBox5.Image = Properties.Resources.satış;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)//Sabit Resim Yükleme
        {
            pictureBox5.Image = Properties.Resources.satış1;
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)//Hareketli Resim Yükleme
        {
            pictureBox6.Image = Properties.Resources.info1;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)//Sabit Resim Yükleme
        {
            pictureBox6.Image = Properties.Resources.info;
        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)//Hareketli Resim Yükleme
        {
            pictureBox7.Image = Properties.Resources.kapat;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)//Sabit Resim Yükleme
        {
            pictureBox7.Image = Properties.Resources.kapat1;
        }

        private void pictureBox7_Click(object sender, EventArgs e)//Program Sonlandırma.
        {
            DialogResult Result = MessageBox.Show("Programı sonlandırmak istiyor musunuz?", "Uyarı.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(Result == DialogResult.Yes) Application.Exit();
        }
        bool dragging=false;
        Point offset;
        private void Form1_MouseDown(object sender, MouseEventArgs e)//FORM1 Sürükleme
        {
            dragging = true;
            offset = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)//FORM1 Sürükleme
        {
            dragging = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)//FORM1 Sürükleme
        {
            if (dragging)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)//Müşteri Formunu Açma
        {
            musteri musteri = new musteri();
            musteri.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)//Demo Uyarısı
        {
            MessageBox.Show("Sadece Müşteri Sayfası Aktiftir.\r Premium'a Yükselt!", "!!!Demo Sürüm!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("KitapTakip Programı Emre YILDIRIM Tarafından Kodlanmıştır.\r Tüm Hakları Saklıdır. \r Copyright©!", "!!!HAKKIMDA!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }  
    }
}
