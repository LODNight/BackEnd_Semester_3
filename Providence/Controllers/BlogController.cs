﻿using Microsoft.AspNetCore.Mvc;
using Providence.Helper;
using Providence.Helpers;
using Providence.Models;
using Providence.Service;
using Providence.Service.Implement;
using Providence.Service.Implement.OutCRUD;
using Providence.Service.Interface;
using System.Diagnostics;

namespace Providence.Controllers;
[Route("api/[controller]")]
public class BlogController : Controller
{
    private readonly IServiceCRUD<Blog> _serviceCRUD;
    private readonly IBlogService blogService;
    private IConfiguration configuration;

    public BlogController(IServiceCRUD<Blog> serviceCRUD, IConfiguration configuration, IBlogService blogService)
    {
        _serviceCRUD = serviceCRUD;
        this.configuration = configuration;
        this.blogService = blogService;
    }

    [Produces("application/json")]
    [HttpGet("findAll")]
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
    [HttpGet("find")]
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
    [HttpPost("create")]
    public IActionResult Create([FromBody] Blog blog)

    {
        try
        {
            blog.CreatedAt = DateTime.Now;
            blog.UpdatedAt = DateTime.Now;


            return Ok(_serviceCRUD.Create(blog));
        }
        catch
        {
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpDelete("delete")]
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
    [HttpPut("uupdate")]
    public IActionResult Update([FromBody] Blog blog)
    {
        try
        {
            blog.UpdatedAt = DateTime.Now;
            return Ok(_serviceCRUD.Update(blog));
        }
        catch
        {
            return BadRequest();
        }
    }

    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPut("hide")]
    public IActionResult Hide(int id)
    {
        try
        {

            return Ok(blogService.Hide(id));
        }
        catch
        {
            return BadRequest();
        }
    }

    [Consumes("multipart/form-data")]
    [Produces("application/json")]
    [HttpPost("addBlog")]
    public IActionResult UploadFiles(IFormFile[] files, IFormCollection formData)
    {
        try
        {
            var blogFile = JsonConvert.DeserializeObject<Blog>(formData["Product"]);
            return Ok(blogService.AddBlog(files, blogFile));
        }
        catch
        {
            return BadRequest();
        }
    }
}
