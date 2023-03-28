using Microsoft.EntityFrameworkCore;
using WebApplicationForTestReactApi.Model;

namespace WebApplicationForTestReactApi.DbContext;

public partial class CharpbankclientdbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public CharpbankclientdbContext()
    {
    }

    public CharpbankclientdbContext(DbContextOptions<CharpbankclientdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=194.67.105.79:5432;Database=charpbankclientdb;Username=charpbankclientuser;Password=qwerty");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clients_pk");

            entity.ToTable("clients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CardNumber)
                .IsRequired()
                .HasMaxLength(16)
                .HasColumnName("card_number");
            entity.Property(e => e.Fio)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnName("fio");
            entity.Property(e => e.Money).HasColumnName("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
