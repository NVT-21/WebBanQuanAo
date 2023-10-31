using System;
using System.Collections.Generic;

namespace CuaHangBanQuanAo.Models;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    public string? TenKh { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? Sdt { get; set; }

    public string? Anh { get; set; }

    public string? MaTk { get; set; }

    public virtual TaiKhoan? MaTkNavigation { get; set; }
}
