using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using SharpDevelopMVC4.Models;

using System.IO;

	
	
	
	
	public class ImageController : Controller
	{
		SdMvc4DbContext _db = new SdMvc4DbContext();
		public ActionResult Index()
		{
			var image = _db.UploadImages.ToList();
			
			return View();
			
		}
		
		[HttpGet]
		public ActionResult Create()
		{
		
			return View();
		
		}
		
		
		[HttpPost]
		public ActionResult Create(HttpPostedFileBase img , UploadImage imgs)
		{
//		    checke if naay sulod ang img
			
			if(img != null){
			
			string filename = Path.GetFileName(img.FileName);
			string _filename = DateTime.Now.ToString("yymmssfff") + filename;
			string extension = Path.GetExtension(img.FileName);
			string path = Path.Combine(Server.MapPath("~/images/"));
			imgs.img = "~/images/" + _filename;
			
			
			
			if(extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
			{
			
				if(img.ContentLength<=1000000)
				{
					_db.UploadImages.Add(imgs);
					if(_db.SaveChanges()>0)
					{
					
						img.SaveAs(path);
						ViewBag.message=" Record Added";
						ModelState.Clear();
					
					}
				  
				}
			}
			  
				else{
				
				    ViewBag.message ="empty";
					ViewBag.msg ="Size not valid";
				}
			
			
			}
			ViewBag.message ="empty";
			return View();
		
		}
	
	
	
}