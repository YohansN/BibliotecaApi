using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
namespace Biblioteca.Controllers;

[ApiController]
[Route("biblioteca")]
public class BibliotecaDataController : ControllerBase
{
    private readonly DataContext context;
    public BibliotecaDataController(DataContext context)
    {
        this.context = context;
    }


    [HttpPost("adddados")]
    public async Task<ActionResult<List<BibliotecaData>>> AddDados(BibliotecaData livro)
    {
        context.BibliotecaDatas.Add(livro);
        await this.context.SaveChangesAsync();

        return Ok(await this.context.BibliotecaDatas.ToListAsync());
    }


    [HttpDelete("deletardados/{id}")]
    public async Task<ActionResult<List<BibliotecaData>>> DeletarDados(string id)
    {
        var encontrarLivro = await this.context.BibliotecaDatas.FindAsync(id);

        if (encontrarLivro == null)
        {
            return BadRequest("Livro não encontrado");
        }

        this.context.BibliotecaDatas.Remove(encontrarLivro);
        await this.context.SaveChangesAsync();
        return Ok(await this.context.BibliotecaDatas.ToListAsync());
    }


    [HttpPut("alterardados")]
    public async Task<ActionResult<List<BibliotecaData>>> AlterarDados(BibliotecaData livro)
    {

        var encontrarLivro = await this.context.BibliotecaDatas.FindAsync(livro.Id);

        if (encontrarLivro == null)
        {
            return BadRequest("Livro não encontrado");
        }

        encontrarLivro.Titulo = livro.Titulo;
        encontrarLivro.Autor = livro.Autor;

        await this.context.SaveChangesAsync();
        return Ok(await this.context.BibliotecaDatas.ToListAsync());

    }


    [HttpGet("mostrardados")]
    public async Task<ActionResult<List<BibliotecaData>>> MostrarDados()
    {
        return Ok(await this.context.BibliotecaDatas.ToListAsync());
    }
}