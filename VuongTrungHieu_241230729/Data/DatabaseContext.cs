using Microsoft.EntityFrameworkCore;
using VuongTrungHieu_241230729.Models;

namespace VuongTrungHieu_241230729.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<HangHoa> HangHoas => Set<HangHoa>();
    public DbSet<LoaiHang> LoaiHangs => Set<LoaiHang>();
    public DbSet<TblAccount> TblAccounts => Set<TblAccount>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<HangHoa>(entity =>
        {
            entity.ToTable("HangHoa");
            entity.HasKey(x => x.MaHang);
            entity.Property(x => x.TenHang).HasMaxLength(50).IsRequired();
            entity.Property(x => x.Gia).HasColumnType("numeric(18,0)");
            entity.Property(x => x.Anh).HasMaxLength(100);
            entity.HasOne(x => x.LoaiHang)
                .WithMany(x => x.HangHoas)
                .HasForeignKey(x => x.MaLoai);
        });

        modelBuilder.Entity<LoaiHang>(entity =>
        {
            entity.ToTable("LoaiHang");
            entity.HasKey(x => x.MaLoai);
            entity.Property(x => x.TenLoai).HasMaxLength(50).IsRequired();
        });

        modelBuilder.Entity<TblAccount>(entity =>
        {
            entity.ToTable("tblAccount");
            entity.HasKey(x => x.Uid);
            entity.Property(x => x.Username).HasMaxLength(10).IsFixedLength();
            entity.Property(x => x.Password).HasMaxLength(10).IsFixedLength();
        });
    }
}
