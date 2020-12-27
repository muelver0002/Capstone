using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharpDevelopMVC4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
      

        public ActionResult Register()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Calcu(string amount,string country,string country1){      
        	string[] Currencies = {
        		"Php","Usd","Myr"
        	};
        	ViewBag.Currencies = Currencies;
        	
        		int a = Convert.ToInt32(amount);
        	    double b=0.00d;
        	
           
        	if(country=="Php"){
        		if(country1=="Usd"){
        		b= a*0.020;
        		}
        	}
        	
        	if(country=="Usd"){
        		if(country1=="Php"){
        		b = a*50;
        		}
        	}
        	
          	ViewBag.Amount=b;
        	return View();
        
        }
        
         
    }
}