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
    public partial class FrmYeni : Form //frmTodoEkranı
    {
        public FrmYeni()
        {
            InitializeComponent();
        }

        TodoIslmeleri todoIslmeleri1 = new TodoIslmeleri();


        private void FrmYeni_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;
            timeEdit1.EditValue = DateTime.Now.ToString("T");
            txtYeniGorev.Text = String.Empty;
            todoIslmeleri1.yapilacakDoldur(chclistYapilacakListesi);
            todoIslmeleri1.haftayiDoldur(chclistHaftaninGorevleri);
            todoIslmeleri1.ayiDoldur(chcAyinGorevleri);
            todoIslmeleri1.uzunVadeDoldu(chcUzunGorevler);
            todoIslmeleri1.suresiDolanlarDoldur(lstSuresiDolanlar);
            todoIslmeleri1.tmListesiDoldur(lstTamamlananlarList);
        }








        private void btnYeni_Click(object sender, EventArgs e)
        {
            if (todoIslmeleri1.buGorevZatenVarmi(txtYeniGorev))
            {
                MessageBox.Show("Bu isimde bir görev zaten var");
            }
            else
            {
                if (txtYeniGorev.Text.Trim().Replace(" ", String.Empty) == "")
                {
                    MessageBox.Show("Boş değer girilemez");
                }
                else
                {

                    todoIslmeleri1.todoKaydet(txtYeniGorev, dateTimePicker1, timeEdit1);// yapilacak listesi kaydet içinde yap
                    todoIslmeleri1.yapilacakDoldur(chclistYapilacakListesi);
                    todoIslmeleri1.haftayiDoldur(chclistHaftaninGorevleri);
                    todoIslmeleri1.ayiDoldur(chcAyinGorevleri);
                    todoIslmeleri1.uzunVadeDoldu(chcUzunGorevler);
                    todoIslmeleri1.suresiDolanlarDoldur(lstSuresiDolanlar);
                }



                //this.chclistYapilacakListesi.Items.Add(yeniGorev);
            }


        }

        private void chclistYapilacakListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            todoIslmeleri1.itemSecildiginde(chclistYapilacakListesi, dateTimePicker1, timeEdit1, txtYeniGorev);

        }
        private void chclistHaftaninGorevleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            todoIslmeleri1.itemSecildiginde(chclistHaftaninGorevleri, dateTimePicker1, timeEdit1, txtYeniGorev);
        }

        private void chcAyinGorevleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            todoIslmeleri1.itemSecildiginde(chcAyinGorevleri, dateTimePicker1, timeEdit1, txtYeniGorev);
        }

        private void chcUzunGorevler_SelectedIndexChanged(object sender, EventArgs e)
        {
            todoIslmeleri1.itemSecildiginde(chcUzunGorevler, dateTimePicker1, timeEdit1, txtYeniGorev);
        }


        private void btnDuzelt_Click(object sender, EventArgs e)
        {
            if (todoIslmeleri1.buGorevZatenVarmi(txtYeniGorev))
            {
                MessageBox.Show("bu isimde bir görev zaten var!");
            }
            else
            {
                if (txtYeniGorev.Text.Trim().Replace(" ", String.Empty) == "")
                {
                    MessageBox.Show("Boş değer girilmez");
                }
                else
                {
                    if (chclistYapilacakListesi.SelectedIndex > -1)
                    {
                        todoIslmeleri1.todoGuncelle(txtYeniGorev, chclistYapilacakListesi, dateTimePicker1, timeEdit1);
                        todoIslmeleri1.yapilacakDoldur(chclistYapilacakListesi);
                        todoIslmeleri1.haftayiDoldur(chclistHaftaninGorevleri);
                        todoIslmeleri1.ayiDoldur(chcAyinGorevleri);
                        todoIslmeleri1.uzunVadeDoldu(chcUzunGorevler);
                        todoIslmeleri1.tmListesiDoldur(lstTamamlananlarList);
                    }
                    if (chclistHaftaninGorevleri.SelectedIndex > -1)
                    {
                        todoIslmeleri1.todoGuncelle(txtYeniGorev, chclistHaftaninGorevleri, dateTimePicker1, timeEdit1);
                        todoIslmeleri1.yapilacakDoldur(chclistYapilacakListesi);
                        todoIslmeleri1.haftayiDoldur(chclistHaftaninGorevleri);
                        todoIslmeleri1.ayiDoldur(chcAyinGorevleri);
                        todoIslmeleri1.uzunVadeDoldu(chcUzunGorevler);
                        todoIslmeleri1.tmListesiDoldur(lstTamamlananlarList);
                    }
                    if (chcAyinGorevleri.SelectedIndex > -1)
                    {
                        todoIslmeleri1.todoGuncelle(txtYeniGorev, chcAyinGorevleri, dateTimePicker1, timeEdit1);
                        todoIslmeleri1.yapilacakDoldur(chclistYapilacakListesi);
                        todoIslmeleri1.haftayiDoldur(chclistHaftaninGorevleri);
                        todoIslmeleri1.ayiDoldur(chcAyinGorevleri);
                        todoIslmeleri1.uzunVadeDoldu(chcUzunGorevler);
                        todoIslmeleri1.tmListesiDoldur(lstTamamlananlarList);
                    }
                    if (chcUzunGorevler.SelectedIndex > -1)
                    {
                        todoIslmeleri1.todoGuncelle(txtYeniGorev, chcUzunGorevler, dateTimePicker1, timeEdit1);
                        todoIslmeleri1.yapilacakDoldur(chclistYapilacakListesi);
                        todoIslmeleri1.haftayiDoldur(chclistHaftaninGorevleri);
                        todoIslmeleri1.ayiDoldur(chcAyinGorevleri);
                        todoIslmeleri1.uzunVadeDoldu(chcUzunGorevler);
                        todoIslmeleri1.tmListesiDoldur(lstTamamlananlarList);
                    }
                }


            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (chclistYapilacakListesi.SelectedIndex == -1)
            {
                MessageBox.Show("lütfen silme işlemi için bir seçin");
                return;
            }


            todoIslmeleri1.todoSil(chclistYapilacakListesi);
            todoIslmeleri1.yapilacakDoldur(chclistYapilacakListesi);
            todoIslmeleri1.haftayiDoldur(chclistHaftaninGorevleri);
            todoIslmeleri1.ayiDoldur(chcAyinGorevleri);
            todoIslmeleri1.uzunVadeDoldu(chcUzunGorevler);
            todoIslmeleri1.tmListesiDoldur(lstTamamlananlarList);

            txtYeniGorev.Text = "";

        }

        private void btnKes_Click(object sender, EventArgs e)
        {
            txtYeniGorev.Cut();
        }

        private void btnKopyala_Click(object sender, EventArgs e)
        {
            txtYeniGorev.Copy();
        }

        private void btnYapistir_Click(object sender, EventArgs e)
        {
            txtYeniGorev.Paste();
        }








        //private void btnTamam_Click(object sender, EventArgs e)
        //{
        //    if (chclistYapilacakListesi.CheckedItems.Count<1)
        //    {
        //        MessageBox.Show("lütfen bir görev seçiniz");
        //        MessageBox.Show(dateTimePicker1.Value.ToString("yyyy/MM/dd HH: mm:ss"));
        //    }
        //    else
        //    {


        //        for (int i = 0; i < chclistYapilacakListesi.CheckedItems.Count; i++)
        //        {
        //            todoIslmeleri1.gorevTamamlandiginda(chclistYapilacakListesi,i);
        //            todoIslmeleri1.yapilacakDoldur(chclistYapilacakListesi);
        //            todoIslmeleri1.haftayiDoldur(chclistHaftaninGorevleri);
        //            todoIslmeleri1.ayiDoldur(chcAyinGorevleri);
        //            todoIslmeleri1.uzunVadeDoldu(chcUzunGorevler);
        //            todoIslmeleri1.tmListesiDoldur(lstTamamlananlarList);

        //        }
        //        //chclistYapilacakListesi.SelectedIndex = -1;
        //    }

        //}

        private void chclistYapilacakListesi_MouseLeave(object sender, EventArgs e)
        {
            //chclistYapilacakListesi.SelectedIndex = -1;

        }

        private void chclistHaftaninGorevleri_MouseLeave(object sender, EventArgs e)
        {
            //chclistHaftaninGorevleri.SelectedIndex = -1;
        }

        private void btnGorevEkle_Click(object sender, EventArgs e)
        {

        }

        private void chcAyinGorevleri_MouseClick(object sender, MouseEventArgs e)
        {
            chclistYapilacakListesi.SelectedIndex = -1;
            chclistHaftaninGorevleri.SelectedIndex = -1;
            chcUzunGorevler.SelectedIndex = -1;
        }

        private void chclistHaftaninGorevleri_MouseClick(object sender, MouseEventArgs e)
        {
            chclistYapilacakListesi.SelectedIndex = -1;
            chcUzunGorevler.SelectedIndex = -1;
            chcAyinGorevleri.SelectedIndex = -1;
        }

        private void chcUzunGorevler_MouseClick(object sender, MouseEventArgs e)
        {
            chclistYapilacakListesi.SelectedIndex = -1;
            chcAyinGorevleri.SelectedIndex = -1;
            chclistHaftaninGorevleri.SelectedIndex = -1;
        }

        private void chclistYapilacakListesi_MouseClick(object sender, MouseEventArgs e)
        {
            chclistHaftaninGorevleri.SelectedIndex = -1;
            chcAyinGorevleri.SelectedIndex = -1;
            chcUzunGorevler.SelectedIndex = -1;
        }


        private void btnsmplGunuKaydet_Click(object sender, EventArgs e)
        {
            if (chclistYapilacakListesi.CheckedItems.Count < 1)
            {
                MessageBox.Show("lütfen bir görev seçiniz");
            }
            else
            {


                for (int i = 0; i < chclistYapilacakListesi.CheckedItems.Count; i++)
                {
                    todoIslmeleri1.gorevTamamlandiginda(chclistYapilacakListesi, i);
                    todoIslmeleri1.yapilacakDoldur(chclistYapilacakListesi);
                    todoIslmeleri1.haftayiDoldur(chclistHaftaninGorevleri);
                    todoIslmeleri1.ayiDoldur(chcAyinGorevleri);
                    todoIslmeleri1.uzunVadeDoldu(chcUzunGorevler);
                    todoIslmeleri1.tmListesiDoldur(lstTamamlananlarList);

                }
                //chclistYapilacakListesi.SelectedIndex = -1;
            }
        }

        private void btnsmplHaftanin_Click(object sender, EventArgs e)
        {
            if (chclistHaftaninGorevleri.CheckedItems.Count < 1)
            {
                MessageBox.Show("lütfen bir görev seçiniz");
            }
            else
            {


                for (int i = 0; i < chclistHaftaninGorevleri.CheckedItems.Count; i++)
                {
                    todoIslmeleri1.gorevTamamlandiginda(chclistHaftaninGorevleri, i);
                    todoIslmeleri1.yapilacakDoldur(chclistYapilacakListesi);
                    todoIslmeleri1.haftayiDoldur(chclistHaftaninGorevleri);
                    todoIslmeleri1.ayiDoldur(chcAyinGorevleri);
                    todoIslmeleri1.uzunVadeDoldu(chcUzunGorevler);
                    todoIslmeleri1.tmListesiDoldur(lstTamamlananlarList);

                }
                //chclistYapilacakListesi.SelectedIndex = -1;
            }
        }

        private void btnsmplAyin_Click(object sender, EventArgs e)
        {
            if (chcAyinGorevleri.CheckedItems.Count < 1)
            {
                MessageBox.Show("lütfen bir görev seçiniz");
            }
            else
            {


                for (int i = 0; i < chcAyinGorevleri.CheckedItems.Count; i++)
                {
                    todoIslmeleri1.gorevTamamlandiginda(chcAyinGorevleri, i);
                    todoIslmeleri1.yapilacakDoldur(chclistYapilacakListesi);
                    todoIslmeleri1.haftayiDoldur(chclistHaftaninGorevleri);
                    todoIslmeleri1.ayiDoldur(chcAyinGorevleri);
                    todoIslmeleri1.uzunVadeDoldu(chcUzunGorevler);
                    todoIslmeleri1.tmListesiDoldur(lstTamamlananlarList);

                }
                //chclistYapilacakListesi.SelectedIndex = -1;
            }
        }

        private void btnsmplUzun_Click(object sender, EventArgs e)
        {
            if (chcUzunGorevler.CheckedItems.Count < 1)
            {
                MessageBox.Show("lütfen bir görev seçiniz");
            }
            else
            {
                for (int i = 0; i < chcUzunGorevler.CheckedItems.Count; i++)
                {
                    todoIslmeleri1.gorevTamamlandiginda(chcUzunGorevler, i);
                    todoIslmeleri1.yapilacakDoldur(chclistYapilacakListesi);
                    todoIslmeleri1.haftayiDoldur(chclistHaftaninGorevleri);
                    todoIslmeleri1.ayiDoldur(chcAyinGorevleri);
                    todoIslmeleri1.uzunVadeDoldu(chcUzunGorevler);
                    todoIslmeleri1.tmListesiDoldur(lstTamamlananlarList);
                }
                //chclistYapilacakListesi.SelectedIndex = -1;
            }
        }

        private void btnsmplGunuSil_Click(object sender, EventArgs e)
        {
            if (chclistYapilacakListesi.CheckedItems.Count < 1)
            {
                MessageBox.Show("lütfen bir görev seçiniz");
            }
            else
            {


                for (int i = 0; i < chclistYapilacakListesi.CheckedItems.Count; i++)
                {
                    todoIslmeleri1.gorevSil(chclistYapilacakListesi, i);
                    todoIslmeleri1.yapilacakDoldur(chclistYapilacakListesi);
                    todoIslmeleri1.haftayiDoldur(chclistHaftaninGorevleri);
                    todoIslmeleri1.ayiDoldur(chcAyinGorevleri);
                    todoIslmeleri1.uzunVadeDoldu(chcUzunGorevler);
                    todoIslmeleri1.tmListesiDoldur(lstTamamlananlarList);

                }
                //chclistYapilacakListesi.SelectedIndex = -1;
            }
        }

        private void btnsmplHaftayiSil_Click(object sender, EventArgs e)
        {
            if (chclistHaftaninGorevleri.CheckedItems.Count < 1)
            {
                MessageBox.Show("lütfen bir görev seçiniz");
            }
            else
            {


                for (int i = 0; i < chclistHaftaninGorevleri.CheckedItems.Count; i++)
                {
                    todoIslmeleri1.gorevSil(chclistHaftaninGorevleri, i);
                    todoIslmeleri1.yapilacakDoldur(chclistYapilacakListesi);
                    todoIslmeleri1.haftayiDoldur(chclistHaftaninGorevleri);
                    todoIslmeleri1.ayiDoldur(chcAyinGorevleri);
                    todoIslmeleri1.uzunVadeDoldu(chcUzunGorevler);
                    todoIslmeleri1.tmListesiDoldur(lstTamamlananlarList);

                }
                //chclistYapilacakListesi.SelectedIndex = -1;
            }
        }

        private void btnsmplAyiSil_Click(object sender, EventArgs e)
        {
            if (chcAyinGorevleri.CheckedItems.Count < 1)
            {
                MessageBox.Show("lütfen bir görev seçiniz");
            }
            else
            {


                for (int i = 0; i < chcAyinGorevleri.CheckedItems.Count; i++)
                {
                    todoIslmeleri1.gorevSil(chcAyinGorevleri, i);
                    todoIslmeleri1.yapilacakDoldur(chclistYapilacakListesi);
                    todoIslmeleri1.haftayiDoldur(chclistHaftaninGorevleri);
                    todoIslmeleri1.ayiDoldur(chcAyinGorevleri);
                    todoIslmeleri1.uzunVadeDoldu(chcUzunGorevler);
                    todoIslmeleri1.tmListesiDoldur(lstTamamlananlarList);

                }
                //chclistYapilacakListesi.SelectedIndex = -1;
            }
        }

        private void btnsmplUzunSil_Click(object sender, EventArgs e)
        {
            if (chcUzunGorevler.CheckedItems.Count < 1)
            {
                MessageBox.Show("lütfen bir görev seçiniz");
            }
            else
            {


                for (int i = 0; i < chcUzunGorevler.CheckedItems.Count; i++)
                {
                    todoIslmeleri1.gorevSil(chcUzunGorevler, i);
                    todoIslmeleri1.yapilacakDoldur(chclistYapilacakListesi);
                    todoIslmeleri1.haftayiDoldur(chclistHaftaninGorevleri);
                    todoIslmeleri1.ayiDoldur(chcAyinGorevleri);
                    todoIslmeleri1.uzunVadeDoldu(chcUzunGorevler);
                    todoIslmeleri1.tmListesiDoldur(lstTamamlananlarList);

                }
                //chclistYapilacakListesi.SelectedIndex = -1;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime secilen = (DateTime)dateTimePicker1.Value;
            if (secilen.Day==DateTime.Now.Day)
            {
               
                timeEdit1.EditValue = secilen.ToString("T");
            }
        }
    }// frmYEni
}
