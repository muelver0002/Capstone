using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SharpDevelopMVC4.Models
{
	[Table("OS_Customer")]
	public class Customer
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string Lastname { get; set; }
		public string Address { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string RetypePassword { get; set; }
		
	}
}
