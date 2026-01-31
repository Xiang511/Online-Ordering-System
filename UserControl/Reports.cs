using AntdUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Ordering_System
{
    public partial class Reports : UserControl
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            // 設定 Segmented 選項
            segmented1.Items.Clear();
            segmented1.Items.Add(new AntdUI.SegmentedItem { Text = "銷售趨勢" });
            segmented1.Items.Add(new AntdUI.SegmentedItem { Text = "產品排名" });
            segmented1.Items.Add(new AntdUI.SegmentedItem { Text = "用戶統計" });
            segmented1.SelectIndex = 0;

            // 設定 DataGridView 樣式
            ConfigureDataGridView();

            // 載入統計卡片
            LoadCardInfo();

            // 載入預設報表
            LoadSalesTrendReport();
        }

        /// <summary>
        /// 設定 DataGridView 外觀
        /// </summary>
        private void ConfigureDataGridView()
        {
            Color borderColor = Color.FromArgb(240, 240, 240);
            Color headerBg = Color.White;
            Color textColor = Color.FromArgb(217, 0, 0, 0);

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = borderColor;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 45;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = headerBg;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = textColor;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerBg;

            dgv.RowTemplate.Height = 45;
            dgv.RowHeadersVisible = false;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 247, 255);
            dgv.DefaultCellStyle.SelectionForeColor = textColor;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.Padding = new Padding(10, 0, 10, 0);

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
        }

        /// <summary>
        /// Segmented 選項變更事件
        /// </summary>
        private void segmented1_SelectIndexChanged(object sender, IntEventArgs e)
        {
            try
            {
                dgv.DataSource = null;

                switch (e.Value)
                {
                    case 0: // 銷售趨勢
                        LoadSalesTrendReport();
                        break;
                    case 1: // 產品排名
                        LoadProductRankingReport();
                        break;
                    case 2: // 用戶統計
                        LoadUserStatisticsReport();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"載入報表失敗: {ex.Message}", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 載入統計卡片資訊
        /// </summary>
        void LoadCardInfo()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    // 銷售總額
                    string query1 = "SELECT ISNULL(SUM(totalamount), 0) FROM Orders";
                    using (SqlCommand cmd = new SqlCommand(query1, connection))
                    {
                        object result = cmd.ExecuteScalar();
                        decimal totalSales = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                        label5.Text = totalSales.ToString("C0");
                    }

                    // 訂單總數
                    string query2 = "SELECT COUNT(orderid) FROM Orders";
                    using (SqlCommand cmd = new SqlCommand(query2, connection))
                    {
                        label6.Text = cmd.ExecuteScalar().ToString() + " 筆";
                    }

                    // 平均訂單金額
                    string query3 = "SELECT ISNULL(AVG(totalamount), 0) FROM Orders";
                    using (SqlCommand cmd = new SqlCommand(query3, connection))
                    {
                        object result = cmd.ExecuteScalar();
                        decimal avgAmount = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                        label9.Text = avgAmount.ToString("C0");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"載入卡片資訊失敗: {ex.Message}");
            }
        }

        /// <summary>
        /// 載入銷售趨勢報表
        /// </summary>
        private void LoadSalesTrendReport()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    
                    // 獲取最近 30 天的銷售數據
                    string query = @"
                        SELECT 
                            CONVERT(DATE, orderdate) AS '日期',
                            COUNT(orderid) AS '訂單數量',
                            SUM(totalamount) AS '銷售總額',
                            AVG(totalamount) AS '平均金額',
                            MIN(totalamount) AS '最小金額',
                            MAX(totalamount) AS '最大金額'
                        FROM Orders
                        WHERE orderdate >= DATEADD(DAY, -30, GETDATE())
                        GROUP BY CONVERT(DATE, orderdate)
                        ORDER BY CONVERT(DATE, orderdate) DESC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            dgv.DataSource = dt;
                            FormatSalesTrendColumns();
                            label2.Text = $"最近 30 天銷售趨勢 - 共 {dt.Rows.Count} 天有訂單記錄";
                        }
                        else
                        {
                            MessageBox.Show("最近 30 天沒有銷售數據", "提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"載入銷售趨勢報表失敗: {ex.Message}", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 載入產品排名報表
        /// </summary>
        private void LoadProductRankingReport()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    
                    string query = @"
                        SELECT 
                            ROW_NUMBER() OVER (ORDER BY SUM(od.quantity) DESC) AS '排名',
                            p.productname AS '產品名稱',
                            c.categoryname AS '類別',
                            COUNT(DISTINCT od.orderid) AS '訂單次數',
                            SUM(od.quantity) AS '銷售數量',
                            SUM(od.quantity * od.price) AS '銷售金額',
                            AVG(od.price) AS '平均單價',
                            p.stock AS '庫存'
                        FROM OrderDetail od
                        INNER JOIN Product p ON od.productid = p.productid
                        INNER JOIN Category c ON p.categoryid = c.categoryid
                        GROUP BY p.productname, c.categoryname, p.stock
                        ORDER BY SUM(od.quantity) DESC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            dgv.DataSource = dt;
                            FormatProductRankingColumns();
                            
                            // 計算統計資訊
                            decimal totalSales = 0;
                            int totalQuantity = 0;
                            foreach (DataRow row in dt.Rows)
                            {
                                totalSales += Convert.ToDecimal(row["銷售金額"]);
                                totalQuantity += Convert.ToInt32(row["銷售數量"]);
                            }
                            
                            label2.Text = $"產品銷售排名 - 共 {dt.Rows.Count} 個產品 | 總銷量: {totalQuantity} 件 | 總金額: {totalSales:C0}";
                        }
                        else
                        {
                            MessageBox.Show("暫無產品銷售數據", "提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"載入產品排名報表失敗: {ex.Message}", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 載入用戶統計報表
        /// </summary>
        private void LoadUserStatisticsReport()
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    
                    string query = @"
                        SELECT 
                            u.username AS '用戶名稱',
                            u.email AS '電子郵件',
                            u.phone AS '電話',
                            CONVERT(VARCHAR(10), u.createdate, 120) AS '註冊日期',
                            COUNT(o.orderid) AS '訂單總數',
                            ISNULL(SUM(o.totalamount), 0) AS '消費總額',
                            ISNULL(AVG(o.totalamount), 0) AS '平均消費',
                            CONVERT(VARCHAR(10), MAX(o.orderdate), 120) AS '最後訂購'
                        FROM [User] u
                        LEFT JOIN Orders o ON u.userid = o.userid
                        GROUP BY u.username, u.email, u.phone, u.createdate
                        ORDER BY ISNULL(SUM(o.totalamount), 0) DESC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            dgv.DataSource = dt;
                            FormatUserStatisticsColumns();
                            label2.Text = $"用戶消費統計 - 共 {dt.Rows.Count} 個用戶";
                        }
                        else
                        {
                            MessageBox.Show("暫無用戶數據", "提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"載入用戶統計報表失敗: {ex.Message}", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 格式化銷售趨勢欄位
        /// </summary>
        private void FormatSalesTrendColumns()
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (col.Name.Contains("金額"))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.DefaultCellStyle.Format = "C0";
                }
                else if (col.Name.Contains("數量"))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        /// <summary>
        /// 格式化產品排名欄位
        /// </summary>
        private void FormatProductRankingColumns()
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Name == "產品名稱" || col.Name == "類別")
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    col.Width = 150;
                }
                else if (col.Name.Contains("金額") || col.Name.Contains("單價"))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.DefaultCellStyle.Format = "C0";
                    col.Width = 120;
                }
                else
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.Width = 100;
                }
            }
        }

        /// <summary>
        /// 格式化用戶統計欄位
        /// </summary>
        private void FormatUserStatisticsColumns()
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Name == "用戶名稱" || col.Name == "電子郵件")
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    col.Width = 150;
                }
                else if (col.Name.Contains("金額"))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.DefaultCellStyle.Format = "C0";
                    col.Width = 120;
                }
                else
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.Width = 100;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
