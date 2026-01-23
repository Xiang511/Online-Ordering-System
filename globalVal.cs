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
        public static List<int> productID = new List<int>();
        public static List<string> productName = new List<string>();
        public static List<decimal> productPrice = new List<decimal>();
        public static List<int> productQuantity = new List<int>();
        public static List<string> productImage = new List<string>();
    }
}
