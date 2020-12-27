using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ImageUploadApp.Models;

namespace SharpDevelopMVC4.Models
{
    public class SdMvc4DbContext : DbContext
    {
        public SdMvc4DbContext() : base("SdMvcDb") // name_of_dbconnection_string
        {
        	
        }

        // Map model classes to database tables
         public DbSet<UserAccount> Users { get; set; }
         public DbSet<Product> Products {get; set; }
         public DbSet<Category> Categories {get; set; }
         public DbSet<Image> images {get; set; }
         public DbSet<Customer> Customers {get; set;}
         public DbSet<UploadImage> UploadImages {get; set;}
    }


}

