
using CuaHangBanQuanAo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangBanQuanAo.ViewComponents
{   
    public class ManViewComponent:ViewComponent
    {
        readonly WebBanQuanAoContext db = new WebBanQuanAoContext();
        public IViewComponentResult Invoke()
        {
            var listSanPham = db.SanPhams
             .Where(sp => sp.Loai == "men") // Lọc sản phẩm theo tên loại
              .ToList();

            return View("RenderMan",listSanPham);
            
        }
    }
}
