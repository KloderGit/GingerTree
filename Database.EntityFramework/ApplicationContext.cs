using Database.Domain;
using Microsoft.EntityFrameworkCore;

namespace Database.EntityFramework
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Map> Structure { get; set; }
        public DbSet<Node> Items { get; set; }

        public ApplicationContext()
        {
            
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=7100;Database=GingerTree;Username=postgres;Password=postgres;SslMode=Disable");
            }
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>(entity =>
            {
                entity.ToTable("Nodes", "Domain");
                entity.Property(e => e.Created).HasColumnType("timestamp with time zone");
                entity.Property(e => e.Modified).HasColumnType("timestamp with time zone");
            });


            modelBuilder.Entity<Map>(entity =>
            {
                entity.ToTable("Maps", "Domain");
                entity.Property(e => e.Created).HasColumnType("timestamp with time zone");
                entity.Property(e => e.Modified).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Children)
                    .HasForeignKey(d => d.ParentId);
                entity.HasIndex(e => e.ParentId);

                entity.HasOne(d => d.Node)
                    .WithMany(p => p.Maps)
                    .HasForeignKey(d => d.NodeId);
                entity.HasIndex(e => e.NodeId);
            });

            modelBuilder.Entity<Payload>(entity =>
            {
                entity.ToTable("Payloads", "Domain");
                entity.Property(e => e.Created).HasColumnType("timestamp with time zone");
                entity.Property(e => e.Modified).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.Node)
                    .WithMany(p => p.Payloads)
                    .HasForeignKey(d => d.NodeId);
                entity.HasIndex(e => e.NodeId);

                entity.HasOne(d => d.Map)
                    .WithMany(p => p.Payloads)
                    .HasForeignKey(d => d.MapId);
                entity.HasIndex(e => e.MapId);
            });
        }
    }
}
