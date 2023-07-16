﻿
using Providence.Models;

namespace Providence.Service;


public interface OrderService
{
    // ====== Find / Search / Filter
    // Find
    public dynamic findAll();

    public bool create(Order order);
    public bool update(Order order);


    // ====== Delete
    public bool Delete(int id);
}
