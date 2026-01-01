using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Online_Ordering_System
{
    public partial class 點餐頁面 : Form
    {
        public 點餐頁面()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable database = DatabaseHelper.GetSinglProducts();
                
                // 調試：檢查是否有資料
                if (database.Rows.Count == 0)
                {
                    MessageBox.Show("資料庫中沒有產品資料", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                // 設定 DataGridView
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.RowTemplate.Height = 100; // 設定行高以顯示圖片
                
                // 清除現有欄位
                dataGridView1.Columns.Clear();
                
                // 添加產品名稱欄位
                DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
                nameColumn.HeaderText = "產品名稱";
                nameColumn.DataPropertyName = "ProductName";
                nameColumn.Width = 200;
                dataGridView1.Columns.Add(nameColumn);
                
                // 添加價格欄位
                DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
                priceColumn.HeaderText = "價格";
                priceColumn.DataPropertyName = "Price";
                priceColumn.Width = 100;
                priceColumn.DefaultCellStyle.Format = "C2"; // 貨幣格式
                dataGridView1.Columns.Add(priceColumn);
                
                // 添加圖片欄位
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn.HeaderText = "圖片";
                imageColumn.Name = "ImageColumn";
                imageColumn.Width = 150;
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dataGridView1.Columns.Add(imageColumn);
                
                // 綁定資料並載入圖片
                dataGridView1.DataSource = database;
                LoadImages(database);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"載入表單時發生錯誤：\n{ex.Message}\n\n詳細資訊：\n{ex.StackTrace}", 
                    "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadImages(DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (i < dataGridView1.Rows.Count)
                {
                    try
                    {
                        object pictureObj = table.Rows[i]["Picture"];
                        string picturePath = pictureObj != DBNull.Value ? pictureObj.ToString() : "";
                        
                        if (!string.IsNullOrEmpty(picturePath))
                        {
                            Image img = LoadImageFromUrlOrPath(picturePath);
                            
                            if (img != null)
                            {
                                dataGridView1.Rows[i].Cells["ImageColumn"].Value = img;
                            }
                            else
                            {
                                // 如果找不到圖片，使用預設圖片
                                dataGridView1.Rows[i].Cells["ImageColumn"].Value = CreateDefaultImage();
                            }
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells["ImageColumn"].Value = CreateDefaultImage();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"載入第 {i + 1} 個產品的圖片時發生錯誤：\n{ex.Message}", 
                            "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // 載入圖片失敗時使用預設圖片
                        dataGridView1.Rows[i].Cells["ImageColumn"].Value = CreateDefaultImage();
                    }
                }
            }
        }

        private Image LoadImageFromUrlOrPath(string source)
        {
            try
            {
                // 檢查是否為 URL
                if (IsUrl(source))
                {
                    return LoadImageFromUrl(source);
                }
                // 檢查是否為本地檔案路徑
                else if (File.Exists(source))
                {
                    return Image.FromFile(source);
                }
                // 檢查是否為相對路徑
                else
                {
                    string fullPath = Path.Combine(Application.StartupPath, source);
                    if (File.Exists(fullPath))
                    {
                        return Image.FromFile(fullPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"載入圖片失敗：{source}\n錯誤：{ex.Message}", 
                    "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            return null;
        }

        private bool IsUrl(string source)
        {
            return Uri.TryCreate(source, UriKind.Absolute, out Uri uriResult) 
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        private Image LoadImageFromUrl(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    // 下載圖片資料
                    byte[] imageData = client.DownloadData(url);
                    
                    // 將位元組陣列轉換為圖片
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        return new Bitmap(ms);
                    }
                }
            }
            catch (WebException webEx)
            {
                MessageBox.Show($"從網路載入圖片失敗：\nURL: {url}\n錯誤：{webEx.Message}", 
                    "網路錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"處理網路圖片時發生錯誤：\nURL: {url}\n錯誤：{ex.Message}", 
                    "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private Image CreateDefaultImage()
        {
            // 建立一個簡單的預設圖片
            Bitmap bmp = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.LightGray);
                using (Font font = new Font("Arial", 10))
                {
                    g.DrawString("無圖片", font, Brushes.Black, new PointF(25, 40));
                }
            }
            return bmp;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
