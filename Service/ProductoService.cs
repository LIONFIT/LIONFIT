using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIONFIT.Models;
using LIONFIT.Data;
using LIONFIT.Service;

namespace LIONFIT.Service;
using Microsoft.EntityFrameworkCore;


public class ProductoService
{

    private readonly ILogger<ProductoService> _Logger;
    private readonly ApplicationDbContext _context;

    public ProductoService(ILogger<ProductoService> logger, ApplicationDbContext context)
    {
        _Logger = logger;
        _context = context;
    }
    //el edit es un apdate y para poder traerlo tiene que se un get

    public async Task<Producto> Create_Update(Producto p)
    {

        _context.Add(p);
        await _context.SaveChangesAsync();
        return p;

    }

    public async Task<List<Producto>> GetAll()
    {
        if (_context.Dataproducto == null)
            return null;
        return await _context.Dataproducto.ToListAsync();


    }
    public async Task<Producto> Get(int? id)
    {

        if (id == null || _context.Dataproducto == null)
        {
            return null;
        }


        var producto = await _context.Dataproducto.FindAsync(id);
        if (producto == null)
        {
            return null;
        }
        return producto;

    }

    public async Task<Producto> FirstOrDefault(int? id)
    {
        var producto = await _context.Dataproducto
.FirstOrDefaultAsync(m => m.Id == id);
        if (producto == null)
        {
            return null;
        }
        return producto;
    }


    public async Task Delete(int? id)
    {

        var producto = await _context.Dataproducto.FindAsync(id);
        if (producto != null)
        {
            _context.Dataproducto.Remove(producto);
        }

        await _context.SaveChangesAsync();

    }

    public bool ProductoExists(int id)
    {
        return (_context.Dataproducto?.Any(e => e.Id == id)).GetValueOrDefault();
    }


}


