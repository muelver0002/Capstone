using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SharpDevelopMVC4.Models;
using System.Linq;

namespace SharpDevelopMVC4.Controllers
{
	
	public class CustomerController : Controller
	{
		SdMvc4DbContext _db = new SdMvc4DbContext();
		
		public ActionResult Index()
		{
			return View();
		}
		
		[HttpGet]
		public ActionResult Register()
		{
			
			
			return View();
		}
		
		
		[HttpPost]
		public ActionResult Register(Customer C ,string Username)
		{
			
			var user = _db.Customers.Where(x => x.Username == Username).FirstOrDefault();
			
			if (user != null) {
			   
				ViewBag.message = "Account already Exist";
				return View();
			   
			}
		//	C.Date = DateTime.Now;
			_db.Customers.Add(C);
			_db.SaveChanges();
			return RedirectToAction("Login");
			
		}
		
		
		[HttpGet]
		public ActionResult Login()
		{
			return View();
		}
		
	
		[HttpPost]
		public ActionResult Login(Customer cust, string Username, string Password)
		{
			List<Customer> customers = _db.Customers.ToList();
			   
			if (customers.Any(x => x.Username == Username && x.Password == Password)) {
				
			    	
					 
				
				Session["Uname"] = Username;
				return RedirectToAction("Index", "Product");
			
			}
			ViewBag.message = "Invalid Username or Password";
			return View();
			
		
			
		}
		
		
	   
		
	}
}