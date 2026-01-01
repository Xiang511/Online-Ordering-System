using MaterialSkin;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            panel1.Dock = DockStyle.Fill;

            // 修正：Image.Width 是唯讀屬性，無法直接設定。需先建立一個指定大小的新 Image，再指派給 toolStripLblTitle.Image。
            if (toolStripLblTitle.Image != null)
            {
                toolStripLblTitle.Image = new Bitmap(toolStripLblTitle.Image, new Size(38, 38));
            }

            toolStripLblTitle.Paint += toolStripLblHome_Paint; // 註冊 Paint 事件

            pictureBox1.Image = new Bitmap(pictureBox1.Image, new Size(38, 38));
            
            // 顯示使用者名稱和訂單計數
            LblUsername.Text = globalVal.Username;
            LblOrderCount.Text = globalVal.UserOrderCount.ToString();

            // 載入使用者訂單資料到 DataGridView
            LoadUserOrders();
        }

        /// <summary>
        /// 載入使用者訂單資料到 DataGridView
        /// </summary>
        private void LoadUserOrders()
        {
            try
            {
                // 取得訂單資料
                DataTable ordersData = DatabaseHelper.GetUserOrders(globalVal.Username);

                // 綁定到 DataGridView
                dataGridView1.DataSource = ordersData;

                // 設定 DataGridView 外觀
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"載入訂單資料時發生錯誤：\n{ex.Message}", 
                    "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 設定 DataGridView 的外觀和格式
        /// </summary>
        private void ConfigureDataGridView()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                // 設定欄位標題
                dataGridView1.Columns["OrderId"].HeaderText = "訂單編號";
                dataGridView1.Columns["ProductName"].HeaderText = "產品名稱";
                dataGridView1.Columns["Quantity"].HeaderText = "數量";
                dataGridView1.Columns["Price"].HeaderText = "單價";
                dataGridView1.Columns["TotalAmount"].HeaderText = "總金額";
                dataGridView1.Columns["OrderDate"].HeaderText = "訂購日期";
                dataGridView1.Columns["Status"].HeaderText = "狀態";

                // 設定欄位寬度
                dataGridView1.Columns["OrderId"].Width = 80;
                dataGridView1.Columns["ProductName"].Width = 200;
                dataGridView1.Columns["Quantity"].Width = 80;
                dataGridView1.Columns["Price"].Width = 100;
                dataGridView1.Columns["TotalAmount"].Width = 100;
                dataGridView1.Columns["OrderDate"].Width = 150;
                dataGridView1.Columns["Status"].Width = 100;

                // 設定數字和日期格式
                dataGridView1.Columns["Price"].DefaultCellStyle.Format = "C2"; // 貨幣格式
                dataGridView1.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
                dataGridView1.Columns["OrderDate"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm";

                // 設定對齊方式
                dataGridView1.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // 設定整體外觀
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;

                // 設定交替行顏色
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            LoadUserControl<UserControl1>();
        }

        private void toolStripLblHome_Paint(object sender, PaintEventArgs e)
        {
            ToolStripLabel lbl = sender as ToolStripLabel;
            if (lbl != null)
            {
                Rectangle rect = lbl.Bounds;
                using (Pen pen = new Pen(ColorTranslator.FromHtml("#F4F4F5"), 1))
                {
                    e.Graphics.DrawLine(pen, 0, rect.Height - 1, rect.Width, rect.Height - 1);
                }
            }
        }

        /// <summary>
        /// 載入 UserControl 到 panel1 的共用方法
        /// </summary>
        /// <typeparam name="T">UserControl 類型</typeparam>
        private void LoadUserControl<T>() where T : UserControl, new()
        {
            // 清除 panel1 中的所有控件
            panel1.Controls.Clear();

            // 創建新的 UserControl 實例
            T userControl = new T();
            userControl.Dock = DockStyle.Fill;

            // 添加到 panel1
            panel1.Controls.Add(userControl);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
