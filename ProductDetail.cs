using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Ordering_System
{
    public partial class ProductDetail : Form
    {
        public ProductDetail()
        {
            InitializeComponent();
        }

        private void ProductDetail_Load(object sender, EventArgs e)
        {   
            if(globalVal.LoadId > 0)
            {
                ProductList.InfoList.Clear();
                try
                {

                    SqlConnection conn = DatabaseHelper.GetConnection();
                    conn.Open();
                    string query =  "SELECT * FROM Product WHERE productid = @productid";
                    
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@productid", globalVal.LoadId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductInfo info = new ProductInfo();

                        info.productID = ((int)reader["productid"]);
                        info.productName = ((string)reader["productname"]);
                        info.productPrice = ((decimal)reader["price"]);
                        info.productQuantity = ((int)reader["stock"]);
                        info.productImage = ((string)reader["image"]);
                        info.productDescription = ((string)reader["description"]);
                        info.productStatus = ((string)reader["status"]);
                        info.productCategotyid = ((int)reader["categoryid"]);
                        info.productISBN = ((string)reader["ISBN"]);
                        info.productPublisher = ((string)reader["publisher"]);
                        ProductList.InfoList.Add(info);

                        string imageName = (string)reader["image"];
                        string ImageDir = globalVal.strImageDir + @"/" + imageName;
                        FileStream fs = File.OpenRead(ImageDir);
                        Image ProductImg = Image.FromStream(fs);
                        imageList1.Images.Add(ProductImg);
                        fs.Close();
                    }
                    reader.Close();
                    conn.Close();

                    imageList1.ImageSize = new Size(190, 246);

                    LblBookName.Text = ProductList.InfoList[0].productName;
                    LblCategory.Text = ProductList.InfoList[0].productCategotyid.ToString();
                    LblPrice.Text = ProductList.InfoList[0].productPrice.ToString("C");
                    LblStock.Text = ProductList.InfoList[0].productQuantity.ToString();
                    LblISBN.Text = ProductList.InfoList[0].productISBN;
                    LblPublisher.Text = ProductList.InfoList[0].productPublisher;
                    txtdescription.Text = ProductList.InfoList[0].productDescription;
                    pictureBox1.Image = imageList1.Images[0];

                    //foreach (ProductInfo item in ProductList.InfoList)
                    //{
                    //    Console.WriteLine($"{item.productID}, {item.productName},{item.productPrice}\n");
                    //}

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading products: " + ex.Message);

                }
            }
            
        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {   //初始化讓滑鼠游標固定在數字後面
            numericUpDown1.Select(numericUpDown1.Text.Length, 0);
        }
    }
}
