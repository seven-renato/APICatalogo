using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers;
[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    { // Usando IEnumerable não precisa ter toda a coleção na memória
      // Adiar a execução, ou seja atua por demanda
      // Interface somente leitura
        var produtos = _context.Produtos.ToList();
        if (produtos is null )
        {
            return NotFound("Produtos não encontrados...");
        }

        return produtos;
    }

    [HttpGet("{id:int}", Name="ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
        Produto produto = _context.Produtos.FirstOrDefault(x => x.Id == id);
        if (produto == null)
        {
            return NotFound("Produto não encontrado...");
        }
        return produto;
    }

    [HttpPost]
    public ActionResult Post(Produto produto)
    {
        if (produto is null)
            return BadRequest();

        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return new CreatedAtRouteResult("ObterProduto",
            new { id = produto.Id }, produto);
        /* 
            {
              "produtoId": 1,
              "nome": "string",
              "descricao": "string",
              "preco": 10,
              "imagemUrl": "string",
              "estoque": 10,
              "dataCadastro": "2024-02-29T20:49:50.985Z",
              "categoriaId": 1
            }
        */
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Produto produto)
    {
        if (id != produto.Id)
        {
            return BadRequest();
        }

        _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified; // O Orm vai saber que essa entidade deve ser mnntida no banco porém com valores alterados
        _context.SaveChanges();

        return Ok(produto);

        /* 
         {
          "Id": 4,
          "Nome": "Teste alterado",
          "Descricao": "Teste alterado",
          "Preco": 99,
          "ImagemUrl": "testealterado.jpg",
          "Estoque": 88,
          "DataCadastro": "2024-03-03T17:13:43.518Z",
          "CategoriaId": 1
        }         
         */
    }


    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
        //var produto = _context.Produtos.Find(id); -> Achar o produto primeiro na memória, mas precisar se a chave primária na tabela

        if (produto is null)
        {
            return NotFound("Produto não localizado");
        }

        _context.Produtos.Remove(produto);
        _context.SaveChanges();

        return Ok();
    }
}
