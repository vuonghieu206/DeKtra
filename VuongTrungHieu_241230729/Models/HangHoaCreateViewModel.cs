using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace VuongTrungHieu_241230729.Models;

public class HangHoaCreateViewModel
{
    [Required(ErrorMessage = "Vui lòng chọn loại hàng.")]
    [Display(Name = "Loại hàng")]
    public int? MaLoai { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên hàng.")]
    [StringLength(50, ErrorMessage = "Tên hàng tối đa 50 ký tự.")]
    [Display(Name = "Tên hàng")]
    public string TenHang { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập giá.")]
    [Range(typeof(decimal), "100", "5000", ErrorMessage = "Giá phải là số trong khoảng 100 đến 5000.")]
    [Display(Name = "Giá")]
    public decimal? Gia { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn ảnh.")]
    [AllowedImageExtensions(".jpg", ".png", ".gif", ".tiff", ErrorMessage = "Ảnh phải có đuôi .jpg, .png, .gif hoặc .tiff.")]
    [Display(Name = "Ảnh (.jpg, .png, .gif, .tiff)")]
    public IFormFile? ImageFile { get; set; }
}
