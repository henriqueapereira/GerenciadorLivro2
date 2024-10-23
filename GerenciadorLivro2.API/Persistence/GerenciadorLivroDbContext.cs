using GerenciadorLivro2.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivro2.API.Persistence;

public class GerenciadorLivroDbContext : DbContext
{
    public GerenciadorLivroDbContext(DbContextOptions<GerenciadorLivroDbContext> options) : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>(e =>
        {
            e.HasKey(u => u.Id);

            e.HasMany(u => u.Loans) // 1 usuario tem muitos empréstimos
                .WithOne(us => us.Usuario)// 1 empréstimo tem 1 unico usuario
                .HasForeignKey(us => us.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Loan>(e =>
        {
            e.HasKey(l => l.Id);

            e.HasOne(l => l.Usuario)
                .WithMany(e => e.Loans)
                .HasForeignKey(l => l.IdUsuario);

            e.HasOne(l => l.Livro)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.IdLivro);


        });

        builder.Entity<Book>(e =>
        {
            e.HasKey(b => b.Id);

            e.HasMany(b => b.Loans)//1 livro tem 1 empréstimo
                .WithOne(l => l.Livro)
                .HasForeignKey(b => b.IdLivro)
                .OnDelete(DeleteBehavior.Restrict);
        });


        base.OnModelCreating(builder);
    }


}
