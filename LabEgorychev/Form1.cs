using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LabEgorychev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        database db = new database("127.0.0.1","root", "", "labsbd");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string telephone = textBox2.Text;
            string work = textBox3.Text;
            DateTime date = dateTimePicker1.Value;
            int staj = (int)numericUpDown1.Value;
            string information = textBox4.Text;
            var end = db.download(name, telephone, work, date, staj, information);
            if(end != -1)
            {
                label1.Text = String.Format("Вставленный id: {0}", end);
            }
            else
            {
                label1.Text = ("Ошибка.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
