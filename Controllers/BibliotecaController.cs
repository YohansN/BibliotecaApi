using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
namespace Biblioteca.Controllers;

[ApiController]
[Route("biblioteca")]
public class BibliotecaDataController : ControllerBase
{
    //Criando livros do tipo BibliotecaData com todos os atributos de um livro:
    private static BibliotecaData livro = new BibliotecaData("", "", "", false);
    //Lista de objetos que contem os objetos BibliotecaData:
    private static List<BibliotecaData> biblioteca = new List<BibliotecaData>();

    private readonly DataContext context;
    public BibliotecaDataController(DataContext context)
    {
        this.context = context;
    }

    [HttpPost("AddDados")]
    public async Task<ActionResult<List<BibliotecaData>>> AddDados(BibliotecaData livro)
    {
        context.BibliotecaDatas.Add(livro);
        await this.context.SaveChangesAsync();

        return Ok(await this.context.BibliotecaDatas.ToListAsync());
    }

    [HttpDelete("DeletarDados")]
    public async Task<ActionResult<List<BibliotecaData>>> DeletarDados(string id)
    {
        biblioteca.Remove(biblioteca.First(x => x.Id.Equals(id)));
        
        return Ok(await this.context.BibliotecaDatas.ToListAsync());
        
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<BibliotecaData>>> AlterarDados(string id, string titulo, string autor)
    {
        foreach (BibliotecaData livro in biblioteca)
        {
            if (livro.Id == id)
            {
                livro.Titulo = titulo;
                livro.Autor = autor;

                await this.context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("Livro não encontrado");
            }
        }
        return Ok(await this.context.BibliotecaDatas.ToListAsync());

    }

    [HttpGet("MostrarDados")]
    public async Task<ActionResult<List<BibliotecaData>>> MostrarDados()
    {
        return Ok(await this.context.BibliotecaDatas.ToListAsync());
    }
}