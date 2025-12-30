using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Ordering_System
{
    public partial class 點餐頁面 : Form
    {
        public 點餐頁面()
        {
            InitializeComponent();
        }

        private void materialExpansionPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList; // 或 DropDown
            for (int i = 1; i <= 10; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
            DataTable  table = DatabaseHelper.GetSinglProducts();
            price珍珠奶茶.Text = table.Rows[0]["ProductName"].ToString();
            price珍珠奶茶.Text += table.Rows[0]["Price"].ToString();

            芒果冰沙.Text = table.Rows[1]["ProductName"].ToString();
            芒果冰沙.Text += table.Rows[1]["Price"].ToString();

            抹茶拿鐵.Text = table.Rows[2]["ProductName"].ToString();
            抹茶拿鐵.Text += table.Rows[2]["Price"].ToString();

            經典美式咖啡.Text = table.Rows[3]["ProductName"].ToString();
            經典美式咖啡.Text += table.Rows[3]["Price"].ToString();

            草莓奶昔.Text = table.Rows[4]["ProductName"].ToString();
            草莓奶昔.Text += table.Rows[4]["Price"].ToString();

            八冰綠.Text = table.Rows[5]["ProductName"].ToString();
            八冰綠.Text += table.Rows[5]["Price"].ToString();
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
              
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void price珍珠奶茶_Click(object sender, EventArgs e)
        {

        }

        private void buy珍珠奶茶_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBox1.Text += comboBox1.SelectedItem.ToString();
           
        }

        private void customer_number_Click(object sender, EventArgs e)
        {

        }
    }
}
