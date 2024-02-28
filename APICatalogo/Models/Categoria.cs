namespace APICatalogo.Models;
// Classes anemicas
public class Categoria
{
    public int CategoriaId { get; set; } // Ou Id, o entity framework core entende como chave primária
    public string? Nome { get; set; }
    public string ImagemUrl { get; set; } = string.Empty;
}
