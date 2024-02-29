using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context;

public class AppDbContext : DbContext // Mapeamento do domínio às tabelas do banco de dados, consultas alterações, inclusão, etc
{
    public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options )
    {        
    }

    public DbSet<Categoria>? Categorias { get; set; } // ? para ser opcionial
    public DbSet<Produto>? Produtos { get; set; } // Criar tabelas com base nas entidades tal
}
