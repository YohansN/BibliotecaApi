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

    [HttpPost("AddDados")]
    public async Task<ActionResult<List<BibliotecaData>>> AddDados(BibliotecaData livro)
    {
        biblioteca.Add(livro);
        return Ok(biblioteca);
    }

    [HttpDelete("DeletarDados")]
    public async Task<ActionResult<List<BibliotecaData>>> DeletarDados(string id)
    {
        biblioteca.Remove(biblioteca.First(x => x.Id.Equals(id)));
        return Ok(biblioteca);
    }

    [HttpPut("AlterarDados")]
    public async Task<ActionResult<List<BibliotecaData>>> AlterarDados(string id, string titulo, string autor)
    {
        foreach (BibliotecaData livro in biblioteca)
        {
            if (livro.Id == id)
            {
                livro.Titulo = titulo;
                livro.Autor = autor;
            }
            BibliotecaData encontrado = livro;
        }
        return Ok(biblioteca);
    }

    [HttpGet("MostrarDados")]
    public async Task<ActionResult<List<BibliotecaData>>> MostrarDados()
    {
        return Ok(biblioteca);
    }
}