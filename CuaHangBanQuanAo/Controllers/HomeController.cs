using CuaHangBanQuanAo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;


using System.Diagnostics;
using CuaHangBanQuanAo.Models.Authentication;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Drawing.Printing;

namespace CuaHangBanQuanAo.Controllers
{
	
	public class HomeController : Controller
	{
		WebBanQuanAoContext db=new WebBanQuanAoContext();
        private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
		[Authentication]
		public IActionResult Index()
		{
			 var listSanPham=db.SanPhams.ToList();

			return View(listSanPham);
		}

		public IActionResult Privacy()
		{
			return View();
		}
        [Authentication]
        public IActionResult ChiTietSanPham(string Masp)
		{
			var sanPham = db.SanPhams.SingleOrDefault(sp => sp.MaSp == Masp);
            return View(sanPham);
		}
        [Authentication]
        public IActionResult HienThiSanPham(int?page)
		{
	
			
			int	pageSize = 6;
			int pageNumber=page==null||page<0?1:page.Value;
			var sanPham = db.SanPhams.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<SanPham> lst = new PagedList<SanPham>(sanPham, pageNumber, pageSize);
			return View(lst);
		}
        [Authentication]
        public IActionResult SanPhamTheoLoai(int?page,string loai)
		{
            int pageSize = 6;
            int pageNumber = page ?? 1; // Sử dụng toán tử null coalescing để xác định trang mặc định (nếu page là null).

            // Lọc sản phẩm theo loại (nếu được chỉ định).
            IQueryable<SanPham> sanPhamQuery = db.SanPhams.AsNoTracking();

            if (!string.IsNullOrEmpty(loai))
            {
                sanPhamQuery = sanPhamQuery.Where(sp => sp.Loai == loai);
                ViewBag.Loai = loai;
            }
            
            // Sắp xếp và tạo danh sách phân trang.
            PagedList<SanPham> lst = new PagedList<SanPham>(sanPhamQuery.OrderBy(x => x.TenSp), pageNumber, pageSize);
            return View(lst);
        }
        public IActionResult TimKiem(string tensp, int page = 1, int pageSize = 5)
		{
            var listProduct = db.SanPhams.Where(p => p.TenSp.StartsWith(tensp)).ToList();
            int totalItems = listProduct.Count();
			var products = listProduct.Skip((page - 1) * pageSize).Take(pageSize).ToList();
			ViewBag.TotalItems = totalItems;
			ViewBag.PageSize = pageSize;
			ViewBag.CurrentPage = page;
			ViewBag.tensp=tensp;

			return View(products);
          
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}