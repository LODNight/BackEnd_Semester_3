﻿using Microsoft.AspNetCore.Mvc;
using Providence.Helpers;
using Providence.Models;
using Providence.Service;
using Providence.Service.Implement;
using Providence.Service.Interface;
using System.Diagnostics;

namespace Providence.Controllers;
[Route("api/[controller]")]
public class OrderDetailController : Controller
{
    private readonly IServiceCRUD<OrderDetail> _serviceCRUD;
    private readonly IOrderDetailService orderDetailService;
    private IConfiguration configuration;

    public OrderDetailController(IServiceCRUD<OrderDetail> serviceCRUD, IConfiguration configuration, IOrderDetailService orderDetailService)
    {
        _serviceCRUD = serviceCRUD;
        this.configuration = configuration;
        this.orderDetailService = orderDetailService;
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
    [HttpGet("find/{id}")]
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
    public IActionResult Create([FromBody] OrderDetail orderDetail)

    {
        try
        {
            return Ok(_serviceCRUD.Create(orderDetail));
        }
        catch
        {
            return BadRequest();
        }
    }

    [Produces("application/json")]
    [HttpDelete("delete/{id}")]
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
    [HttpPut("update")]
    public IActionResult Update([FromBody] OrderDetail orderDetail)
    {
        try
        {
            return Ok(_serviceCRUD.Update(orderDetail));
        }
        catch
        {
            return BadRequest();
        }
    }

}
