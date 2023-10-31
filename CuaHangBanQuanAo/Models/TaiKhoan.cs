using System;
using System.Collections.Generic;

namespace CuaHangBanQuanAo.Models;

public partial class TaiKhoan
{
    public string MaTk { get; set; } = null!;

    public string? Tk { get; set; }

    public string? MatKhau { get; set; }
    public string? VaiTro { get; set; }

    public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();
}
