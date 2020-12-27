using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SharpDevelopMVC4.Models
{
	[Table("OS_Products")]
	public class Product
	{
		public int Id {get; set;}
	    public int CategoryID {get; set;}
		public string Name { get; set; }
		public double Price { get; set; }
		public int StockOnHand { get; set; }
		public string Location {get; set;}
		public string Schedule { get; set; }
		public string  Services { get; set; }
		public string ContactInfo { get; set; }
//		 [ScaffoldColumn(false)]
//        public string PictureFilename { get; set; }

		
	}
}
