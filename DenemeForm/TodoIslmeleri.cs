using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenemeForm
{
    internal class TodoIslmeleri
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-T1V9836;Ini" +
            "tial Catalog=kullanici_girisi;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader read;



        public void todoKaydet(TextBox gorevmetni,DateTimePicker tarih,TimeEdit timeEdit)
        {
            conn.Close();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            DateTime secilen = (DateTime)tarih.Value;
            //if (secilen.Day==DateTime.Now.Day)
            //{

            //}
            
            
            string gorevTarihi =  tarih.Value.ToString("yyyy/MM/dd")+" "+
                timeEdit.Text.ToString();           
            
            cmd.CommandText = "insert into TodoLar values('"+Kullanici_formu.girisyapan+"','"+gorevmetni.Text+"','"+gorevTarihi+ "','"+false+"')";
            cmd.ExecuteNonQuery();
            conn.Close();
          


        }

        public void todoGuncelle(TextBox textBox,CheckedListBox checkedListBox,DateTimePicker dateTimePicker,TimeEdit timeEdit)
        {       
            
            conn.Close();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            DateTime secilenTarih = (DateTime)dateTimePicker.Value;
            char[] ayrac = { ':' };
            string[] secilenGorevmetni = checkedListBox.SelectedItem.ToString().Split(ayrac);
            string gorevTarihi = dateTimePicker.Value.ToString("yyyy/MM/dd") + " " +
                timeEdit.Text.ToString();
      
            cmd.CommandText = "update TodoLar set gorevmetni='"+textBox.Text+"' , tmDate='"+gorevTarihi+"' where userid="+Kullanici_formu.girisyapan+" and gorevmetni='" + secilenGorevmetni[0] +"'";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void todoSil(CheckedListBox chclistYapilacakListesi)
        {
            conn.Close ();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            string secilen = (string)chclistYapilacakListesi.Items[chclistYapilacakListesi.SelectedIndex];
            cmd.CommandText = "delete from TodoLar where userid =" + Kullanici_formu.girisyapan + " and gorevmetni = '" + secilen + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void yapilacakDoldur(CheckedListBox chclistYapilacakListesi)
        {
            chclistYapilacakListesi.Items.Clear();
            conn.Close();   
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM TodoLar  inner JOIN  kullanci_girisi on TodoLar.userid = kullanci_girisi.Id where Id="+Kullanici_formu.girisyapan;
            read = cmd.ExecuteReader();
            


            while (read.Read())
            {
                DateTime tarih = (DateTime)read["tmDate"];
                DateTime bugün = DateTime.Now;
                TimeSpan gunfarki = tarih - bugün;

                if ((bool)read["tamamlandimi"] == false && gunfarki.TotalHours<24 && gunfarki.TotalHours>0)
                {
                    DateTime dateTime = (DateTime)read["tmDate"];
                    
                    chclistYapilacakListesi.Items.Add(read["gorevmetni"]+" :   "+ "(Son "+(int)gunfarki.TotalHours +"s "+ (int)gunfarki.Minutes+"dk)");
                }
                    
            }

            conn.Close();

        }

        public void haftayiDoldur(CheckedListBox chclistHaftaninGorevleri)
        {
            chclistHaftaninGorevleri.Items.Clear();
            conn.Close();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM TodoLar  inner JOIN  kullanci_girisi on TodoLar.userid = kullanci_girisi.Id where Id=" + Kullanici_formu.girisyapan;
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                DateTime tarih = (DateTime)read["tmDate"];

                DateTime bugün = DateTime.Now;

                TimeSpan gunfarki = tarih - bugün;

                


                if ((bool)read["tamamlandimi"] == false && gunfarki.TotalDays>1 && gunfarki.TotalDays<8)
                {
                    chclistHaftaninGorevleri.Items.Add(read["gorevmetni"] + " : "+"(Son "+(int)gunfarki.TotalDays+ " gün)");
                }

            }
            conn.Close();


        }

        public void ayiDoldur(CheckedListBox chcAyinGorevleri)
        {
            chcAyinGorevleri.Items.Clear ();
            conn.Close();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM TodoLar  inner JOIN  kullanci_girisi on TodoLar.userid = kullanci_girisi.Id where Id=" + Kullanici_formu.girisyapan;
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                DateTime tarih = (DateTime)read["tmDate"];

                DateTime bugün = DateTime.Now;

                TimeSpan gunFarki = tarih - bugün;

                


                if ((bool)read["tamamlandimi"] == false && gunFarki.TotalDays > 7 && gunFarki.TotalDays < 30)
                {
                    chcAyinGorevleri.Items.Add(read["gorevmetni"] + " :   "+"(Son gün "+tarih.ToString("M")+")" );
                }

            }
            conn.Close();


        }

        public void uzunVadeDoldu(CheckedListBox chcUzunGorevler)
        {
            chcUzunGorevler.Items.Clear();
            conn.Close();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM TodoLar  inner JOIN  kullanci_girisi on TodoLar.userid = kullanci_girisi.Id where Id=" + Kullanici_formu.girisyapan;
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                DateTime tarih = (DateTime)read["tmDate"];

                DateTime bugün = DateTime.Now;

                TimeSpan gunfarki = tarih - bugün;

                


                if ((bool)read["tamamlandimi"] == false && 30<gunfarki.TotalDays)
                {
                    chcUzunGorevler.Items.Add(read["gorevmetni"] + ":   (Son " +(int)gunfarki.TotalDays+ " gün)");
                }

            }
            conn.Close();
        }

        public void suresiDolanlarDoldur(ListBox checkedListBox)
        {
            checkedListBox.Items.Clear();
            conn.Close();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM TodoLar  inner JOIN  kullanci_girisi on TodoLar.userid = kullanci_girisi.Id where Id=" + Kullanici_formu.girisyapan;
            read = cmd.ExecuteReader();


            while (read.Read())
            {
                DateTime tarih = (DateTime)read["tmDate"];

                DateTime bugün = DateTime.Now;

                TimeSpan gunfarki = tarih - bugün;


                if ((bool)read["tamamlandimi"] == false &&  0 > gunfarki.Seconds)
                {
                    checkedListBox.Items.Add(read["gorevmetni"] + ":   Görevin Süresi Geçti");
                }

            }
            conn.Close();









        }

        public void tmListesiDoldur(ListBox lstTamamlananlarList)
        {
            lstTamamlananlarList.Items.Clear();
            conn.Close();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM TodoLar  inner JOIN  kullanci_girisi on TodoLar.userid = kullanci_girisi.Id where Id=" + Kullanici_formu.girisyapan;
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                if ((bool)read["tamamlandimi"]==true)
                {
                    lstTamamlananlarList.Items.Add(read["gorevmetni"].ToString());
                }
            }
                
        }

        public void gorevTamamlandiginda(CheckedListBox chclistYapilacakListesi,int item)
        {


                conn.Close();    
                conn.Open();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                char[] ayrac = {':' };
                string[] gorevmetni = chclistYapilacakListesi.Items[item].ToString().Split(ayrac);
                cmd.CommandText = "update TodoLar set tamamlandimi='True' where gorevmetni='"+gorevmetni[0]+"'";
                cmd.ExecuteNonQuery();
                conn.Close();

                //string gorev = (string)chclistYapilacakListesi.SelectedItem;
                
            
        }

        public void gorevSil(CheckedListBox checkedListBox,int item)
        {
            conn.Close();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            char[] ayrac = { ':' };
            string[] gorevmetni = checkedListBox.Items[item].ToString().Split(ayrac);
            cmd.CommandText = "delete from TodoLar where userid =" + Kullanici_formu.girisyapan + " and gorevmetni = '" +gorevmetni[0]+ "'";
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void itemSecildiginde(CheckedListBox checkedListBox,DateTimePicker dateTimePicker , TimeEdit timeEdit,TextBox textBox)
        {
            if (checkedListBox.SelectedIndex == -1)
            {
                return;
            }
            
            conn.Close();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            char[] ayrac = { ':' };
            string[] gorevmetni = checkedListBox.SelectedItem.ToString().Split(ayrac);
            cmd.CommandText = "SELECT * FROM TodoLar  inner JOIN  kullanci_girisi on TodoLar.userid = kullanci_girisi.Id where Id='"+Kullanici_formu.girisyapan+"' and gorevmetni='"+gorevmetni[0]+"' ";
            read = cmd.ExecuteReader();
            
            while (read.Read())
            {
                DateTime tarih = (DateTime)read["tmDate"];
                string saat = tarih.ToString("T");
                textBox.Text = gorevmetni[0];               
                //dateTimePicker.MinDate = DateTime.Now.AddDays(-2);
                dateTimePicker.Value = tarih;
                timeEdit.EditValue=saat;               
            }
            conn.Close();


        }

        public bool buGorevZatenVarmi(TextBox gorev)
        {
            bool durum = false;
            conn.Close();
            conn.Open();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Todolar where userid='" + Kullanici_formu.girisyapan + "'";
            read = cmd.ExecuteReader();

            while (read.Read()==true)
            {
                if (read["gorevmetni"].ToString()==gorev.Text.ToString())
                {
                    durum = true;
                }
            }
            conn.Close();
            return durum;
        }
    }
}
