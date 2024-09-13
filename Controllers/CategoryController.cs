using ContaineredSql.Data;
using ContaineredSql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContaineredSql.Controllers;

[Route("[controller]")]
public class CategoryController(AppDbContext db) : ControllerBase
{
    [HttpGet("[action]")]
    public async Task<IActionResult> Get() =>
        Ok(await db.Categories.ToListAsync());

    [HttpGet("[action]/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) =>
        Ok(await db.Categories.FindAsync(id));

    [HttpPost("[action]")]
    public async Task<IActionResult> Save([FromBody] Category category)
    {
        if (category.Id > 0)
            db.Categories.Update(category);
        else
            await db.Categories.AddAsync(category);

        await db.SaveChangesAsync();

        return Ok(category);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> Remove([FromBody] Category category)
    {
        db.Categories.Remove(category);
        int result = await db.SaveChangesAsync();

        return result > 0
            ? Ok(result)
            : BadRequest();
    }
}