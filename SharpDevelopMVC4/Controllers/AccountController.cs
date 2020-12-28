using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using SharpDevelopMVC4.Models;

namespace SharpDevelopMVC4.Controllers
{
	/// <summary>
	/// Description of AccountController.
	/// </summary>
	public class AccountController : Controller
	{ 
		SdMvc4DbContext _db = new SdMvc4DbContext();
		
		public ActionResult Login()
		{
			return View();
		}
		
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]		
		public ActionResult Login(string username, string password, bool rememberme = false)
		{
			if (UserAccount.Authenticate(username, password)) {
				var user = UserAccount.GetUserByUserName(username);
		        
				var authTicket = new FormsAuthenticationTicket(
	                 1,                             	// version
	                 user.UserName,               	// user name
	                 DateTime.Now,                  	// created
	                 DateTime.Now.AddMinutes(20),   	// expires
	                 rememberme,                    	// persistent?
	                 user.Roles              		// can be used to store roles
	                
                 );
				
				string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
				
				var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
				System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
				
				Session["user"] = user.UserName;
				
				
				
			return RedirectToAction("Index", "Product");
				
		//	return Redirect(FormsAuthentication.GetRedirectUrl(user.UserName, rememberme));
				
			}
			
		    
			// invalid username or password
			ModelState.AddModelError("", "Invalid username or password");
			return View();
			
		}
		
		
		public ActionResult Logoff()
		{
			Session.Clear();
			FormsAuthentication.SignOut();
			return Redirect("login");
		}
		
		public ActionResult Register()
		{
		
			return View();
		}
		
		[HttpPost]
		public ActionResult Register(Customer newUser)
		{
			
		
			if(newUser.Password == newUser.RetypePassword) {
			
				var res = UserAccount.Create(newUser.Username, newUser.Password);
				
				if (res != null) {
				
					var newCust = new Customer();
					
					_db.Customers.Add(newUser);
					_db.SaveChanges();
					
					return RedirectToAction("Login");
					
				}
				ViewBag.message = "Registration Failed";
			}
			
			
			else{
				
			ViewBag.message="Password not matched";
			
			}
			
			return View();
		   
		
		
		}
	}
}