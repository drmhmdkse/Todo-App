using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;


namespace DenemeForm
{
    public partial class Form1 : Form
    {

        Thread th;
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-T1V9836;Initial Catalog=kullanici_girisi;Integrated Security=True");

        Kullanici_formu kullanici_Formu = new Kullanici_formu();
        FrmYeni yeni = new FrmYeni();
        private void button1_Click(object sender, EventArgs e)//giriş işlemi kontrolü;
        {
            if (textBox1.Text.Trim().Replace(" ", String.Empty) == "")
            {
                MessageBox.Show("Kullanıcı adı için boş değer geçersizdir");
            }
            else
            {
                if (textBox2.Text.Trim().Replace(" ", String.Empty) == "")
                {
                    MessageBox.Show("Parola için boş değer geçersizdir");
                }
                else
                {
                    bool durum = kullanici_Formu.kullanici(textBox1, textBox2);
                    if (durum == true)
                    {

                        this.Close();
                        th = new Thread(opennewform);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();

                    }
                }


            }



        }
        private void opennewform(object obj)
        {
            Application.Run(new FrmYeni());
        }

        private void button2_Click_1(object sender, EventArgs e)// kullanıcı kaydet
        {
            kullanici_Formu.kullanici_kaydet(textBox3, usernametxt, sifretxt, sorutxt, cevaptxt, groupBox2);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSifreunuttum frmSifreunuttum = new FrmSifreunuttum();
            frmSifreunuttum.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
