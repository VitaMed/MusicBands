using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicBands.Models;
using Microsoft.EntityFrameworkCore;

namespace MusicBands.Data
{
    public class BandsContext : DbContext
    {
        public BandsContext(DbContextOptions<BandsContext> options)
           : base(options)
        {
        }
        public DbSet<ALBUMS> ALBUMS { get; set; }
        public DbSet<Group> GROUPS { get; set; }
        public DbSet<Musician> MUSICIANS { get; set; }
        public DbSet<Musicians_in_groups> MUSICIANS_IN_GROUPS { get; set; }
        public DbSet<Producer> PRODUCERS { get; set; }
        public DbSet<Song> SONGS { get; set; }
        public DbSet<Type_of_instruments> TYPE_OF_INSTRUMENTS { get; set; }
        public DbSet<Instruments> Instruments { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musicians_in_groups>()
        .HasKey(bc => new { bc.GR_ID, bc.MS_ID});
            modelBuilder.Entity<Musicians_in_groups>()
                .HasOne(bc => bc.GROUP)
                .WithMany(b => b.MUSICIANS_IN_GROUPS)
                .HasForeignKey(bc => bc.GR_ID);
            modelBuilder.Entity<Musicians_in_groups>()
                .HasOne(bc => bc.MUSICIAN)
                .WithMany(c => c.MUSICIANS_IN_GROUPS)
                .HasForeignKey(bc => bc.MS_ID);
            modelBuilder.Entity<Group>()
                .HasOne(bc => bc.PRODUCER)
                .WithMany(c => c.GROUPS)
                .HasForeignKey(bc => bc.PR_ID);
          
            modelBuilder.Entity<Song>()
                .HasOne(bc => bc.ALBUM)
                .WithMany(c => c.SONGS)
                .HasForeignKey(bc => bc.AL_ID);

            modelBuilder.Entity<Instruments>()
                .HasKey(bc => new { bc.TYPE_ID, bc.MS_ID });
            modelBuilder.Entity<Instruments>()
                .HasOne(bc => bc.Type_Of_Instruments)
                .WithMany(b => b.Instruments)
                .HasForeignKey(bc => bc.TYPE_ID);
            modelBuilder.Entity<Instruments>()
                .HasOne(bc => bc.MUSICIAN)
                .WithMany(c => c.Instruments)
                .HasForeignKey(bc => bc.MS_ID);
            

            modelBuilder.Entity<Song>()
                .HasOne(bc => bc.GROUP)
                .WithMany(c => c.SONGS)
                .HasForeignKey(bc => bc.GR_ID);
            modelBuilder.Entity<ALBUMS>().ToTable("ALBUM");
            modelBuilder.Entity<Group>().ToTable("GROUP");
            modelBuilder.Entity<Musician>().ToTable("MUSICIAN");
            modelBuilder.Entity<Musicians_in_groups>().ToTable("MUSICIANS_IN_GROUPS");
            modelBuilder.Entity<Producer>().ToTable("PRODUCER");
            modelBuilder.Entity<Song>().ToTable("SONG");
            modelBuilder.Entity<Type_of_instruments>().ToTable("TYPE_OF_INSTRUMENTS");
            modelBuilder.Entity<Instruments>().ToTable("INSTRUMENTS");
        }
        
    }
}
