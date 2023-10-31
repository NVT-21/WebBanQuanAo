using CuaHangBanQuanAo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangBanQuanAo.ViewComponents
{
    public class WomenViewComponent: ViewComponent
    {
        readonly WebBanQuanAoContext db = new WebBanQuanAoContext();
        public IViewComponentResult Invoke()
        {
            var listSanPham = db.SanPhams
             .Where(sp => sp.Loai == "women") // Lọc sản phẩm theo tên loại
              .ToList();

            return View("RenderWomen", listSanPham);

        }
    }
}
