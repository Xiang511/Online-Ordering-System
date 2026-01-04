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

            
            Width = 1500;
            Height = 800;

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


        private void toolStripLblLogout_Click(object sender, EventArgs e)
        {
            globalVal.Username = string.Empty;
            globalVal.UserOrderCount = 0;
            this.Close();
            Form1 loginForm = new Form1();
            loginForm.Show();
            MessageBox.Show("已登出！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
