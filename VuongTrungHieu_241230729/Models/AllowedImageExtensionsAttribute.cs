using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace VuongTrungHieu_241230729.Models;

[AttributeUsage(AttributeTargets.Property)]
public sealed class AllowedImageExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _extensions;

    public AllowedImageExtensionsAttribute(params string[] extensions)
    {
        _extensions = extensions.Select(x => x.ToLowerInvariant()).ToArray();
    }

    public override bool IsValid(object? value)
    {
        if (value is null) return true; // [Required] kiểm tra trường hợp chưa chọn file.
        if (value is not IFormFile file) return false;
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        return _extensions.Contains(extension);
    }
}
