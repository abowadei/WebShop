using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
   
            public class PitShopContext : System.Data.Entity.DbContext
            {
                public PitShopContext(): base("WebShopContext")
                {

                }
                public DbSet<User> Users { get; set; }
                public DbSet<Order> Orders { get; set; }
                public DbSet<Product> Products { get; set; }
                public DbSet<OrderRow> OrderRows { get; set; }
            }

            public class User
            {
                [Key]
                public int ID { get; set; }
                [Required]
                public string Name { get; set; }
        public string PassWord { get; set; }
        public string Adress { get; set; }
                public int PhonNumber { get; set; }
                public string EmailAdress { get; set; }
                public virtual List<Order> Orderlist { get; set; }
            }

            public class Product
            {
                [Key]
                public int Id { get; set; }
                public string BrandName { get; set; }
                public string Type { get; set; }
                public string Model { get; set; }
                public int price { get; set; }
                public virtual List<OrderRow> orderrowlist1 { get; set; }
            }


            public class Order
            {
                [Key]
                public int Id { get; set; }
                public DateTime DateOfOrder { get; set; }
                public virtual User user { get; set; }
                public virtual List<OrderRow> orderrowlist { get; set; }

            }

            public class OrderRow
            {
                [Key]
                public int Id { get; set; }
                public virtual Product product { get; set; }
                public virtual Order order { get; set; }



            }


       
}