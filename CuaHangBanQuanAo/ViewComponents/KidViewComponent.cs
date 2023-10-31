using CuaHangBanQuanAo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangBanQuanAo.ViewComponents
{
    public class KidViewComponent:ViewComponent
    {
        readonly WebBanQuanAoContext db = new WebBanQuanAoContext();
        public IViewComponentResult Invoke()
        {
            var listSanPham = db.SanPhams
               .Where(sp => sp.Loai == "Kid") // Lọc sản phẩm theo tên loại
                .ToList();

            return View("RenderKid", listSanPham);

        }
    }
}
