using Microsoft.AspNetCore.Mvc;
using Providence.Models;
using Providence.Service;
using System.Diagnostics;

namespace Providence.Controllers;
[Route("api/product")]
public class ProductController : Controller
{
    private ProductService productService;
    private IWebHostEnvironment webHostEnvironment;

    public ProductController(ProductService productService, IWebHostEnvironment webHostEnvironment)
    {
        this.productService = productService;
        this.webHostEnvironment = webHostEnvironment;
    }

    [Produces("application/json")]
    [HttpGet("findAll")]
    public IActionResult findAll()
    {
        try
        {
            return Ok(productService.findAll());
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpGet("find/{id}")]
    public IActionResult Find(int id)
    {
        try
        {
            return Ok(productService.find(id));
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpPost("create")]
    public IActionResult Create([FromBody] Product product)
    {
        try
        {
            return Ok(new
            {
                status = productService.Create(product)
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpPut("edit")]
    public IActionResult Edit([FromBody] Product product)
    {
        try
        {
            return Ok(new
            {
                status = productService.Edit(product)
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            return Ok(new
            {
                status = productService.Delete(id)
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return BadRequest();
        }
    }
}
