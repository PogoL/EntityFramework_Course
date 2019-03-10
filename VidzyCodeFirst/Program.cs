using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyCodeFirst
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public Classification Classification { get; set; }
        public List<Tag> Tags { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Video> Videos { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Video> Videos { get; set; }
    }

    public enum Classification : byte
    {
        Silver = 1,
        Gold,
        Platinum
    }

    public class VidzyContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>()
                        .Property(v => v.Name)
                        .HasMaxLength(255)
                        .IsRequired();

            modelBuilder.Entity<Video>()
                        .HasRequired(v => v.Genre)
                        .WithMany(g => g.Videos)
                        .HasForeignKey(v => v.GenreId);

            modelBuilder.Entity<Genre>()
                        .Property(g => g.Name)
                        .HasMaxLength(255)
                        .IsRequired();

            modelBuilder.Entity<Video>()
                        .HasMany(v => v.Tags)
                        .WithMany(t => t.Videos)
                        .Map(m =>
                        {
                            m.MapLeftKey("VideoId");
                            m.MapRightKey("TagId");
                            m.ToTable("VideoTags");
                        });
                        

            base.OnModelCreating(modelBuilder);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
