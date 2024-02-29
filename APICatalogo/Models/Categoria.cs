using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;
// Classes anemicas
[Table("Categorias")]
public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>(); // Inicializando um coleção de produtos
    }
    [Key]
    public int CategoriaId { get; set; } // Ou apena Id, o entity framework core entende como chave primária
    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }
    [Required]
    [StringLength(300)]
    public string ImagemUrl { get; set; } = string.Empty;
    public ICollection<Produto>? Produtos { get; set; }
}
