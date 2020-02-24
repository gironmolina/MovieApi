using Microsoft.EntityFrameworkCore;
using MovieApi.CrossCutting.Interfaces;
using MovieApi.Entities;

namespace MovieApi.Infrastructure.DbContext
{
	public class BeezyCinemaContext : Microsoft.EntityFrameworkCore.DbContext
	{
		private readonly IAppConfigSettings _appConfigSettings;

		public BeezyCinemaContext(IAppConfigSettings appConfigSettings)
		{
			_appConfigSettings = appConfigSettings;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_appConfigSettings.BeezyCinemaDb);
		}

		public DbSet<CinemaEntity> Cinema { get; set; }
		public DbSet<CityEntity> City { get; set; }
		public DbSet<GenreEntity> Genre { get; set; }
		public DbSet<MovieEntity> Movie { get; set; }
		public DbSet<MovieGenreEntity> MovieGenre { get; set; }
		public DbSet<RoomEntity> Room { get; set; }
		public DbSet<SessionEntity> Session { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CinemaEntity>(entity =>
			{
				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(255);

				entity.Property(e => e.OpenSince).HasColumnType("datetime");

				entity.HasOne(d => d.City)
					.WithMany(p => p.Cinema)
					.HasForeignKey(d => d.CityId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Cinema_City");
			});

			modelBuilder.Entity<CityEntity>(entity =>
			{
				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(255);
			});

			modelBuilder.Entity<GenreEntity>(entity =>
			{
				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(255);
			});

			modelBuilder.Entity<MovieEntity>(entity =>
			{
				entity.Property(e => e.OriginalLanguage).HasMaxLength(255);

				entity.Property(e => e.OriginalTitle)
					.IsRequired()
					.HasMaxLength(512);

				entity.Property(e => e.ReleaseDate).HasColumnType("datetime");
			});

			modelBuilder.Entity<MovieGenreEntity>(entity => { entity.HasKey(e => new {e.MovieId, e.GenreId}); });

			modelBuilder.Entity<RoomEntity>(entity =>
			{
				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(255);

				entity.Property(e => e.Size)
					.IsRequired()
					.HasMaxLength(255);

				entity.HasOne(d => d.Cinema)
					.WithMany(p => p.Room)
					.HasForeignKey(d => d.CinemaId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Room_Cinema");
			});

			modelBuilder.Entity<SessionEntity>(entity =>
			{
				entity.Property(e => e.EndTime).HasColumnType("datetime");

				entity.Property(e => e.StartTime).HasColumnType("datetime");

				entity.HasOne(d => d.Movie)
					.WithMany(p => p.Session)
					.HasForeignKey(d => d.MovieId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Session_Movie");

				entity.HasOne(d => d.Room)
					.WithMany(p => p.Session)
					.HasForeignKey(d => d.RoomId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_Session_Room");
			});
		}
	}
}