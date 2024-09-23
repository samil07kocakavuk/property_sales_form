using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=sahibinden.accdb");
        private void verigör()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select * from daire";
            OleDbDataReader oku = komut.ExecuteReader();
            listView1.Items.Clear();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["kod"].ToString();
                ekle.SubItems.Add(oku["etip"].ToString());
                ekle.SubItems.Add(oku["mkare"].ToString());
                ekle.SubItems.Add(oku["osay"].ToString());
                ekle.SubItems.Add(oku["byas"].ToString());
                ekle.SubItems.Add(oku["kat"].ToString());
                ekle.SubItems.Add(oku["isitma"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["il"].ToString());
                ekle.SubItems.Add(oku["ilce"].ToString());
                ekle.SubItems.Add(oku["mah"].ToString());
                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            verigör();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "insert into daire (kod,etip,mkare,osay,byas,kat,isitma,fiyat,il,ilce,mah) values ('" + textBox1.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "')";
            komut.ExecuteNonQuery();
            baglanti.Close();
            verigör();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
            comboBox4.Text = null;

        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select * from daire where kod = '" + textBox1.Text.ToString() + "'";
            OleDbDataReader oku = komut.ExecuteReader();
            oku.Read();
            textBox2.Text = oku["mkare"].ToString();
            textBox3.Text = oku["byas"].ToString();
            textBox4.Text = oku["fiyat"].ToString();
            textBox5.Text = oku["il"].ToString();
            textBox6.Text = oku["ilce"].ToString();
            textBox7.Text = oku["mah"].ToString();
            comboBox1.Text = oku["etip"].ToString();
            comboBox2.Text = oku["osay"].ToString();
            comboBox3.Text = oku["kat"].ToString();
            comboBox4.Text = oku["isitma"].ToString();
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "delete  from daire where kod = '" + textBox1.Text.ToString() + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            verigör();



        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "update daire set etip  = '" + comboBox1.Text + "',mkare = '" + textBox2.Text + "', osay = '" + comboBox2.Text + "',byas = '" + textBox3.Text + "',kat = '" + comboBox3.Text + "',isitma = '" + comboBox4.Text + "',fiyat = '" + textBox4.Text + "',il = '" + textBox5.Text + "',ilce = '" + textBox6.Text + "',mah = '" + textBox7.Text + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            verigör();

        }

        

        
    }
}
