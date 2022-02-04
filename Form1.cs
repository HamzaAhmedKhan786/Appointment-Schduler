using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Documents;
using System.Data.SqlClient;

namespace Appointment_Scheduler
{
    public partial class Form1 : Form
    {
        private Data_Object d_obj = new Data_Object();
        private Database db;

        private BindingSource bindingSource1 = new BindingSource();

        public Form1()
        {

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox2.SelectedIndex = 0;
            comboBox2.SelectedItem = 0;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //comboBox1.SelectedIndex = 0;
            comboBox1.SelectedItem = 1;

        }
        private void FillYear()
        {

            int i = DateTime.Now.Year;
            comboBox1.Items.Add(i);

        }
        private void FillMonths()
        {
            List<string> mylist = new List<string>(new string[] { "Select", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }); ;
            comboBox2.DataSource = mylist.ToList();

        }

        private void FillDays()
        {


        }
        private void Form1_Load(object sender, EventArgs e)
        {

            FillYear();
            FillMonths();

        }

        private void Save_Click(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.Text + comboBox2.Text + textBox6.Text);


            int month = d_obj.Create_Month(comboBox2.Text);

            if (month != 0 && comboBox2.SelectedIndex != 0 && comboBox1.SelectedIndex == 0 && textBox3.Text != string.Empty && textBox7.Text != string.Empty && textBox5.Text != string.Empty)
            {

                DateTime dt = new DateTime(int.Parse(comboBox1.Text), month, int.Parse(textBox6.Text));
                string hour = textBox3.Text.Split(':')[0];
                string minute = textBox3.Text.Split(':')[1];
                DateTime time = new DateTime(int.Parse(comboBox1.Text), month, int.Parse(textBox6.Text), int.Parse(hour), int.Parse(minute), 00);


                d_obj.id = Guid.NewGuid();
                d_obj.dt = dt;
                d_obj.time = time;
                d_obj.appointment_subject = textBox7.Text;
                d_obj.desc = textBox4.Text;
                d_obj.attnd = textBox5.Text;


                //(d_obj.dt == null && d_obj.appointment_subject == null && d_obj.attnd == null && d_obj.time == null)
                //                {
                //                    Form1_Load(Close);
                //                }
                db = new Database();
                db.Set_Data(d_obj);
                db.Insert_Data();
            }
            else
            {
                MessageBox.Show("Please Enter Required values");
                Validate();
            }

        }

        private void Form1_Load(Action close)
        {
            throw new NotImplementedException();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fill_Data(button1.Text);
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            fill_Data(button2.Text);
        }
        //private void Desc(string month)
        //{
        //    DataTable dt1 = db.Get_Data(month);
        //    textBox2.Text = dt1.ToString();
        //    //string query;
        //    //query = "SELECT * from dt2 where Appointment_Subject ="+lc.UseColumnTextForLinkValue+ "";
        //    //dt1 = a.executequerydata(query);

        //}
        private void fill_Data(string month)
        {
            db = new Database();
            db.Get_Data(month);
            DataTable dt1 = db.Get_Data(month);
            DataTable dt2 = dt1.DefaultView.ToTable(false, "Date", "Time", "Appointment_Subject");
            DataTable dt3 = dt1.DefaultView.ToTable(false, "Date", "Time", "Appointment_Subject", "Description", "Attendees");
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dt2;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                DataGridViewLinkCell lc = new DataGridViewLinkCell();
                lc.Value = r.Cells[2].Value;
                dataGridView1[2, r.Index] = lc;

            }

            int i =0 ;
            if (dataGridView1.Rows[i].Selected == true)
            {
    
            for (i =0; i < dataGridView1.SelectedCells.Count; i++)
            {
                string a = dt3.Rows[i].ItemArray[0].ToString();
                string b = dt3.Rows[i].ItemArray[1].ToString();
                string c = dt3.Rows[i].ItemArray[2].ToString();
                string d = dt3.Rows[i].ItemArray[3].ToString();
                string e = dt3.Rows[i].ItemArray[4].ToString();
                    string newLine = Environment.NewLine;
                    textBox2.Text = "Date :" + a + newLine + "Time :" + b + newLine + "Subject :" + c + newLine + "Description :" + d + newLine + "Attendees :" + e;
                    break;
            }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fill_Data(button2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fill_Data(button3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fill_Data(button4.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fill_Data(button5.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fill_Data(button6.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fill_Data(button7.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            fill_Data(button8.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            fill_Data(button9.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            fill_Data(button10.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            fill_Data(button11.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            fill_Data(button12.Text);
        }
    }
}
