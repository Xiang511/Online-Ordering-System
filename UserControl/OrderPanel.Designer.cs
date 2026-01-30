namespace Online_Ordering_System
{
    partial class OrderPanel
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.materialCard2 = new MaterialSkin.Controls.MaterialCard();
            this.listView2 = new System.Windows.Forms.ListView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.onlineOrderingSystemDataSet = new Online_Ordering_System.OnlineOrderingSystemDataSet();
            this.ordersTableAdapter = new Online_Ordering_System.OnlineOrderingSystemDataSetTableAdapters.OrdersTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.materialCard3 = new MaterialSkin.Controls.MaterialCard();
            this.AdminToolSave = new System.Windows.Forms.Button();
            this.AdminTool = new System.Windows.Forms.GroupBox();
            this.AdminToolCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.materialCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlineOrderingSystemDataSet)).BeginInit();
            this.materialCard3.SuspendLayout();
            this.AdminTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard2
            // 
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.Controls.Add(this.listView2);
            this.materialCard2.Depth = 0;
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(450, 125);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(545, 550);
            this.materialCard2.TabIndex = 1;
            // 
            // listView2
            // 
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(1, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(544, 550);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(415, 550);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "orderid";
            this.dataGridViewTextBoxColumn1.HeaderText = "編號";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 54;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "orderdate";
            this.dataGridViewTextBoxColumn2.HeaderText = "日期";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 54;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "status";
            this.dataGridViewTextBoxColumn3.HeaderText = "狀態";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 54;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "totalamount";
            this.dataGridViewTextBoxColumn4.HeaderText = "金額";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 54;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Orders";
            this.bindingSource1.DataSource = this.onlineOrderingSystemDataSet;
            // 
            // onlineOrderingSystemDataSet
            // 
            this.onlineOrderingSystemDataSet.DataSetName = "OnlineOrderingSystemDataSet";
            this.onlineOrderingSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ordersTableAdapter
            // 
            this.ordersTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(14, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "查看訂單歷史紀錄";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "訂單管理";
            // 
            // materialCard3
            // 
            this.materialCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard3.Controls.Add(this.dataGridView1);
            this.materialCard3.Depth = 0;
            this.materialCard3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard3.Location = new System.Drawing.Point(18, 125);
            this.materialCard3.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard3.Name = "materialCard3";
            this.materialCard3.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard3.Size = new System.Drawing.Size(416, 550);
            this.materialCard3.TabIndex = 6;
            // 
            // AdminToolSave
            // 
            this.AdminToolSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.AdminToolSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdminToolSave.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AdminToolSave.ForeColor = System.Drawing.Color.White;
            this.AdminToolSave.Location = new System.Drawing.Point(332, 8);
            this.AdminToolSave.Name = "AdminToolSave";
            this.AdminToolSave.Size = new System.Drawing.Size(83, 30);
            this.AdminToolSave.TabIndex = 7;
            this.AdminToolSave.Text = "儲存";
            this.AdminToolSave.UseVisualStyleBackColor = false;
            this.AdminToolSave.Click += new System.EventHandler(this.AdminToolSave_Click);
            // 
            // AdminTool
            // 
            this.AdminTool.Controls.Add(this.label1);
            this.AdminTool.Controls.Add(this.AdminToolCB);
            this.AdminTool.Controls.Add(this.AdminToolSave);
            this.AdminTool.Location = new System.Drawing.Point(18, 681);
            this.AdminTool.Name = "AdminTool";
            this.AdminTool.Size = new System.Drawing.Size(415, 41);
            this.AdminTool.TabIndex = 9;
            this.AdminTool.TabStop = false;
            // 
            // AdminToolCB
            // 
            this.AdminToolCB.Font = new System.Drawing.Font("新細明體", 14F);
            this.AdminToolCB.FormattingEnabled = true;
            this.AdminToolCB.Location = new System.Drawing.Point(184, 10);
            this.AdminToolCB.Name = "AdminToolCB";
            this.AdminToolCB.Size = new System.Drawing.Size(142, 27);
            this.AdminToolCB.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "管理者工具";
            // 
            // OrderPanel
            // 
            this.Controls.Add(this.materialCard3);
            this.Controls.Add(this.AdminTool);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.materialCard2);
            this.Name = "OrderPanel";
            this.Size = new System.Drawing.Size(1073, 725);
            this.Load += new System.EventHandler(this.OrderPanel_Load);
            this.materialCard2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onlineOrderingSystemDataSet)).EndInit();
            this.materialCard3.ResumeLayout(false);
            this.AdminTool.ResumeLayout(false);
            this.AdminTool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private OnlineOrderingSystemDataSet onlineOrderingSystemDataSet;
        private OnlineOrderingSystemDataSetTableAdapters.OrdersTableAdapter ordersTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button AdminToolSave;
        private System.Windows.Forms.GroupBox AdminTool;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AdminToolCB;
    }
}
