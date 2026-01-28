using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Ordering_System
{
    public class globalVal
    {
        public static bool islogin = false;

        public static int bannerIndex = 0;

        public static string strImageDir = @"../../Image";

        public static int LoadId = 0 ;

        public static int currentid = 0;
    }
    public class UserProfile
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string Email { get; set; }

        public static string Password { get; set; }
        public static string Phone { get; set; }
        public static string Photo { get; set; }

        public static int Role { get; set; }

        public static DateTime CreatedDate { get; set; }
    }

    public class ProductInfo
    {        
        public int productID { get; set; }
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public int productQuantity { get; set; }
        public string productImage { get; set; }

        public string productDescription { get; set; }
        public string productStatus { get; set; }

        public int productCategotyid { get; set; }

        public String productISBN { get; set; }

        public String productPublisher { get; set; }
    }

    public class ProductList
    {
        public static List<ProductInfo> InfoList = new List<ProductInfo>();
    }

    public class CartInfo
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public int productQuantity { get; set; }
        public string productImage { get; set; }
        public int orderQuantity { get; set; }
    }

    public class CartList
    {
        public static List<CartInfo> InfoList = new List<CartInfo>();
    }

    public class OrderInfo
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public int productQuantity { get; set; }
        public string productImage { get; set; }
        public int orderQuantity { get; set; }
    }

    public class OrderList
    {
        public static List<OrderInfo> InfoList = new List<OrderInfo>();
    }
}
