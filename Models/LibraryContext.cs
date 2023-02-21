using Microsoft.EntityFrameworkCore;

namespace SahafWebAPI.Models
{
    public class LibraryContext : DbContext
    {
 public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
        {

        }
        public DbSet<Kitap> Kitap { get; set; } = null!;
        public DbSet<Kitapci> Kitapci { get; set; } = null!;
        public DbSet<Kullanici> Kullanici { get; set;} = null!;
        public DbSet<Gunluk_Rapor> Gunluk_Rapor { get; set; } = null!;
    }
   
}
