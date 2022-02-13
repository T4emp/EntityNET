using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityNET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "localdbDataSet.Phone". При необходимости она может быть перемещена или удалена.
            this.phoneTableAdapter.Fill(this.localdbDataSet.Phone);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создание объекта класса Phone
            Phone phone = new Phone();
            // Присваивание элемента к конкретному ТекстБоксу
            phone.number = textBox1.Text; 
            phone.name = textBox2.Text;
            phone.@operator = textBox3.Text;
            // Создание объекта класса localdbEntities
            localdbEntities localdbEntities = new localdbEntities();
            // Занесение полей в бд "Phone"
            localdbEntities.Phone.Add(phone);
            // Сохранение внесений
            localdbEntities.SaveChanges();

            // Создание объекта класса List
            List<Phone> ListPhone = new List<Phone>();
            // Возврат объекта содержащий элементы из взодной последовательности
            ListPhone = localdbEntities.Phone.ToList();
            // Возврат объекта содержащий данные в dataGridView1
            dataGridView1.DataSource = ListPhone;
        }
    }
}
