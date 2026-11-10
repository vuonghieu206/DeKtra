using System.ComponentModel.DataAnnotations;

namespace VuongTrungHieu_241230729.Models;

public class TblAccount
{
    [Key]
    public int Uid { get; set; }
    [StringLength(10)]
    public string? Username { get; set; }
    [StringLength(10)]
    public string? Password { get; set; }
}
