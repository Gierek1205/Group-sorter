using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MATMA
{



    public partial class Form1 : Form
    {

        Random rnd = new Random();

        public int trycatch(string tocheck)
        {
            int result = 0;
            
            
            try
            {
                result = Convert.ToInt32(tocheck);
            }
            catch (FormatException)
            {
                MessageBox.Show("Zły format (podaj liczbe)");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Przekroczony zakres (podaj liczbe)");
            }
            

            return result;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.Hide();
            checkedListBox2.Hide();
            
            checkBox1.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int ilosc_uczniow = Convert.ToInt32(textBox1.Text);

            if (checkBox1.Checked )
            {


                for (int x = 1;( x <= ilosc_uczniow && x <= 20); ++x)
                {
                    checkedListBox1.Items.Add(Convert.ToString(x));
                }
                if (ilosc_uczniow > 20)
                {
                    for (int x = 21; x <= ilosc_uczniow; x++)
                    {
                        checkedListBox2.Items.Add(Convert.ToString(x));
                    }
                }


                checkedListBox1.Show();
                if(ilosc_uczniow > 20)
                {
                    checkedListBox2.Show();
                }

            }
            else
            {
                checkedListBox1.Items.Clear();
                checkedListBox2.Items.Clear();
                checkedListBox1.Hide();
                checkedListBox2.Hide();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


            int val = 0;
            checkedListBox1.Items.Clear();

            if (textBox1.TextLength >= 1)
            {
                val = trycatch(textBox1.Text);

            }
            
            if (val >= 1)
            {

                checkBox1.Show();


            }
            else
            {
                checkBox1.Hide();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int grup_val = 0;
            if (textBox2.TextLength >= 1)
            {
                    grup_val = trycatch(textBox2.Text);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            List<int> obecni_list = new List<int>();
            List<int> nieobecni_list = new List<int>();

            foreach(string nieobecny in checkedListBox1.CheckedItems)
            {
                nieobecni_list.Add(Convert.ToInt32(nieobecny));
            }

            foreach (string nieobecny in checkedListBox2.CheckedItems)
            {
                nieobecni_list.Add(Convert.ToInt32(nieobecny));
            }


            int ile_grup = trycatch(textBox2.Text);
            
            int liczba_uczniow = trycatch(textBox1.Text);


            //Lista obecnych
            for(int x = 1; x <= liczba_uczniow; x++)
            {
                if (!nieobecni_list.Contains(x))
                {
                    obecni_list.Add(x);
                }

            }


            int obecni = obecni_list.Count;
            int ile_osob_w_grupie = obecni / ile_grup;
            int reszta_w_grupach = obecni % ile_grup;
            
            

            
            for (int x = 1; x <= ile_grup; x++)
            {
                string nazwa_grupy = "";
                int ile_w_jednej_grupie = obecni / ile_grup;

                if (reszta_w_grupach > 0)
                {
                    ile_w_jednej_grupie = (obecni / ile_grup) + 1;
                }

                List<int> grup = new List<int>();

                do
                {
                    int wylosowany = rnd.Next(1, liczba_uczniow+1);

                    if (obecni_list.Contains(wylosowany))
                    {
                        grup.Add(wylosowany);
                        obecni_list.Remove(wylosowany);
                    }


                } while (grup.Count < ile_w_jednej_grupie);

                foreach(int numer in grup)
                {
                    nazwa_grupy += Convert.ToString(numer + ", ");
                }

                if (reszta_w_grupach > 0)
                {
                    reszta_w_grupach -= 1;
                }
                listView1.Items.Add(nazwa_grupy);

            }
            






        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Gierek1205/Group-sorter");
        }
    }
}
