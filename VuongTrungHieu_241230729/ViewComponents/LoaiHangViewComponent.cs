using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VuongTrungHieu_241230729.Data;

namespace VuongTrungHieu_241230729.ViewComponents;

public class LoaiHangViewComponent : ViewComponent
{
    private readonly DatabaseContext _context;

    public LoaiHangViewComponent(DatabaseContext context) => _context = context;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var loaiHangs = await _context.LoaiHangs
            .AsNoTracking()
            .OrderBy(x => x.MaLoai)
            .ToListAsync();

        return View(loaiHangs);
    }
}
