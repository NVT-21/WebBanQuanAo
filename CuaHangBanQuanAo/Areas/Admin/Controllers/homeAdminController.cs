using Azure;
using CuaHangBanQuanAo.Models;
using CuaHangBanQuanAo.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using X.PagedList;

namespace CuaHangBanQuanAo.Areas.Admin.Controllers
{
	[Area("admin")]
	[Route("/admin")]
	[Route("/admin/homeadmin")]

	public class homeAdminController : Controller
	{
		WebBanQuanAoContext db = new WebBanQuanAoContext();
		[Route("")]
		[Route("index")]
        [Authentication]
        public IActionResult Index()
		{
			return View();
		}
		[Route("TatCaSanPham")]
        [Authentication]
        public IActionResult TatCaSanPham(int? page)
		{
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"]; 
            }

            int pageSize = 6;

			int pageNumber = page == null || page < 0 ? 1 : page.Value;
			var sanPham = db.SanPhams.AsNoTracking().OrderBy(x => x.TenSp);

			PagedList<SanPham> lst = new PagedList<SanPham>(sanPham, pageNumber, pageSize);
			return View(lst);
		}
        [Route("ThemSanPhamMoi")]
        [Authentication]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
        
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public IActionResult ThemSanPhamMoi(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("TatCaSanPham");
            }
            return View(sanPham);
        }

        [Route("SuaSanPham")]
        [HttpGet]
        [Authentication]
        public IActionResult SuaSanPham(string maSanPham)
        {
           
            var sanPham = db.SanPhams.Find(maSanPham);
            return View(sanPham);
           
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public IActionResult SuaSanPham(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TatCaSanPham");
            }
            return View(sanPham);
        }
        [Route("XoaSanPham")]
        [HttpGet]
        [Authentication]
        public ActionResult XoaSanPham(string maSanPham)
        {
            TempData["Message"] = "";
          
            db.Remove(db.SanPhams.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm này đã được xoá";
            return RedirectToAction("TatCaSanPham");
        }


    }



}

