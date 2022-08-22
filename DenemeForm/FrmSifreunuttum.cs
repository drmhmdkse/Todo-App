using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenemeForm
{
    public partial class FrmSifreunuttum : Form
    {
        public FrmSifreunuttum()
        {
            InitializeComponent();
        }
        Kullanici_formu kullanici_Formu = new Kullanici_formu();
        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox3.Text.Trim().Replace(" ", String.Empty) == "")
            {
                MessageBox.Show("Ad Soyad alanı için boş değer geçerli değildir");
            }
            else
            {
                bool islem = kullanici_Formu.sifre(textBox3, usernametxt, sifretxt, sorutxt, cevaptxt, groupBox2);
                if (islem == true)
                {
                    MessageBox.Show("İşlem başarılı");
                    this.Close();
                }
            }




        }

      

        private void btnUserAra_Click(object sender, EventArgs e)
        {
            if (usernametxt.Text.Trim().Replace(" ", String.Empty) == "")
            {
                MessageBox.Show("Boş değer girilemez");
            }
            else
            {
                if (kullanici_Formu.usernamevarmi(usernametxt) == true)
                {
                    usernametxt.Enabled = false;
                    label3.Visible = true;
                    textBox3.Visible = true;
                    label5.Visible = true;
                    sifretxt.Visible = true;
                    label6.Visible = true;
                    sorutxt.Visible = true;
                    label7.Visible = true;
                    cevaptxt.Visible = true;
                    button2.Visible = true;
                    kullanici_Formu.getSoru(usernametxt, sorutxt);
                }
                else
                {
                    MessageBox.Show("Böyle bir kullanıcı bulunamadı");
                }


            }
        }
    }
}
