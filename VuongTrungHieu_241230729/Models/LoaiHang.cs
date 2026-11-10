using System.ComponentModel.DataAnnotations;

namespace VuongTrungHieu_241230729.Models;

public class LoaiHang
{
    [Key]
    public int MaLoai { get; set; }

    [Required, StringLength(50)]
    public string TenLoai { get; set; } = string.Empty;

    public ICollection<HangHoa> HangHoas { get; set; } = new List<HangHoa>();
}
