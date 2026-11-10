using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VuongTrungHieu_241230729.Models;

public class HangHoa
{
    [Key]
    public int MaHang { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn loại hàng.")]
    [Display(Name = "Loại hàng")]
    public int MaLoai { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên hàng.")]
    [StringLength(50, ErrorMessage = "Tên hàng tối đa 50 ký tự.")]
    [Display(Name = "Tên hàng")]
    public string TenHang { get; set; } = string.Empty;

    [Range(typeof(decimal), "100", "5000",
        ErrorMessage = "Giá phải nằm trong khoảng từ 100 đến 5000.")]
    [Column(TypeName = "numeric(18,0)")]
    [Display(Name = "Giá")]
    public decimal? Gia { get; set; }

    [StringLength(100)]
    [Display(Name = "Tên file ảnh")]
    public string? Anh { get; set; }

    [ForeignKey(nameof(MaLoai))]
    public LoaiHang? LoaiHang { get; set; }
}
