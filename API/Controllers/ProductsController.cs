using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class ProductsController(IUnitOfWork unit) : BaseApiController
{


    [Cached(600)]
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts([FromQuery]ProductspecParam specParams)
    {
        var spec = new ProductSpecification(specParams);
        
        
        return await CreatePagedResult(unit.Repository<Product>(), spec, specParams.PageIndex, specParams.PageSize);
    }

    [Cached(600)]
    [HttpGet("{id:int}")]
    //[Authorize(Roles = "Admin")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await unit.Repository<Product>().GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return product;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [InvalidateCache("api/products|")]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        unit.Repository<Product>().Add(product);
        if (await unit.Complete())
        {
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }
        return BadRequest("Failed to create product");
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    [InvalidateCache("api/products|")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.Id || !ProductExists(id))
        {
            return BadRequest("Cannot update this product");
        }

        unit.Repository<Product>().Update(product);
        if (await unit.Complete())
        {
            return NoContent();
        }
        return BadRequest("Failed to update product");
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    [InvalidateCache("api/products|")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await unit.Repository<Product>().GetByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        unit.Repository<Product>().Remove(product);

        if (await unit.Complete())
        {
            return NoContent();
        }

        return BadRequest("Failed to delete product");
    }

    [Cached(1000)]
    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
    {
        var spec = new BrandListSpecification();
        var brands = await unit.Repository<Product>().ListAsync(spec);
        return Ok(brands);
    }

    [Cached(1000)]
    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
    {
        var spec = new TypeListSpecification();
        var types = await unit.Repository<Product>().ListAsync(spec);
        return Ok(types);
    }

    private bool ProductExists(int id)
    {
        return unit.Repository<Product>().Exists(id);
    }
    
}
