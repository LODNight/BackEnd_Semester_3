﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Providence.Models;
using Providence.Service;
using Providence.Service.Implement;
using Providence.Service.Interface;
using System.Diagnostics;
using static Azure.Core.HttpHeader;
namespace Providence.Controllers;
[Route("api/[controller]")]
public class CategoryController : Controller
{
    private readonly IServiceCRUD<Category> _serviceCRUD;
    private IConfiguration configuration;

    public CategoryController(IServiceCRUD<Category> serviceCRUD)
    {
        _serviceCRUD = serviceCRUD;
    }

    [Produces("application/json")]
    [HttpGet("Read")]
    public IActionResult Read()
    {
        try
        {
            return Ok(_serviceCRUD.Read());
        }
        catch
        {
            return BadRequest();
        }
    }


    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpGet("Get")]
    public IActionResult Get(int id)
    {
        try
        {
            return Ok(_serviceCRUD.Get(id));
        }
        catch
        {
            return BadRequest();
        }
    }

    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPost("Create")]
    public IActionResult Create([FromBody] Category category)

    {
        try
        {
            return Ok(_serviceCRUD.Create(category));
        }
        catch
        {
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpDelete("Delete")]
    public IActionResult Delete(int id)
    {
        try
        {
            return Ok(_serviceCRUD.Delete(id));
        }
        catch
        {
            return BadRequest();
        }
    }

    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPut("Update")]
    public IActionResult Update([FromBody] Category category)
    {
        try
        {
            return Ok(_serviceCRUD.Update(category));
        }
        catch
        {
            return BadRequest();
        }
    }

}
