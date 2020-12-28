
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace SharpDevelopMVC4.Models
{
	[Table("OS_Categories")]
		
	public class Category
	{
		
		public int Id {get; set;}
		
		public string Name { get; set; }
		
		public string Description { get; set; }
		
	}
}
