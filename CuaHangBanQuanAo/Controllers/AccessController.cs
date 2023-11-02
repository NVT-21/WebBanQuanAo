using CuaHangBanQuanAo.Models;
using CuaHangBanQuanAo.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangBanQuanAo.Controllers
{

    public class AccessController : Controller
    {
        WebBanQuanAoContext db = new WebBanQuanAoContext();
        [HttpGet]
        
        public ActionResult Login()
        {

            if (HttpContext.Session.GetString("Username") == null)
            {
                return View();

            }
            else if (HttpContext.Session.GetString("Role").Equals( "admin"))
            {
                return RedirectToAction("admin");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }




        }
        [HttpPost]
        public ActionResult Login(TaiKhoan user)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                var u = db.TaiKhoans.Where(x => x.Tk.Equals(user.Tk) && x.MatKhau.Equals(user.MatKhau)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("UserName", u.Tk.ToString());
                    HttpContext.Session.SetString("Role", u.VaiTro);

                    if (u.VaiTro == "admin")
                    {
                        if (u.VaiTro == "admin")
                        {
                            return RedirectToAction("HomeAdmin", "Admin"); 
                        }

                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View();


        }
      
    }
}
