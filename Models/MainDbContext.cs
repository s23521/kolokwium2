using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {

        }

        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Musician_Track> MusicianTracks { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Musiclabel> Musiclabels { get; set; }

        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musician>(m =>
            {
                m.HasKey(m => m.IdMusician);
                m.Property(m => m.Firstname).IsRequired().HasMaxLength(30);
                m.Property(m => m.LastName).IsRequired().HasMaxLength(50);
                m.Property(m => m.Nickname).IsRequired().HasMaxLength(20);

                m.HasData(
                    new Musician { IdMusician = 1, Firstname = "Domino", LastName = "Jachaś", Nickname = "nickanme"},
                    new Musician { IdMusician = 1, Firstname = "fbdsfgd", LastName = "asdsadasd", Nickname = "nfaadsa"}
                );
            });

            modelBuilder.Entity<Musician_Track>(m =>
            {
                m.HasOne(m => m.Musician).WithMany(m => m.MusicianTracks).HasForeignKey(e => e.IdMusician);
                m.HasOne(m => m.Track).WithMany(m => m.MusicianTracks).HasForeignKey(e => e.Idtrack);
            
                m.HasData(
                    new Musician_Track { Idtrack = 1, IdMusician = 1},
                    new Musician_Track { Idtrack = 2, IdMusician = 2}
                );
            });

            modelBuilder.Entity<Track> (t => 
            {
                t.HasKey(t => t.IdTrack);
                t.Property(t => t.TrackName).IsRequired().HasMaxLength(20);
                t.Property(t => t.Duration).IsRequired();
                t.HasOne(t => t.Album).WithMany(t => t.Tracks).HasForeignKey(e => e.IdMusicAlbum);
           
                t.HasData(
                    new Track { IdTrack = 1, TrackName = "track1", Duration = 3.5, IdMusicAlbum = 1},
                    new Track { IdTrack = 2, TrackName = "track2", Duration = 4.5, IdMusicAlbum = 2}
                );
            });

            modelBuilder.Entity<Album>(a => 
            {
                a.HasKey(a => a.IdAlbum);
                a.Property(a => a.AlbumName).IsRequired().HasMaxLength(30);
                a.Property(a => a.PublishDate).IsRequired();
                a.HasOne(a => a.Musiclabel).WithMany(a => a.Albums).HasForeignKey(e => e.IdMusicLabel);
            
                a.HasData(
                    new Album { IdAlbum = 1, AlbumName = "name1", PublishDate = DateTime.Parse("2022-06-07"), IdMusicLabel = 1}
                );
            });

            modelBuilder.Entity<Musiclabel>(m => 
            {
                m.HasKey(m => m.IdMusicLabel);
                m.Property(m => m.Name).IsRequired().HasMaxLength(50);
            
                m.HasData(
                    new Musiclabel { IdMusicLabel = 1, Name = "name1"},
                    new Musiclabel { IdMusicLabel = 2, Name = "name2"}
                );
            });
        }
    }
}