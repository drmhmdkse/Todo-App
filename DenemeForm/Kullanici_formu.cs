using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DenemeForm
{
    public class Kullanici_formu
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-T1V9836;Ini" +
            "tial Catalog=kullanici_girisi;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader read;

        public static int girisyapan;
        public void getSoru(TextBox username, TextBox txtSoru)
        {
            conn.Close();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from kullanci_girisi where username='" + username.Text + "'";
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                txtSoru.Text = read["soru"].ToString();

            }
            conn.Close();

        }

        public bool kullanici(TextBox username, TextBox sifre)// giriş işlemi kontrolü
        {
            bool durum = false;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from kullanci_girisi where username='" + username.Text + "'";
            read = cmd.ExecuteReader();
            if (read.Read() == true && username.Text.ToString() == read["username"].ToString())
            {
                if (sifre.Text == read["sifre"].ToString())
                {
                    MessageBox.Show(username.Text + "--" + read["username"]);
                    girisyapan = int.Parse(read["Id"].ToString());
                    durum = true;

                }
                else
                {
                    MessageBox.Show("kullanıcı adı ve ya şifre ahtalı");
                }
            }
            else
            {
                MessageBox.Show("böyle bir kullanıcı bulunamadı");
            }
            conn.Close();
            return durum;

        }

        public void kullanici_kaydet(TextBox adsoyad, TextBox username, TextBox sifre, TextBox soru, TextBox cevap, GroupBox grup)
        {

            bool durum = this.usernamevarmi(username);

            if (durum == true)
            {
                MessageBox.Show("bu kullanıc zaten var");
            }
            else if (this.adKontrol(adsoyad) == false)
            {
                MessageBox.Show("İsim Alanı Zrounludur");
            }
            else if (this.sifreKontrol(sifre) == false)
            {
                MessageBox.Show("Şifre uzunluğu 6'dan büyük olmalıdır ve boşluk kullanmayın");
            }
            else if (this.soruCevapKontrol(soru, cevap) == false)
            {

            }
            else
            {
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;


                cmd.CommandText = "insert into kullanci_girisi values('" + adsoyad.Text + "','" + username.Text + "','" + sifre.Text + "','" + soru.Text + "','" + cevap.Text + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("üye eklendi");
                foreach (Control item in grup.Controls) if (item is TextBox) item.Text = "";
            }



        }

        public bool usernamevarmi(TextBox username)
        {
            bool kontrol = false;
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select username from kullanci_girisi";
            read = cmd.ExecuteReader();


            if (read.Read() == true)
            {
                foreach (var item in read)
                {
                    string deneme = read["username"].ToString();

                    if (deneme == username.Text)
                    {
                        kontrol = true;

                    }
                }

            }
            conn.Close();
            return kontrol;

        }// username zaten var mı kontrolü
        public bool adKontrol(TextBox adSoyad)
        {
            bool kontrol = true;
            if (adSoyad.Text.Trim().Replace(" ", String.Empty) == "")
            {
                kontrol = false;
            }
            return kontrol;
        }//adsoyad kontrol
        public bool sifreKontrol(TextBox sifre)
        {
            bool kontrol = true;
            if (sifre.Text.Length < 6 || sifre.Text.Trim().Replace(" ", String.Empty) == "")
            {
                kontrol = false;
            }
            return kontrol;

        }//sifre kontrol
        public bool soruCevapKontrol(TextBox soru, TextBox cevap)
        {
            bool soruCevap = true;
            if (soru.Text.Trim().Replace(" ", String.Empty) != "" && cevap.Text.Trim().Replace(" ", String.Empty) == "")
            {
                soruCevap = false;
                MessageBox.Show("Lütfen bir Cevap giriniz");
            }
            if (cevap.Text.Trim().Replace(" ", String.Empty) != "" && soru.Text.Trim().Replace(" ", String.Empty) == "")
            {
                soruCevap = false;
                MessageBox.Show("Lütfen bir soru giriniz");
            }
            if (soru.Text.Trim().Replace(" ", String.Empty) == "" && cevap.Text.Trim().Replace(" ", String.Empty) == "")
            {
                soruCevap = false;
                MessageBox.Show("Soru cevap boş değer alamaz");
            }
            return soruCevap;
        }// soru cevap kontrol





        public bool sifre(TextBox adsoyad, TextBox username, TextBox sifre, TextBox soru, TextBox cevap, GroupBox grup)// şifre güncelleme işlemi;
        {
            bool islem = false;
            conn.Open();
            cmd = new SqlCommand("select * from kullanci_girisi where username='" + username.Text + "'  ", conn);
            read = cmd.ExecuteReader();
            if (read.Read() == true) // okuma işlemi doğeuysa
            {
                if (soru.Text == read["soru"].ToString() && cevap.Text == read["cevap"].ToString())
                {
                    if (this.sifreKontrol(sifre) == true)
                    {
                        conn.Close();
                        conn.Open();
                        cmd = new SqlCommand("update kullanci_girisi set adsoyad='" + adsoyad.Text + "',sifre='" + sifre.Text + "' where username='" + username.Text + "' ", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("işlem Başarılı");
                        islem = true;
                        foreach (Control item in grup.Controls) if (item is TextBox) item.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Şifre 6 karakterden fazla olmalıdır");
                    }


                }
                else
                {
                    MessageBox.Show("Yanlış soru cevap girdiniz");
                }
            }
            else
            {
                MessageBox.Show("Böyle bir kullanıci bulunamadı");
            }
            conn.Close();
            return islem;



        }



    }
}
