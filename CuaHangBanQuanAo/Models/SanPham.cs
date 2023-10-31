using System;
using System.Collections.Generic;

namespace CuaHangBanQuanAo.Models;

public partial class SanPham
{
    public string MaSp { get; set; } = null!;

    public string? TenSp { get; set; }

    public int? GiaBan { get; set; }

    public string? Mota { get; set; }

    public string? Anh { get; set; }
    public string? Loai { get; set; }

}
