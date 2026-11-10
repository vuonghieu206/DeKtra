using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VuongTrungHieu_241230729.Data;
using VuongTrungHieu_241230729.Models;

namespace VuongTrungHieu_241230729.Controllers;

public class HangHoaController : Controller
{
    private readonly DatabaseContext _context;
    private readonly IWebHostEnvironment _environment;

    public HangHoaController(DatabaseContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    // Câu 3: mặc định chỉ hiển thị hàng hóa có giá >= 100.
    public async Task<IActionResult> Index(int? maLoai)
    {
        var query = _context.HangHoas
            .AsNoTracking()
            .Include(x => x.LoaiHang)
            .Where(x => x.Gia >= 100);

        if (maLoai.HasValue)
            query = query.Where(x => x.MaLoai == maLoai.Value);

        ViewBag.MaLoai = maLoai;
        ViewBag.TieuDe = "Vương Trung Hiếu";
        var hangHoas = await query.OrderBy(x => x.MaHang).ToListAsync();
        return View(hangHoas);
    }

    // Câu 4: trả về riêng phần danh sách để JavaScript thay bằng AJAX.
    [HttpGet]
    public async Task<IActionResult> LocTheoLoai(int? maLoai)
    {
        var query = _context.HangHoas
            .AsNoTracking()
            .Include(x => x.LoaiHang)
            .Where(x => x.Gia >= 100);

        if (maLoai.HasValue)
            query = query.Where(x => x.MaLoai == maLoai.Value);

        var hangHoas = await query.OrderBy(x => x.MaHang).ToListAsync();
        return PartialView("_DanhSachHangHoa", hangHoas);
    }

    [HttpGet]
    public async Task<IActionResult> TimKiem(string? tuKhoa)
    {
        var query = _context.HangHoas
            .AsNoTracking()
            .Include(x => x.LoaiHang)
            .Where(x => x.Gia >= 100);

        if (!string.IsNullOrWhiteSpace(tuKhoa))
            query = query.Where(x => x.TenHang.Contains(tuKhoa));

        var hangHoas = await query.OrderBy(x => x.MaHang).ToListAsync();
        return PartialView("_DanhSachHangHoa", hangHoas);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await LoadLoaiHang();
        return View(new HangHoaCreateViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(HangHoaCreateViewModel model)
    {
        await LoadLoaiHang();

        if (!ModelState.IsValid)
            return View(model);

        var extensionSafe = Path.GetExtension(model.ImageFile!.FileName).ToLowerInvariant();
        var fileName = $"{Guid.NewGuid():N}{extensionSafe}";
        var uploadFolder = Path.Combine(_environment.WebRootPath, "Content", "images", "uploads");
        Directory.CreateDirectory(uploadFolder);
        var filePath = Path.Combine(uploadFolder, fileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
            await model.ImageFile.CopyToAsync(stream);

        var hangHoa = new HangHoa
        {
            MaLoai = model.MaLoai!.Value,
            TenHang = model.TenHang.Trim(),
            Gia = model.Gia,
            Anh = fileName
        };

        _context.HangHoas.Add(hangHoa);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index), new { maLoai = (int?)null });
    }

    private async Task LoadLoaiHang()
    {
        ViewBag.LoaiHangs = new SelectList(
            await _context.LoaiHangs.AsNoTracking().OrderBy(x => x.TenLoai).ToListAsync(),
            "MaLoai", "TenLoai");
    }
}
