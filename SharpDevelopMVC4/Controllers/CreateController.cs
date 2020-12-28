using System;
using System.Web;
using System.Web.Mvc;
using ImageUploadApp.Models;
using SharpDevelopMVC4.Models;

namespace SharpDevelopMVC4.Controllers
{
	/// <summary>
	/// Description of CreateController.
	/// </summary>
	public class CreateController : Controller
	{
		SdMvc4DbContext _db = new SdMvc4DbContext();
		
		public ActionResult Index()
		{
			return View();
		}
		
		
		
//		public ActionResult Create(Image img, HttpPostedFileBase file)
//{
//    if (ModelState.IsValid)
//    {
//        if (file != null)
//        {
//            file.SaveAs(HttpContext.Server.MapPath("~/Images/") 
//                                                  + file.FileName);
//            img.ImagePath = file.FileName;
//        }  
//        
//        _db.images.Add(img);
//        _db.SaveChanges();
//        return RedirectToAction("Index");
//    }
//    return View(img);
//}
		
		
	}
}